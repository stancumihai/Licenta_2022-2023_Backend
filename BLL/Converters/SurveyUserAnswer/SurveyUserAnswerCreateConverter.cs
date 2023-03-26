using Library.Models.SurveyUserAnswer;

namespace BLL.Converters.SurveyUserAnswer
{
    public class SurveyUserAnswerCreateConverter
    {
        internal static SurveyUserAnswerCreate ToBLLModel(DAL.Models.SurveyUserAnswer surveyUserAnswerDALModel)
        {
            return new SurveyUserAnswerCreate
            {
                UserUid = Guid.Parse(surveyUserAnswerDALModel.UserGUID),
                SurveyAnswerUid = surveyUserAnswerDALModel.SurveyAnswerGUID,
                SurveyQuestionUid = surveyUserAnswerDALModel.SurveyQuestionGUID,
                Value = surveyUserAnswerDALModel.Value
            };
        }

        internal static DAL.Models.SurveyUserAnswer ToDALModel(SurveyUserAnswerCreate surveyUserAnswerBLLModel)
        {
            return new DAL.Models.SurveyUserAnswer
            {
                UserGUID = surveyUserAnswerBLLModel.UserUid.ToString(),
                SurveyAnswerGUID = surveyUserAnswerBLLModel.SurveyAnswerUid,
                SurveyQuestionGUID = surveyUserAnswerBLLModel.SurveyQuestionUid,
                Value = surveyUserAnswerBLLModel.Value
            };
        }
    }
}