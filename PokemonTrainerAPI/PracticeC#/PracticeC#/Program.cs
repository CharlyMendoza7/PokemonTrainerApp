
using PracticeC_.Consumers;
using PracticeC_.Implementations;
using PracticeC_.Services;

namespace PracticeC_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NotificationManager notif = new NotificationManager(new EmailNotificacionService(), new ConsoleLogger());

            notif.NotifyUser("carlos", "Hello my friend");

            notif.NotifyUser("david", "are  youi there");

        }

    }
}