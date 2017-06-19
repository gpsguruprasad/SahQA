namespace QA.Base.Handlers
{
    public class InputRule
    {
        public int Paragraph { get; set; }
        public int QStart { get; set; }
        public int QEnd { get; set; }
        public int PossibleAnswer { get; set; }
        public int QCount => QEnd - QStart + 1;
    }
}
