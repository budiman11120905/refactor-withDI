## before
public interface INotificationService
{
    void Send(string message);
}

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class NotificationController
{
    private readonly INotificationService _notificationService;

    public NotificationController()
    {
        // Direct instantiation (tight coupling)
        _notificationService = new EmailNotificationService();
    }

    public void Notify(string message)
    {
        _notificationService.Send(message);
    }
}


##after refactor
public interface INotificationService
{
    void Send(string message);
}

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class NotificationController
{
    private readonly INotificationService _notificationService;

    // Dependency Injection via constructor
    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void Notify(string message)
    {
        _notificationService.Send(message);
    }
}
