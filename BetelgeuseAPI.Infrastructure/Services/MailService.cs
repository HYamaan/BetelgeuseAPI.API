using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;

namespace BetelgeuseAPI.Infrastructure.Services;

public class MailService : IMailService
{
    public MailSettings _mailSettings { get; }

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendMailAsync(MailRequest mailRequest)
    {
        try
        {
            // create message
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailRequest.From ?? _mailSettings.EmailFrom);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
        catch (System.Exception ex)
        {
            throw new ApiException(ex.Message);
        }
    }

    public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken,string endpoint)
    {
        StringBuilder mailBody = new StringBuilder();

        mailBody.AppendLine("<!doctype html>");
        mailBody.AppendLine("<html lang=\"en-US\">");
        mailBody.AppendLine("<head>");
        mailBody.AppendLine("<meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\" />");
        mailBody.AppendLine("<title>Reset Password</title>");
        mailBody.AppendLine("<meta name=\"description\" content=\"Reset Password.\">");
        mailBody.AppendLine("<style type=\"text/css\">");
        mailBody.AppendLine("a:hover {text-decoration: underline !important;}");
        mailBody.AppendLine("</style>");
        mailBody.AppendLine("</head>");
        mailBody.AppendLine("<body marginheight=\"0\" topmargin=\"0\" marginwidth=\"0\" style=\"margin: 0px; background-color: #f2f3f8;\" leftmargin=\"0\">");
        mailBody.AppendLine("<!--100% body table-->");
        mailBody.AppendLine("<table cellspacing=\"0\" border=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#f2f3f8\"");
        mailBody.AppendLine("style=\"@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;\">");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td>");
        mailBody.AppendLine("<table style=\"background-color: #f2f3f8; max-width:670px;  margin:0 auto;\" width=\"100%\" border=\"0\"");
        mailBody.AppendLine("align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"height:80px;\">&nbsp;</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"text-align:center;\">");
        mailBody.AppendLine("<a href=\"https://rakeshmandal.com\" title=\"logo\" target=\"_blank\">");
        mailBody.AppendLine("<img width=\"60\" src=\"https://i.ibb.co/hL4XZp2/android-chrome-192x192.png\" title=\"logo\" alt=\"logo\">");
        mailBody.AppendLine("</a>");
        mailBody.AppendLine("</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"height:20px;\">&nbsp;</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td>");
        mailBody.AppendLine("<table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"");
        mailBody.AppendLine("style=\"max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);\">");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"height:40px;\">&nbsp;</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"padding:0 35px;\">");
        mailBody.AppendLine("<h1 style=\"color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;\">You have");
        mailBody.AppendLine("Reset your password</h1>");
        mailBody.AppendLine("<span");
        mailBody.AppendLine("style=\"display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;\"></span>");
        mailBody.AppendLine("<p style=\"color:#455056; font-size:15px;line-height:24px; margin:0;\">");
        mailBody.AppendLine("We cannot simply send you your old password. A unique link to reset your");
        mailBody.AppendLine("password has been generated for you. To reset your password, click the");
        mailBody.AppendLine("following link and follow the instructions.");
        mailBody.AppendLine("</p>");
        mailBody.AppendLine("<a href=\"" + endpoint + "/update-password/" + userId + "/" + resetToken + "\"");
        mailBody.AppendLine("style=\"background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;\">Reset");
        mailBody.AppendLine("Password</a>");
        mailBody.AppendLine("</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"height:40px;\">&nbsp;</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("</table>");
        mailBody.AppendLine("</td>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"height:20px;\">&nbsp;</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"text-align:center;\">");
        mailBody.AppendLine("<p style=\"font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;\">&copy; <strong>www.rakeshmandal.com</strong></p>");
        mailBody.AppendLine("</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("<tr>");
        mailBody.AppendLine("<td style=\"height:80px;\">&nbsp;</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("</table>");
        mailBody.AppendLine("</td>");
        mailBody.AppendLine("</tr>");
        mailBody.AppendLine("</table>");
        mailBody.AppendLine("<!--/100% body table-->");
        mailBody.AppendLine("</body>");
        mailBody.AppendLine("</html>");


        var emailRequest = new MailRequest()
        {
            Body = mailBody.ToString(),
            ToEmail =to,
            Subject = "Reset Password",
        };

        await SendMailAsync(emailRequest);
    }
}
