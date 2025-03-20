using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace T4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomersConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //string s = Session["CustName"].ToString();
            //Label1.Text = s;

            HttpCookie c = Request.Cookies["nm"];
            string ab = c["CustName"];
            Label1.Text = ab;
        }
    }
}