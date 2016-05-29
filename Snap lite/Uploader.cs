using Snap_lite;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Snap_lite
{
    class Uploader
    {
        private static string clientID = "7dd1b869f7a306a";
        private static WebClient w = new WebClient();
        private static ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
        private static System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        private static EncoderParameters myEncoderParameters = new EncoderParameters(1);

        public static void initClient()
        {
            w.Headers.Add("Authorization", "Client-ID " + clientID);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static byte[] ReadFully(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        public static string GetStringFromImage(Bitmap image)
        {
            if (image != null)
            {
                ImageConverter ic = new ImageConverter();

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 90L);

                myEncoderParameters.Param[0] = myEncoderParameter;

                MemoryStream stream = new MemoryStream();

                image.Save(stream, jgpEncoder, myEncoderParameters);
                
                byte[] buffer = ReadFully(stream);

                return Convert.ToBase64String(
                    buffer,
                    Base64FormattingOptions.InsertLineBreaks);
            }
            else
                return null;
        }

        public static string Upload(string imageAsBase64String)
        {
            Program.formSelect.trayIcon.Icon = Properties.Resources.uploadIcon;
            var values = new NameValueCollection
            {
                { "image", imageAsBase64String }
            };

            byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);

            XDocument xD = XDocument.Load(new MemoryStream(response));
            
            Console.WriteLine(xD);

            string url = xD.Root.Element("link").Value;
            Clipboard.SetText(url);
            Program.formSelect.trayIcon.Icon = Properties.Resources.defaultIcon;
            return url;
        }

        public static Bitmap takeFullScreen(Screen s)
        {
            Bitmap bmp = new Bitmap(s.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Rectangle currentScreen = s.Bounds;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(currentScreen.X, currentScreen.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            };

            return bmp;
        }

        public static Bitmap takeDefaultFullScreen()
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Rectangle currentScreen = Screen.PrimaryScreen.Bounds;
           
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(currentScreen.X, currentScreen.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            };

            return bmp;
        }

        public static Bitmap takeCropped(int widht, int height, int x, int y)
        {
            if (Screen.AllScreens.Length > 1)
            {
                Bitmap[] screenShots = new Bitmap[Screen.AllScreens.Length];
                int fullWidht = 0,fullHeight = 0;
                for (int i = 0; i < screenShots.Length; i++)
                {
                    fullHeight = fullHeight < Screen.AllScreens[i].Bounds.Height ? Screen.AllScreens[i].Bounds.Height : fullHeight;
                    fullWidht += Screen.AllScreens[i].Bounds.Width;

                    screenShots[i] = takeFullScreen(Screen.AllScreens[i]);
                }

                Bitmap allScreens = new Bitmap(fullWidht, fullHeight);
                int xOffset = 0;
                foreach (Image img in screenShots)
                {
                    using (Graphics grfx = Graphics.FromImage(img))
                    {
                        grfx.DrawImage(allScreens, xOffset, 0);
                    }
                    xOffset += img.Width;
                }

                Rectangle rect = new Rectangle(x, y, widht, height);
                Bitmap cropped = allScreens.Clone(rect, allScreens.PixelFormat);
                return cropped;
            }
            else
            {
                Screen s = Screen.FromPoint(new Point(x, y));
                Bitmap bmp = takeFullScreen(s);
                Rectangle rect = new Rectangle(x - s.Bounds.X, y - s.Bounds.Y, widht, height);
                Bitmap cropped = bmp.Clone(rect, bmp.PixelFormat);

                return cropped;
            }
        }
    }
}
