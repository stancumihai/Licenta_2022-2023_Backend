using Library.Models.Users;

namespace Library.Models.SurveyAnswer
{
    public class SurveyAnswerRead
    {
        public Guid Uid { get; set; }
        public Guid SurveyQuestionGUID { get; set; }
        public ICollection<UserRead> Users { get; set; }
        public string Value { get; set; }
    }
}