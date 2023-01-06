namespace BLL.Converters.SurveyAnswer
{
    public class SurveyAnswerReadConverter
    {
        internal static Library.Models.SurveyAnswer.SurveyAnswerRead ToBLLModel(DAL.Models.SurveyAnswer surveyAnswerDALModel)
        {
            return new Library.Models.SurveyAnswer.SurveyAnswerRead
            {
                Uid = surveyAnswerDALModel.SurveyAnswerGUID,
                SurveyQuestionGUID = surveyAnswerDALModel.SurveyQuestionGUID,
                Value = surveyAnswerDALModel.Value
            };
        }

        internal static DAL.Models.SurveyAnswer ToDALModel(Library.Models.SurveyAnswer.SurveyAnswerRead surveyAnswerBLLModel)
        {
            return new DAL.Models.SurveyAnswer
            {
                SurveyAnswerGUID = surveyAnswerBLLModel.Uid,
                SurveyQuestionGUID = surveyAnswerBLLModel.SurveyQuestionGUID,
                Value = surveyAnswerBLLModel.Value
            };
        }
    }
}