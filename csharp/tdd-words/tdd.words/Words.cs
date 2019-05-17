using System;
using System.Linq;
using System.Text;

namespace tdd.words
{
    public static class Words
    {
        private const string AllowedChars = "0123456789abcdefghijklmnopqrstuvwxyz";
        public static int Count(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return 0;
            }


            sentence = sentence.ToLowerInvariant();
            sentence = new string(sentence.Select(c => AllowedChars.Contains(c) ? c : ' ').ToArray());

            var words = sentence.Trim().Split(" \r\n\t\0".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return words.Distinct().Count();
        }
    }
}
