using MediatR;

namespace MediatorR.Notification
{
    public class UserRegisteredNotification : INotification
    {
        public string UserName { get; set; }
    }
}
