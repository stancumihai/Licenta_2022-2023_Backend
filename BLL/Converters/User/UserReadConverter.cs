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
                Email = userDALModel.Email,
                Password = userDALModel.Password,
                Role = (Library.Enums.Roles)userDALModel.Role,
                PasswordHash = userDALModel.PasswordHash,
                PasswordSalt = userDALModel.PasswordSalt,
                RefreshToken = userDALModel.RefreshToken,
                TokenCreated = userDALModel.TokenCreated,
                TokenExpires = userDALModel.TokenExpires,
                //SurveyAnswers = userDALModel.SurveyAnswers
                //    .Select(surveyAnswer => SurveyAnswerReadConverter.ToBLLModel(surveyAnswer))
                //    .ToList()
            };
        }

        internal static DAL.Models.User ToDALModel(UserRead userBLLModel)
        {
            return new DAL.Models.User
            {
                UserGUID = userBLLModel.Uid,
                Email = userBLLModel.Email,
                Password = userBLLModel.Password,
                Role = (DAL.Enums.Roles)userBLLModel.Role,
                PasswordSalt = userBLLModel.PasswordSalt,
                RefreshToken = userBLLModel.RefreshToken,
                TokenCreated = userBLLModel.TokenCreated,
                TokenExpires = userBLLModel.TokenExpires,
                //SurveyAnswers = userBLLModel.SurveyAnswers
                //    .Select(surveyAnswer => SurveyAnswerReadConverter.ToDALModel(surveyAnswer))
                //    .ToList()
            };
        }
    }
}