

using NotificationPush.Classes;

List<Notificacao> notList = new List<Notificacao>();
Notificacao nova = null;

while (true)
{
    Console.WriteLine("\n=== Gestor de Notificações ===");
    Console.WriteLine("Bem vindo");
    Console.WriteLine("[1] Criar Nova Notificação");
    Console.WriteLine("[2] Historial de Notificações");
    Console.WriteLine("[3] Exit");
    Console.Write("Escolha: ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.WriteLine("Escolha Uma Opção:\n");
        Console.WriteLine("[1] E-Mail");
        Console.WriteLine("[2] SMS");
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
                Guid guid = Guid.NewGuid();
                string str = guid.ToString();
                nova = new Email(str,dest, mensagem, tipo);
                if (nova != null)
                {
                    Console.WriteLine($"Notificação do tipo {tipo} criada com sucesso!");
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
            Console.WriteLine("Mensagem: ");
            string mensagem = Console.ReadLine();
            string tipo = "SMS";
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            nova = new Sms(str, dest, mensagem, tipo);
            if (nova != null)
            {
                Console.WriteLine($"Notificação do tipo {tipo} criada com sucesso!");
            }
        }
    }

    if (choice == 2)
    {
        Console.WriteLine("OLA");
    }
    
}