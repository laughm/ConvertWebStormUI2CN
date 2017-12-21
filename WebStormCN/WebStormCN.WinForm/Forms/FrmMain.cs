using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebStormCN.WinForm.Public;

namespace WebStormCN.WinForm.Forms
{
    public partial class FrmMain : Form
    {
        #region 私有变量

        /// <summary>
        /// 是否运行
        /// </summary>
        private bool isRun = false;
        Operate op = null;
        private int lstvSelectIndex = 0;
        private List<LangItemInfo> currentFileContent = null;
        private string currentFilePath = "";
        private string distJarName = "resources_cn.jar";
        #endregion

        #region 构造方法
        public FrmMain()
        {
            InitializeComponent();
            op = new Operate();
            Public.Operate.OnFilePathError += Operate_OnFilePathError;
            Public.Operate.OnFileOperate += Operate_OnFileOperate;
            Public.Operate.OnFileOperateComplete += Operate_OnFileOperateComplete;
        }

        #endregion

        #region 控件方法
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.SetStatusControlWidth();
            this.SetToolStripButtonState(false);
            this.splitContainer1.Visible = false;
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isRun)
            {
                e.Cancel = true;
            }
            if (!e.Cancel)
            {
                if (MessageBox.Show("确定要退出程序吗？", "系统信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
            //删除操作中生成的临时文件
            op.DeleteOperateFileDirectory();
        }
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            this.SetStatusControlWidth();
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.isRun = true;
            Task task = Task.Factory.StartNew(new Action(op.StartCovertCN));
        }

        private void tsbSetup_Click(object sender, EventArgs e)
        {
            if (!hasForm("frmOptions"))
            {
                Form frm = new frmOptions();
                frm.ShowDialog();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            string disPath = op.DistPath;
            if (!Directory.Exists(disPath))
            {
                this.ShowAlert("无对应资源，请执行【开始】汉化后再操作");
                return;
            }
            string[] distFileName = op.GetFileName(disPath);
            if (distFileName.Length < 1)
            {
                return;
            }
            var dataL = (from i in distFileName
                        select new
                        {
                            Name = Path.GetFileName(i),
                            Id = i
                        }).ToList();
            this.splitContainer1.Visible = dataL.Count > 0;
            this.tvFileName.ShowRootLines = true;
            this.tvFileName.Nodes.Clear();
            var root = this.tvFileName.Nodes.Add("中文资源文件列表");
            foreach (var item in dataL)
            {
                TreeNode tn = new TreeNode();
                tn.Name = item.Id;
                tn.Text = item.Name;
                root.Nodes.Add(tn);
                if(root.Nodes.Count ==1)
                {
                    this.tvFileName.SelectedNode = tn;
                }
            }            
            root.Expand();
            this.tvFileName.Focus();
        }
                

        private void tvFileName_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.txtItemValue.Text = this.txtEngValue.Text = this.txtCNValue.Text = "";
            if (this.btnSaveChange.Enabled)
            {
                DialogResult result = MessageBox.Show("修改的资源文件没有保存，确定要保存吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.btnSaveChange_Click(null, null);
                }
                this.btnSaveChange.Enabled = false;
            }

            this.lstvCnFileContent.Items.Clear();
            string sourceFile = this.tvFileName.SelectedNode.Name;
            this.currentFilePath = sourceFile;//临时保存当前操作的文件，方便保存修改
            List<LangItemInfo> fileInfo = op.GetFileLanItemInfo(sourceFile);
            if(fileInfo == null)//未取到对应的文件信息
            {
                return;
            }
            this.currentFileContent = fileInfo;//临时保存，用来修改时的数据保存
            int len = fileInfo.Count;

            if (len > 0)
            {
                ListViewItem[] lviArr = new ListViewItem[len];
                int index = 0;
                foreach (var item in fileInfo)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { (index + 1).ToString(), item.ItemText, item.EngText, item.CnText });
                    lviArr[index] = lvi;
                    index++;
                }
                this.lstvCnFileContent.Items.AddRange(lviArr);
            }
        }


        private void lstvCnFileContent_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem item = e.Item;
            if (item != null)
            {
                this.lstvSelectIndex = int.Parse(item.SubItems[0].Text);
                this.txtItemValue.Text = item.SubItems[1].Text;
                this.txtEngValue.Text = item.SubItems[2].Text;
                this.txtCNValue.Text = item.SubItems[3].Text;
                this.ttpWS.SetToolTip(this.txtItemValue, this.txtItemValue.Text);
                this.ttpWS.SetToolTip(this.txtEngValue, this.txtEngValue.Text);
                this.ttpWS.SetToolTip(this.txtCNValue, this.txtCNValue.Text);
            }

        }

        private void txtCNValue_KeyUp(object sender, KeyEventArgs e)
        {
            
            int index = this.lstvSelectIndex - 1;
            ListViewItem item = this.lstvCnFileContent.Items[index];
            if (item != null)
            {
                item.SubItems[3].Text = this.txtCNValue.Text.Trim();
                var itemContent = currentFileContent.Find(c => (c.ItemText == this.txtItemValue.Text.Trim() && c.CnText != this.txtCNValue.Text.Trim()));
                if (itemContent != null)
                {
                    itemContent.CnTextNew = this.txtCNValue.Text.Trim();
                    if (!this.btnSaveChange.Enabled)
                    {
                        this.btnSaveChange.Enabled = this.currentFileContent.Where(c => !string.IsNullOrWhiteSpace(c.CnTextNew)).Count() > 0;
                    }
                }
            }
        }        

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            string sourceFile = this.currentFilePath;
            List<LangItemInfo> changeItem = this.currentFileContent.Where(c => !string.IsNullOrWhiteSpace(c.CnTextNew)).ToList();
            bool ok = op.WriteChangeToFile(sourceFile, changeItem);
            if (ok)
            {
                this.ShowAlert("保存修改成功！");
                this.btnSaveChange.Enabled = false;
            }
            else
            {
                this.ShowAlert("保存修改错误，请稍侯再试！");
            }
        }


        private void tsbView_Click(object sender, EventArgs e)
        {
            string disPath = op.DistPath;
            if(!Directory.Exists(disPath))
            {
                this.ShowAlert("无对应资源，请执行【开始】汉化后再操作");
                return;
            }
            System.Diagnostics.Process.Start("explorer.exe", disPath);
        }

        private void tsbCreate_Click(object sender, EventArgs e)
        {
            string distPath = op.DistPath;
            CfgInfo cfg = op.GetCfgInfo();
            string sourceJarFile = cfg.Source;
            string distJarFilePath = cfg.Dist;
            string distJarFileName = Path.Combine(distJarFilePath, distJarName);
            string cmdExecuteFile = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"Dll\UnPress.exe");
            string cmd = "a " + distJarFileName + " -ibck -o+ messages";
            if (!Directory.Exists(distPath))
            {
                this.ShowAlert("无对应资源，请执行【开始】汉化后再操作");
                return;
            }
            if (!File.Exists(sourceJarFile))
            {
                this.ShowAlert("无英文资源文件" + Path.GetFileName(sourceJarFile) + "\r\n请在【设置】中设置它的正确路径");
                return;
            }
            //中文资源存放路径不存在，建立
            if (!Directory.Exists(distJarFilePath))
            {
                Directory.CreateDirectory(distJarFilePath);
            }
            //复制英文文件，然后替换
            File.Copy(sourceJarFile, distJarFileName, true);

            System.Diagnostics.Process.Start(cmdExecuteFile, cmd);
            this.ShowAlert("成功生成中文语言资源文件【" + this.distJarName + "】");
        }

        private void tsbQuit_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        void Operate_OnFilePathError(object sender, FileInfoEventArgs e)
        {
            string errorInfo = e.Desc;
            if (!string.IsNullOrWhiteSpace(errorInfo))
            {
                this.ShowAlert(errorInfo);
            }
            this.SetControlDefaultState(false);
        }

        void Operate_OnFileOperate(object sender, FileInfoEventArgs e)
        {
            string fileName = e.Desc;
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                this.tssInfo.Text = fileName;
                this.tssInfo.ToolTipText = fileName;
                this.SetProgressValue((int)(e.Rate * 100));
            }
        }

        void Operate_OnFileOperateComplete(object sender, FileInfoEventArgs e)
        {
            string info = e.Desc;
            if (!string.IsNullOrWhiteSpace(info))
            {
                this.ShowAlert(info);
            }
            this.SetControlDefaultState(true);
        }

        private void SetControlDefaultState(bool isAll)
        {
            this.SetControlState(true,isAll);
            this.SetProgressValue(0);
            this.tssInfo.Text = "";
            this.isRun = false;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 设置ToolStrip中校对，查看，创建的Enabled状态
        /// </summary>
        /// <param name="enabled"></param>
        private void SetToolStripButtonState(bool enabled)
        {
            this.tsbEdit.Enabled = this.tsbView.Enabled = this.tsbCreate.Enabled = enabled;
        }
        /// <summary>
        /// 判定当前窗体是否已经存在
        /// 存在的话激活
        /// </summary>
        /// <param name="frmName"></param>
        /// <returns></returns>
        private bool hasForm(string frmName)
        {
            bool hasFromWin = false;
            Form frm = Application.OpenForms[frmName];
            if (frm != null)
            {
                hasFromWin = true;
                frm.WindowState = FormWindowState.Normal;
                frm.Activate();
            }
            return hasFromWin;
        }

        private void SetStatusControlWidth()
        {
            int winW = this.Width;           
            this.tssInfo.Width = winW / 2;
            this.tspbInfo.ProgressBar.Width = winW / 2;
            this.tspbInfo.ProgressBar.Visible = false;
        }

        private void SetControlState(bool enabled)
        {
            this.SetControlState(enabled, false);

        }
        private void SetControlState(bool enabled,bool isAll)
        {
            this.SetControlState(this.tsbStart, enabled);
            this.SetControlState(this.tsbSetup, enabled);
            if (isAll)
            {
                this.SetControlState(this.tsbEdit, enabled);
                this.SetControlState(this.tsbView, enabled);
                this.SetControlState(this.tsbCreate, enabled);
            }
            this.SetControlState(this.tsbQuit, enabled);

        }

        private void SetControlState(ToolStripButton tsb, bool enabled)
        {
            if (this.toolStrip1.InvokeRequired)
            {
                DelSetControlState dscs = new DelSetControlState(SetControlStateVal);
                this.Invoke(dscs, new object[] { tsb, enabled });
            }
            tsb.Enabled = enabled;
        }
        private void SetControlStateVal(ToolStripButton tsb, bool enabled)
        {
            tsb.Enabled = enabled;
        }
        private void SetProgressValue(int val)
        {
            if (this.tspbInfo.ProgressBar.InvokeRequired)
            {
                DelSetProgressVal dspv = new DelSetProgressVal(SetProgressVal);
                this.Invoke(dspv, val);
            }
            else
            {
                this.SetProgressVal(val);
            }
        }
        private void SetProgressVal(int val)
        {
            if(!this.tspbInfo.ProgressBar.Visible)
            {
                this.tspbInfo.ProgressBar.Visible = true;
            }
            this.tspbInfo.ProgressBar.Value = val;
            if(val == 0)
            {
                this.tspbInfo.ProgressBar.Visible = false;
            }
        }
        private delegate void DelSetProgressVal(int v);
        private delegate void DelSetControlState(ToolStripButton tsb, bool enabled);
        private delegate void MessageBoxShow(string msg,string tilte);

        /// <summary>
        /// 显示系统警告框
        /// </summary>
        /// <param name="info"></param>
        /// <param name="title"></param>
        private void MessageShow(string info,string title)
        {
            MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 显示系统警告框
        /// </summary>
        /// <param name="info"></param>
        private void ShowAlert(string info)
        {
            MessageBoxShow showBox = this.MessageShow;
            this.Invoke(showBox, new object[] { info, "系统信息" });
        }

        #endregion
        
    }
}
