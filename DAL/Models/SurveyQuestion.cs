using DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class SurveyQuestion
    {
        [Key]
        public Guid SurveyQuestionGUID { get; set; }
        public string? Value { get; set; }
        public List<SurveyAnswer>? SurveyAnswers { get; set; }
        public SurveyQuestionCategory Category { get; set; }

        public override string ToString()
        {
            return "SurveyQuestionGUID :" + SurveyQuestionGUID +
                " Value: " + Value + "Category: " + Category.ToString();
        }
    }
}