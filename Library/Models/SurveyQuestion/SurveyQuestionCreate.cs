using Library.Enums;

namespace Library.Models.SurveyQuestion
{
    public class SurveyQuestionCreate
    {
        public string? Value { get; set; }
        public SurveyQuestionCategory Category { get; set; }
    }
}