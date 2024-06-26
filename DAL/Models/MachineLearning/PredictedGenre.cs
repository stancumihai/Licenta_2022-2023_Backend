﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.MachineLearning
{
    public class PredictedGenre
    {
        [Key]
        public Guid PredictedGenreGUID { get; set; }
        [ForeignKey("User")]
        public string UserGUID { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Genre { get; set; }
    }
}