namespace MovieRatingsAnalyser.Services
{
    public interface IMovieService
    {
        List<Models.Movie> GetAllMovies();
        List<Models.Movie> GetTopRatedMovies(int count = 5);
        List<Models.Movie> GetWorstRatedMovies(int count);
        double GetAverageRating();
        int? GetTheBestYear();
        void AddMovie(Models.Movie movie);
        void UpdateMovie(Models.Movie movie);
        void DeleteMovie(int id);
    }
}
