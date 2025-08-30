using System.ComponentModel.DataAnnotations;

namespace MovieRatingsAnalyser.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } 
        public string Genre { get; set; }
        public int Rating { get; set; } // Rating out of 10
        public string Source { get; set; } // Source of the rating (e.g., IMDb, Rotten Tomatoes)
        public int Year { get; set; } // Release year
        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; } // Date of the review

    }
}
