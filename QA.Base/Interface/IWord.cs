namespace QA.Base.Interface
{
    public interface IWord : IQABase, IVisitorAction
    {
        string Tag { get; set; }
    }
}
