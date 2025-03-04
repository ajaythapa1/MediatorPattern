using MediatR;

namespace MediatorR.Notification
{
    public class UserRegisteredNotificationHandler : INotificationHandler<UserRegisteredNotification>
    {
        public Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            //logic to handle user registration notification
            Console.WriteLine($"User '{notification.UserName}' has been registered.");
            return Task.CompletedTask;
        }
    }
}
