using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WebStormCN.WinForm.Public;

namespace WebStormCN.WinForm.Forms
{
    public partial class frmOptions : Form
    {
        #region 私有变量

        Operate op = null;

        #endregion

        #region 构造方法
        public frmOptions()
        {
            InitializeComponent();
            op = new Operate();

        }
        #endregion

        #region 控件方法

        /// <summary>
        /// 关闭设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗口加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.InitFrom();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            this.LoadDefaultInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sourcePath = this.txtSourcePath.Text.Trim();
            string distPath = this.txtDistPath.Text.Trim();

            #region 判定信息完整性
            
            if (sourcePath == "")
            {
                ShowBox("英文源文件不能为空！\r\n");
                this.txtSourcePath.SelectAll();
                this.txtSourcePath.Focus();
                return;
            }

            if (!System.IO.File.Exists(sourcePath))
            {
                ShowBox("英文源文件不存在！\r\n");
                this.txtSourcePath.SelectAll();
                this.txtSourcePath.Focus();
                return;
            }

            if (distPath == "")
            {
                ShowBox("中文文件夹不能为空！\r\n");
                this.txtDistPath.SelectAll();
                this.txtDistPath.Focus();
                return;
            }

            if (!System.IO.Directory.Exists(distPath))
            {
                ShowBox("中文文件夹不存在！\r\n");
                this.txtDistPath.SelectAll();
                this.txtDistPath.Focus();
                return;
            }
            #endregion

            bool isSuccess = op.SaveCfgInfo(new CfgInfo
            {
                Source = sourcePath,
                Dist = distPath
            });
           if (isSuccess)
           {
                this.ShowBox("配置信息保存成功！");
           }
           else
           {
                this.ShowBox("配置信息保存失败，请稍后再试！");
           }
            this.Close();
        }

        private void btnSourePath_Click(object sender, EventArgs e)
        {
            this.ofdSourceFile.Filter = "语言资源文件(resources_en.jar)|resources_en.jar";
            this.ofdSourceFile.CheckPathExists = true;
            this.ofdSourceFile.FileName = this.txtSourcePath.Text.Trim();
            if(this.ofdSourceFile.ShowDialog() == DialogResult.OK)
            {
                this.txtSourcePath.Text = this.ofdSourceFile.FileName;
            }
        }

        private void btnRefPath_Click(object sender, EventArgs e)
        {
            
            //this.fbdPath.SelectedPath = this.txtRefPath.Text.Trim();
            //if (this.fbdPath.ShowDialog() == DialogResult.OK)
            //{
            //    this.txtRefPath.Text = this.fbdPath.SelectedPath;
            //}
        }

        private void btnDistPath_Click(object sender, EventArgs e)
        {
            this.fbdPath.SelectedPath = this.txtDistPath.Text.Trim();
            if (this.fbdPath.ShowDialog() == DialogResult.OK)
            {
                this.txtDistPath.Text = this.fbdPath.SelectedPath;
            }
        }

        #endregion

        #region 私有方法
        private void InitFrom()
        {
            CfgInfo cfg = op.GetCfgInfo();
            this.txtSourcePath.Text = cfg.Source;
            this.txtDistPath.Text = cfg.Dist;
            this.toolTip1.SetToolTip(this.lblSourcePath, "原始的英文资源文件");
            this.toolTip1.SetToolTip(this.lblDistPath, "汉化后的中文资源文件(resources_cn.jar)存放路径");
        }

        private void LoadDefaultInfo()
        {
            CfgInfo cfg = op.GetDefaultCfgInfo();

            this.txtSourcePath.Text = cfg.Source;
            this.txtDistPath.Text = cfg.Dist;
        }

        private void ShowBox(string info)
        {
            MessageBox.Show(info, "配置信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
                
               
    }
}
