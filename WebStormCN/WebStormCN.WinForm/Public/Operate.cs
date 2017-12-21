using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;
using Microsoft.Win32;

namespace WebStormCN.WinForm.Public
{
    public class Operate
    {
        #region 私有变量
        /// <summary>
        /// 参考文件路径
        /// </summary>
        private string refPath = "";
        /// <summary>
        /// 源文件路径
        /// </summary>
        private string sourcePath = "";
        /// <summary>
        /// 汉化后暂时保存的路径
        /// </summary>
        private string distPath = "";
        /// <summary>
        /// 执行程序的路径
        /// </summary>
        private string appStartPath = "";
        private string[] baseDir = new string[] { "resources_ref", "resources_en", "" };
        private string sourceFileDir = "messages";
        private string refSourceName = "";
        private string sourceJarName = "resources_en.jar";
        private string cmdExecuteFile = "";
        private string cmdSourcePara = "e -ibck -o+ \"{0}\" @fileList.lst \"{1}\"";
        private string cmdRefPara = "e -ibck -o+ \"{0}\" \"{1}\"";

        public static event EventHandler<FileInfoEventArgs> OnFilePathError;
        public static event EventHandler<FileInfoEventArgs> OnFileOperate;
        public static event EventHandler<FileInfoEventArgs> OnFileOperateComplete;
        #endregion

