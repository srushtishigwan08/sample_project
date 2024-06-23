using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Drawing;
using System.IO;
namespace Event_Mgt_QR_Code
{
    public partial class UploadCSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                FillGV();
                FillDrp();
            }
        }

        protected void FillGV()
        {
            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Members", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();

        }
        protected void FillDrp()
        {
            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Event_Master", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            DropDownList1.DataSource = ds.Tables["t1"];
            DropDownList1.DataTextField = "ename";
            DropDownList1.DataValueField = "eid";

            DropDownList1.DataBind();
            con.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Members where eid="+DropDownList1.SelectedValue, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            //Create a DataTable.
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("memberno", typeof(string)),
        new DataColumn("mem_name", typeof(string)),
        new DataColumn("contact_no", typeof(string)),
        new DataColumn("emailid",typeof(string)) });

            //Read the contents of CSV file.
            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    //Execute a loop over the columns.
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            //Bind the DataTable.
            GridView2.DataSource = dt;
            GridView2.DataBind();
            int cnt = dt.Rows.Count;

            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            for (int i=1;i<=cnt-1;i=i+1)
            {
                string memno = dt.Rows[i]["memberno"].ToString();
                string memnm = dt.Rows[i]["mem_name"].ToString();
                string contno = dt.Rows[i]["contact_no"].ToString();
                string emailid = dt.Rows[i]["emailid"].ToString();
                SqlCommand cmd = new SqlCommand("insert into members(eid,ename,memberno,mem_name,contact_no,emailid) values(@eid,@ename,@memberno,@mem_name,@contact_no,@emailid)", con);
                cmd.Parameters.AddWithValue("eid", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("ename", DropDownList1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("memberno", memno);
                cmd.Parameters.AddWithValue("mem_name", memnm);
                cmd.Parameters.AddWithValue("contact_no", contno);
                cmd.Parameters.AddWithValue("emailid", contno);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            FillGV();
          //  lblmsg.Text = "CSV FIle data Uploaded   successfully.";
            //foreach (DataRow r1 in dt.Rows)
            //{
            //    string memno = r1["memberno"].ToString();
            //    string memnm = r1["mem_name"].ToString();
            //}
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Event_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
    }
}