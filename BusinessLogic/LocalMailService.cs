using System.Diagnostics;
using Contracts.Services;
using Dtos;
using Microsoft.Extensions.Options;

namespace BusinessLogic
{
    public class LocalMailService : IMailService
    {
        private readonly IOptions<Email> _config;

        public LocalMailService(IOptions<Email> config)
        {
            _config = config;
        }

        private string _mailTo;
        private string _mailFrom;

        public void Send(string subject, string message)
        {
            _mailTo = _config.Value.mailToAddress;
            _mailFrom = _config.Value.mailFromAddress;

            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo} with LocalMailService");
            Debug.WriteLine($"Subject : {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
