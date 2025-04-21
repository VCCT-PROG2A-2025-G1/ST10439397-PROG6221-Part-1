using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ST10439397_PROG6221_Part_1
{
    internal class VoiceGreeting
    {
        public static void Greeting()
        {

            SoundPlayer player = new SoundPlayer("Greeting.wav");
            player.Play();

        }
    }
}
//-----------------------------------------0000EndOfFile0000------------------------------------------