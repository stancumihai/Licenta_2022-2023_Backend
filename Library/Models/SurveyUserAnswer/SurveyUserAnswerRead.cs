namespace Library.Models
{
    public class SurveyUserAnswerRead
    {
        public Guid Uid { get; set; }
        public Guid UserUid { get; set; }
        public Guid? SurveyAnswerUid { get; set; }
        public Guid SurveyQuestionUid { get; set; }
        public string? Value { get; set; }
    }
}