using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacySpyPlus.Readers
{
    static public class MD_Genesis
    {
        const int PACKET_SIZE = 32;

        static readonly string[] BUTTONS = {
            "a", "b", "c", "x", "y", "z", "start", "up", "down", "left", "right"
        };

        static float readStick (byte input) {
            return (float)((sbyte)input) / 128;
        }

        static public ControllerState ReadFromPacket (byte[] packet)
        {
            if (packet.Length < PACKET_SIZE) return null;

            var state = new ControllerStateBuilder ();

            for (int i = 0 ; i < BUTTONS.Length ; ++i) {
                if (string.IsNullOrEmpty (BUTTONS [i])) continue;
                state.SetButton (BUTTONS[i], packet[i] != 0x00);
            }

            return state.Build ();
        }
    }
}
