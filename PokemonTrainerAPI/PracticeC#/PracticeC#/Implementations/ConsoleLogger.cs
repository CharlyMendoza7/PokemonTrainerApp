namespace PracticeC_.Implementations
{
    public class ConsoleLogger : Interfaces.ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}
