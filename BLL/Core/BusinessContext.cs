using BLL.Interfaces;

namespace BLL.Core;
public class BusinessContext
{
    public IUsers Users { get; set; }
    public ISurveyQuestions SurveyQuestions { get; set; }
    public ISurveyAnswers SurveyAnswers { get; set; }

    public BusinessContext(IUsers users, ISurveyQuestions surveyQuestions, ISurveyAnswers surveyAnswers)
    {
        Users = users;
        SurveyQuestions = surveyQuestions;
        SurveyAnswers = surveyAnswers;
    }
}
