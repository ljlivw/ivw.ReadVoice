using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Configuration;

namespace ivw.ReadVoice
{
    public class VoiceHelper
    {
        private delegate void SpeakCompletedHandle();
        private static event SpeakCompletedHandle SpeakCompletedEvent;
        private static SpeechSynthesizer ss;
        public VoiceHelper()
        {
            ss = new SpeechSynthesizer();
        }
        /// <summary>
        /// 读文字已语音播放
        /// </summary>
        /// <param name="Rate">设置语音速度</param>
        /// <param name="SpeakText">需要读的文字</param>
        /// <param name="Volume">设置语音音量(默认是100)</param>
        public void ReadVoice(int Rate, string SpeakText, string VoiceName, int Volume = 100)
        {
            ss = new SpeechSynthesizer();
            ss.Rate = Rate;//设置语音速度
            ss.Volume = Volume;//设置语音音量
            ss.SelectVoice(VoiceName);
            ss.SpeakAsyncCancelAll();
            ss.SpeakAsync(SpeakText);
            ss.SpeakCompleted += ss_SpeakCompleted;
        }
        private static bool k = false;
        static void VoiceHelper_SpeakCompletedEvent()
        {
            k = true;
            SpeakCompletedEvent -= VoiceHelper_SpeakCompletedEvent;
            SpeakCompletedEvent = null;
        }

        static void ss_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            ss.Dispose();
            SpeakCompletedEvent += VoiceHelper_SpeakCompletedEvent;
            SpeakCompletedEvent();
        }

        public void SpeakClose()
        {
            if (k == false && ss != null)
            {
                k = true;
                ss.SpeakAsyncCancelAll();
            }
        }

        /// <summary>
        /// 读文字已语音播放(调Com组件)
        /// </summary>
        /// <param name="SpeakText">需要读的文字</param>
        public void ComReadVoice(string SpeakText)
        {
            Type type = Type.GetTypeFromProgID("SAPI.SpVoice");
            dynamic spVoice = Activator.CreateInstance(type);
            spVoice.Speak(SpeakText);
        }

        public List<InstalledVoice> GetVoices()
        {
            return ss.GetInstalledVoices().ToList();
        }
    }
}
