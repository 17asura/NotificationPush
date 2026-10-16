namespace NotificationPush.Classes;

public class Email : Notificacao
{
    public Email(string id, string destinatario, string mensagem, string tipo) : base(id, destinatario, mensagem, tipo){}
    public override void Sendmessage(string destinatario, string mensagem, string tipo)
    {
        Console.WriteLine($"Destinatário:{destinatario}\n Mensagem:{mensagem}\n Tipo: {tipo}");
    }
}
