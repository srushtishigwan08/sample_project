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
    public partial class Registration : System.Web.UI.Page
    {
        string fileTitle11;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HyperLink1.Visible = false;
                Button1.Visible = false;
            }
        }

        protected void BtnRegistration_Click(object sender, EventArgs e)
        {
            CheckUserName();
        }

        protected void CheckUserName()
        {
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from primary_registration", con);
            da.Fill(ds, "t1");
            Boolean flag = false;
            foreach (DataRow r1 in ds.Tables["t1"].Rows)
            {
                if (r1["username"].ToString() == txtUname.Text && r1["pass"].ToString() == txtpassowrd.Text)
                {
                    flag = true;
                }
            }
            con.Close();

            if (flag == true)
            {
                lblmsg.Text = "wrong username or password";
                txtpassowrd.Text = "";
                txtUname.Text = "";
            }
            else
            {
                Session["un"] = txtUname.Text;
                InsertFunction();
              
            }
        }

        protected void InsertFunction()
        {
            uploadimage1();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into primary_registration (marksheet,coursename,status,username,pass,fname,mname,lname,email,contactno) values(@marksheet,@coursename,@status,@username,@pass,@fname,@mname,@lname,@email,@contactno)", con);
            cmd.Parameters.AddWithValue("marksheet", "~/Img/" + fileTitle11);
            cmd.Parameters.AddWithValue("coursename", txtcname.Text);
            cmd.Parameters.AddWithValue("status", "New Registration");
            cmd.Parameters.AddWithValue("username", txtUname.Text);
            cmd.Parameters.AddWithValue("pass", txtpassowrd.Text);
            cmd.Parameters.AddWithValue("fname", txtfname.Text);
            cmd.Parameters.AddWithValue("mname", txtmname.Text);
            cmd.Parameters.AddWithValue("lname", txtlname.Text);
            cmd.Parameters.AddWithValue("email", txtemail.Text);
            cmd.Parameters.AddWithValue("contactno", txtContact.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Registration has done successfully, Creadentials are sent on yours email,Login and update yours Profile";
            BtnRegistration.Visible = false;
            HyperLink1.Visible = true;
            sendEmail();
            Button1.Visible = true;
        }
        protected void sendEmail()
        {

            string mEmail =txtemail.Text;
            string mUser = txtUname.Text;
            string mpass = txtpassowrd.Text;

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("student.community.platform@gmail.com");

            msg.To.Add(mEmail);

            msg.Subject = "Welcome to Student Community Platform";

            msg.Body = "Welcome <font color='red'>" + txtfname.Text + " " + txtlname.Text + "</font> <br/> your username is" + mUser + "and password" + mpass;

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/index.aspx");
        }

        protected void uploadimage1()
        {
            string fileName = FileUpload1.PostedFile.FileName;



            string fileExtension = System.IO.Path.GetExtension(fileName);

            string fileMimeType = FileUpload1.PostedFile.ContentType;

            int fileSizeInKb = FileUpload1.PostedFile.ContentLength / 1024;
            fileTitle11 = FileUpload1.FileName;
            string[] MatchExtension = { ".jpg", ".jpeg", ".png", ".gif" };
            string[] MatchMimeType = { "image/jpeg", "image/gif", "image/png" };
            if (FileUpload1.HasFile)
            {
                if (MatchExtension.Contains(fileExtension) || MatchMimeType.Contains(fileMimeType))
                {
                    if (fileSizeInKb <= 1024)
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/img/" + fileTitle11));
                    }
                    else
                    {
                        Response.Write("file Size less than 1 Mb");
                    }

                }
                else
                {
                    Response.Write("Please Upload an .jpg,.jpeg,.gif or .png image");
                }
            }
            else
            {
                Response.Write("please Upload an image");
            }
        }
    }
}