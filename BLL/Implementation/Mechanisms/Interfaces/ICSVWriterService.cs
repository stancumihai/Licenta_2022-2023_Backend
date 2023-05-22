namespace BLL.Implementation.Mechanisms.Interfaces
{
    public interface ICSVWriterService
    {
        void WriteCSV<T>(List<T> records);
    }
}