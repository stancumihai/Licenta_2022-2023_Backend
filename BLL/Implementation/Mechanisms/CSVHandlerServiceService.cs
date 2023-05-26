using BLL.Implementation.Mechanisms.Interfaces;
using CsvHelper;
using System.Globalization;

namespace BLL.Implementation.Mechanisms
{
    public class CSVHandlerServiceService : ICSVHandlerService
    {
        public string FileName { get; set; }
        public CSVHandlerServiceService(string fileName)
        {
            FileName = fileName;
        }
        public void AppendRowsToCsv(string filePath, List<List<string>> newRows)
        {
            using var writer = new StreamWriter(filePath, true);
            foreach (var row in newRows)
            {
                writer.WriteLine(string.Join(",", row));
            }
        }

        public void RemoveLastColumn()
        {
            List<List<string>> rows = ReadCsvFile();
            foreach (var row in rows)
            {
                row.RemoveAt(row.Count - 1);
            }
            WriteCsvFile(FileName, rows);
        }

        public void UpdateCsvFile(List<string> newData, string newColumnName)
        {
            List<List<string>> rows = ReadCsvFile();
            rows[0].Add(newColumnName);
            for (int i = 1; i < rows.Count; i++)
            {
                rows[i].Add(newData[i - 1]);
            }
            WriteCsvFile(FileName, rows);
        }

        public void WriteCSV<T>(List<T> records)
        {
            using var writer = new StreamWriter(FileName);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }

        public List<List<string>> ReadCsvFile()
        {
            List<List<string>> rows = new();

            using (var reader = new StreamReader(FileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine()!;
                    List<string> row = new(line.Split(','));
                    rows.Add(row);
                }
            }

            return rows;
        }

        private static void WriteCsvFile(string filePath, List<List<string>> rows)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var row in rows)
            {
                writer.WriteLine(string.Join(",", row));
            }
        }
    }
}