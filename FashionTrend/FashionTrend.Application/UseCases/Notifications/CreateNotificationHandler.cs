using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class CreateNotificationHandler
{
    private string AccountsID;
    private string AuthToken;
    private string TwilioPhoneNumber;
    private readonly ILogger<CreateNotificationHandler> _logger;

    public CreateNotificationHandler(ILogger<CreateNotificationHandler> logger)
    {
        _logger = logger;
    }
    public CreateNotificationHandler(string _accountId, string _authToken, string _twilioPhoneNumber)
    {
        AccountsID = _accountId;
        AuthToken = _authToken;
        TwilioPhoneNumber = _twilioPhoneNumber;
    }

    public void SmsNotifier(string accountId, string authToken, string twilioPhoneNumber)
    {
        this.AccountsID = accountId;
        this.AuthToken = authToken;
        this.TwilioPhoneNumber = twilioPhoneNumber;
    }

    public void SendSMS(string toPhoneNumber, string message)
    {
        try
        {
            TwilioClient.Init(AccountsID, AuthToken);
            var messageOption = new CreateMessageOptions(new Twilio.Types.PhoneNumber(toPhoneNumber))
            {
                Body = message,
                From = new Twilio.Types.PhoneNumber(TwilioPhoneNumber)
            };

            var messageResponse = MessageResource.Create(messageOption);

            _logger.LogTrace("Sms enviado com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Create Supplier.");
            throw;
        }
    }

}