namespace Library.Comparer
{
    public class SurveyQuestionComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return x!.CompareTo(y);
        }
    }
}