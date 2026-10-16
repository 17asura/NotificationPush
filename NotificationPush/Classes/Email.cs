namespace NotificationPush.Classes;
using System;
using System.Net;
using System.Net.Mail;
public class Email : Notificacao
{
    private string Emailstr;
    public Email(string email,string mensagem, string tipo) : base(mensagem, tipo)
    {
        Emailstr = email;
    }
    public override async void Sendmessage(string destinatario, string mensagem, string tipo)
    {
        Console.WriteLine($"Destinatário:{destinatario}\n Mensagem:{mensagem}\n Tipo: {tipo}");
        // Obter credenciais das Variáveis de Ambiente do sistema
        string remetente = Environment.GetEnvironmentVariable("REMETENTE") ?? 
                           throw new InvalidOperationException("A variável REMETENTE não está definida.");
        string appPassword = Environment.GetEnvironmentVariable("APP_PASSWORD") ??
                             throw new InvalidOperationException("A variável APP_PASSWORD não está definida.");
        
        // Criar a mensagem
        using MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(remetente);
        mailMessage.To.Add(destinatario);
        mailMessage.Subject = "17Asura";
        mailMessage.Body = mensagem;
        mailMessage.IsBodyHtml = false;

        // Configurar o cliente SMTP
        using SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(remetente, appPassword);
        
        try
        { 
            // Enviar o e-mail (Esta classe bloqueia a thread se não for assíncrona)
            await smtpClient.SendMailAsync(mailMessage);
            Console.WriteLine("E-mail enviado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar: {ex.Message}");
        }
    }
}
