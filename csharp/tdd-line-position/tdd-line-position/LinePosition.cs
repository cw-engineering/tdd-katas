using System;

namespace TddLinePosition
{
    public struct LinePosition
    {

        public int Line { get; }

        public int Column { get; }

        public LinePosition(int line, int column)
        {
            if (line <= 0 || column <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Column = column;
            Line = line;
        }

        override public string ToString() => $"{Line}:{Column}";

        public static bool TryParse(string text, out LinePosition x)
        {
            if (text != null) {
                var parsedText = text.Split(':');
                int line = int.Parse(parsedText[0]);
                int column = int.Parse(parsedText[1]);
                x = new LinePosition(line, column);
                return true;
            }
            x = default;
            return false;
        }
    }
}
