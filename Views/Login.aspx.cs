using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBookShop.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con= new Models.Functions();
        }
        public static string UName = "";
        public static int User = 3;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UnameTb.Value==""|| PasswordTb.Value == "")
            {
                ErrMsg.Text = "Specify all the mentioned Details!!";
            }
            else if(UnameTb.Value=="admin@gmail.com" && PasswordTb.Value=="Password")
            {
                Response.Redirect("Admin/Books.aspx");
            }
            else
            {
                string Query = "Select * from SelTbl where SelEmail ='{0}' and SelPass='{1}'";
                Query = string.Format(Query, UnameTb.Value,PasswordTb.Value);
                DataTable dt= Con.GetData(Query);
                if(dt.Rows.Count == 0)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    UName = UnameTb.Value;
                    User= Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Selling.aspx");

                }
            }
        }
    }
}