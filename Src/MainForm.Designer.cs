namespace Src
{
    partial class MainForm
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
            this.fileChangeWatcher = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkFileName = new System.Windows.Forms.LinkLabel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBundle = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileChangeWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // fileChangeWatcher
            // 
            this.fileChangeWatcher.EnableRaisingEvents = true;
            this.fileChangeWatcher.IncludeSubdirectories = true;
            this.fileChangeWatcher.SynchronizingObject = this;
            this.fileChangeWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileChangeWatcher_Changed);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Json Files (*.json)|*.json";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(136, 16);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(38, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Config file:";
            // 
            // lnkFileName
            // 
            this.lnkFileName.AutoSize = true;
            this.lnkFileName.Location = new System.Drawing.Point(79, 21);
            this.lnkFileName.Name = "lnkFileName";
            this.lnkFileName.Size = new System.Drawing.Size(51, 13);
            this.lnkFileName.TabIndex = 2;
            this.lnkFileName.TabStop = true;
            this.lnkFileName.Text = "FileName";
            this.lnkFileName.Visible = false;
            this.lnkFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFileName_LinkClicked);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(13, 72);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(366, 260);
            this.txtLog.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(16, 42);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.toolTip1.SetToolTip(this.btnStart, "Start listening to changes made to file, and automatically bundle and minify any " +
        "changes.");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBundle
            // 
            this.btnBundle.Enabled = false;
            this.btnBundle.Location = new System.Drawing.Point(97, 42);
            this.btnBundle.Name = "btnBundle";
            this.btnBundle.Size = new System.Drawing.Size(75, 23);
            this.btnBundle.TabIndex = 5;
            this.btnBundle.Text = "Bundle";
            this.toolTip1.SetToolTip(this.btnBundle, "Bundle/Minify now");
            this.btnBundle.UseVisualStyleBackColor = true;
            this.btnBundle.Click += new System.EventHandler(this.btnBundle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 344);
            this.Controls.Add(this.btnBundle);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lnkFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Name = "MainForm";
            this.Text = "Minify";
            ((System.ComponentModel.ISupportInitialize)(this.fileChangeWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileChangeWatcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel lnkFileName;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBundle;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

