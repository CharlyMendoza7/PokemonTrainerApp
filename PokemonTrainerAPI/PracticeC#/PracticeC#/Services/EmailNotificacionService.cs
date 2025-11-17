using PracticeC_.Interfaces;

namespace PracticeC_.Services
{
    public class EmailNotificacionService : INotificationService
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending Email to {to}: {message}");
        }
    }
}
