using Library.Enums;
using Library.Models.SurveyAnswer;

namespace Library.Models.SurveyQuestion
{
    public class SurveyQuestionRead
    {
        public Guid Uid { get; set; }
        public string? Value { get; set; }
        public List<SurveyAnswerRead>? SurveyAnswers { get; set; }
        public SurveyQuestionCategory? Category { get; set; }
    }
}