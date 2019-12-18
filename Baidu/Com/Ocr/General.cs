using Baidu.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Com.Ocr
{
    public class General
    {
        public static string general_basic = $@"https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token={AI.AccessToken.TOKEN}";
        /// <summary>
        /// 通用文字识别
        /// </summary>
        /// <param name="generalRequest"></param>
        /// <returns></returns>
        public static Model.GeneralResponse GetGeneral(Model.GeneralRequest generalRequest)
        {
            string sRet = HttpHelper.Post(general_basic, generalRequest.ToJson());
            return sRet.ToObject<Model.GeneralResponse>();
        }
    }
}
