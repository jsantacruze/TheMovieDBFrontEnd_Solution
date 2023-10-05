using TheMovieDBFrontEnd.Models.Movies.DB;
using TheMovieDBFrontEnd.Models.Movies.Response;

namespace TheMovieDBFrontEnd.Models.Movies
{
    public class MovieMapper
    {
        public static Movie movieDBToEntity(MovieMovieDb moviedb)
        {
            return new Movie(moviedb.Adult,
            (moviedb.BackdropPath != "")
              ? "https://image.tmdb.org/t/p/w500" + moviedb.BackdropPath
              : "https://sd.keepcalms.com/i-w600/keep-calm-poster-not-found.jpg",
            moviedb.Genres.Select(g => g.Name).ToList(),
            moviedb.Id,
            moviedb.OriginalLanguage,
            moviedb.OriginalTitle,
            moviedb.Overview,
            moviedb.Popularity,
            (moviedb.PosterPath != "")
              ? "https://image.tmdb.org/t/p/w500" + moviedb.PosterPath
              : "https://www.movienewz.com/img/films/poster-holder.jpg",
            moviedb.ReleaseDate,
            moviedb.Title,
            moviedb.Video,
            moviedb.VoteAverage,
            moviedb.VoteCount
          );
        }

        public static Movie movieDBToEntity(Result moviedb)
        {
            return new Movie(moviedb.Adult,
            (moviedb.BackdropPath != "")
              ? "https://image.tmdb.org/t/p/w500" + moviedb.BackdropPath
              : "https://sd.keepcalms.com/i-w600/keep-calm-poster-not-found.jpg",
            moviedb.GenreIds.Select(g => g.ToString()).ToList(),
            moviedb.Id,
            moviedb.OriginalLanguage,
            moviedb.OriginalTitle,
            moviedb.Overview,
            moviedb.Popularity,
            (moviedb.PosterPath != "")
              ? "https://image.tmdb.org/t/p/w500" + moviedb.PosterPath
              : "https://www.movienewz.com/img/films/poster-holder.jpg",
            moviedb.ReleaseDate,
            moviedb.Title,
            moviedb.Video,
            moviedb.VoteAverage,
            moviedb.VoteCount
          );
        }
    }
}
