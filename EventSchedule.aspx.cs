using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Text;
using System.IO;
namespace Event_Mgt_QR_Code
{
    public partial class EventSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSUbmit_Click(object sender, EventArgs e)
        {
            submitdata();
        }

        protected void submitdata()
        {
            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Event_master(ename,edate,e_for,contact_persone,contact_no,location,etime) values(@ename,@edate,@e_for,@contact_person,@contact_no,@location,@etime)", con);
            cmd.Parameters.AddWithValue("ename", txtEventName.Text);
            cmd.Parameters.AddWithValue("edate", txteventDate.Text);
            cmd.Parameters.AddWithValue("e_for", txtEventOraganization.Text);
            cmd.Parameters.AddWithValue("contact_person", txtcontactperson.Text);
            cmd.Parameters.AddWithValue("contact_no", txtContactNum.Text);
            cmd.Parameters.AddWithValue("location", txtLOcation.Text);
            cmd.Parameters.AddWithValue("etime", txtEventTime.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            
            lblmsg.Text = "Event Details added  successfully.";
        }
    }
}