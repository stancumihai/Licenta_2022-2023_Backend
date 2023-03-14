namespace Library.Models.SurveyAnswer
{
    public class SurveyAnswerRead
    {
        public Guid Uid { get; set; }
        public Guid SurveyQuestionGUID { get; set; }
        public List<SurveyUserAnswerRead>? SurveyUserAnswers { get; set; }
        public string? Value { get; set; }
    }
}