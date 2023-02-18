namespace Library.Models.SurveyAnswer
{
    public class SurveyAnswerCreate
    {
        public Guid? SurveyQuestionGUID { get; set; }
        public string? Value { get; set; }
    }
}
