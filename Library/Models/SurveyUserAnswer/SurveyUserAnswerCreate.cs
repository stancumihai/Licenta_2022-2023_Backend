namespace Library.Models.SurveyUserAnswer
{
    public class SurveyUserAnswerCreate
    {   
        public Guid? SurveyAnswerUid { get; set; }
        public Guid SurveyQuestionUid { get; set; }
        public Guid UserUid { get; set; }
        public string? Value { get; set; }
    }
}