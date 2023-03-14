using DAL.Models;
using ExcelDataReader;
using Library.Models.Excel;
using System.Text;

namespace BLL.Implementation.Mechanisms
{
    public class CSVReader
    {
        private readonly static string MOVIE_DATA_PATH =
            "D:\\Munca\\Licenta\\backend\\Licenta_2022_Backend\\DAL\\Datasets\\data3Dummy.xlsx";
        private readonly static string RATING_DATA_PATH =
            "D:\\Munca\\Licenta\\backend\\Licenta_2022_Backend\\DAL\\Datasets\\data5Dummy.xlsx";
        private readonly static string PERSON_DATA_PATH =
            "D:\\Munca\\Licenta\\backend\\Licenta_2022_Backend\\DAL\\Datasets\\data1Dummy.xlsx";

        public static List<Movie> GetMovies()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(MOVIE_DATA_PATH, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            List<Movie> movies = new();
            do
            {
                int index = 0;
                while (reader.Read())
                {
                    index++;
                    if (index == 1)
                    {
                        continue;
                    }
                    Movie movie = new()
                    {
                        MovieGUID = Guid.NewGuid(),
                        MovieId = reader.GetValue(0).ToString()!,
                        Title = reader.GetValue(1).ToString()!,
                        YearOfRelease = int.Parse(reader.GetValue(2).ToString()!),
                        Runtime = int.Parse(reader.GetValue(3).ToString()!),
                        Genres = reader.GetValue(4).ToString()!
                    };
                    movies.Add(movie);
                }
            } while (reader.NextResult());
            return movies;
        }
        public static void GetMovieRatings()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(RATING_DATA_PATH, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            do
            {
                int index = 0;
                while (reader.Read())
                {
                    index++;
                    if (index == 1)
                    {
                        continue;
                    }
                    Library.Models.Excel.MovieRating movieRating = new()
                    {
                        MovieRatingGUID = Guid.NewGuid(),
                        MovieId = reader.GetValue(0).ToString()!,
                        AverageRating = decimal.Parse(reader.GetValue(1).ToString()!),
                        VotesNumber = long.Parse(reader.GetValue(2).ToString()!)
                    };
                }
            } while (reader.NextResult());
        }
        public static void ReadPersons()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(PERSON_DATA_PATH, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            do
            {
                int index = 0;
                while (reader.Read())
                {
                    index++;
                    if (index == 1)
                    {
                        continue;
                    }
                    Person person = new()
                    {
                        PersonGUID = Guid.NewGuid(),
                        PersonId = reader.GetValue(0).ToString()!,
                        Name = reader.GetValue(1).ToString()!,
                        YearOfBirth = int.Parse(reader.GetValue(2).ToString()!),
                        YearOfDeath = int.Parse(reader.GetValue(3).ToString()!),
                        Profession = HandleEnumeration(reader.GetValue(5).ToString()!)[0],
                        Movies = HandleEnumeration(reader.GetValue(5).ToString()!)
                    };
                }
            } while (reader.NextResult());
        }
        private static List<string> HandleEnumeration(string enumeration)
        {
            if (!enumeration.Contains(','))
            {
                return new List<string>() { enumeration };
            }
            return enumeration.Split(',').ToList();
        }
    }
}