using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Com.Model
{
    public class GeneralRequest
    {
        /// <summary>
        /// 和url二选一
        /// 图像数据，base64编码后进行urlencode，要求base64编码和urlencode后大小不超过4M，最短边至少15px，最长边最大4096px,支持jpg/png/bmp格式，当image字段存在时url字段失效
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 和image二选一
        /// 图片完整URL，URL长度不超过1024字节，URL对应的图片base64编码后大小不超过4M，最短边至少15px，最长边最大4096px,支持jpg/png/bmp格式，当image字段存在时url字段失效，不支持https的图片链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 识别语言类型，默认为CHN_ENG。可选值包括：
        ///- CHN_ENG：中英文混合；
        ///- ENG：英文；
        ///- POR：葡萄牙语；
        ///- FRE：法语；
        ///- GER：德语；
        ///- ITA：意大利语；
        ///- SPA：西班牙语；
        ///- RUS：俄语；
        ///- JAP：日语；
        ///- KOR：韩语
        /// </summary>
        public string language_type { get; set; }
        /// <summary>
        /// 是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:
        ///- true：检测朝向；
        ///- false：不检测朝向。
        /// </summary>
        public string detect_direction { get; set; }
        /// <summary>
        /// 是否检测语言，默认不检测。当前支持（中文、英语、日语、韩语）
        ///- true：检测；
        ///- false：不检测。
        /// </summary>
        public string detect_language { get; set; }
        /// <summary>
        /// 是否返回识别结果中每一行的置信度
        /// true、false
        /// </summary>
        public string probability { get; set; }
        /// <summary>
        /// -1:未知、0:英文、1:日文、2:韩文、3:中文【当detect_language=true时存在】
        /// </summary>
        public int language { get; set; }
    }
}
