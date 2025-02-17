public interface IEmailNotificacion 
{
    void SendEmail(string email, string mensaje);
}

public interface ISMSNotificacion 
{
    void SendSMS(string telefono, string mensaje);
}

public interface IPushNotificacion 
{
    void SendNotificationPush(string token, string mensaje);
}


public class Notificaciones : IEmailNotificacion, ISMSNotificacion, IPushNotificacion
{

    public void SendEmail(string email, string mensaje)
    {
        Console.WriteLine($"Enviando email a {email}: {mensaje}");
    }

    public void SendSMS(string telefono, string mensaje)
    {
        Console.WriteLine($"Enviando SMS a {telefono}: {mensaje}");
    }

    public void SendNotificationPush(string token, string mensaje)
    {
        Console.WriteLine($"Enviando push a {token}: {mensaje}");
    }
}

public interface INotificationService
{
    void SendNotification(string tipo, string destino, string mensaje);
}

public class NotificationService : INotificationService
{
    private readonly IEmailNotification _email;
    private readonly ISMSNotification _sms;
    private readonly IPushNotificacion _push;

    public NotificationService(
        IEmailNotification email,
        ISMSNotification sms,
        IPushNotification push)
    {
        _email = email;
        _sms = sms;
        _push = push;
    }

    public void SendNotification(string tipo, string destino, string mensaje)
    {
        switch(tipo.ToLower())
        {
            case "email":
                _email.SendEmail(destino, mensaje);
                break;
            case "sms":
                _sms.SendSMS(destino, mensaje);
                break;
            case "push":
                _push.SendNotificationPush(destino, mensaje);
                break;
            default:
                throw new ArgumentException("Tipo de notificación no válido");
        }
    }
}



