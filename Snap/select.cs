using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snap
{
    public partial class select : Form
    {
        public bool wasOptionsformShown = false;
        private bool inSelectMode = false;
        private int x0, y0, x1, y1;
        private Bitmap bm;

        public select()
        {
            InitializeComponent();
        }

        private void select_Load(object sender, EventArgs e)
        {
            int height = 0;
            int width = 0;
            foreach (var screen in Screen.AllScreens)
            {
                //take biggest height
                height = (screen.Bounds.Height >= height) ? screen.Bounds.Height : height;
                width += screen.Bounds.Width;
            }

            this.Size = new Size(width, height);
        }

        public void initBmp()
        {
            Rectangle b = Screen.GetBounds(new Point(MousePosition.X, MousePosition.Y));
            bm = new Bitmap(b.Width, b.Height);
        }

        private void selectArea_MouseUp(object sender, MouseEventArgs e)
        {
            inSelectMode = false;
            label1.Text = "Press [Enter] to upload or [ESC] to cancel";
        }

        private void selectArea_MouseDown(object sender, MouseEventArgs e)
        {
            inSelectMode = true;
            x0 = e.X;
            y0 = e.Y;
        }

        private void selectArea_Click(object sender, EventArgs e)
        {

        }

        private void select_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (wasOptionsformShown)
                {
                    wasOptionsformShown = false;
                    Program.formOptions.Show();
                }
                Close();
            } 
            else if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
                Bitmap bmp = Uploader.takeCropped(Math.Abs(x0 - x1), Math.Abs(y0 - y1), x0, y0);
                Uploader.Upload(Uploader.GetStringFromImage(bmp));
                Program.formOptions.displayInfo();
                if (wasOptionsformShown)
                {
                    wasOptionsformShown = false;
                    Program.formOptions.Show();
                }
                Close();
            }
        }

        private void selectArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < label1.Width + label1.Left + 10 && e.Y < label1.Height + label1.Top + 10)
            {
                label1.Location = new Point(label1.Location.X, this.Height - label1.Height - 15);
            }

            if (e.X > label1.Width + 15 + 10 || e.Y > label1.Height + 15 + 10)
            {
                label1.Location = new Point(15, 15);
            }

            if (!inSelectMode) return;

            x1 = e.X;
            y1 = e.Y;
            int w = Math.Abs(x0 - x1);
            int h = Math.Abs(y0 - y1);

            label1.Text = "X: " + x0 + ", Y: " + y0 + ", W: " + w + ", H: " + h;

            // Draw the rectangle.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Transparent);
                gr.DrawRectangle(Pens.Red,
                    Math.Min(x0, x1), Math.Min(y0, y1),
                    w, h);
            }

            // Display the temporary bitmap.
            selectArea.Image = bm;
        }
    }
}
