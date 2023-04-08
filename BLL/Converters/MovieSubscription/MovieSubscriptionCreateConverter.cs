﻿using Library.Models.MovieSubscription;

namespace BLL.Converters.MovieSubscription
{
    public class MovieSubscriptionCreateConverter
    {
        public static MovieSubscriptionCreate ToBLLModel(DAL.Models.MovieSubscription movieSubscriptionDALModel)
        {
            MovieSubscriptionCreate linkedMovieCreate = new()
            {
                MovieUid = movieSubscriptionDALModel.MovieGUID,
                UserUid = movieSubscriptionDALModel.UserGUID
            };

            return linkedMovieCreate;
        }

        public static DAL.Models.MovieSubscription ToDALModel(MovieSubscriptionCreate movieSubscriptionBLLModel)
        {
            DAL.Models.MovieSubscription movieSubscriptionEntity = new()
            {
                MovieGUID = movieSubscriptionBLLModel.MovieUid,
                UserGUID = movieSubscriptionBLLModel.UserUid
            };

            return movieSubscriptionEntity;
        }
    }
}