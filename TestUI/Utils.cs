using System;

namespace TestUI
{
    public class Utils
    {
        public static int convertCtF(int C)
        {
            return (int) Math.Round((C * 1.8) + 32);
        }

        public static int convertFtC(int F)
        {
            return (int) Math.Round((F - 32) * 0.555);
        }

        public static int getIntFromString(string data)
        {
            return Convert.ToInt16(data.Trim(new char[] {'°', 'C', 'F'}));
        }
    }
}