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
    public partial class CreateClassRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            InsertFunction();
        }
        protected void InsertFunction()
        {
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ClassRoom (RoomName,Description,CreatedBy) values(@RoomName,@Description,@CreatedBy)", con);
            cmd.Parameters.AddWithValue("RoomName", txtClassRoom.Text);
            cmd.Parameters.AddWithValue("Description", txtDesc.Text);
            cmd.Parameters.AddWithValue("CreatedBy", Session["un"].ToString());

            
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Communication Class Room Created  successfully";
            BtnSubmit.Visible = false;
        }
    }
}