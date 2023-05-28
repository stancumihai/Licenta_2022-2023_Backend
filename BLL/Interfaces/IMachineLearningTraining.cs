﻿namespace BLL.Interfaces
{
    public interface IMachineLearningTraining
    {
        void GenerateTrainingPredictedGenre();
        void GenerateTrainingPredictedMovieCount();
        void GenerateTrainingPredictedMovieRuntime();
        void GenerateTrainingPredictedAgesViewership();
        void GenerateTrainingPredictedMovies();
    }
}