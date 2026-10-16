namespace NotificationPush.Classes;

public abstract class Notificacao
{
    protected string Mensagem { get; set; } // criar método depois
    protected string Tipo { get; set; }

    protected Notificacao(string mensagem, string tipo)
    {
        Mensagem = mensagem;
        Tipo =  tipo;
    }
    
    public abstract void Sendmessage(string destinatario, string mensagem, string tipo);
    
}