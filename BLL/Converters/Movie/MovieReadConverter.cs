﻿using Library.Models.Movie;

namespace BLL.Converters.Movie
{
    public class MovieReadConverter
    {
        public static MovieRead ToBLLModel(DAL.Models.Movie movieDALModel)
        {
            MovieRead movieRead = new()
            {
                Uid = movieDALModel.MovieGUID,
                MovieId = movieDALModel.MovieId,
                Title = movieDALModel.Title,
                YearOfRelease = movieDALModel.YearOfRelease,
                Runtime = movieDALModel.Runtime,
                Genres = movieDALModel.Genres
            };

            return movieRead;
        }

        public static DAL.Models.Movie ToDALModel(MovieRead movieBLLModel)
        {
            DAL.Models.Movie movieEntity = new()
            {
                MovieGUID = movieBLLModel.Uid,
                MovieId = movieBLLModel.MovieId,
                Title = movieBLLModel.Title,
                YearOfRelease = movieBLLModel.YearOfRelease,
                Runtime = movieBLLModel.Runtime,
                Genres = movieBLLModel.Genres
            };

            return movieEntity;
        }
    }
}