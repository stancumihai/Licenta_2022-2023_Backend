using BLL.Converters.SurveyUserAnswer;
using DAL.Models;
using Library.Models.Users;

namespace BLL.Converters.User
{
    public class UserReadConverter
    {
        internal static UserRead ToBLLModel(ApplicationUser userDALModel)
        {
            return new UserRead
            {
                Uid = new Guid(userDALModel.Id),
                Email = userDALModel.Email,
                Password = userDALModel.Password,
                RefreshToken = userDALModel.RefreshToken,
                RefreshTokenExpiryTime = userDALModel.RefreshTokenExpiryTime,
                SurveyUserAnswers = userDALModel.SurveyUserAnswers!
                    .Select(surveyUserAnswer => SurveyUserAnswerReadConverter.ToBLLModel(surveyUserAnswer))
                    .ToList()
            };
        }

        internal static ApplicationUser ToDALModel(UserRead userBLLModel)
        {
            return new ApplicationUser
            {
                Id = userBLLModel.Uid.ToString(),
                Email = userBLLModel.Email,
                Password = userBLLModel.Password,
                RefreshToken = userBLLModel.RefreshToken,
                RefreshTokenExpiryTime = userBLLModel.RefreshTokenExpiryTime,
                SurveyUserAnswers = userBLLModel.SurveyUserAnswers!
                    .Select(surveyUserAnswer => SurveyUserAnswerReadConverter.ToDALModel(surveyUserAnswer))
                    .ToList()
            };
        }
    }
}