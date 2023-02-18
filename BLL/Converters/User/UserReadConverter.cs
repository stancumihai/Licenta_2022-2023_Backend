using BLL.Converters.SurveyAnswer;
using Library.Models.Users;

namespace BLL.Converters.User
{
    public class UserReadConverter
    {
        internal static UserRead ToBLLModel(DAL.Models.User userDALModel)
        {
            return new UserRead
            {
                Uid = userDALModel.UserGUID,
                Username = userDALModel.Username,
                Email = userDALModel.Email,
                Password = userDALModel.Password,
                Role = (Library.Enums.Roles)userDALModel.Role,
                SurveyAnswers = userDALModel.SurveyAnswers
                    .Select(surveyAnswer => SurveyAnswerReadConverter.ToBLLModel(surveyAnswer))
                    .ToList()
            };
        }

        internal static DAL.Models.User ToDALModel(UserRead userBLLModel)
        {
            return new DAL.Models.User
            {
                UserGUID = userBLLModel.Uid,
                Username = userBLLModel.Username,
                Email = userBLLModel.Email,
                Password = userBLLModel.Password,
                Role = (DAL.Enums.Roles)userBLLModel.Role,
                SurveyAnswers = userBLLModel.SurveyAnswers
                    .Select(surveyAnswer => SurveyAnswerReadConverter.ToDALModel(surveyAnswer))
                    .ToList()
            };
        }
    }
}