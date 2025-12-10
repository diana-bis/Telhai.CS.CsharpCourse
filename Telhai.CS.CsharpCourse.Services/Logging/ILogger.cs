namespace Telhai.CS.CsharpCourse.Services.Logging
{
    public interface ILogger
    {
        static abstract void Log(string message);
        static abstract void Log(string message, LogLevel level);
    }
}