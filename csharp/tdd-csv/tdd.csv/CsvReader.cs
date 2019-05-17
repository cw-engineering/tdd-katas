using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tdd.csv
{
    public class CsvReader
    {
        TextReader textReader;
        private int index = 0;
        private string[] textArray;
        public CsvReader(TextReader textReader)
        {
            this.textReader = textReader ?? throw new ArgumentNullException();
            string text = textReader.ReadToEnd();
            textArray = text.Split(new[] { "\n" }, StringSplitOptions.None);
        }

        public string[] ReadNext()
        {

            if (index >= textArray.Length)
            {
                return null;
            }

            var text = textArray[index].Replace("\"", "");
            var val = text.Split(new[] {","}, StringSplitOptions.None); //new [] { text };
            index++;
            return val;
        }
    }
}
