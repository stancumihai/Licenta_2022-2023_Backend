using System.Diagnostics;

namespace BLL.Implementation.Mechanisms
{
    public class ScriptEngine
    {
        public static readonly string INTERPRETER_PATH = "D:\\Munca\\Licenta\\machineLearning\\newvenv\\Scripts\\python.exe";
        public static readonly string BASE_SCRIPT_PATH = "D:\\Munca\\Licenta\\machineLearning\\";

        public static string GetPredictedData(string dataType, string fileExtension, string algorithmName)
        {
            string scriptPath = BASE_SCRIPT_PATH + dataType + "\\" + fileExtension + ".py";
            var processStartInfo = new ProcessStartInfo
            {
                FileName = INTERPRETER_PATH,
                Arguments = $"\"{scriptPath}\" \"{algorithmName}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            using var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();
            int exitCode = process.ExitCode;
            return output;
        }

        public static void TrainToPredictModel(string dataType, string fileExtension, string algorithmName)
        {
            string scriptPath = BASE_SCRIPT_PATH + dataType;
            var processStartInfo = new ProcessStartInfo
            {
                FileName = INTERPRETER_PATH,
                Arguments = $"\"{scriptPath}\" \"{fileExtension}\" \"{algorithmName}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            using var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();
            int exitCode = process.ExitCode;
        }
    }
}