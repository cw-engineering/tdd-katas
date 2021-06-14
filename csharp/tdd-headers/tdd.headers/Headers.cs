using System;

namespace Tdd
{
    public class Headers : IHeaders
    {
        public string this[string field]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Count => throw new NotImplementedException();

        public void Add(string field, string value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string field)
        {
            throw new NotImplementedException();
        }
    }
}
