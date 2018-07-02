using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    bllUsers blu = new bllUsers();
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string i = "wilshaks7@gmail.com";
        string j = "qwerty";

        if (txtEmail.Text == i && txtPassword.Text == j)
        {
            Response.Redirect("ManageCategory.aspx");
        }
        //else if (Session["string"]!=null)
        //{
        //    string idvalue = (string)Session["string"];
        //    Request.Url.AbsoluteUri.Replace("Login.aspx", "ProductDetails.aspx?id=" + idvalue);
        //}
        //else
        {
            String encrypt = blu.Encrypt(txtPassword.Text);
            DataTable dt = blu.SelectAllFromUsers(txtEmail.Text, encrypt);
            if (dt.Rows.Count > 0)
            {
                bool active = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                string firstname = dt.Rows[0]["Firstname"].ToString();
                int userid = Convert.ToInt32(dt.Rows[0]["UserID"].ToString());
                if (active == true)
                {
                    Session["Firstname"] = firstname;
                    Session["Userid"] = userid;
                    using (MailMessage mm = new MailMessage("reliceco@gmail.com", txtEmail.Text))
                    {
                        mm.Subject = "Logging";
                        mm.Body = "You just logged in to your account";
                        mm.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("reliceco@gmail.com", "relic1234");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                    }
                    Response.Redirect("ProductDetails.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Activate your account');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email or password does not match');", true);
            }
        }
    }
}

