using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Com.Model
{
    public class GeneralResponse
    {
        /// <summary>
        /// 图像方向，当detect_direction=true时存在。
        ///- -1:未定义，
        ///- 0:正向，
        ///- 1: 逆时针90度，
        ///- 2:逆时针180度，
        ///- 3:逆时针270度
        /// </summary>
        public int direction { get; set; }
        /// <summary>
        /// 唯一的log id，用于问题定位
        /// </summary>
        public ulong log_id { get; set; }
        /// <summary>
        /// 识别结果数组
        /// </summary>
        public List<words_result> words_result { get; set; }
        /// <summary>
        /// 识别结果数，表示words_result的元素个数
        /// </summary>
        public uint words_result_num { get; set; }
        /// <summary>
        /// 识别结果中每一行的置信度值，包含average：行置信度平均值，variance：行置信度方差，min：行置信度最小值
        /// </summary>
        public object probability { get; set; }
    }
    public class words_result
    {
        /// <summary>
        /// 识别结果字符串
        /// </summary>
        public string words { get; set; }
    }
}
