namespace BLL.Implementation.Mechanisms.Interfaces
{
    public interface ICSVHandlerService
    {
        void WriteCSV<T>(List<T> records);
        void UpdateCsvFile(List<string> newData, string newColumnName);
        void RemoveLastColumn();
        List<List<string>> ReadCsvFile();
        void AppendRowsToCsv(string filePath, List<List<string>> newRows);
    }
}