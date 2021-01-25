using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRazorPortfolio.Helper
{
  public  interface IEmailSender
    {

        public void SendEmail(string recepients, string sender, string title, string body);

    }
}
