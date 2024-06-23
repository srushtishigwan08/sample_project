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
using System.Net.Mail;
using System.Net;
using IronBarCode;

namespace Event_Mgt_QR_Code
{
    public partial class GenerateQR : System.Web.UI.Page
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
            SqlDataAdapter da = new SqlDataAdapter("select * from Members where eid=" + DropDownList1.SelectedValue, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            con.Close();
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    var myBarcode=     QRCodeWriter.CreateQrCode("hello world", 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng(Server.MapPath("~/QRCode/"+"myqr1.png"));



        //    BarcodeResults results = BarcodeReader.Read(Server.MapPath("~/QRCode/" + "myqr1.png"));
        //    if (results != null)
        //    {
        //        foreach (BarcodeResult result in results)
        //        {
        //            Console.WriteLine(result.Text);
        //            Label6.Text = result.Text;
        //        }
               
        //    }

        //    ////var myBarcode = BarcodeWriter.CreateBarcode("12345", BarcodeWriterEncoding.EAN8);

        //    //// Reading a barcode is easy with IronBarcode:
        //    //var resultFromFile = BarcodeReader.Read(@Server.MapPath("~/QRCode/" + "myqr1.png")); // From a file
        //    ////var resultFromPdf = BarcodeReader.ReadPdf(@"file/mydocument.pdf"); // From PDF use ReadPdf

        //    //// After creating a barcode, we may choose to resize and save which is easily done with:
        //    //myBarcode.ResizeTo(500, 500);
        //    //myBarcode.SaveAsImage(Server.MapPath("~/QRCode/" + "myqr1.jpeg"));
        //}

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Values["id"].ToString();
            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from members", con);
            da.Fill(ds, "t1");
            string emailid = null;
            foreach (DataRow r1 in ds.Tables["t1"].Rows)
            {
                if (r1["id"].ToString() == id)
                {
                    emailid = r1["emailid"].ToString();
                }
            }
            con.Close();


            //generating qr code
            QRCodeWriter.CreateQrCode(emailid, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng(Server.MapPath("~/QRCode/" + emailid + ".png"));
            string qr_parh = "~/QRCode/" + emailid + ".png";
            string qr_parh2 =  emailid + ".png";
            HiddenField1.Value = qr_parh;
            HiddenField2.Value = emailid;
            con.Open();
            SqlCommand cmd = new SqlCommand("update members set qr_code=@qr_code,qr_code2=@qr_code2  where id=@id", con);
            cmd.Parameters.AddWithValue("@qr_code", qr_parh);
            cmd.Parameters.AddWithValue("@qr_code2", qr_parh2);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            FillGV();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Values["id"].ToString();
            string strcon = WebConfigurationManager.ConnectionStrings["EventMgt_DB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from members", con);
            da.Fill(ds, "t1");
            string emailid = null;
            string qrimg = null;
            string qrimg2 = null;
            foreach (DataRow r1 in ds.Tables["t1"].Rows)
            {
                if (r1["id"].ToString() == id)
                {
                    emailid = r1["emailid"].ToString();
                    qrimg = r1["qr_code"].ToString();
                    qrimg2 = r1["qr_code2"].ToString();

                }
            }

            HiddenField2.Value = emailid.ToString();
            HiddenField1.Value=qrimg.ToString();
            HiddenField3.Value = qrimg2.ToString();
            con.Close();
            // sendEmail();

            string Themessage = @"<html>
                              <body>
                                <table width=""80%"">
                                <tr>
                                    <td style=""font-style:arial; color:maroon; font-weight:bold"">
                                   Hi! <br>
                                    <img src=cid:myImageID>
                                    </td>
                                </tr>
                                </table>
                                </body>
                                </html>";
            sendHtmlEmail("hopecenterbyvaibhavi@gmail.com", HiddenField2.Value.ToString(), Themessage, "Event Management", "Kindly find QR Code", "smtp.gmail.com", 25);
        }


        protected void sendEmail()
        {

            string mEmail = HiddenField2.Value.ToString();
            string qrimg = HiddenField1.Value.ToString();

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("hopecenterbyvaibhavi@gmail.com");

            msg.To.Add(mEmail);

            msg.Subject = "QR code";
         //   msg.AlternateViews.Add(GetEmbeddedImage()
             //     mail.AlternateViews.Add(GetEmbeddedImage('c://image.png'));
            msg.Body = "Welcome <font color='red'>  Kindly find QR code </font> <br/> " +
                "<img src=\'C:\\ASP_Practicle\\MyQr.png'> </img>";

            msg.IsBodyHtml = true;


            SmtpClient smt = new SmtpClient();

            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new NetworkCredential();
            ntwd.UserName = "hopecenterbyvaibhavi@gmail.com";
            ntwd.Password = "iexokwxhmsjzrtbo";
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);



        }

        protected void sendHtmlEmail(string from_Email, string to_Email, string body, string from_Name, string Subject, string SMTP_IP, Int32 SMTP_Server_Port)
        {
            //create an instance of new mail message
            MailMessage mail = new MailMessage();

            //set the HTML format to true
            mail.IsBodyHtml = true;

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

            //Add Image
            //  LinkedResource theEmailImage = new LinkedResource("C:\\ASP_Practicle\\myqr.png");
            string pathFromWeb= System.Web.Configuration.WebConfigurationManager.AppSettings["myFilePath"].ToString();
            LinkedResource theEmailImage = new LinkedResource(pathFromWeb+"/QRCode/" + HiddenField3.Value.ToString());
            theEmailImage.ContentId = "myImageID";

            //Add the Image to the Alternate view
            htmlView.LinkedResources.Add(theEmailImage);

            //Add view to the Email Message
            mail.AlternateViews.Add(htmlView);

            //set the "from email" address and specify a friendly 'from' name
            mail.From = new MailAddress(from_Email, from_Name);

            //set the "to" email address
            mail.To.Add(to_Email);

            //set the Email subject
            mail.Subject = Subject;

            //set the SMTP info
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("hopecenterbyvaibhavi@gmail.com", "iexokwxhmsjzrtbo");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = cred;
            //send the email
            smtp.Send(mail);
        }
        


    }
}