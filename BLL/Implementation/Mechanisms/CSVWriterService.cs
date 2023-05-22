using BLL.Implementation.Mechanisms.Interfaces;
using CsvHelper;
using System.Globalization;

namespace BLL.Implementation.Mechanisms
{
    public class CSVWriterService : ICSVWriterService
    {
        public string FileName { get; set; }
        public CSVWriterService(string fileName)
        {
            FileName = fileName;
        }

        public void WriteCSV<T>(List<T> records)
        {
            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }
    }
}