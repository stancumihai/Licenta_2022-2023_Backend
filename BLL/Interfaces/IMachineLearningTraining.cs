namespace BLL.Interfaces
{
    public interface IMachineLearningTraining
    {
        void GenerateTrainingPredictedGenre(int year, int month);
        void GenerateTrainingPredictedMovieCount(int year, int month);
        void GenerateTrainingPredictedMovieRuntime(int year, int month);
        void GenerateTrainingPredictedAgesViewership(int year, int month);
        void GenerateTrainingPredictedMovies(int year, int month);
    }
}