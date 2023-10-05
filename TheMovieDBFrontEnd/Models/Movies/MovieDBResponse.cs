using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace TheMovieDBFrontEnd.Models.Movies.Response
{
    public partial class MovieDbResponse
    {
        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
    }

    public partial class Dates
    {
        [JsonProperty("maximum")]
        public DateTimeOffset Maximum { get; set; }

        [JsonProperty("minimum")]
        public DateTimeOffset Minimum { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        public List<long> GenreIds { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("original_language")]
        public String OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }
    }


    public partial class MovieDbResponse
    {
        public static MovieDbResponse FromJson(string json) => JsonConvert.DeserializeObject<MovieDbResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MovieDbResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
