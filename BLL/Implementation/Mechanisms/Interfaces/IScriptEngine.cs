namespace BLL.Implementation.Mechanisms.Interfaces
{
    public interface IScriptEngine
    {
        void CallScript(string scriptType, string filePath, string algorithmName, object[] dataArray);
    }
}