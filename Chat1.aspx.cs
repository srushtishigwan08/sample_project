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
    public partial class Chat1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }

        protected void FillData()
        {
            string cid = Session["ClassRoomId"].ToString();
            string constr = WebConfigurationManager.ConnectionStrings["StudentComm_db"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //  SqlDataAdapter da = new SqlDataAdapter("select b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username", con);
            SqlDataAdapter da = new SqlDataAdapter("select photo,b.username,id,CAST(jdate AS varchar(103)) as jdate,fname +' '+lname as fullname from joinclass a,primary_registration b where  a.username=b.username and a.classroomid=" + cid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            DataList1.DataSource = ds.Tables["t1"];
            DataList1.DataBind();
            con.Close();

        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            //Label nowprice = (Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label3");
            //LinkButton add = (LinkButton)DataList1.Items[e.Item.ItemIndex].FindControl("LinkButton1");
            //BtnArgument = add.CommandArgument.ToString();

        }
    }
}