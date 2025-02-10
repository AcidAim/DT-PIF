using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using PostmarkDotNet;

namespace XE908.Services.EMailService;

public class EMailSender : IEmailSender
{
    private readonly ILogger<IEmailSender> _logger;

    public EMailSender(ILogger<IEmailSender> logger, IOptions<AuthMessageSenderOptions> optionsAccessor)
    {
        _logger = logger;
        Options = optionsAccessor.Value;
    }

    private AuthMessageSenderOptions Options { get; }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        if (string.IsNullOrEmpty(Options.PostMarkKey))
        {
            throw new Exception("Null PostMarkKey");
        }
        await Execute(Options.PostMarkKey, subject, htmlMessage, email);
    }

    private async Task Execute(string postMarkKey, string subject, string content, string toEmail)
    {
        var message = new PostmarkMessage()
        {
            To = toEmail,
            From = "info@datacorp.site",
            TrackOpens = true,
            Subject = subject,
            TextBody = content,
            HtmlBody = content,
            MessageStream = "email-confirmation"
        };

        var client = new PostmarkClient(postMarkKey);
        var sendResult = await client.SendMessageAsync(message);

        _logger.LogInformation(sendResult.Status == PostmarkStatus.Success
            ? $"Email to {toEmail} queued successfully"
            : $"Email to {toEmail} failed");
    }
}