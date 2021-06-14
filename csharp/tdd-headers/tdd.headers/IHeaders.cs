namespace Tdd
{
    public interface IHeaders
    {
        string this[string field] { get; set; }

        int Count { get; }

        void Add(string field, string value);

        void Remove(string field);
    }
}
