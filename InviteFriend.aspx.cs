using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
namespace StudentCommunityPlatform
{
    public partial class InviteFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sendEmail();
        }
        protected void sendEmail()
        {

            string mEmail = txtemail.Text;

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("student.community.platform@gmail.com");

            msg.To.Add(mEmail);

            msg.Subject = "Invitation ";

            msg.Body = "Invitation From Student Community Platform to Join";

            msg.IsBodyHtml = true;


            SmtpClient smt = new SmtpClient();

            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "student.community.platform@gmail.com";
            ntwd.Password = "ycrg jslx ijig wmwv";
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);



        }
    }
}