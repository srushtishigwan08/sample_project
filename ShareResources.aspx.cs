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
namespace StudentCommunityPlatform
{
    public partial class ShareResources : System.Web.UI.Page
    {
        string fileTitle11;
        string Username;
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
            SqlDataAdapter da = new SqlDataAdapter("select b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username and a.classroomid=" + cid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();

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
                        Response.Write("file Size greater than 1 Mb");
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Username = GridView1.DataKeys[e.RowIndex].Values["Username"].ToString();
            HiddenField1.Value = Username;
            Panel1.Visible = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            uploadimage1();
           // string muser = Session["un"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into sharedResources (usernameto,filename1) values(@usernameto,@filename1)", con);

            cmd.Parameters.AddWithValue("@usernameto", HiddenField1.Value.ToString());
            cmd.Parameters.AddWithValue("@filename1", "~/Img/" + fileTitle11);
           
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Shared Successfully";
         
        }
    }
}