using System;
using System.Collections.Generic;

namespace tdd.headers
{
    public class Headers
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();        
        public string this[string field]
        {
            get
            {
                return _headers.ContainsKey(field.ToLower())
                    ? _headers[field.ToLower()]
                    : null;
            }
            set
            {
                if (field == null)
                {
                    throw new ArgumentNullException();
                }
                _headers[field.ToLower()] = value;
            }
        }

        public int Count { get => _headers.Count; }

        public void Add(string v1, string v2)
        {
            this[v1] = v2;
        }
    }
}
