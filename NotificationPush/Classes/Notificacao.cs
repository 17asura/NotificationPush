namespace NotificationPush.Classes;

public abstract class Notificacao
{
    protected string Id { get; private set; }
    protected string Destinatario { get; set; }
    protected string Mensagem { get; set; } // criar método depois
    protected string Tipo { get; set; }

    protected Notificacao(string id, string destinatario, string mensagem, string tipo)
    {
        Id = id;
        Destinatario = destinatario;
        Mensagem = mensagem;
        Tipo =  tipo;
    }
    
    public abstract void Sendmessage(string destinatario, string mensagem, string tipo);
    
}