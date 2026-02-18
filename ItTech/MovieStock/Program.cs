public class Program
{
    public List<Movie> _movies = new List<Movie>();
    public void AddMovie(string movieDetails)
    {
        var input = movieDetails.Split(',');
        Movie movie1 = new Movie()
        {
            Title = input[0].Trim(),
            Artist = input[1].Trim(),
            Genre = input[2].Trim(),
            Ratings = int.Parse(input[3].Trim())
        };
        _movies.Add(movie1);
        Console.WriteLine("movie added to the list");
    }
    public List<Movie> ViewMoviesByGenre(string genre)
    {
        return _movies.Where(k=> k.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public List<Movie> ViewMoviesByRatings()
    {
        return _movies.OrderByDescending(k=>k.Ratings).ToList();
    }
    public static void Main(string[] args)
    {
        Program program = new Program();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Enter movie details (Title, Artist, Genre, Rating):");
            program.AddMovie(Console.ReadLine());
        }
        Console.WriteLine("\nEnter Genre to search:");
        string searchGenre = Console.ReadLine();
        var genreResults = program.ViewMoviesByGenre(searchGenre);
       
       if (!genreResults.Any())
        {
            Console.WriteLine("No movies found in that genre.");
        }
        else
        {
            foreach (var item in genreResults)
            {
                Console.WriteLine($"Title: {item.Title} | Rating: {item.Ratings}");
            }
        }


        Console.WriteLine("\n--- Movies Sorted by Rating ---");
        foreach (var item in program.ViewMoviesByRatings())
        {
            Console.WriteLine($"{item.Ratings}/10 - {item.Title}");
        }
    
    }
}