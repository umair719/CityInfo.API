using System.Diagnostics;
using System;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
		private string _mailTo = "admin@mycompany.com";
		private string _mailFrom = "noreply@mycompany.com";

		// UK - mimic sending email
		public void Send(string subject, string message)
		{
			// send mail - output to debug window
			Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}
    }
}
