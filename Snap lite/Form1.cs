using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snap_lite
{
    public partial class select : Form
    {
        Boolean bHaveMouse;
        Point ptOriginal = new Point();
        Point ptLast = new Point();

        public select()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Uploader.initClient();
            trayIcon.Visible = true;
            int height = 0;
            int width = 0;
            foreach (var screen in Screen.AllScreens)
            {
                //take biggest height
                height = (screen.Bounds.Height >= height) ? screen.Bounds.Height : height;
                width += screen.Bounds.Width;
            }
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
        }

        private void MyDrawReversibleRectangle(Point p1, Point p2)
        {
            Rectangle rc = new Rectangle();

            // Convert the points to screen coordinates.
            p1 = PointToScreen(p1);
            p2 = PointToScreen(p2);
         
            rc.X = Math.Min(p1.X, p2.X);
            rc.Width = Math.Abs(p1.X - p2.X);
            rc.Y = Math.Min(p1.Y, p2.Y);
            rc.Height = Math.Abs(p1.Y - p2.Y);

            // Draw the reversible frame.
            ControlPaint.DrawReversibleFrame(rc, Color.Red, FrameStyle.Dashed);
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            Point ptCurrent = new Point(e.X, e.Y);
            // If we "have the mouse", then we draw our lines.
            if (bHaveMouse)
            {
                // If we have drawn previously, draw again in
                // that spot to remove the lines.
                if (ptLast.X != -1)
                {
                    MyDrawReversibleRectangle(ptOriginal, ptLast);
                }
                // Update last point.
                ptLast = ptCurrent;
                // Draw new lines.
                MyDrawReversibleRectangle(ptOriginal, ptCurrent);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ptLast.X != -1)
            {
                Point ptCurrent = new Point(e.X, e.Y);
                MyDrawReversibleRectangle(ptOriginal, ptLast);
            }
            // Make a note that we "have the mouse".
            bHaveMouse = true;
            // Store the "starting point" for this rubber-band rectangle.
            ptOriginal.X = e.X;
            ptOriginal.Y = e.Y;
            // Special value lets us know that no previous
            // rectangle needs to be erased.
            ptLast.X = -1;
            ptLast.Y = -1;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bHaveMouse = false;
            ttip.SetToolTip(this, "Press [ESC] to exit or [ENTER] to upload");
        }

        private void select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
                ttip.Hide(this);
                if (ptLast.X != -1)
                {
                    MyDrawReversibleRectangle(ptOriginal, ptLast);
                }
                Bitmap bmp = Uploader.takeCropped(Math.Abs(ptOriginal.X - ptLast.X), Math.Abs(ptOriginal.Y - ptLast.Y), Math.Min(ptOriginal.X, ptLast.X), Math.Min(ptOriginal.Y, ptLast.Y));
                Uploader.Upload(Uploader.GetStringFromImage(bmp));
                Close();
            }
        }
    }
}
