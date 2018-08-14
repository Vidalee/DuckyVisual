using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckyVisual
{
    class Color
    {
        private readonly int Red;
        private readonly int Green;
        private readonly int Blue;

        public Color(int red, int green, int blue)
        {
            if (red < 0 || red > 255 || green < 0 || green > 255 || blue < 0 || blue > 255)
                throw new Exception();
            Red = red;
            Green = green;
            Blue = blue;
        }

        public string GetHexString()
        {
            return Red.ToString("X") + Green.ToString("X") + Blue.ToString("X");
        }
    }
}
