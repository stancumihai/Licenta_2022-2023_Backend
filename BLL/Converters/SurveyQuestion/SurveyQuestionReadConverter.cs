namespace BLL.Converters.SurveyQuestion
{
    public class SurveyQuestionReadConverter
    {
        internal static Library.Models.SurveyQuestion.SurveyQuestionRead ToBLLModel(DAL.Models.SurveyQuestion surveyQuestionDALModel)
        {
            return new Library.Models.SurveyQuestion.SurveyQuestionRead
            {
                Uid = surveyQuestionDALModel.SurveyQuestionGUID,
                Value = surveyQuestionDALModel.Value
            };
        }
        internal static DAL.Models.SurveyQuestion ToDALModel(Library.Models.SurveyQuestion.SurveyQuestionRead surveyQuestionBLLModel)
        {
            return new DAL.Models.SurveyQuestion
            {
                SurveyQuestionGUID = surveyQuestionBLLModel.Uid,
                Value = surveyQuestionBLLModel.Value
            };
        }
    }
}