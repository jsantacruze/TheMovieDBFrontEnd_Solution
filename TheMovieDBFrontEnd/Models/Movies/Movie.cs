namespace TheMovieDBFrontEnd.Models.Movies
{
    public class Movie
    {
        public bool adult { get; set; }
        public String backdropPath { get; set; }
        public List<String> genreIds { get; set; }
        public long id { get; set; }
        public String originalLanguage { get; set; }
        public String originalTitle { get; set; }
        public String overview { get; set; }
        public double popularity { get; set; }
        public String posterPath { get; set; }
        public DateTimeOffset releaseDate { get; set; }
        public String title { get; set; }
        public bool video { get; set; }
        public double voteAverage { get; set; }
        public long voteCount { get; set; }

        public Movie(bool adult, string backdropPath,
            List<string> genreIds, long id, string originalLanguage, string originalTitle, string overview,
            double popularity, string posterPath, DateTimeOffset releaseDate, string title, bool video, double voteAverage, long voteCount)
        {
            this.adult = adult;
            this.backdropPath = backdropPath;
            this.genreIds = genreIds;
            this.id = id;
            this.originalLanguage = originalLanguage;
            this.originalTitle = originalTitle;
            this.overview = overview;
            this.popularity = popularity;
            this.posterPath = posterPath;
            this.releaseDate = releaseDate;
            this.title = title;
            this.video = video;
            this.voteAverage = voteAverage;
            this.voteCount = voteCount;
        }
    }
}
