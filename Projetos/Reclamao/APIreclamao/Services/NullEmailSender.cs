using Microsoft.AspNetCore.Identity; // Necessário para IEmailSender<TUser>
using System.Threading.Tasks;
using System; // Para Console.WriteLine
using bibliotecaReclamao.Banco.Modelos; // Necessário para referenciar seu modelo de Usuario

namespace APIreclamao.Services // <<<< AJUSTE ESTE NAMESPACE PARA O SEU PROJETO
{
    public class NullEmailSender : IEmailSender<Usuario>
    {
        // Método SendEmailAsync (MANTENHA APENAS ESTA VERSÃO!)
        public Task SendEmailAsync(Usuario user, string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Simulando envio de e-mail para: {email} (Usuário: {user?.UserName}), Assunto: {subject}");
            return Task.CompletedTask;
        }

        // Métodos adicionais exigidos por IEmailSender<TUser>
        public Task SendConfirmationLinkAsync(Usuario user, string email, string confirmationLink)
        {
            Console.WriteLine($"Simulando envio de link de confirmação para: {email} (Usuário: {user?.UserName}), Link: {confirmationLink}");
            return Task.CompletedTask;
        }

        public Task SendPasswordResetLinkAsync(Usuario user, string email, string resetLink)
        {
            Console.WriteLine($"Simulando envio de link de reset de senha para: {email} (Usuário: {user?.UserName}), Link: {resetLink}");
            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(Usuario user, string email, string resetCode)
        {
            Console.WriteLine($"Simulando envio de código de reset de senha para: {email} (Usuário: {user?.UserName}), Código: {resetCode}");
            return Task.CompletedTask;
        }
    }
}