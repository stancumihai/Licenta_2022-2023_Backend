namespace BLL.Converters.SurveyAnswer
{
    public class SurveyAnswerCreateConverter
    {
        internal static Library.Models.SurveyAnswer.SurveyAnswerCreate ToBLLModel(DAL.Models.SurveyAnswer surveyAnswerDALModel)
        {
            return new Library.Models.SurveyAnswer.SurveyAnswerCreate
            {
                SurveyQuestionUid = surveyAnswerDALModel.SurveyQuestionGUID,
                Value = surveyAnswerDALModel.Value
            };
        }

        internal static DAL.Models.SurveyAnswer ToDALModel(Library.Models.SurveyAnswer.SurveyAnswerCreate surveyAnswerBLLModel)
        {
            return new DAL.Models.SurveyAnswer
            {
                SurveyQuestionGUID = surveyAnswerBLLModel.SurveyQuestionUid,
                Value = surveyAnswerBLLModel.Value,
            };
        }
    }
}