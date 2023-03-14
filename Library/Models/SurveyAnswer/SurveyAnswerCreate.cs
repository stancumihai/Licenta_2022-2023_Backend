namespace Library.Models.SurveyAnswer
{
    public class SurveyAnswerCreate
    {
        public Guid SurveyQuestionUid { get; set; }
        public string? Value { get; set; }
    }
}