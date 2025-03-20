using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace T3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeesConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            print();
        }

        public void print()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [EmpName], [DateOfBirth], [Department], [ProfileImage] FROM [Emp]", con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Emp] ([EmpName], [DateOfBirth], [Department], [ProfileImage]) VALUES (@EmpName, @DateOfBirth, @Department, @ProfileImage)", con);
            cmd.Parameters.AddWithValue("EmpName", TextBox1.Text);
            cmd.Parameters.AddWithValue("DateOfBirth", TextBox2.Text);
            cmd.Parameters.AddWithValue("Department", TextBox3.Text);
            cmd.Parameters.AddWithValue("ProfileImage", FileUpload1.FileName);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();

            if (r == 1)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                FileUpload1.SaveAs(Server.MapPath("Upload\\"+FileUpload1.FileName));
                Label1.Text = "Data inserted";
                print();
            }
        }
    }
}