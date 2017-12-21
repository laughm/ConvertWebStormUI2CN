namespace WebStormCN.WinForm.Forms
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbInfo = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbQuit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvFileName = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstvCnFileContent = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.engValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chsValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSaveChange = new System.Windows.Forms.Button();
            this.txtCNValue = new System.Windows.Forms.TextBox();
            this.lblItemTitle = new System.Windows.Forms.Label();
            this.txtEngValue = new System.Windows.Forms.TextBox();
            this.lblEngTitle = new System.Windows.Forms.Label();
            this.txtItemValue = new System.Windows.Forms.TextBox();
            this.lblCNTitle = new System.Windows.Forms.Label();
            this.ttpWS = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslInfo,
            this.tssInfo,
            this.tspbInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 30);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslInfo
            // 
            this.tsslInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslInfo.Name = "tsslInfo";
            this.tsslInfo.Size = new System.Drawing.Size(0, 25);
            // 
            // tssInfo
            // 
            this.tssInfo.AutoSize = false;
            this.tssInfo.Name = "tssInfo";
            this.tssInfo.Size = new System.Drawing.Size(300, 25);
            this.tssInfo.Tag = "";
            this.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbInfo
            // 
            this.tspbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tspbInfo.Name = "tspbInfo";
            this.tspbInfo.Size = new System.Drawing.Size(200, 24);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.toolStripSeparator1,
            this.tsbSetup,
            this.toolStripSeparator2,
            this.tsbEdit,
            this.toolStripSeparator3,
            this.tsbView,
            this.toolStripSeparator5,
            this.tsbCreate,
            this.toolStripSeparator4,
            this.tsbQuit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbStart
            // 
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(84, 36);
            this.tsbStart.Text = "开始(&B)";
            this.tsbStart.ToolTipText = "开始汉化";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSetup
            // 
            this.tsbSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetup.Image")));
            this.tsbSetup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetup.Name = "tsbSetup";
            this.tsbSetup.Size = new System.Drawing.Size(83, 36);
            this.tsbSetup.Text = "设置(&S)";
            this.tsbSetup.ToolTipText = "设置要汉化的文件路径";
            this.tsbSetup.Click += new System.EventHandler(this.tsbSetup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(83, 36);
            this.tsbEdit.Text = "校对(&E)";
            this.tsbEdit.ToolTipText = "校对汉化内容";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbView
            // 
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(84, 36);
            this.tsbView.Text = "查看(&V)";
            this.tsbView.ToolTipText = "查看汉化后的源文件";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbCreate
            // 
            this.tsbCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreate.Image")));
            this.tsbCreate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreate.Name = "tsbCreate";
            this.tsbCreate.Size = new System.Drawing.Size(84, 36);
            this.tsbCreate.Text = "创建(&C)";
            this.tsbCreate.ToolTipText = "创建中文语言包";
            this.tsbCreate.Click += new System.EventHandler(this.tsbCreate_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbQuit
            // 
            this.tsbQuit.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuit.Image")));
            this.tsbQuit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuit.Name = "tsbQuit";
            this.tsbQuit.Size = new System.Drawing.Size(86, 36);
            this.tsbQuit.Text = "退出(&Q)";
            this.tsbQuit.ToolTipText = "退出系统";
            this.tsbQuit.Click += new System.EventHandler(this.tsbQuit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvFileName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 382);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvFileName
            // 
            this.tvFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFileName.Location = new System.Drawing.Point(0, 0);
            this.tvFileName.Name = "tvFileName";
            this.tvFileName.Size = new System.Drawing.Size(150, 382);
            this.tvFileName.TabIndex = 1;
            this.tvFileName.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFileName_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstvCnFileContent);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSaveChange);
            this.splitContainer2.Panel2.Controls.Add(this.txtCNValue);
            this.splitContainer2.Panel2.Controls.Add(this.lblItemTitle);
            this.splitContainer2.Panel2.Controls.Add(this.txtEngValue);
            this.splitContainer2.Panel2.Controls.Add(this.lblEngTitle);
            this.splitContainer2.Panel2.Controls.Add(this.txtItemValue);
            this.splitContainer2.Panel2.Controls.Add(this.lblCNTitle);
            this.splitContainer2.Panel2MinSize = 90;
            this.splitContainer2.Size = new System.Drawing.Size(630, 382);
            this.splitContainer2.SplitterDistance = 288;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstvCnFileContent
            // 
            this.lstvCnFileContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.menuItem,
            this.engValue,
            this.chsValue});
            this.lstvCnFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvCnFileContent.FullRowSelect = true;
            this.lstvCnFileContent.Location = new System.Drawing.Point(0, 0);
            this.lstvCnFileContent.Name = "lstvCnFileContent";
            this.lstvCnFileContent.Size = new System.Drawing.Size(630, 288);
            this.lstvCnFileContent.TabIndex = 0;
            this.lstvCnFileContent.UseCompatibleStateImageBehavior = false;
            this.lstvCnFileContent.View = System.Windows.Forms.View.Details;
            this.lstvCnFileContent.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstvCnFileContent_ItemSelectionChanged);
            // 
            // Id
            // 
            this.Id.Text = "序号";
            // 
            // menuItem
            // 
            this.menuItem.Text = "数据项";
            this.menuItem.Width = 120;
            // 
            // engValue
            // 
            this.engValue.Text = "英文值";
            this.engValue.Width = 171;
            // 
            // chsValue
            // 
            this.chsValue.Text = "中文翻译";
            this.chsValue.Width = 184;
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveChange.Enabled = false;
            this.btnSaveChange.Location = new System.Drawing.Point(529, 32);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(89, 23);
            this.btnSaveChange.TabIndex = 2;
            this.btnSaveChange.Text = "保存修改(&U)";
            this.ttpWS.SetToolTip(this.btnSaveChange, "写修改内容到文件中");
            this.btnSaveChange.UseVisualStyleBackColor = true;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // txtCNValue
            // 
            this.txtCNValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCNValue.Location = new System.Drawing.Point(74, 60);
            this.txtCNValue.Multiline = true;
            this.txtCNValue.Name = "txtCNValue";
            this.txtCNValue.Size = new System.Drawing.Size(439, 21);
            this.txtCNValue.TabIndex = 1;
            this.txtCNValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCNValue_KeyUp);
            // 
            // lblItemTitle
            // 
            this.lblItemTitle.AutoSize = true;
            this.lblItemTitle.Location = new System.Drawing.Point(3, 10);
            this.lblItemTitle.Name = "lblItemTitle";
            this.lblItemTitle.Size = new System.Drawing.Size(65, 12);
            this.lblItemTitle.TabIndex = 0;
            this.lblItemTitle.Text = "数 据 项：";
            // 
            // txtEngValue
            // 
            this.txtEngValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEngValue.Location = new System.Drawing.Point(74, 33);
            this.txtEngValue.Multiline = true;
            this.txtEngValue.Name = "txtEngValue";
            this.txtEngValue.ReadOnly = true;
            this.txtEngValue.Size = new System.Drawing.Size(439, 21);
            this.txtEngValue.TabIndex = 1;
            // 
            // lblEngTitle
            // 
            this.lblEngTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEngTitle.AutoSize = true;
            this.lblEngTitle.Location = new System.Drawing.Point(3, 37);
            this.lblEngTitle.Name = "lblEngTitle";
            this.lblEngTitle.Size = new System.Drawing.Size(65, 12);
            this.lblEngTitle.TabIndex = 0;
            this.lblEngTitle.Text = "英 文 值：";
            // 
            // txtItemValue
            // 
            this.txtItemValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemValue.Location = new System.Drawing.Point(74, 7);
            this.txtItemValue.Name = "txtItemValue";
            this.txtItemValue.ReadOnly = true;
            this.txtItemValue.Size = new System.Drawing.Size(439, 21);
            this.txtItemValue.TabIndex = 1;
            // 
            // lblCNTitle
            // 
            this.lblCNTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCNTitle.AutoSize = true;
            this.lblCNTitle.Location = new System.Drawing.Point(3, 64);
            this.lblCNTitle.Name = "lblCNTitle";
            this.lblCNTitle.Size = new System.Drawing.Size(65, 12);
            this.lblCNTitle.TabIndex = 0;
            this.lblCNTitle.Text = "中文翻译：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 490);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebStorm 汉化辅助工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbQuit;
        private System.Windows.Forms.ToolStripStatusLabel tsslInfo;
        private System.Windows.Forms.ToolStripStatusLabel tssInfo;
        private System.Windows.Forms.ToolStripProgressBar tspbInfo;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lstvCnFileContent;
        private System.Windows.Forms.ColumnHeader engValue;
        private System.Windows.Forms.ColumnHeader chsValue;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader menuItem;
        private System.Windows.Forms.TextBox txtItemValue;
        private System.Windows.Forms.Label lblItemTitle;
        private System.Windows.Forms.TextBox txtEngValue;
        private System.Windows.Forms.Label lblEngTitle;
        private System.Windows.Forms.TextBox txtCNValue;
        private System.Windows.Forms.Label lblCNTitle;
        private System.Windows.Forms.Button btnSaveChange;
        private System.Windows.Forms.ToolTip ttpWS;
        private System.Windows.Forms.ToolStripButton tsbCreate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.TreeView tvFileName;
    }
}