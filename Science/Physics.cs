using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W3b.Sine;

namespace Science
{
    class Physics
    {
        public static BigNumDec ParseNum(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string trimmed = input.Replace(" ", "").ToLower();
            string exponented = input.Replace("x10^-", "E-").Replace("x10^", "E");
            BigNum output;
            if (!BigNum.TryParse(exponented, out output))
            {
                output = 0;
                Achievement.Trigger("Trash Collector");
            }
            return (BigNumDec)output;
        }

        public static double ParseDouble(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            string trimmed = input.Replace(" ", "").ToLower();
            string exponented = input.Replace("x10^-", "E-").Replace("x10^", "E");
            double output;          
            if (!double.TryParse(exponented, out output))
            {
                output = 0;
                Achievement.Trigger("Trash Collector");
            }
            return output;
        }

        public static Settings AppSettings { get; set; }
    }
}
