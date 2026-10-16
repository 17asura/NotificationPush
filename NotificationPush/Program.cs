using NotificationPush.Classes;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

List<Notificacao> notList = new List<Notificacao>();
Notificacao nova = null;
while (true)
{
    Console.WriteLine("\n=== Gestor de Notificações ===");
    Console.WriteLine("Bem vindo");
    Console.WriteLine("[1] Criar Nova Notificação");
    Console.WriteLine("[2] Exit");
    Console.Write("Escolha: ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.WriteLine("Escolha Uma Opção:\n");
        Console.WriteLine("[1] E-Mail");
        Console.WriteLine("[2] SMS");
        Console.WriteLine("[3] Push");
        int choice2 = int.Parse(Console.ReadLine());
        if (choice2 == 1)
        {
            Console.WriteLine("Email: ");
            string dest = Console.ReadLine();
            
            bool IsValidEmail(string email)
            {
                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith(".")) {
                    return false;
                }
                try {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == trimmedEmail;
                }
                catch {
                    return false;
                }
            }

            if (IsValidEmail(dest))
            {
                Console.WriteLine("Mensagem: ");
                string mensagem = Console.ReadLine();
                string tipo = "EMAIL";
                nova = new Email(dest, mensagem, tipo);
                if (nova != null)
                {
                    Console.WriteLine($"Notificação do tipo {tipo} criada com sucesso!\n");
                    nova.Sendmessage(dest, mensagem, tipo);
                }
            }
            else
            {
                Console.WriteLine($"Email {dest} inválido!");
            }
            
        }
        else if (choice2 == 2)
        {
            Console.WriteLine("Contacto: ");
            string dest = Console.ReadLine();
            if (dest.ToString().Length == 9)
            {
                Console.WriteLine("Mensagem: ");
                string mensagem = Console.ReadLine();
                string tipo = "SMS";
                nova = new Sms(dest, mensagem, tipo);
                if (nova != null)
                {
                    Console.WriteLine($"Notificação do tipo {tipo} criada com sucesso!");
                    nova.Sendmessage(dest, mensagem, tipo);
                }
            }
            else
            {
                Console.WriteLine($"Contacto {dest} inválido!");
            }

        } else if (choice2 == 3)
        {
            Console.WriteLine("Titulo: ");
            string titulo = Console.ReadLine();
            string tipo = "PUSH";
            Console.WriteLine("Tópico: ");
            string topico = Console.ReadLine();
            Console.WriteLine("Mensagem: ");
            string mensagem = Console.ReadLine();
            nova = new Push(titulo, mensagem, tipo);
            if (nova != null)
            {
                HttpClient client = new HttpClient();
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
    }else if (choice == 2)
    {
        Console.WriteLine("Goodbye\n ");
        break;
    }
}