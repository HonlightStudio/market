using CW10B.Consts;

namespace CW10B.Logger;

public class FileLogger : ILogger
{
    public void LogWarning(string message)
    {
        Log("Waring :: " +message);
    }

    public void Log(string message)
    {
        if (File.Exists(FilePath.LogPath))
        {
            File.AppendAllText(FilePath.LogPath, message + Environment.NewLine);
            return;
        }
        File.WriteAllText(FilePath.LogPath, message + Environment.NewLine);
        
    }

    public void LogError(string message)
    {
        Log("Error :: " +message);
    }
}