        #region 构造函数
        public Operate()
        {
            appStartPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            cmdExecuteFile = Path.Combine(appStartPath, @"Dll\UnPress.exe");
            refSourceName = Path.Combine(appStartPath, @"Dll\refSource.dll");
            SetPathInfo();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 生成文件路径
        /// </summary>
        public string DistPath
        {
            get { return this.distPath; }
        }

        #endregion

        #region 处理方法
        public void StartCovertCN()
        {
            this.SetPathInfo();            

            #region 源文件解压缩/参考文件解压缩
            CfgInfo cfg = this.GetCfgInfo();
            if (!File.Exists(cfg.Source))
            {
                this.TriggleErrorEvent("要汉化的英文资源文件不存在\r\n请在【设置】中正确设置，之后再操作");
                return;
            }
            if (!File.Exists(Path.Combine(appStartPath,this.refSourceName)))
            {
                this.TriggleErrorEvent("参考的中文资源文件不存在\r\n请确定在当前文件夹中存在【" + this.refSourceName + "】，之后再操作");
                return;
            }

            //创建操作所用的临时目录
            this.CreateOperateFileDirectory();

            //解压缩文件
            //生成要解压文件列表
            string fileLstName = "fileList.lst";
            File.WriteAllText(fileLstName, @"messages\*.*");
            UnPressSourceFile(this.cmdSourcePara,cfg.Source, sourcePath);
            UnPressSourceFile(this.cmdRefPara, refSourceName, refPath);
            File.Delete(fileLstName);

            #endregion

            #region 文件夹及文件是否存在判定
            string sName = "源";
            string sDesc = "（即将要汉化的）";
            string refName = "参照";
            string refDesc = "（即已汉化过的）";
            string DirNoSave = "{0}文件文件夹不存在";
            string DirNoSaveAlert = @"请确认{0}文件夹在 {1} 下，或通过【设置】设置文件路径";
            if (!Directory.Exists(sourcePath))
            {
                OutErrorInfo(string.Format(DirNoSave, sName + sDesc), string.Format(DirNoSaveAlert, sName, sourcePath));
                return;
            }
            if (!Directory.Exists(refPath))
            {
                OutErrorInfo(string.Format(DirNoSave, refName + refDesc), string.Format(DirNoSaveAlert, refName, refPath));
                return;
            }
            string fileNoSave = "{0}文件不存在";
            string fileNoSaveAlert = @"请复制{0}文件到 {1} 下，或通过【设置】设置文件路径";
            if (GetFileName(sourcePath) == null || GetFileName(sourcePath).Length < 1)
            {
                OutErrorInfo(string.Format(fileNoSave, sName + sDesc), string.Format(fileNoSaveAlert, sName, sourcePath));
                return;
            }
            if (GetFileName(refPath) == null || GetFileName(refPath).Length < 1)
            {
                OutErrorInfo(string.Format(fileNoSave, refName + refDesc), string.Format(fileNoSaveAlert, refName, refPath));
                return;
            }
            #endregion

            var sFileList = GetFileName(sourcePath);
            int fileCount = sFileList.Length;
            decimal index = 1m;
            if (sFileList != null && sFileList.Length > 0)
            {
                foreach (var file in sFileList)
                {
                    string fileInfo = string.Format("处理文件：{0} ...", Path.GetFileName(file));
                    if (OnFileOperate != null)
                    {
                        OnFileOperate(this, new FileInfoEventArgs { Desc = fileInfo,Rate = index/fileCount });
                    }
                    ReplaceInfoByReferenceInfo(file, refPath, distPath);
                    index++;
                    System.Threading.Thread.Sleep(200);
                }


            }
            List<string> error = new List<string>();
            error.Add("");
            error.Add("文件处理完...");
            error.Add("");
            error.Add("");
            error.Add("请用Beyond Compare之类软件进行比较修正");
            error.Add("以获得更好的效果");

            error.Add("");
            string errorInfo = string.Join("\r\n", error.ToArray());
            if (OnFileOperateComplete != null)
            {
                FileInfoEventArgs args = new FileInfoEventArgs();
                args.Desc = errorInfo;
                OnFileOperateComplete(this, args);
                return;
            }
        }

        

        #endregion

        #region 私有方法

        /// <summary>
        /// 删除操作中创建的临时文件夹
        /// </summary>
        public void DeleteOperateFileDirectory()
        {
            try
            {
                foreach (var item in baseDir)
                {
                    string currentPath = Path.Combine(appStartPath, item == "" ? sourceFileDir : item);
                    if (Directory.Exists(currentPath))
                    {
                        Directory.Delete(currentPath, true);
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="pressFile"></param>
        /// <param name="unPressPath"></param>
        private void UnPressSourceFile(string cmdPath, string pressFile, string unPressPath)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo(this.cmdExecuteFile, string.Format(cmdPath, pressFile, unPressPath));
            info.CreateNoWindow = false;
            p.StartInfo = info;
            p.Start();
            p.WaitForExit();
            p.Dispose();
            p = null;
            System.Threading.Thread.Sleep(500);
        }

        private void SetPathInfo()
        {
            sourcePath = Path.Combine(appStartPath, baseDir[1], sourceFileDir);
            refPath = Path.Combine(appStartPath, baseDir[0], sourceFileDir);
            distPath = Path.Combine(appStartPath, baseDir[2], sourceFileDir);
        }

        /// <summary>
        /// 建立程序需要的操作文件夹
        /// </summary>
        private void CreateOperateFileDirectory()
        {
            foreach (var item in baseDir)
            {
                string currentPath = Path.Combine(item, sourceFileDir);
                if (!Directory.Exists(currentPath))
                {
                    Directory.CreateDirectory(currentPath);
                }
            }
        }
        private void TriggleErrorEvent(string errorInfo)
        {
            if (OnFilePathError != null)
            {
                FileInfoEventArgs args = new FileInfoEventArgs();
                args.Desc = errorInfo;
                OnFilePathError(this, args);
            }
        }
        private void OutErrorInfo(string info1, string info2)
        {
            List<string> error = new List<string>();
            error.Add("");
            error.Add(info1);
            error.Add(info2);
            error.Add("");
            error.Add("准备好后再运行些程序！");
            error.Add("");
            string errorInfo = string.Join("\r\n", error.ToArray());
            TriggleErrorEvent(errorInfo);
        }
        private void CW(string info)
        {
            Console.WriteLine(info);
        }

        /// <summary>
        /// 得到当前路径下的文件（.properties）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] GetFileName(string path)
        {
            string[] fileName = null;
            if (Directory.Exists(path))
            {
                fileName = Directory.GetFiles(path, "*.properties", SearchOption.TopDirectoryOnly);
            }
            return fileName;
        }

        public List<LangItemInfo> GetFileLanItemInfo(string cnFilePath)
        {
            List<LangItemInfo> langInfoList = null;
            if (File.Exists(cnFilePath))
            {
                string fileName = Path.GetFileName(cnFilePath);
                string refereceFile = Path.Combine(sourcePath, fileName);
                if (File.Exists(refereceFile))
                {
                    var refContent = this.GetFileInfo(refereceFile);
                    var sContent = File.ReadAllLines(cnFilePath, Encoding.ASCII).Where(l => !l.StartsWith("#")).Where(l => l.Trim() != "").Where(l => l.IndexOf("=") != -1).ToList().Select(l => new InfoItem { Key = l.Split('=')[0], Value = GetSecondToEndInfo(l.Split('=')) }).ToList();
                    langInfoList = (from r in refContent
                                   join s in sContent on r.Key equals s.Key
                                   select new LangItemInfo
                                   {
                                       ItemText = s.Key,
                                       EngText = r.Value,
                                       CnText = Regex.Unescape(s.Value)
                                   }).ToList();

                }
            }

            return langInfoList;
        }

        public bool WriteChangeToFile(string filePath,List<LangItemInfo> list)
        {
            bool isOk = true;
            try
            {
                List<InfoItem> fileContent = this.GetFileAllLine(filePath);
                if (list != null && fileContent != null)
                {
                    foreach (var item in list)
                    {
                        fileContent.Find(c => c.Key == item.ItemText).Value = this.string2Unicode(item.CnTextNew);
                    }
                }
                var distContent = fileContent.Select(c => c.Key + (c.Key != "" ? "=" : "") + c.Value).ToList();
                File.WriteAllLines(filePath, distContent, Encoding.ASCII);
            }
            catch
            {
                isOk = false;
            }
            return isOk;
        }

        private List<InfoItem> GetFileInfo(string filePath)
        {
            List<InfoItem> cList = null;
            //得到WebStorm语言资源文件内容，#开头（注册），空行过滤
            var lList = File.ReadAllLines(filePath, Encoding.ASCII)
                .Where(l => !l.StartsWith("#"))
                .Where(l => l.Trim() != "");
            int index = 0;
            InfoItem ii = null;
            if(lList.Count() >0)
            {
                cList = new List<InfoItem>();
            }
            foreach (var item in lList)
            {
                string[] itemArr = item.Split('=');
                if (itemArr.Length > 1)
                {                    
                    var val = GetSecondToEndInfo(itemArr);
                    ii = new InfoItem
                    {
                        Key = itemArr[0],
                        Value = val
                    };
                    cList.Add(ii);
                }
                if(!item.Contains("=") && index >0)
                {
                    int count = cList.Count;
                    cList[count - 1].Value += "\r\n" + item;
                }

                index++;
            }
            return cList;
        }

        /// <summary>
        /// 得到文件的所有行（包括空行、#开头的）
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<InfoItem> GetFileAllLine(string filePath)
        {
            List<InfoItem> cList = null;
            var lList = File.ReadAllLines(filePath, Encoding.ASCII);
            int index = 0;
            InfoItem ii = null;
            if (lList.Count() > 0)
            {
                cList = new List<InfoItem>();
            }
            foreach (var item in lList)
            {
                if(item == "" || item.StartsWith("#"))
                {
                    cList.Add(new InfoItem { Key = "", Value = item });
                }
                else
                {
                    string[] itemArr = item.Split('=');
                    if (itemArr.Length > 1)
                    {
                        var val = GetSecondToEndInfo(itemArr);
                        ii = new InfoItem
                        {
                            Key = itemArr[0],
                            Value = val
                        };
                        cList.Add(ii);
                    }
                    if (!item.Contains("=") && index > 0)
                    {
                        int count = cList.Count;
                        cList[count - 1].Value += "\r\n" + item;
                    }
                }
                index++;
            }
            return cList;
        }

        private string string2Unicode(string source)
        {
            StringBuilder outStr = new StringBuilder();
            if (!string.IsNullOrEmpty(source))
            {
                Regex reg = new Regex(@"^\w+$");
                for (int i = 0; i < source.Length; i++)
                {

                    if (((int)source[i]).ToString("x").Length <= 2)
                    {
                        outStr.Append(source[i]);
                    }
                    else
                    {
                        outStr.Append(@"\u" + ((int)source[i]).ToString("x"));
                    }
                }
            }
            return outStr.ToString();
        }
        

        private void ReplaceInfoByReferenceInfo(string sourceFile, string refPath, string distPath)
        {
            try
            {
                if (File.Exists(sourceFile))
                {
                    string fileName = Path.GetFileName(sourceFile);
                    string refereceFile = Path.Combine(refPath, fileName);
                    if (!Directory.Exists(distPath))
                    {
                        Directory.CreateDirectory(distPath);
                    }
                    string distFile = Path.Combine(distPath, fileName);
                    if (File.Exists(refereceFile))
                    {
                        //string noOperateFileName = "";
                        var refContent = this.GetFileInfo(refereceFile);//File.ReadAllLines(refereceFile, Encoding.ASCII).Where(l => !l.StartsWith("#")).Where(l => l.Trim() != "").Where(l => l.IndexOf("=") != -1).ToList().Select(l => new InfoItem { Key = l.Split('=')[0], Value = GetSecondToEndInfo(l.Split('=')) }).ToList();
                        var sContent = this.GetFileAllLine(sourceFile);//File.ReadAllLines(sourceFile, Encoding.ASCII);

                        foreach (var item in sContent)
                        {
                            if (item.Key != "")
                            {
                                InfoItem findIt = refContent.Find(r => r.Key == item.Key);
                                item.Value = findIt != null ? findIt.Value : item.Value;
                            }
                        }
                        File.WriteAllLines(distFile, sContent.Select(c => c.Key + (c.Key != "" ? "=" : "") + c.Value));
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 得到数组第一个以外的所有值
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private string GetSecondToEndInfo(string[] array)
        {
            string result = "";
            int len = array.Length;
            if (len > 1)
            {
                switch (len)
                {
                    case 2:
                        result = array[1];
                        break;
                    default:
                        result = string.Join("=", array.Skip(1));
                        break;
                }
            }
            return result;
        }

        private void WriteLog(string path, string content)
        {
            File.AppendAllText(path, content, Encoding.UTF8);
        }

        public CfgInfo GetDefaultCfgInfo()
        {
            string wsPath = this.GetWebStormPath();
            string source = Path.Combine(wsPath == "" ? appStartPath : wsPath, sourceJarName);
            string dist = Path.Combine(appStartPath);
            //先赋默认值
            CfgInfo cfg = new CfgInfo
            {
                Source = source,
                Dist = dist
            };

            return cfg;
        }
        private string GetWebStormPath()
        {
            return this.GetWebStormPath(64) == "" ? this.GetWebStormPath(32) : this.GetWebStormPath(64);
        }

        /// <summary>
        /// 根据系统特点得到WebStorm的路径
        /// </summary>
        /// <param name="sysBit">32或64位</param>
        /// <returns></returns>
        private string GetWebStormPath(int sysBit)
        {
            string path = "";
            RegistryKey uninstall = null;
            switch (sysBit)
            {
                case 64:
                    uninstall = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
                    break;
                case 32:
                    uninstall = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                    break;
            }

            if (uninstall != null)
            {
                string wsName = uninstall.GetSubKeyNames().FirstOrDefault(i => i.ToLower().StartsWith("webstorm"));
                if (!string.IsNullOrWhiteSpace(wsName))
                {
                    path = uninstall.OpenSubKey(wsName).GetValue("InstallLocation", "").ToString();
                }
            }
            if (!string.IsNullOrWhiteSpace(path))
            {
                path = Path.Combine(path, "lib");
            }
            if (uninstall != null)
            {
                uninstall.Close();
            }
            return path;
        }

        public CfgInfo GetCfgInfo()
        {
            CfgInfo cfg = null;
            string cfgFile = Path.Combine(appStartPath, "FilePath.cfg");
            bool noCfg = false;

            //如果有配置文件且内容不为空（对应的各项）
            if (File.Exists(cfgFile))
            {
                XDocument doc = XDocument.Load(cfgFile);

                var cfgItem = doc.Element("path");
                if (cfgItem != null)
                {
                    string source = cfgItem.Element("sourceDirName").Value ?? "";
                    string dist = cfgItem.Element("distDirName").Value ?? "";

                    if (!(string.IsNullOrWhiteSpace(source) && string.IsNullOrWhiteSpace(dist)))
                    {
                        cfg = new CfgInfo
                        {
                            Source = source,
                            Dist = dist
                        };
                    }
                }
                else
                {
                    noCfg = true;
                }
            }
            else
            {
                noCfg = true;
            }
            if (noCfg)//无配置文件，取默认的值
            {
                cfg = this.GetDefaultCfgInfo();
            }
            return cfg;
        }
        

        public bool SaveCfgInfo(CfgInfo info)
        {
            bool isOk = true;
            try
            {
                string cfgFile = Path.Combine(appStartPath, "FilePath.cfg");
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
               new XElement("path",
                     new XComment("英文资源文件"),
                    new XElement("sourceDirName", info.Source),                    
                    new XComment("最终生成文件的文件夹"),
                    new XElement("distDirName", info.Dist)
                    ));
                //doc.Save(Console.Out);
                doc.Save(cfgFile);
            }
            catch
            {
                isOk = false;
            }
            return isOk;            
        }

        #endregion
    }

    #region 信息类

    public class CfgInfo
    {
        public string Source { get; set; }
        public string Dist { get; set; }
    }
    public class InfoItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class FileInfoEventArgs : EventArgs
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
        public decimal Rate { get; set; }
    }

    public class LangItemInfo
    {
        public string ItemText { get; set; }
        public string EngText { get; set; }
        public string CnText { get; set; }
        public string CnTextNew { get; set; }
    }
    #endregion

}
