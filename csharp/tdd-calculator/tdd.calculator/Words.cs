using System;
using System.Linq;


namespace tdd.calculator
{
    public static class Words
    {
        public static int Count(string sentence)
        {
            if (sentence == null || sentence.Trim() == "") return 0;

            return sentence.Trim()
                .Split(' ', '\r', '\n', '\t')
                .Select(word => word.ToUpperInvariant().TrimEnd('.', ',', '-').Trim())
                .Where(word => word != "")
                .Distinct()
                .Count();
        }
    }
}
