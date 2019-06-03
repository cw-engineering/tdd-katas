using System;

namespace TddLinePosition
{
    public struct LinePosition : IEquatable<LinePosition>
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
            if (!string.IsNullOrEmpty(text))
            {
                var parsedText = text.Split(':');
                try
                {
                    int column = int.Parse(parsedText[1]);

                    int line = int.Parse(parsedText[0]);

                    if (line >= 0 && column >= 0)
                    {
                        x = new LinePosition(line, column);
                        return true;
                    }
                }
                catch (FormatException)
                {
                    x = default;
                    return false;
                }

            }
            x = default;
            return false;
        }

        public void Deconstruct(out int location, out int column)
        {
            column = Column;
            location = Line;
        }

        public bool Equals(LinePosition other)
        {
            return true;
        }
    }
}
