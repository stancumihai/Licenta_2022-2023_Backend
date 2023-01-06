namespace DAL.Interfaces
{
    public interface IDALContext
    {
        IUsers Users { get; }
        ISurveyAnswers SurveyAnswers { get; }
        ISurveyQuestions SurveyQuestions { get; }
    }
}