using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DuckyVisual
{
    class DuckyInterface
    {
        private HIDDevice Device;
        private KeyArea keyArea00;
        private KeyArea keyArea02;
        private KeyArea keyArea04;
        private KeyArea keyArea06;
        private KeyArea keyArea08;
        private KeyArea keyArea0A;
        private KeyArea keyArea0C;
        private KeyArea keyArea0D;
        private List<KeyArea> listKeyArea = new List<KeyArea>();

        private const string OPEN_PAYLOAD = "ressources\\open_extract.txt";
        private const string CM1_PAYLOAD = "ressources\\cm1_extract.txt";
        private const string CLOSE_PAYLOAD = "ressources\\close_extract.txt";

        public DuckyInterface(HIDDevice device)
        {
            Device = device;
            PopulateKeyMaps();
            SendPayload(OPEN_PAYLOAD);
            Thread.Sleep(4000);
            SendPayload(CM1_PAYLOAD);

        }

        public void ColorKey(string key, Color color)
        {
            key = "\"" + key + "\"";
            foreach(KeyArea ka in listKeyArea)
            {
                ka.ColorKey(key, color);
            }
        }

        public void ColorAllKeys(Color color)
        {
            foreach (KeyArea ka in listKeyArea)
            {
                ka.ColorAllKeys(color);
            }
        }

        public void UpdateColors()
        {
            foreach (KeyArea ka in listKeyArea)
            {
                Device.write(Util.StringToByteArrayFastest(ka.GetHexDataProp()));
            }
        }

        public void SendClosePayload()
        {
            SendPayload(CLOSE_PAYLOAD);
        }

        private void SendPayload(string payload)
        {
            string[] readText = File.ReadAllLines(payload);
            foreach (string s in readText)
            {
                string hex = s;
                hex = hex.Replace(" ", "");
                Device.write(Util.StringToByteArrayFastest(hex));
            }
        }
        
        private void PopulateKeyMaps()
        {
            Color color = new Color(0, 0, 0);
            Dictionary<string, Color> keyMap00 = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap02 = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap04 = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap06 = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap08 = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap0A = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap0C = new Dictionary<string, Color>();
            Dictionary<string, Color> keyMap0D = new Dictionary<string, Color>();

            keyMap00.Add("\"²\"", color);
            keyMap00.Add("\"1\"", color);
            keyMap00.Add("\"TAB\"", color);
            keyMap00.Add("\"Q\"", color);
            keyMap00.Add("\"A\"", color);
            keyMap00.Add("\"SHIFT\"", color);
            keyMap00.Add("\"Z\"", color);
            keyMap00.Add("\"2\"", color);
            keyMap00.Add("\"3\"", color);
            keyMap00.Add("\"W\"", color);
            keyMap00.Add("\"E\"", color);
            keyMap00.Add("\"S\"", color);
            keyMap00.Add("\"D\"", color);
            keyMap00.Add("\"X\"", color);
            keyMap00.Add("\"C\"", color);
            keyMap02.Add("\"4\"", color);
            keyMap02.Add("\"5\"", color);
            keyMap02.Add("\"R\"", color);
            keyMap02.Add("\"T\"", color);
            keyMap02.Add("\"F\"", color);
            keyMap02.Add("\"G\"", color);
            keyMap02.Add("\"V\"", color);
            keyMap02.Add("\"B\"", color);
            keyMap02.Add("\"6\"", color);
            keyMap02.Add("\"7\"", color);
            keyMap02.Add("\"Y\"", color);
            keyMap02.Add("\"U\"", color);
            keyMap02.Add("\"H\"", color);
            keyMap02.Add("\"J\"", color);
            keyMap02.Add("\"N\"", color);
            keyMap02.Add("\"?\"", color);
            keyMap04.Add("\"8\"", color);
            keyMap04.Add("\"9\"", color);
            keyMap04.Add("\"I\"", color);
            keyMap04.Add("\"O\"", color);
            keyMap04.Add("\"K\"", color);
            keyMap04.Add("\"L\"", color);
            keyMap04.Add("\";\"", color);
            keyMap04.Add("\":\"", color);
            keyMap04.Add("\"0\"", color);
            keyMap04.Add("\")\"", color);
            keyMap04.Add("\"P\"", color);
            keyMap04.Add("\"^\"", color);
            keyMap04.Add("\"M\"", color);
            keyMap04.Add("\"ù\"", color);
            keyMap04.Add("\"!\"", color);
            keyMap04.Add("\"RSHIFT\"", color);
            keyMap06.Add("\"=\"", color);
            keyMap06.Add("\"RETURN\"", color);
            keyMap06.Add("\"$\"", color);
            keyMap06.Add("\"*\"", color);
            keyMap06.Add("\"ENTER\"", color);
            keyMap06.Add("\"RCTRL\"", color);
            keyMap06.Add("\"INSERT\"", color);
            keyMap06.Add("\"ORIGIN\"", color);
            keyMap06.Add("\"SUPR\"", color);
            keyMap06.Add("\"FIN\"", color);
            keyMap06.Add("\"FN\"", color);
            keyMap06.Add("\"UP\"", color);
            keyMap06.Add("\"DOWN\"", color);
            keyMap06.Add("\"LEFT\"", color);
            keyMap08.Add("\"PGPR\"", color);
            keyMap08.Add("\"PGSV\"", color);
            keyMap08.Add("\"F10\"", color);
            keyMap08.Add("\"F11\"", color);
            keyMap08.Add("\"F12\"", color);
            keyMap08.Add("\"RIGHT\"", color);
            keyMap08.Add("\"N0\"", color);
            keyMap08.Add("\"NUM\"", color);
            keyMap08.Add("\"N/\"", color);
            keyMap08.Add("\"N7\"", color);
            keyMap08.Add("\"N8\"", color);
            keyMap08.Add("\"N4\"", color);
            keyMap08.Add("\"N5\"", color);
            keyMap08.Add("\"N1\"", color);
            keyMap08.Add("\"N2\"", color);
            keyMap0A.Add("\"N*\"", color);
            keyMap0A.Add("\"N-\"", color);
            keyMap0A.Add("\"N9\"", color);
            keyMap0A.Add("\"N+\"", color);
            keyMap0A.Add("\"N6\"", color);
            keyMap0A.Add("\"NENTER\"", color);
            keyMap0A.Add("\"N3\"", color);
            keyMap0A.Add("\"N.\"", color);
            keyMap0A.Add("\"LWINDOWS\"", color);
            keyMap0A.Add("\"LCTRL\"", color);
            keyMap0A.Add("\"LALT\"", color);
            keyMap0A.Add("\"SPACEBAR\"", color);
            keyMap0A.Add("\"RALT\"", color);
            keyMap0A.Add("\"RWINDOWS\"", color);
            keyMap0C.Add("\"ECHAP\"", color);
            keyMap0C.Add("\"F1\"", color);
            keyMap0C.Add("\"F2\"", color);
            keyMap0C.Add("\"F3\"", color);
            keyMap0C.Add("\"PRTSC\"", color);
            keyMap0C.Add("\"SCRLK\"", color);
            keyMap0C.Add("\"F4\"", color);
            keyMap0C.Add("\"F5\"", color);
            keyMap0C.Add("\"F6\"", color);
            keyMap0C.Add("\"PAUSE\"", color);
            keyMap0C.Add("\"VOLUMEPLUS\"", color);
            keyMap0C.Add("\"VOLUMEMINUS\"", color);
            keyMap0C.Add("\"CAL\"", color);
            keyMap0C.Add("\"MUTE\"", color);
            keyMap0D.Add("\"F4\"", color);
            keyMap0D.Add("\"F5\"", color);
            keyMap0D.Add("\"F6\"", color);
            keyMap0D.Add("\"PAUSE\"", color);
            keyMap0D.Add("\"VOLUMEPLUS\"", color);
            keyMap0D.Add("\"VOLUMEMINUS\"", color);
            keyMap0D.Add("\"CAL\"", color);
            keyMap0D.Add("\"MUTE\"", color);
            keyMap0D.Add("\"F7\"", color);
            keyMap0D.Add("\"F8\"", color);
            keyMap0D.Add("\"F9\"", color);

            //Each one represents 16 keys, changed later into the rgb hexadecimal representation of the color we want
            String s00 = "51 A8 00 00 \"²\" \"1\" \"TAB\" \"Q\" 00 00 00 \"A\" \"SHIFT\" \"Z\" \"2\" \"3\" \"W\" \"E\" \"S\" \"D\" \"X\" \"C\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s02 = "51 A8 02 00 \"4\" \"5\" \"R\" \"T\" \"F\" \"G\" \"V\" \"B\" \"6\" \"7\" \"Y\" \"U\" \"H\" \"J\" \"N\" \"?\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s04 = "51 A8 04 00 \"8\" \"9\" \"I\" \"O\" \"K\" \"L\" \";\" \":\" \"0\" \")\" \"P\" \"^\" \"M\" \"ù\" \"!\" \"RSHIFT\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s06 = "51 A8 06 00 \"=\" \"RETURN\" \"$\" \"*\" \"ENTER\" 00 00 00 \"RCTRL\" 00 00 00 \"INSERT\" \"ORIGIN\" \"SUPR\" \"FIN\" \"FN\" \"UP\" \"DOWN\" \"LEFT\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s08 = "51 A8 08 00 \"PGPR\" 00 00 00 \"PGSV\" \"F10\" \"F11\" \"F12\" \"RIGHT\" \"N0\" \"NUM\" \"N/\" \"N7\" \"N8\" \"N4\" \"N5\" \"N1\" \"N2\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s0A = "51 A8 0A 00 \"N*\" \"N-\" \"N9\" \"N+\" \"N6\" \"NENTER\" \"N3\" \"N.\" 00 00 00 00 00 00 \"LWINDOWS\" \"LCTRL\" \"LALT\" \"SPACEBAR\" \"RALT\" \"RWINDOWS\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s0C = "51 A8 0C 00 \"ECHAP\" \"F1\" \"F2\" \"F3\" 00 00 00 00 00 00 \"PRTSC\" \"SCRLK\" \"F4\" \"F5\" \"F6\" \"PAUSE\" \"VOLUMEPLUS\" \"VOLUMEMINUS\" \"CAL\" \"MUTE\" 00 00 00 00 00 00 00 00 00 00 00 00";
            String s0D = "51 A8 0D 00 \"F4\" \"F5\" \"F6\" \"PAUSE\" \"VOLUMEPLUS\" \"VOLUMEMINUS\" \"CAL\" \"MUTE\" \"F7\" \"F8\" \"F9\" 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";


            keyArea00 = new KeyArea(keyMap00, s00);
            keyArea02 = new KeyArea(keyMap02, s02);
            keyArea04 = new KeyArea(keyMap04, s04);
            keyArea06 = new KeyArea(keyMap06, s06);
            keyArea08 = new KeyArea(keyMap08, s08);
            keyArea0A = new KeyArea(keyMap0A, s0A);
            keyArea0C = new KeyArea(keyMap0C, s0C);
            keyArea0D = new KeyArea(keyMap0D, s0D);

            listKeyArea.Add(keyArea00);
            listKeyArea.Add(keyArea02);
            listKeyArea.Add(keyArea04);
            listKeyArea.Add(keyArea06);
            listKeyArea.Add(keyArea08);
            listKeyArea.Add(keyArea0A);
            listKeyArea.Add(keyArea0D);
            listKeyArea.Add(keyArea0C);
        }
    }
}
