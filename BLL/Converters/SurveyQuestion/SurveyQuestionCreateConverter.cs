namespace BLL.Converters.SurveyQuestion
{
    public class SurveyQuestionCreateConverter
    {
        internal static Library.Models.SurveyQuestion.SurveyQuestionCreate ToBLLModel(DAL.Models.SurveyQuestion surveyQuestionDALModel)
        {
            return new Library.Models.SurveyQuestion.SurveyQuestionCreate
            {
                Value = surveyQuestionDALModel.Value,
                Category = (Library.Enums.SurveyQuestionCategory)surveyQuestionDALModel.Category
            };
        }
        internal static DAL.Models.SurveyQuestion ToDALModel(Library.Models.SurveyQuestion.SurveyQuestionCreate surveyQuestionBLLModel)
        {
            return new DAL.Models.SurveyQuestion
            {
                Value = surveyQuestionBLLModel.Value,
                Category = (DAL.Enums.SurveyQuestionCategory)surveyQuestionBLLModel.Category
            };
        }
    }
}