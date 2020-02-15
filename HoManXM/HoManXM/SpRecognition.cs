using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
namespace HoManXM
{
    class SpRecognition
    {
        private SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();
        /// <summary>
        //  语音转文本
        /// </summary>
        /// <param name="str"></param>
        private void VoiceToText(object str)
        {
            try
            {
                string filepath = str.ToString(); ;
                SRE.SetInputToWaveFile(filepath);         //<=======默认的语音输入设备，你可以设定为去识别一个WAV文件。
                GrammarBuilder GB = new GrammarBuilder();
                //需要判断的文本（相当于语音库）
                GB.Append(new Choices(new string[] { "时间", "电话", "短信", "定位", "天气", "帮助" }));
                Grammar G = new Grammar(GB);
                G.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(G_SpeechRecognized);
                SRE.LoadGrammar(G);
                SRE.RecognizeAsync(RecognizeMode.Multiple); //<=======异步调用识别引擎，允许多次识别（否则程序只响应你的一句话）
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }


        /// <summary>
        /// 判断语音并转化为需要输出的文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void G_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            string RetSpeck = string.Empty;
            switch (result)
            {
                case "时间":
                    RetSpeck = "你输入了时间";
                    break;
                case "电话":
                    RetSpeck = "你输入了电话";
                    break;
                case "短信":
                    RetSpeck = "你输入了短信";
                    break;
                case "定位":
                    RetSpeck = "你输入了定位";
                    break;
                case "天气":
                    RetSpeck = "你输入了天气";
                    break;
                case "帮助":
                    RetSpeck = "你输入了帮助";
                    break;
            }
            //speak(RetSpeck);
            System.Windows.Forms.MessageBox.Show(RetSpeck);
        }
    }
}
