using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentCommunityPlatform
{
    public partial class chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void brnadd_Click(object sender, EventArgs e)
        {
            Session["name"] = TextBox1.Text;
            lbluname.Text = "Welcome " + TextBox1.Text;
            TextBox1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            string message = txtsend.Text;
            string my = name + "::" +message;

            Application["message"] = Application["message"] + my + Environment.NewLine;
            txtsend.Text = "";
        }
    }
}