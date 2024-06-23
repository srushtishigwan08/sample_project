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
    public partial class BrowseClassRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                {
                   FillData();
                SharedFillData();
                }
        }

        protected void FillData()
        {
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select classroomid,roomname,description,fname +' '+lname as fullname from ClassRoom a,Primary_registration b where a.createdby=b.username", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ClassRoomId = GridView1.DataKeys[e.RowIndex].Values["ClassRoomId"].ToString();
            Session["ClassRoomId"] = ClassRoomId;
            Response.Redirect("JoinClassRoom.aspx");
        }


        protected void SharedFillData()
        {
            // string cid = Session["ClassRoomId"].ToString();
            string un = Session["un"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //  SqlDataAdapter da = new SqlDataAdapter("select b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username", con);
            SqlDataAdapter da = new SqlDataAdapter("select *  from sharedResources where usernameto='"+ un+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            int cnt = ds.Tables["t1"].Rows.Count;
            if (cnt > 0)
            {
                Label4.Visible = true;
            }
            else
            {
                Label4.Visible = false;
            }

            DataList1.DataSource = ds.Tables["t1"];
            DataList1.DataBind();
            con.Close();

        }
    }
}