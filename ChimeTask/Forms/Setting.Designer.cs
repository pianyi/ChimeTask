namespace chimeTask.Forms
{
    partial class Setting
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonTestPlay = new System.Windows.Forms.Button();
            this.textBoxPlayFile = new System.Windows.Forms.TextBox();
            this.buttonSelectPalyFile = new System.Windows.Forms.Button();
            this.labelPlayFile = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonClear = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxTimer = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.numericUpDownHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinute = new System.Windows.Forms.NumericUpDown();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonStartUp = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTestPlay
            // 
            this.buttonTestPlay.Location = new System.Drawing.Point(97, 40);
            this.buttonTestPlay.Name = "buttonTestPlay";
            this.buttonTestPlay.Size = new System.Drawing.Size(89, 40);
            this.buttonTestPlay.TabIndex = 2;
            this.buttonTestPlay.Text = "再生";
            this.buttonTestPlay.UseVisualStyleBackColor = true;
            this.buttonTestPlay.Click += new System.EventHandler(this.buttonTestPlay_Click);
            // 
            // textBoxPlayFile
            // 
            this.textBoxPlayFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayFile.Location = new System.Drawing.Point(97, 12);
            this.textBoxPlayFile.Name = "textBoxPlayFile";
            this.textBoxPlayFile.Size = new System.Drawing.Size(373, 22);
            this.textBoxPlayFile.TabIndex = 0;
            this.textBoxPlayFile.Text = " ";
            this.textBoxPlayFile.TextChanged += new System.EventHandler(this.textBoxPlayFile_TextChanged);
            this.textBoxPlayFile.Leave += new System.EventHandler(this.textBoxPlayFile_Leave);
            // 
            // buttonSelectPalyFile
            // 
            this.buttonSelectPalyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectPalyFile.Location = new System.Drawing.Point(476, 12);
            this.buttonSelectPalyFile.Name = "buttonSelectPalyFile";
            this.buttonSelectPalyFile.Size = new System.Drawing.Size(75, 24);
            this.buttonSelectPalyFile.TabIndex = 1;
            this.buttonSelectPalyFile.Text = "参照";
            this.buttonSelectPalyFile.UseVisualStyleBackColor = true;
            this.buttonSelectPalyFile.Click += new System.EventHandler(this.buttonSelectPalyFile_Click);
            // 
            // labelPlayFile
            // 
            this.labelPlayFile.AutoSize = true;
            this.labelPlayFile.Location = new System.Drawing.Point(12, 16);
            this.labelPlayFile.Name = "labelPlayFile";
            this.labelPlayFile.Size = new System.Drawing.Size(67, 15);
            this.labelPlayFile.TabIndex = 3;
            this.labelPlayFile.Text = "再生音源";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "MP3ファイル|*.mp3";
            this.openFileDialog.Title = "再生ファイル選択";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(476, 40);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 24);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "クリア";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "チャイムタスク";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSetting,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(109, 58);
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemSetting.Text = "設定";
            this.toolStripMenuItemSetting.Click += new System.EventHandler(this.toolStripMenuItemSetting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemExit.Text = "終了";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // listBoxTimer
            // 
            this.listBoxTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxTimer.FormattingEnabled = true;
            this.listBoxTimer.ItemHeight = 15;
            this.listBoxTimer.Location = new System.Drawing.Point(97, 113);
            this.listBoxTimer.Name = "listBoxTimer";
            this.listBoxTimer.ScrollAlwaysVisible = true;
            this.listBoxTimer.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTimer.Size = new System.Drawing.Size(126, 124);
            this.listBoxTimer.Sorted = true;
            this.listBoxTimer.TabIndex = 7;
            this.listBoxTimer.DoubleClick += new System.EventHandler(this.listBoxTimer_DoubleClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(429, 113);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 42);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(229, 213);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 24);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // numericUpDownHour
            // 
            this.numericUpDownHour.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownHour.Location = new System.Drawing.Point(229, 113);
            this.numericUpDownHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDownHour.Name = "numericUpDownHour";
            this.numericUpDownHour.Size = new System.Drawing.Size(75, 40);
            this.numericUpDownHour.TabIndex = 4;
            this.numericUpDownHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownHour.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // numericUpDownMinute
            // 
            this.numericUpDownMinute.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownMinute.Location = new System.Drawing.Point(348, 113);
            this.numericUpDownMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDownMinute.Name = "numericUpDownMinute";
            this.numericUpDownMinute.Size = new System.Drawing.Size(75, 40);
            this.numericUpDownMinute.TabIndex = 5;
            this.numericUpDownMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMinute.Enter += new System.EventHandler(this.numericUpDown_Enter);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTime.Location = new System.Drawing.Point(310, 115);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(32, 33);
            this.labelTime.TabIndex = 10;
            this.labelTime.Text = "：";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonStartUp
            // 
            this.buttonStartUp.Location = new System.Drawing.Point(412, 211);
            this.buttonStartUp.Name = "buttonStartUp";
            this.buttonStartUp.Size = new System.Drawing.Size(139, 26);
            this.buttonStartUp.TabIndex = 11;
            this.buttonStartUp.Text = "スタートアップ登録";
            this.buttonStartUp.UseVisualStyleBackColor = true;
            this.buttonStartUp.Click += new System.EventHandler(this.buttonbuttonStartUp_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 255);
            this.Controls.Add(this.buttonStartUp);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.numericUpDownMinute);
            this.Controls.Add(this.numericUpDownHour);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxTimer);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelPlayFile);
            this.Controls.Add(this.buttonSelectPalyFile);
            this.Controls.Add(this.textBoxPlayFile);
            this.Controls.Add(this.buttonTestPlay);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(581, 302);
            this.Name = "Setting";
            this.ShowInTaskbar = false;
            this.Text = "チャイムタスク - 設定画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Shown += new System.EventHandler(this.Setting_Shown);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTestPlay;
        private System.Windows.Forms.Label labelPlayFile;
        private System.Windows.Forms.Button buttonSelectPalyFile;
        private System.Windows.Forms.TextBox textBoxPlayFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListBox listBoxTimer;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown numericUpDownHour;
        private System.Windows.Forms.NumericUpDown numericUpDownMinute;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Button buttonStartUp;
    }
}

