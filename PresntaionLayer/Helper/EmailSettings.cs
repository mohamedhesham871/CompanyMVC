using Microsoft.AspNetCore.Components.Web;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace PresntaionLayer.Helper
{
	public static class EmailSettings
	{
		public static bool SendEmail(Email email)
		{
			// Servce name :Gamil
			//protacol : SMTP {Simple Mail Transfer Protocol}
			//Port : 587
			//host : smtp.gmail.com
			try
			{
				
				var client = new SmtpClient("smtp.gmail.com", 587);
					client.EnableSsl = true;
				//sender Data 
				client.Credentials = new NetworkCredential("mmmelkady23@gmail.com", "oqsgmlzlqvqflipo");
			
				client.Send(from: "mmmelkady23@gmail.com",
					recipients: email.To,
					subject: email.Subject,
					body: email.Body);
				return true;
			}
			catch (Exception)
			{
				return false;
				//log the error
				//return false;
			}
		}
	}
}
