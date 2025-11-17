using PracticeC_.Interfaces;

namespace PracticeC_.Services
{
    public class SmsNotificationService : INotificationService
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Sending SMS to {to}: {message}");
        }
    }
}
