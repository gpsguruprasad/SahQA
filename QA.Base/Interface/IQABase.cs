namespace QA.Base.Interface
{
    public interface IQABase
    {
        int Index { get; set; }
        string SubjectInsensitive { get; set; }
        string Subject { get; }
        int Rank { get; set; }
        int Count { get; set; }
        IQABase Parent { get; set; }
    }
}
