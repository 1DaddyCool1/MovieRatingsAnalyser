using MovieRatingsAnalyser.Models;
using MovieRatingsAnalyser.Repositories;

namespace MovieRatingsAnalyser.Services
{
    public class MovieServiceImpl : IMovieService
    {
        private readonly MovieRepository _movieRepository;
        public MovieServiceImpl(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies() => _movieRepository.LoadMovies();

        public List<Movie> GetTopRatedMovies(int count)
        {
            var movies = _movieRepository.LoadMovies();
            return movies.OrderByDescending(m => m.Rating).Take(count).ToList();
        }

        public List<Movie> GetWorstRatedMovies(int count)
        {
            var movies = _movieRepository.LoadMovies();
            return movies.OrderBy(m => m.Rating).Take(count).ToList();
        }

        public double GetAverageRating()
        {
            var movies = _movieRepository.LoadMovies();
            if (movies.Count == 0) return 0.0;
            return movies.Average(m => m.Rating);
        }

        public int? GetTheBestYear()
        {
            var movies = _movieRepository.LoadMovies();
            if (movies.Count == 0) return null;
            return movies
                .GroupBy(m => m.Year)
                .Select(g => new { Year = g.Key, AverageRating = g.Average(m => m.Rating) })
                .OrderByDescending(y => y.AverageRating)
                .First().Year;
        }

        public void AddMovie(Movie movie)
        {
            var movies = _movieRepository.LoadMovies();

            Movie newMovie = new Movie
            {
                // Assign a new Id
                Id = movies.Any() ? movies.Max(m => m.Id) + 1 : 1,
                Title = movie.Title,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Source = movie.Source,
                Year = movie.Year,
                ReviewDate = movie.ReviewDate
            };
            movies.Add(newMovie);
            _movieRepository.SaveMovies(movies);
        }

        public void DeleteMovie(int id)
        {
            var movies = _movieRepository.LoadMovies();
            // Find the movie by Id
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
                _movieRepository.SaveMovies(movies);
            }
        }

        public void UpdateMovie(Movie movie)
        {
            var movies = _movieRepository.LoadMovies();
            // Find the movie by Id
            var existingMovie = movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                existingMovie.Rating = movie.Rating;
                existingMovie.Source = movie.Source;
                existingMovie.Year = movie.Year;
                existingMovie.ReviewDate = movie.ReviewDate;
                _movieRepository.SaveMovies(movies);
            }
            else
            {
                throw new Exception("Movie not found");
            }
        }
    }
}

