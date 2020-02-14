using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
namespace HoManXM
{
    class VoiceHelper
    {

        public static System.Speech.Synthesis.SpeechSynthesizer synth;

        public static void SpeakAsync(string content)
          {
            Dispose();
            synth = new System.Speech.Synthesis.SpeechSynthesizer();
            synth.SpeakAsyncCancelAll();
           synth.SpeakAsync(content);//异步朗读
        }

        public static void Dispose()
        {
            if (synth != null)
            {
                synth.Dispose();
            }


        }
         }

}
