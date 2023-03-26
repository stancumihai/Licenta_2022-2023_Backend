using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class SurveyUserAnswer
    {
        [Key]
        public Guid SurveyUserAnswerGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("SurveyQuestion")]
        public Guid SurveyQuestionGUID { get; set; }
        public SurveyQuestion SurveyQuestion { get; set; }
        [ForeignKey("SurveyAnswer")]
        public Guid? SurveyAnswerGUID { get; set; }
        public SurveyAnswer? SurveyAnswer { get; set; }
        public string? Value { get; set; }
    }
}