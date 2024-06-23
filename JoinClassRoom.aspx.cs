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
    public partial class JoinClassRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField1.Value = "0";
                FindClassName();
                FindUserNameExist();
                AddUsernameInJoinClass();
                FillData();
            }

        }

        protected void FindClassName()
        {
            string cid = Session["ClassRoomId"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from ClassRoom where classroomid=" + cid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            foreach (DataRow r1 in ds.Tables["t1"].Rows)
            {

                string cname = r1["roomname"].ToString();
                lblclass.Text = cname;
               lbl2.Text = cname;
            }
        }

        protected void FindUserNameExist()
        {
            string cid = Session["ClassRoomId"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from joinclass", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            foreach (DataRow r1 in ds.Tables["t1"].Rows)
            {
                if (r1["username"].ToString()==Session["un"].ToString() && r1["ClassRoomId"].ToString() == cid)
                { 
                string uname = r1["username"].ToString();
                HiddenField1.Value = "1";
                }
            }
        }
        protected void AddUsernameInJoinClass()
        {
            if (HiddenField1.Value.ToString() == "0")
            {
                string cid = Session["ClassRoomId"].ToString();
                string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into joinClass (ClassRoomId,username,jdate) values(@ClassRoomId,@username,@jdate)", con);
                cmd.Parameters.AddWithValue("ClassRoomId", cid);
                cmd.Parameters.AddWithValue("username", Session["un"].ToString());
                cmd.Parameters.AddWithValue("jdate", System.DateTime.Now);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void FillData()
        {
            string cid= Session["ClassRoomId"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
           // SqlDataAdapter da = new SqlDataAdapter("select id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b,classroomc C  where  c.createdby=a.username and a.username=b.username and a.classroomid=" + cid, con);
            SqlDataAdapter da = new SqlDataAdapter("select id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b,classroom C  where  c.ClassRoomid=a.ClassRoomid and a.username=b.username and a.classroomid=" + cid, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();

        }
    }
}