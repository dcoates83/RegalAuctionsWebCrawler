using System.Net;
using System.Net.Mail;

public class Emailer
{
    private readonly string _senderEmail;
    private readonly string _password;
    private readonly string _recipientEmail;
    private readonly List<string> _ccEmails;

    public Emailer(string senderEmail, string password, string recipientEmail, List<string> ccEmails)
    {
        _senderEmail = senderEmail;
        _password = password;
        _recipientEmail = recipientEmail;
        _ccEmails = ccEmails;
    }

    public void SendEmail(string subject, string body)
    {
        MailMessage mail = new();
        using SmtpClient smtp = new("smtp.gmail.com", 587);

        mail.From = new MailAddress(_senderEmail);
        mail.To.Add(_recipientEmail);
        if (_ccEmails != null && _ccEmails.Count > 0)
        {
            foreach (string ccEmail in _ccEmails)
            {
                mail.CC.Add(ccEmail);
            }
        }



        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;


        smtp.Credentials = new NetworkCredential(_senderEmail, _password);
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}
