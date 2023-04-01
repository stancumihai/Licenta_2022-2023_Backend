using DAL.Models;
using ExcelDataReader;
using System.Text;

namespace BLL.Implementation.Mechanisms
{
    public class CSVReader
    {
        private readonly static string PERSON_DATA_PATH =
            "D:\\Munca\\Licenta\\backend\\Licenta_2022_Backend\\DAL\\Datasets\\original\\data1.xlsx";
        private readonly static string MOVIE_AND_RATING_INFORMATION_PATH =
        "D:\\Munca\\Licenta\\backend\\Licenta_2022_Backend\\DAL\\Datasets\\original\\Final2.xlsx";

        public static Tuple<List<Movie>, List<Library.Models.Excel.MovieRating>> GetMovieInformation()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(MOVIE_AND_RATING_INFORMATION_PATH, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            List<Movie> movies = new();
            List<Library.Models.Excel.MovieRating> ratingList = new();
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
                    Library.Models.Excel.MovieRating movieRating = new()
                    {
                        MovieRatingGUID = Guid.NewGuid(),
                        MovieId = reader.GetValue(0).ToString()!,
                        AverageRating = decimal.Parse(reader.GetValue(5).ToString()!),
                        VotesNumber = long.Parse(reader.GetValue(6).ToString()!)
                    };
                    movies.Add(movie);
                    ratingList.Add(movieRating);
                }
            } while (reader.NextResult());
            return Tuple.Create(movies, ratingList);
        }

        public static List<Library.Models.Excel.Person> GetPersons()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(PERSON_DATA_PATH, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            List<Library.Models.Excel.Person> persons = new();
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

                    Library.Models.Excel.Person person = new()
                    {
                        PersonGUID = Guid.NewGuid(),
                        PersonId = reader.GetValue(0).ToString()!,
                        Name = reader.GetValue(1).ToString()!,
                        YearOfBirth = int.Parse(reader.GetValue(2).ToString()!),
                        YearOfDeath = 0,
                        Professions = reader.GetValue(4).ToString()!,
                        Movies = HandleEnumeration(reader.GetValue(5).ToString()!)
                    };
                    if (reader.GetValue(3).ToString() != "\\N")
                    {
                        person.YearOfDeath = int.Parse(reader.GetValue(3).ToString()!);
                    }
                    persons.Add(person);
                }
            } while (reader.NextResult());

            return persons;
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