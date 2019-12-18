using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Com.AI
{
    public class AccessToken
    {
        // 调用getAccessToken()获取的 access_token建议根据expires_in 时间 设置缓存
        // 返回token示例
        public static String TOKEN = string.Empty;
        // 百度云中开通对应服务应用的 API Key 建议开通应用的时候多选服务
        public static String ClientId = string.Empty;
        // 百度云中开通对应服务应用的 Secret Key
        public static String ClientSecret = string.Empty;
        /// <summary>
        /// 获取Access Token
        /// </summary>
        /// <returns></returns>
        public static Model.AccessTokenResponse GetAccessToken()
        {
            String sUri = $@"https://aip.baidubce.com/oauth/2.0/token?grant_type=client_credentials&client_id={ClientId}&client_secret={ClientSecret}";
            Model.AccessTokenResponse accessTokenResponse= JsonConvert.DeserializeObject<Model.AccessTokenResponse>(Helper.HttpHelper.Post(sUri));
            TOKEN = accessTokenResponse.access_token;
            return accessTokenResponse;
        }
    }
}
