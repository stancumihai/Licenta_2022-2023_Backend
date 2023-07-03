using Library.Models._UI;
using Library.Models.Movie;
using Library.Models.MovieSubscription;
using Library.Models.SeenMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class MoviesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public async Task<IActionResult> GetAll()
        {
            //BusinessContext.MachineLearningTraining.GenerateTrainingPredictedMovies(2023, 7);
            //BusinessContext.MachineLearningTraining.GenerateTrainingPredictedAgesViewership();
            //List<Library.MachineLearningModels.PredictedGenre> predictedGenres = await BusinessContext.PredictedGenres.GetLastMonthData();
            //ICSVWriterService writer = new CSVWriterService("test_genres_predicted.csv");
            //writer.WriteCSV(predictedGenres);

            //BusinessContext.MachineLearningTraining.GenerateTrainingPredictedMovieCount();
            //List<Library.MachineLearningModels.PredictedMovieCount> predictedMovieCounts = await BusinessContext.PredictedMoviesCount.GetLastMonthData();
            //ICSVWriterService writer = new CSVWriterService("test_movies_count_predicted.csv");
            //writer.WriteCSV(predictedMovieCounts);

            //BusinessContext.MachineLearningTraining.GenerateTrainingPredictedMovieRuntime();
            //List<Library.MachineLearningModels.PredictedMovieRuntime> predictedMovieRuntimes = await BusinessContext.PredictedMoviesRuntime.GetLastMonthData();
            //ICSVWriterService writer = new CSVWriterService("test_movies_runtimes_predicted.csv");
            //writer.WriteCSV(predictedMovieRuntimes);
            return Ok(BusinessContext.Movies!.GetAll());
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetPaginatedMovies([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetPaginatedMovies(pageNumber, pageSize));
        }

        [HttpGet("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetByUid([FromRoute] Guid uid)
        {
            return Ok(BusinessContext.Movies!.GetByUid(uid));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Add([FromBody] MovieCreate movie)
        {
            return Ok(BusinessContext.Movies!.Add(movie));
        }

        [HttpGet("person/{personUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetAllByPersonUid([FromRoute] Guid personUid)
        {
            return Ok(BusinessContext.Movies!.GetAllByPersonUid(personUid));
        }

        [HttpGet("genres/{genre}/{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieRead>))]
        public IActionResult GetMoviesByGenre([FromRoute] string genre, [FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetMoviesByGenrePaginated(genre, pageNumber, pageSize));
        }

        [HttpGet("genres")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
        public IActionResult GetMovieGenres()
        {
            return Ok(BusinessContext.Movies!.GetMovieGenres());
        }

        [HttpGet("history/{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieRead>>))]
        [Authorize]
        public IActionResult GetMoviesHistoryPaginated([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetMoviesHistoryPaginated(pageNumber, pageSize));
        }

        [HttpGet("subscription/{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieRead>>))]
        [Authorize]
        public IActionResult GetMoviesSubscriptionPaginated([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetMoviesSubscriptionPaginated(pageNumber, pageSize));
        }


        [HttpGet("collection/{pageNumber}/{pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieRead>>))]
        [Authorize]
        public IActionResult GetMoviesCollectionPaginated([FromRoute] int pageNumber, [FromRoute] int pageSize)
        {
            return Ok(BusinessContext.Movies!.GetMoviesCollectionPaginated(pageNumber, pageSize));
        }

        [HttpGet("history")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<SeenMovieRead>>))]
        [Authorize]
        public IActionResult GetMoviesHistory()
        {
            return Ok(BusinessContext.Movies!.GetMoviesHistory());
        }

        [HttpGet("subscription")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieSubscriptionRead>>))]
        [Authorize]
        public IActionResult GetMoviesSubscription()
        {
            return Ok(BusinessContext.Movies!.GetMoviesSubscription());
        }

        [HttpGet("collection")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieRead>>))]
        [Authorize]
        public IActionResult GetMoviesCollection()
        {
            return Ok(BusinessContext.Movies!.GetMoviesCollection());
        }

        [HttpGet("collection/{userUid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieRead>>))]
        [Authorize]
        public IActionResult GetAllMoviesCollectionByUser(string userUid)
        {
            return Ok(BusinessContext.Movies!.GetAllMoviesCollectionByUser(userUid));
        }

        [HttpGet("topGenres")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<string>>))]
        public IActionResult GetTopLikedGenres()
        {
            return Ok(BusinessContext.Movies.GetTopLikedGenres());
        }

        [HttpPost("advancedSearch")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List<MovieRead>>))]
        public IActionResult GetAdvancedSearchResult([FromBody] SearchModel searchModel)
        {
            return Ok(BusinessContext.Movies.GetAdvancedSearchMovies(searchModel));
        }
    }
}