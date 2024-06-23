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
namespace StudentCommunityPlatform
{
    public partial class updateprofile : System.Web.UI.Page
    {
        string fileTitle11;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchUser();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            uploadimage1();
            UpdateFunction();
        }
        protected void UpdateFunction()
        {
            string muser = Session["un"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update primary_registration set fname=@fname,mname=@mname,lname=@lname,email=@email,contactno=@contactno,coursename=@coursename,hobbies=@hobbies,aboutme=@aboutme,photo=@photo where username='" + muser+"'", con);
           
            cmd.Parameters.AddWithValue("fname", txtfname.Text);
            cmd.Parameters.AddWithValue("mname", txtmname.Text);
            cmd.Parameters.AddWithValue("lname", txtlname.Text);
            cmd.Parameters.AddWithValue("email", txtemail.Text);
            cmd.Parameters.AddWithValue("contactno", txtcontact.Text);
            cmd.Parameters.AddWithValue("coursename", txtcourse.Text);
            cmd.Parameters.AddWithValue("hobbies", txthob.Text);
            cmd.Parameters.AddWithValue("aboutme", txtabout.Text);
            cmd.Parameters.AddWithValue("photo", "~/Img/"+fileTitle11);
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Profile Updated Successfully";
            btnUpdate.Visible = false;
        }
        protected void SearchUser()
        {
            string muser = Session["un"].ToString();
            string s1, s2;
            s1 = ConfigurationManager.ConnectionStrings["StudentComm_db"].ConnectionString;
            // s2 = "Select UserName,FName,MName,LName,ContactNo,Address,Location,City,EmailId,PinCode from CoustmerRegistration";
            s2 = "Select * from Primary_registration";

            SqlConnection conn = new SqlConnection(s1);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(s2, s1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "t1");

            foreach (DataRow r1 in ds1.Tables["t1"].Rows)
            {
                if ((r1["UserName"].ToString() == muser))
                {
                    txtabout.Text = r1["aboutme"].ToString();
                    txtadd.Text = r1["address"].ToString();
                    txtcontact.Text = r1["contactno"].ToString();
                    txtemail.Text = r1["email"].ToString();
                    txtfname.Text = r1["fname"].ToString();
                    txthob.Text = r1["hobbies"].ToString();
                    txtlname.Text = r1["lname"].ToString();
                    txtmname.Text = r1["mname"].ToString();
                    txtpin.Text = r1["pin"].ToString();
                    txtcourse.Text = r1["coursename"].ToString();
                    Image1.ImageUrl = r1["photo"].ToString();

                }
            }
            conn.Close();
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