using BLL.Converters.SurveyAnswer;
using Library.Models;

namespace BLL.Converters.SurveyUserAnswer
{
    public class SurveyUserAnswerReadConverter
    {
        internal static SurveyUserAnswerRead ToBLLModel(DAL.Models.SurveyUserAnswer surveyUserAnswerDALModel)
        {
            return new SurveyUserAnswerRead
            {
                Uid = surveyUserAnswerDALModel.SurveyUserAnswerGUID,
                SurveyQuestionUid = surveyUserAnswerDALModel.SurveyQuestionGUID,
                UserUid = Guid.Parse(surveyUserAnswerDALModel.UserGUID),
                Value = surveyUserAnswerDALModel.Value
            };
        }

        internal static DAL.Models.SurveyUserAnswer ToDALModel(SurveyUserAnswerRead surveyUserAnswerBLLModel)
        {
            return new DAL.Models.SurveyUserAnswer
            {
                SurveyUserAnswerGUID = surveyUserAnswerBLLModel.Uid,
                SurveyQuestionGUID = surveyUserAnswerBLLModel.SurveyQuestionUid,
                UserGUID = surveyUserAnswerBLLModel.UserUid.ToString(),
                Value = surveyUserAnswerBLLModel.Value
            };
        }
    }
}