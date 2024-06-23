using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Drawing;
using System.Net.Mail;
using System.Net;
namespace StudentCommunityPlatform
{
    public partial class ApprovalStatusUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label email = (Label)GridView1.Rows[e.RowIndex].FindControl("label6");
            HiddenField2.Value = email.Text;
            string st_id = GridView1.DataKeys[e.RowIndex].Values["st_id"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update primary_registration set status=@status where st_id=" + st_id, con);

            cmd.Parameters.AddWithValue("status", "Rejected");

            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Rejected Successfully";
            HiddenField1.Value = "Rejected";
            sendEmail();
           

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label email = (Label)GridView1.Rows[e.RowIndex].FindControl("label6");
            HiddenField2.Value = email.Text;
            string st_id = GridView1.DataKeys[e.RowIndex].Values["st_id"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update primary_registration set status=@status where st_id=" + st_id , con);

            cmd.Parameters.AddWithValue("status", "Approved");
           
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Apporved Successfully";
            HiddenField1.Value = "Approved";
            sendEmail();
            //btnUpdate.Visible = false;
        }
        protected void sendEmail()
        {

            string mEmail = HiddenField2.Value.ToString();
          

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("student.community.platform@gmail.com");

            msg.To.Add(mEmail);

            msg.Subject = "Registration status from student community Platform";

            msg.Body = "Yours Registration is "+HiddenField1.Value.ToString()+" by Admin ";

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
        protected void FillData()
        {
           
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //  SqlDataAdapter da = new SqlDataAdapter("select b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username", con);
            SqlDataAdapter da = new SqlDataAdapter("select * from Primary_Registration where status='"+DropDownList1.SelectedValue.ToString()+"'" , con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }
    }
}