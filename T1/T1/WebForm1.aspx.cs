using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace T1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            print();
        }
        public void print()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [Name], [Age], [Grade] FROM [student]", con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Button1.Text=="Save")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [student] ([Name], [Age], [Grade]) VALUES (@Name, @Age, @Grade)", con);
                cmd.Parameters.AddWithValue("Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("Age", TextBox2.Text);
                cmd.Parameters.AddWithValue("Grade", TextBox3.Text);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                con.Close();

                if (r == 1)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    Label1.Text = "Data inserted";
                    print();
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE [student] SET [Name] = @Name, [Age] = @Age, [Grade] = @Grade WHERE [Id] = @Id", con);
                cmd.Parameters.AddWithValue("Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("Age", TextBox2.Text);
                cmd.Parameters.AddWithValue("Grade", TextBox3.Text);
                cmd.Parameters.AddWithValue("Id", ViewState["Id"]);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                con.Close();

                if (r == 1)
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    Label1.Text = "Data updated";
                    print();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlCommand cmd = new SqlCommand("DELETE FROM [student] WHERE [Id] = @Id", con);
            cmd.Parameters.AddWithValue("Id", btn.CommandArgument);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            con.Close();
            if(r==1)
            {
                Label1.Text = "Data deleted";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [Name], [Age], [Grade] FROM [student] WHERE [Id] ="+btn.CommandArgument, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            TextBox1.Text = dt.Rows[0][1].ToString();
            TextBox2.Text = dt.Rows[0][2].ToString();
            TextBox3.Text = dt.Rows[0][3].ToString();
            ViewState["Id"] = btn.CommandArgument;
            Button1.Text = "Update";
        }
    }
}