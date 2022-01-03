using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole
{
    public partial class login : System.Web.UI.Page
    {
        static UserFunctions userFunctions = new UserFunctions();
        static UserDataServiceContext userSVC;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSVC = userFunctions.ConnectToTable("UserTable");
        }

        //login button
        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = loginEmail.Text;
            string password = loginPassword.Text;

            var query = userSVC.CreateQuery<User>("UserTable").Where(user => (user.email == email && user.password == password));
            try
            {
                User user = query.First();
                Response.Redirect("dashboard.aspx?nickname=" + user.nickname);
            }
            catch (Exception)
            {
                errorLabel.Text = "Wrong email or password";
            }
        }

        //signup button
        protected void Button2_Click(object sender, EventArgs e)
        {
            string nickname = signupNickname.Text;
            string email = signupEmail.Text;
            string password = signupPassword.Text;

            var query = userSVC.CreateQuery<User>("UserTable").Where(user => (user.email == email || user.nickname == nickname));

            try
            {
                User user = query.First();
                errorLabel.Text = "User already exist, try to change email and nickname";
            }
            catch(Exception)
            {
                userSVC.AddObject("UserTable", new User(nickname, email, password));
                userSVC.SaveChanges();
                Response.Redirect("dashboard.aspx?nickname="+nickname);
            }
        }
    }
}