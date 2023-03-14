using BLL.Interfaces;
using BLL.Interfaces.Mechanisms;

namespace BLL.Core;
public class BusinessContext
{
    public IUsers? Users { get; set; }
    public ISurveyQuestions? SurveyQuestions { get; set; }
    public ISurveyAnswers? SurveyAnswers { get; set; }
    public ISurveyUserAnswers? SurveyUserAnswers { get; set; }

    public IAuthentication? Authentication { get; set; }

    public IEmailSender EmailSender { get; set; }

    public BusinessContext(ISurveyQuestions surveyQuestions,
                            ISurveyAnswers surveyAnswers,
                            IAuthentication? authentication,
                            IUsers? users,
                            IEmailSender emailSender,
                            ISurveyUserAnswers? surveyUserAnswers)
    {
        SurveyQuestions = surveyQuestions;
        SurveyAnswers = surveyAnswers;
        Authentication = authentication;
        Users = users;
        EmailSender = emailSender;
        SurveyUserAnswers = surveyUserAnswers;
    }
}