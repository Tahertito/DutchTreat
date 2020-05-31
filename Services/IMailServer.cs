namespace DutchTreat.Services
{
    public interface IMailServer
    {
     
        void SendMail(string from, string subject, string message);
    }
}