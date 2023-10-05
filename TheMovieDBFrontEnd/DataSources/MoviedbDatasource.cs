namespace TheMovieDBFrontEnd.DataSources
{
    using RestSharp;
    using TheMovieDBFrontEnd.Models.Movies.Response;
    using TheMovieDBFrontEnd.Models.Movies;
    using TheMovieDBFrontEnd.Models.Movies.DB;

    public class MoviedbDatasource
    {
        private readonly RestClient _client;
        public MoviedbDatasource()
        {
            _client = new RestClient("https://api.themoviedb.org/3");
            _client.AddDefaultQueryParameter("Accept", "application/json");
            _client.AddDefaultQueryParameter("api_key", "6b9e52712002426b0a3a17ff6a9707d5");
            _client.AddDefaultQueryParameter("language", "es-MX");
        }
        private List<Movie> jsonToMovies(string json)
        {
            MovieDbResponse movieDBResponse = MovieDbResponse.FromJson(json);

            List<Movie> movies = movieDBResponse.Results
            .Where(m => m.PosterPath != "no-poster").ToList()
            .Select(m => MovieMapper.movieDBToEntity(m)).ToList();

            return movies;

        }

        public async Task<List<Movie>> getNowPlaying()
        {
            var request = new RestRequest("/movie/now_playing", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ErrorMessage);
            }
            return jsonToMovies(response.Content!);
        }


        public async Task<List<Movie>> getUpcoming()
        {
            var request = new RestRequest("/movie/upcoming", Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ErrorMessage);
            }
            return jsonToMovies(response.Content!);
        }

        public async Task<Movie> getMovieDeail(long id)
        {
            var request = new RestRequest("/movie/" + id.ToString(), Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.ErrorMessage);
            }
            var movieDB = MovieMovieDb.FromJson(response.Content!);
            Movie result = MovieMapper.movieDBToEntity(movieDB);
            return result;
        }

    }
}
