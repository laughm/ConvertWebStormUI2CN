namespace WebStormCN.WinForm.Forms
{
    partial class frmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.clientInfo = new System.Windows.Forms.GroupBox();
            this.lblCNDesc = new System.Windows.Forms.Label();
            this.lblEnDesc = new System.Windows.Forms.Label();
            this.btnDistPath = new System.Windows.Forms.Button();
            this.btnSourePath = new System.Windows.Forms.Button();
            this.txtDistPath = new System.Windows.Forms.TextBox();
            this.lblDistPath = new System.Windows.Forms.Label();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.btnDefault = new System.Windows.Forms.Button();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ofdSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.clientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(612, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(612, 188);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭(&X)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // clientInfo
            // 
            this.clientInfo.Controls.Add(this.lblCNDesc);
            this.clientInfo.Controls.Add(this.lblEnDesc);
            this.clientInfo.Controls.Add(this.btnDistPath);
            this.clientInfo.Controls.Add(this.btnSourePath);
            this.clientInfo.Controls.Add(this.txtDistPath);
            this.clientInfo.Controls.Add(this.lblDistPath);
            this.clientInfo.Controls.Add(this.txtSourcePath);
            this.clientInfo.Controls.Add(this.lblSourcePath);
            this.clientInfo.Location = new System.Drawing.Point(12, 12);
            this.clientInfo.Name = "clientInfo";
            this.clientInfo.Size = new System.Drawing.Size(583, 226);
            this.clientInfo.TabIndex = 2;
            this.clientInfo.TabStop = false;
            this.clientInfo.Text = "路径信息";
            // 
            // lblCNDesc
            // 
            this.lblCNDesc.AutoSize = true;
            this.lblCNDesc.Location = new System.Drawing.Point(76, 175);
            this.lblCNDesc.Name = "lblCNDesc";
            this.lblCNDesc.Size = new System.Drawing.Size(329, 12);
            this.lblCNDesc.TabIndex = 11;
            this.lblCNDesc.Text = "汉化后的中文资源文件（名称：resources_cn.jar）存放路径";
            // 
            // lblEnDesc
            // 
            this.lblEnDesc.AutoSize = true;
            this.lblEnDesc.Location = new System.Drawing.Point(66, 77);
            this.lblEnDesc.Name = "lblEnDesc";
            this.lblEnDesc.Size = new System.Drawing.Size(455, 12);
            this.lblEnDesc.TabIndex = 10;
            this.lblEnDesc.Text = "此文件位于 WebStorm 安装路径中的【lib】文件夹中，名称为【resources_en.jar】";
            // 
            // btnDistPath
            // 
            this.btnDistPath.AutoSize = true;
            this.btnDistPath.Image = ((System.Drawing.Image)(resources.GetObject("btnDistPath.Image")));
            this.btnDistPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDistPath.Location = new System.Drawing.Point(526, 138);
            this.btnDistPath.Name = "btnDistPath";
            this.btnDistPath.Size = new System.Drawing.Size(38, 38);
            this.btnDistPath.TabIndex = 9;
            this.btnDistPath.UseVisualStyleBackColor = true;
            this.btnDistPath.Click += new System.EventHandler(this.btnDistPath_Click);
            // 
            // btnSourePath
            // 
            this.btnSourePath.AutoSize = true;
            this.btnSourePath.Image = ((System.Drawing.Image)(resources.GetObject("btnSourePath.Image")));
            this.btnSourePath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSourePath.Location = new System.Drawing.Point(526, 39);
            this.btnSourePath.Name = "btnSourePath";
            this.btnSourePath.Size = new System.Drawing.Size(40, 40);
            this.btnSourePath.TabIndex = 7;
            this.btnSourePath.UseVisualStyleBackColor = true;
            this.btnSourePath.Click += new System.EventHandler(this.btnSourePath_Click);
            // 
            // txtDistPath
            // 
            this.txtDistPath.Location = new System.Drawing.Point(78, 147);
            this.txtDistPath.Name = "txtDistPath";
            this.txtDistPath.Size = new System.Drawing.Size(434, 21);
            this.txtDistPath.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtDistPath, "汉化后的中文资源文件（名称：resources_cn.jar）存放路径");
            // 
            // lblDistPath
            // 
            this.lblDistPath.AutoSize = true;
            this.lblDistPath.Location = new System.Drawing.Point(6, 151);
            this.lblDistPath.Name = "lblDistPath";
            this.lblDistPath.Size = new System.Drawing.Size(77, 12);
            this.lblDistPath.TabIndex = 6;
            this.lblDistPath.Text = "中文文件夹：";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(78, 48);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(434, 21);
            this.txtSourcePath.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtSourcePath, "此文件位于 WebStorm 安装路径中的【lib】文件夹中，名称为【resources_en.jar】");
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(6, 52);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(77, 12);
            this.lblSourcePath.TabIndex = 2;
            this.lblSourcePath.Text = "英文源文件：";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(611, 36);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 6;
            this.btnDefault.Text = "默认(&L)";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 249);
            this.ControlBox = false;
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.clientInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序配置设置";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.clientInfo.ResumeLayout(false);
            this.clientInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox clientInfo;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox txtDistPath;
        private System.Windows.Forms.Label lblDistPath;
        private System.Windows.Forms.Button btnSourePath;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.Button btnDistPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog ofdSourceFile;
        private System.Windows.Forms.Label lblCNDesc;
        private System.Windows.Forms.Label lblEnDesc;
    }
}