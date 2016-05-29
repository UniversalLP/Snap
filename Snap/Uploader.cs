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

namespace Snap
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

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, Program.formOptions.tb_quality.Value);

                myEncoderParameters.Param[0] = myEncoderParameter;

                MemoryStream stream = new MemoryStream();

                image.Save(stream, jgpEncoder, myEncoderParameters);
                
                byte[] buffer = ReadFully(stream);
                Console.WriteLine(buffer.Length);
               

                if (Properties.Settings.Default.savelocal)
                {
                    image.Save(Program.formOptions.tb_path.Text + "\\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".jpg", jgpEncoder, myEncoderParameters);
                }

                return Convert.ToBase64String(
                    buffer,
                    Base64FormattingOptions.InsertLineBreaks);
            }
            else
                return null;
        }

        public static string Upload(string imageAsBase64String)
        {
            Program.formOptions.trayicon.Icon = Properties.Resources.uploadIcon;
            var values = new NameValueCollection
            {
                { "image", imageAsBase64String }
            };

            byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);

            XDocument xD = XDocument.Load(new MemoryStream(response));
            
            Console.WriteLine(xD);

            string url = xD.Root.Element("link").Value;
            Clipboard.SetText(url);
            Program.formOptions.trayicon.Icon = Properties.Resources.defaultIcon;
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
            Bitmap bmp = takeFullScreen(Screen.FromPoint(new Point(x, y)));
            Rectangle rect = new Rectangle(x, y, widht, height);
            Bitmap cropped = bmp.Clone(rect, bmp.PixelFormat);

            return cropped;
        }
    }
}
