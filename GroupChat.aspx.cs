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
    public partial class GroupChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["un"] == null)
                {
                    Response.Redirect("~/INdex.aspx");
                }
                else
                {
                    TextBox1.Text = Session["un"].ToString();

                }
            } 
        }

        protected void brnadd_Click(object sender, EventArgs e)
        {
            CheckUserName();
            //Session["name"] = TextBox1.Text;
            //lbluname.Text = "Welcome " + HiddenField1.Value.ToString();
            //TextBox1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            string message = txtsend.Text;
            string my = name + "::" + message;

            Application["message"] = Application["message"] + my + Environment.NewLine;
            txtsend.Text = "";
        }

        protected void CheckUserName()
        {
            string cid = Session["ClassRoomId"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select b.username,id,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username and a.classroomid=" + cid, con);

            da.Fill(ds, "t1");
            Boolean flag = false;
            foreach (DataRow r1 in ds.Tables["t1"].Rows)
            {
                if (r1["username"].ToString() == TextBox1.Text)
                {
                    HiddenField1.Value = r1["fullname"].ToString();
                    flag = true;
                }
            }
            con.Close();

            if (flag == false)
            {
                lblmsg.Text = "Not is this class romm";
              
                TextBox1.Text = "";
            }
            else
            {
                lblmsg.Text = "";
                Session["name"] = TextBox1.Text;
                lbluname.Text = "Welcome " + HiddenField1.Value.ToString();
                TextBox1.Text = "";
                // Session["un"] = txtun.Text;
              //  Response.Redirect("~/BrowseClassRoom.aspx");
            }
        }
    }
}