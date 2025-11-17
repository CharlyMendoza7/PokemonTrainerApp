using PracticeC_.Interfaces;

namespace PracticeC_.Consumers
{
    public class NotificationManager
    {
        private readonly INotificationService _notificationService;
        private readonly Interfaces.ILogger _logger;

        public NotificationManager(INotificationService notificationService, Interfaces.ILogger logger)
        {
            _notificationService = notificationService;
            _logger = logger;
        }

        public void NotifyUser(string to, string message)
        {
            _notificationService.Send(to, message);
            _logger.Log(message);
        }
    }
}
