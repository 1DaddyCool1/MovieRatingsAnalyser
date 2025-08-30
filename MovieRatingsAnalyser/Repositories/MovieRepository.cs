using MovieRatingsAnalyser.Models;
using System.Text.Json;

namespace MovieRatingsAnalyser.Repositories
{
    public class MovieRepository
    {
        private readonly string _filePath;
        public MovieRepository(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(env.ContentRootPath, "AppData", "movie.json");

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<Movie> LoadMovies()
        {
            try
            {
                if (!File.Exists(_filePath)) return new List<Movie>();

                var jsonData = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(jsonData)) return new List<Movie>();

                return JsonSerializer.Deserialize<List<Movie>>(jsonData) ?? new List<Movie>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Error parsing JSON data from movie.json.");
                return new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error loading movies: {ex.Message}");
                return new List<Movie>();
            }
        }

        public void SaveMovies(List<Movie> movies)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving movies to file: {ex.Message}");

            }
        }
    }
}
