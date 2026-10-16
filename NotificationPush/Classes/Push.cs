namespace NotificationPush.Classes;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//public static async Task EnviarNotificacaoAsync(string topico, string mensagem, string titulo = "Notificação")
public class Push : Notificacao
{
    private string Titulo;
    private string Topico;
    private static readonly HttpClient client = new HttpClient();
    public Push(string titulo, string topico, string mensagem, string tipo) : base(mensagem, tipo)
    {
        Titulo = titulo;
        Topico = topico;
    }
    public override async void Sendmessage(string titulo, string topico, string mensagem, string tipo)
    {
        Console.WriteLine($"Titulo: {titulo}\n Mensagem:{mensagem}\n Tipo: {tipo}");
    

    
    {
        // URL do ntfy com o seu tópico personalizado (ex: https://ntfy.sh/meu_topico_secreto_123)
        string url = $"https://ntfy.sh/{topico}";

        // Criar o conteúdo do pedido POST
        // O corpo do pedido é a própria mensagem que vai aparecer na notificação
        HttpContent content = new StringContent(mensagem, Encoding.UTF8);

        // Opcional: Adicionar cabeçalhos para configurar título e prioridade
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Add("Title", titulo);
        client.DefaultRequestHeaders.Add("Priority", "default"); // min, low, default, high, urgent

        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Notificação enviada com sucesso via ntfy.sh!");
            }
            else
            {
                Console.WriteLine($"Erro ao enviar notificação: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro de rede: {ex.Message}");
        }
    }
    }
}
