using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Configuration;
namespace STudentCommunityPlatform
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }   

        protected void CheckUserName()
        {
            if (txtun.Text == "admin123" && txtpass.Text == "admin123")
            {
                Response.Redirect("~/ApprovalStatusUpdate.aspx");
            }
            else
            {
                string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("select * from Primary_registration", con);
                da.Fill(ds, "t1");
                Boolean flag = false;
                foreach (DataRow r1 in ds.Tables["t1"].Rows)
                {
                    if (r1["username"].ToString() == txtun.Text && r1["pass"].ToString() == txtpass.Text && r1["status"].ToString() == "Approved")
                    {
                        flag = true;
                    }
                }
                con.Close();

                if (flag == false)
                {
                    lblmsg.Text = "Invalid username or password";
                    txtpass.Text = "";
                    txtun.Text = "";

                }
                else
                {
                    Session["un"] = txtun.Text;
                    Response.Redirect("~/BrowseClassRoom.aspx");
                }
            }
        }

        

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            CheckUserName();
        }

        protected void BtnRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration.aspx");
        }
    }
}