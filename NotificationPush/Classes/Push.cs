namespace NotificationPush.Classes;

//public static async Task EnviarNotificacaoAsync(string topico, string mensagem, string titulo = "Notificação")
public class Push : Notificacao
{
    private string Titulo;

    public Push(string titulo, string mensagem, string tipo) : base(mensagem, tipo)
    {
        Titulo = titulo;
    }

    public override async void Sendmessage(string titulo, string mensagem, string tipo)
    {
        Console.WriteLine($"Titulo: {titulo}\n Mensagem:{mensagem}\n Tipo: {tipo}");
    }
}