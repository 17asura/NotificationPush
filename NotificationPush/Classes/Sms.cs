namespace NotificationPush.Classes;

public class Sms : Notificacao
{
    private string Smsstr;

    public Sms(string smsstr, string mensagem, string tipo) : base(mensagem, tipo)
    {
        Smsstr = smsstr;
    }
    public override void Sendmessage(string destinatario, string mensagem, string tipo)
    {
        Console.WriteLine($"Destinatário:{destinatario}\n Mensagem:{mensagem}\n Tipo: {tipo}");
    }
}