using ProductTracking.Core.Interfaces;

namespace ProductTracking.Infrastructure.Services;
public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        // TODO: Implement Email logic here
        return Task.CompletedTask;
    }
}
