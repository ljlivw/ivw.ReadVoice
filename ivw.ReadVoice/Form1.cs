using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ivw.ReadVoice
{
    public partial class Form1 : Form
    {
        VoiceHelper voiceHelper = new VoiceHelper();
        public Form1()
        {
            InitializeComponent();
            List<InstalledVoice> installedVoices = voiceHelper.GetVoices();
            List<string> vs = new List<string>();
            foreach (var item in installedVoices)
            {
                vs.Add(item.VoiceInfo.Name);
            }
            listBox1.DataSource = vs;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            voiceHelper.ReadVoice(trackBar1.Value, textBox1.Text, listBox1.SelectedItem.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        frmCutter cutter;
        private void BtnImageToWords_Click(object sender, EventArgs e)
        {
            // 新建一个和屏幕大小相同的图片
            Bitmap CatchBmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);

            // 创建一个画板，让我们可以在画板上画图
            // 这个画板也就是和屏幕大小一样大的图片
            // 我们可以通过Graphics这个类在这个空白图片上画图
            Graphics g = Graphics.FromImage(CatchBmp);

            // 把屏幕图片拷贝到我们创建的空白图片 CatchBmp中
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));

            // 创建截图窗体
            cutter = new frmCutter
            {

                // 指示窗体的背景图片为屏幕图片
                BackgroundImage = CatchBmp
            };
            // 显示窗体
            //cutter.Show();
            // 如果Cutter窗体结束，则从剪切板获得截取的图片，并显示在聊天窗体的发送框中
            if (cutter.ShowDialog() == DialogResult.OK)
            {
                IDataObject iData = Clipboard.GetDataObject();
                DataFormats.Format format = DataFormats.GetFormat(DataFormats.Bitmap);
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    Bitmap bitmap = cutter.bitmapCutter;
                    ImageToWords(bitmap);
                    // richTextBox1.Paste(format);

                    // 清楚剪贴板的图片
                    Clipboard.Clear();
                }
            }
        }

        void ImageToWords(Bitmap bitmap)
        {
           // Baidu.Com.Model.AccessTokenResponse accessTokenResponse = Baidu.Com.AI.AccessToken.GetAccessToken();
            byte[] imageBase64;
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Bmp);
                imageBase64 = ms.GetBuffer();
            }
            bitmap.Dispose();
            Baidu.Aip.Ocr.Ocr ocr = new Baidu.Aip.Ocr.Ocr(Baidu.Com.AI.AccessToken.ClientId, Baidu.Com.AI.AccessToken.ClientSecret);

            var jObject = ocr.General(imageBase64);
            Baidu.Com.Model.GeneralResponse generalResponse = jObject.ToObject<Baidu.Com.Model.GeneralResponse>();
            textBox1.Text = "";
            foreach (var item in generalResponse.words_result)
            {
                textBox1.Text += item.words;
            }

        }
    }
}
