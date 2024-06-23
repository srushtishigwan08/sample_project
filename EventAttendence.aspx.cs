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
using IronBarCode;
namespace Event_Mgt_QR_Code
{
    public partial class EventAttendence : System.Web.UI.Page
    {
        string fileTitle11;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               
                FillDrp();
            }
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
                       // FileUpload1.SaveAs(Server.MapPath("~/Admin/" + fileTitle11));
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

            //   BarcodeResults results = BarcodeReader.Read(Server.MapPath("~/QRCode/" + "myqr1.png"));
         //   Image1.ImageUrl = Server.MapPath("~/QRCode/" + fileTitle11);
            BarcodeResults results = BarcodeReader.Read(Server.MapPath("~/QRCode/" + fileTitle11));
            if (results != null)
            {
                foreach (BarcodeResult result in results)
                {
                    //  Console.WriteLine(result.Text);
                    Label1.Text = result.Text;
                }

            }
            else
            {
                Label1.Text = "Invalid";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            uploadimage1();
        }
    }
}