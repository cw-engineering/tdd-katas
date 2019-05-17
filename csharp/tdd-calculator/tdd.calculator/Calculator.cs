using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace tdd.calculator
{
    public static class Calculator
    {
        public static int Add(string input)
        {
            var listNumbers = 0;
            bool delimiterFound = false;
            if (input != null)
            {
                var endOfFirstLine = 0;
                var delimiters = ",";
                if (input.StartsWith("#"))
                {
                    delimiterFound = true;
                    string[] lin = input.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
                    endOfFirstLine =lin[0].Length - 1;
                    delimiters = input.Substring(1, endOfFirstLine);
                }
                string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for(var i=0;i<lines.Length;i++)
                {
                    if (i == 0 && delimiterFound)
                    {
                        continue;
                    }

                    var strings = lines[i].Split(new[] {delimiters}, StringSplitOptions.None);
                    foreach (var s in strings)
                    {
                        int.TryParse(s, out int temp);
                        listNumbers += temp;
                    }
                }
            }

            return listNumbers;
        }
    }
}
