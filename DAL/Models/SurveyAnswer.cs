using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class SurveyAnswer
    {
        [Key]
        public Guid SurveyAnswerGUID { get; set; }
        [ForeignKey("SurveyQuestion")]
        public Guid SurveyQuestionGUID { get; set; }
        public SurveyQuestion SurveyQuestion { get; set; }
        public ICollection<User> Users { get; set; }
        public string Value { get; set; }
    }
}