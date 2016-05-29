using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Snap
{
    public partial class options : Form
    {
        private int key_Mod, key_main;
        private string modName = "NULL";
        private string mainName;

        private static KeysConverter kConv = new KeysConverter();

        public options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideToTray();
        }
        
        public void hideToTray()
        {
            this.Hide();
            trayicon.Visible = true;
            saveSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void initScreens()
        {
            if (Screen.AllScreens.Length > 1)
            {
                int index = 0;

                foreach (var screen in Screen.AllScreens)
                {
                    string txt = (index + 1) + ". Screen" + " (" + screen.Bounds.Width + "x" + screen.Bounds.Height + ")";

                    ToolStripMenuItem item = new ToolStripMenuItem(txt);

                    item.ToolTipText = index.ToString();

                    item.Click += new System.EventHandler(this.on_screenSelect);
                    fullscreenShotToolStripMenuItem.DropDownItems.Add(item);
                    cb_action.Items.Add("Screenshot of Screen " + (index + 1) + " (" + screen.Bounds.Width + "x" + screen.Bounds.Height + ")");

                    index++;
                }
            }

        }

        public void loadSettings()
        {
            cb_balloontip.Checked = Properties.Settings.Default.showBalloon;
            cb_localcopy.Checked = Properties.Settings.Default.savelocal;
            tb_path.Text = Properties.Settings.Default.path;
            tb_quality.Value = Properties.Settings.Default.quality;

            if (Properties.Settings.Default.actionindex < cb_action.Items.Count)
                cb_action.SelectedIndex = Properties.Settings.Default.actionindex;
            else
                cb_action.SelectedIndex = 0;

            if (cb_localcopy.Checked)
            {
                btn_getpath.Enabled = true;
                tb_path.Enabled = true;
            }
            else
            {
                btn_getpath.Enabled = false;
                tb_path.Enabled = false;
            }
        }

        private void saveSettings()
        {
            Properties.Settings.Default.showBalloon = cb_balloontip.Checked;
            Properties.Settings.Default.savelocal = cb_localcopy.Checked;
            Properties.Settings.Default.path = tb_path.Text;
            Properties.Settings.Default.actionindex = cb_action.SelectedIndex;
            Properties.Settings.Default.quality = tb_quality.Value;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveSettings();
            trayicon.Visible = false;
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            if (Program.formSelect == null || Program.formSelect.IsDisposed)
                Program.formSelect = new select();
            Program.formSelect.initBmp();
            Program.formSelect.Show();
            Program.formSelect.wasOptionsformShown = true;
            trayicon.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uploader.Upload(Uploader.GetStringFromImage(Uploader.takeFullScreen(Screen.FromPoint(new Point(MousePosition.X, MousePosition.Y)))));
            this.Show();
        }

        private void croppedScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.formSelect == null || Program.formSelect.IsDisposed)
                Program.formSelect = new select();
            Program.formSelect.initBmp();
            Program.formSelect.Show();
        }


        private void defaultMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uploader.Upload(Uploader.GetStringFromImage(Uploader.takeDefaultFullScreen()));
            displayInfo();
        }

        public void displayInfo()
        {
            if (Properties.Settings.Default.showBalloon)
            {
                trayicon.BalloonTipText = "Uploaded to imgur.com.\nLink copied to clipboard";
                trayicon.BalloonTipTitle = "Success!";
                trayicon.ShowBalloonTip(2000);
            }
        }

        public void on_screenSelect(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                int monitorID = Convert.ToInt16(((ToolStripMenuItem)sender).ToolTipText);
                Uploader.Upload(Uploader.GetStringFromImage(Uploader.takeFullScreen(Screen.AllScreens[monitorID])));
                displayInfo();
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uploader.Upload(Uploader.GetStringFromImage(Uploader.takeDefaultFullScreen()));
            displayInfo();
        }

        private void showOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.formOptions.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trayicon.Visible = false;
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_localcopy.Checked)
            {
                tb_path.Enabled = true;
                btn_getpath.Enabled = true;
            }
            else
            {
                tb_path.Enabled = false;
                btn_getpath.Enabled = false;
            }
        }

        private void btn_getpath_Click(object sender, EventArgs e)
        {
            folderdialog.ShowDialog();
            tb_path.Text = folderdialog.SelectedPath;
            if (tb_path.Text == "")
                tb_path.Text = "C:\\";
        }

        private void options_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
            trayicon.Visible = false;
            Application.Exit();
        }

        private void trayicon_Click(object sender, EventArgs e)
        {
       
        }

        private void trayicon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (cb_action.SelectedIndex == 0)
                {
                    Hide();
                    if (Program.formSelect == null || Program.formSelect.IsDisposed)
                        Program.formSelect = new select();
                    Program.formSelect.initBmp();
                    Program.formSelect.Show();
                }
                else if (cb_action.SelectedIndex == 1)
                {
                    this.Hide();
                    Uploader.Upload(Uploader.GetStringFromImage(Uploader.takeDefaultFullScreen()));
                    this.Show();
                }
                else
                {
                    int monitorID = cb_action.SelectedIndex - 2;
                    if (monitorID < Screen.AllScreens.Length)
                    {
                        this.Hide();
                        Uploader.Upload(Uploader.GetStringFromImage(Uploader.takeFullScreen(Screen.AllScreens[monitorID])));
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Cannot find monitor with ID " + monitorID + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void trayicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            mainName = kConv.ConvertToString(key_main);
            modName = kConv.ConvertToString(key_Mod);

            textBox1.Clear();
            if (modName != "None")
                textBox1.Text = modName + " + " + mainName;
            else
                textBox1.Text = mainName;
            
            e.Handled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
            
        }
    }
}
