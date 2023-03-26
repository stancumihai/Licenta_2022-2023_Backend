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
                SurveyAnswerUid = surveyUserAnswerDALModel.SurveyAnswerGUID,
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
                SurveyAnswerGUID = surveyUserAnswerBLLModel.SurveyAnswerUid,
                SurveyQuestionGUID = surveyUserAnswerBLLModel.SurveyQuestionUid,
                UserGUID = surveyUserAnswerBLLModel.UserUid.ToString(),
                Value = surveyUserAnswerBLLModel.Value
            };
        }
    }
}