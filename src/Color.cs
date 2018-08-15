using System;

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
            string red = Red.ToString("X");
            if (red.Length == 1)
                red = "0" + red;
            string green = Green.ToString("X");
            if (green.Length == 1)
                green = "0" + green;
            string blue = Blue.ToString("X");
            if (blue.Length == 1)
                blue = "0" + blue;
            return red + green + blue;
        }
    }
}
