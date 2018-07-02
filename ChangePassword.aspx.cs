using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    bllUsers blu = new bllUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string Email = !string.IsNullOrEmpty(Request.QueryString["Email"]) ? Request.QueryString["Email"] : Guid.Empty.ToString();
            txtEmail.Text = Email;
        }
    }
    
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        String Encrypt = blu.Encrypt(txtNewPassword.Text);
        int password =Convert.ToInt32(blu.ResetPassword(Encrypt, txtEmail.Text));
    }
}


        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //using (MailMessage mm = new MailMessage("reliceco@gmail.com", txtEmail.Text))
        //{
        //    mm.Subject = "Logging";            
        //    mm.Body = "You just logged in to your account";

        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.EnableSsl = true;
        //    NetworkCredential NetworkCred = new NetworkCredential("reliceco@gmail.com", "relic1234");
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = NetworkCred;
        //    smtp.Port = 587;
        //    smtp.Send(mm);
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        //}
  
//}      //Response.Redirect("Sign Up.aspx");
//    }

        //string oldpassword =blu.Encrypt(txtOldPassword.Text);
        //DataTable dt = blu.SelectAllFromUsers(txtEmail.Text);
        //if(dt.Rows.Count>0)
        //{
        //    string password = dt.Rows[0]["Password"].ToString();
        //    if (oldpassword==password)
        //    {
        //        if (txtNewPassword.Text==txtConfirmPasswrod.Text)
        //        {
        //            string encryptedtext = blu.Encrypt(txtNewPassword.Text);
        //            int i = blu.UpdateAfterPasswordChange(encryptedtext,txtEmail.Text);
        //            DataTable datatable = blu.SelectAllFromUsers(txtEmail.Text);
        //            string newpassword = datatable.Rows[0]["Password"].ToString();
        //            String Decrypt1 = blu.Decrypt(newpassword);

        //            string email = datatable.Rows[0]["Email"].ToString();
        //            using (MailMessage mm = new MailMessage("reliceco@gmail.com", email))
        //            {
        //                mm.Subject = "Logging";
        //                mm.Body = "Your new password is:" + Decrypt1;

        //                mm.IsBodyHtml = false;
        //                SmtpClient smtp = new SmtpClient();
        //                smtp.Host = "smtp.gmail.com";
        //                smtp.EnableSsl = true;
        //                NetworkCredential NetworkCred = new NetworkCredential("reliceco@gmail.com", "relic1234");
        //                smtp.UseDefaultCredentials = true;
        //                smtp.Credentials = NetworkCred;
        //                smtp.Port = 587;
        //                smtp.Send(mm);
        //                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        //            }
        //        }
        //        else
        //        {
        //            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('passwords does not match');", true);
        //        }
        //    }
        //    else
        //    {
        //        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Incorrect password');", true);
        //    }
        //}
    