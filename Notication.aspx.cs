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
    public partial class Notication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillData();
                Panel1.Visible = false;
            }
        }
        protected void FillData()
        {
            string cid = Session["ClassRoomId"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //  SqlDataAdapter da = new SqlDataAdapter("select b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username", con);
            SqlDataAdapter da = new SqlDataAdapter("select email,b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username and a.classroomid=" + cid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string email = GridView1.DataKeys[e.RowIndex].Values["email"].ToString();
            HiddenField1.Value = email;
            Panel1.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sendEmail();
            lblmsg.Text = "Notification Sent on Email";
            Button1.Visible = false;
        }
        protected void sendEmail()
        {

            string mEmail = HiddenField1.Value.ToString();
          
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("student.community.platform@gmail.com");

            msg.To.Add(mEmail);

            msg.Subject = "Notification From Student Community Platform";

            msg.Body = txtnot.Text;

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