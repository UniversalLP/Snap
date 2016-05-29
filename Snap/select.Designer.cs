namespace Snap
{
    partial class select
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(select));
            this.selectArea = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectArea)).BeginInit();
            this.SuspendLayout();
            // 
            // selectArea
            // 
            this.selectArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectArea.Location = new System.Drawing.Point(0, 0);
            this.selectArea.Name = "selectArea";
            this.selectArea.Size = new System.Drawing.Size(292, 273);
            this.selectArea.TabIndex = 0;
            this.selectArea.TabStop = false;
            this.selectArea.Click += new System.EventHandler(this.selectArea_Click);
            this.selectArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectArea_MouseDown);
            this.selectArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.selectArea_MouseMove);
            this.selectArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectArea_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "X: 0, Y: 0, W: 0, H: 0";
            // 
            // select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectArea);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "select";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.Text = "select";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.select_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.select_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.select_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.selectArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox selectArea;
        private System.Windows.Forms.Label label1;
    }
}