using BLL.Converters.SurveyAnswer;

namespace BLL.Converters.SurveyQuestion
{
    public class SurveyQuestionReadConverter
    {
        internal static Library.Models.SurveyQuestion.SurveyQuestionRead ToBLLModel(DAL.Models.SurveyQuestion surveyQuestionDALModel)
        {
            return new Library.Models.SurveyQuestion.SurveyQuestionRead
            {
                Uid = surveyQuestionDALModel.SurveyQuestionGUID,
                Value = surveyQuestionDALModel.Value,
                Category = (Library.Enums.SurveyQuestionCategory)surveyQuestionDALModel.Category,
                SurveyAnswers = surveyQuestionDALModel.SurveyAnswers
                    .Select(sa => SurveyAnswerReadConverter.ToBLLModel(sa)).ToList(),
            };
        }
        internal static DAL.Models.SurveyQuestion ToDALModel(Library.Models.SurveyQuestion.SurveyQuestionRead surveyQuestionBLLModel)
        {
            return new DAL.Models.SurveyQuestion
            {
                SurveyQuestionGUID = surveyQuestionBLLModel.Uid,
                Value = surveyQuestionBLLModel.Value,
                Category = (DAL.Enums.SurveyQuestionCategory)surveyQuestionBLLModel.Category,
                SurveyAnswers = surveyQuestionBLLModel.SurveyAnswers
                    .Select(sa => SurveyAnswerReadConverter.ToDALModel(sa)).ToList(),
            };
        }
    }
}