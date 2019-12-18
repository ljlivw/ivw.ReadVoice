using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ivw.ReadVoice
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //仅做测试，请使用者自行申请，百度免费2000次一个月，不要使用此ID和Secret
            Baidu.Com.AI.AccessToken.ClientId = "hSIckGgXCiEiQplB7PezCMjh";
            Baidu.Com.AI.AccessToken.ClientSecret = "VYXEY2CTnmo2PklS78zpLm2GB01M839g";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
