using Library.Models.SurveyAnswer;

namespace BLL.Converters.SurveyAnswer
{
    public class SurveyAnswerReadConverter
    {
        internal static SurveyAnswerRead ToBLLModel(DAL.Models.SurveyAnswer surveyAnswerDALModel)
        {
            if (surveyAnswerDALModel.Value == null)
            {
                surveyAnswerDALModel.Value = "";
            }

            if (surveyAnswerDALModel.SurveyUserAnswers == null)
            {
                surveyAnswerDALModel.SurveyUserAnswers = new List<DAL.Models.SurveyUserAnswer>();
            }

            SurveyAnswerRead surveyAnswerRead = new()
            {
                Uid = surveyAnswerDALModel.SurveyAnswerGUID,
                SurveyQuestionGUID = surveyAnswerDALModel.SurveyQuestionGUID,
                Value = surveyAnswerDALModel.Value,
                SurveyUserAnswers = new List<Library.Models.SurveyUserAnswerRead>()
            };

            return surveyAnswerRead;
        }

        internal static DAL.Models.SurveyAnswer ToDALModel(SurveyAnswerRead surveyAnswerBLLModel)
        {
            return new DAL.Models.SurveyAnswer
            {
                SurveyAnswerGUID = surveyAnswerBLLModel.Uid,
                SurveyQuestionGUID = surveyAnswerBLLModel.SurveyQuestionGUID,
                Value = surveyAnswerBLLModel.Value,
                SurveyUserAnswers = new List<DAL.Models.SurveyUserAnswer>()
            };
        }
    }
}