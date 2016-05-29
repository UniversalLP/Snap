namespace Snap
{
    partial class options
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(options));
            this.btn_hidetotray = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_fullscreen = new System.Windows.Forms.Button();
            this.btn_cropped = new System.Windows.Forms.Button();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullscreenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.croppedScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_balloontip = new System.Windows.Forms.CheckBox();
            this.lbl_header = new System.Windows.Forms.Label();
            this.cb_localcopy = new System.Windows.Forms.CheckBox();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_getpath = new System.Windows.Forms.Button();
            this.folderdialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lbl_actiononclick = new System.Windows.Forms.Label();
            this.cb_action = new System.Windows.Forms.ComboBox();
            this.tb_quality = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trayContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_quality)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_hidetotray
            // 
            this.btn_hidetotray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_hidetotray.Location = new System.Drawing.Point(79, 319);
            this.btn_hidetotray.Name = "btn_hidetotray";
            this.btn_hidetotray.Size = new System.Drawing.Size(109, 23);
            this.btn_hidetotray.TabIndex = 0;
            this.btn_hidetotray.Text = "Hide to traybar";
            this.btn_hidetotray.UseVisualStyleBackColor = true;
            this.btn_hidetotray.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.Location = new System.Drawing.Point(12, 319);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(61, 23);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_fullscreen
            // 
            this.btn_fullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_fullscreen.Location = new System.Drawing.Point(12, 261);
            this.btn_fullscreen.Name = "btn_fullscreen";
            this.btn_fullscreen.Size = new System.Drawing.Size(176, 23);
            this.btn_fullscreen.TabIndex = 2;
            this.btn_fullscreen.Text = "Take screenshot";
            this.btn_fullscreen.UseVisualStyleBackColor = true;
            this.btn_fullscreen.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_cropped
            // 
            this.btn_cropped.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cropped.Location = new System.Drawing.Point(12, 290);
            this.btn_cropped.Name = "btn_cropped";
            this.btn_cropped.Size = new System.Drawing.Size(176, 23);
            this.btn_cropped.TabIndex = 3;
            this.btn_cropped.Text = "Take cropped screenshot";
            this.btn_cropped.UseVisualStyleBackColor = true;
            this.btn_cropped.Click += new System.EventHandler(this.button4_Click);
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayicon.ContextMenuStrip = this.trayContextMenu;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "Snap";
            this.trayicon.Click += new System.EventHandler(this.trayicon_Click);
            this.trayicon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseClick);
            this.trayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseDoubleClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullscreenShotToolStripMenuItem,
            this.croppedScreenshotToolStripMenuItem,
            this.showOptionsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.trayContextMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.trayContextMenu.Size = new System.Drawing.Size(179, 98);
            // 
            // fullscreenShotToolStripMenuItem
            // 
            this.fullscreenShotToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fullscreenShotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem});
            this.fullscreenShotToolStripMenuItem.Name = "fullscreenShotToolStripMenuItem";
            this.fullscreenShotToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fullscreenShotToolStripMenuItem.Text = "Fullscreen screenshot";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.defaultToolStripMenuItem.Text = "Default Screen";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // croppedScreenshotToolStripMenuItem
            // 
            this.croppedScreenshotToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.croppedScreenshotToolStripMenuItem.Name = "croppedScreenshotToolStripMenuItem";
            this.croppedScreenshotToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.croppedScreenshotToolStripMenuItem.Text = "Cropped screenshot";
            this.croppedScreenshotToolStripMenuItem.Click += new System.EventHandler(this.croppedScreenshotToolStripMenuItem_Click);
            // 
            // showOptionsToolStripMenuItem
            // 
            this.showOptionsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showOptionsToolStripMenuItem.Name = "showOptionsToolStripMenuItem";
            this.showOptionsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.showOptionsToolStripMenuItem.Text = "Show options";
            this.showOptionsToolStripMenuItem.Click += new System.EventHandler(this.showOptionsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cb_balloontip
            // 
            this.cb_balloontip.AutoSize = true;
            this.cb_balloontip.Location = new System.Drawing.Point(12, 36);
            this.cb_balloontip.Name = "cb_balloontip";
            this.cb_balloontip.Size = new System.Drawing.Size(152, 30);
            this.cb_balloontip.TabIndex = 4;
            this.cb_balloontip.Text = "Show Balloon tip info after \r\nscreenshot\r\n";
            this.cb_balloontip.UseVisualStyleBackColor = true;
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_header.Location = new System.Drawing.Point(57, 9);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(76, 24);
            this.lbl_header.TabIndex = 5;
            this.lbl_header.Text = "Settings";
            // 
            // cb_localcopy
            // 
            this.cb_localcopy.AutoSize = true;
            this.cb_localcopy.Location = new System.Drawing.Point(12, 72);
            this.cb_localcopy.Name = "cb_localcopy";
            this.cb_localcopy.Size = new System.Drawing.Size(102, 17);
            this.cb_localcopy.TabIndex = 6;
            this.cb_localcopy.Text = "Save local copy";
            this.cb_localcopy.UseVisualStyleBackColor = true;
            this.cb_localcopy.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(12, 95);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(142, 20);
            this.tb_path.TabIndex = 7;
            this.tb_path.Text = "C:\\";
            // 
            // btn_getpath
            // 
            this.btn_getpath.Location = new System.Drawing.Point(160, 93);
            this.btn_getpath.Name = "btn_getpath";
            this.btn_getpath.Size = new System.Drawing.Size(28, 23);
            this.btn_getpath.TabIndex = 8;
            this.btn_getpath.Text = "...";
            this.btn_getpath.UseVisualStyleBackColor = true;
            this.btn_getpath.Click += new System.EventHandler(this.btn_getpath_Click);
            // 
            // folderdialog
            // 
            this.folderdialog.Description = "Select a folder to save your screenshots";
            // 
            // lbl_actiononclick
            // 
            this.lbl_actiononclick.AutoSize = true;
            this.lbl_actiononclick.Location = new System.Drawing.Point(9, 122);
            this.lbl_actiononclick.Name = "lbl_actiononclick";
            this.lbl_actiononclick.Size = new System.Drawing.Size(167, 13);
            this.lbl_actiononclick.TabIndex = 9;
            this.lbl_actiononclick.Text = "Clicking on the trayicon will take a";
            // 
            // cb_action
            // 
            this.cb_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_action.FormattingEnabled = true;
            this.cb_action.Items.AddRange(new object[] {
            "Cropped screenshot",
            "Screenshot of default screen"});
            this.cb_action.Location = new System.Drawing.Point(12, 140);
            this.cb_action.Name = "cb_action";
            this.cb_action.Size = new System.Drawing.Size(176, 21);
            this.cb_action.TabIndex = 10;
            // 
            // tb_quality
            // 
            this.tb_quality.Location = new System.Drawing.Point(10, 186);
            this.tb_quality.Maximum = 100;
            this.tb_quality.Minimum = 1;
            this.tb_quality.Name = "tb_quality";
            this.tb_quality.Size = new System.Drawing.Size(178, 42);
            this.tb_quality.TabIndex = 11;
            this.tb_quality.TickFrequency = 100;
            this.tb_quality.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_quality.Value = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "JPG Quality";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 234);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Caputer fullscreen key:";
            // 
            // options
            // 
            this.AcceptButton = this.btn_hidetotray;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(200, 354);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_fullscreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_quality);
            this.Controls.Add(this.cb_action);
            this.Controls.Add(this.lbl_actiononclick);
            this.Controls.Add(this.btn_getpath);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.cb_localcopy);
            this.Controls.Add(this.lbl_header);
            this.Controls.Add(this.cb_balloontip);
            this.Controls.Add(this.btn_cropped);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_hidetotray);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "options";
            this.Text = "Snap options";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.options_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.trayContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_hidetotray;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_fullscreen;
        private System.Windows.Forms.Button btn_cropped;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem fullscreenShotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem croppedScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_balloontip;
        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.CheckBox cb_localcopy;
        private System.Windows.Forms.Button btn_getpath;
        private System.Windows.Forms.FolderBrowserDialog folderdialog;
        public System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Label lbl_actiononclick;
        private System.Windows.Forms.ComboBox cb_action;
        public System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TrackBar tb_quality;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}

