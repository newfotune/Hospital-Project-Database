using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*  SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=SampleDatabase; user=sa; password=fortune1566");
          conn.Open();
          if (conn.State==System.Data.ConnectionState.Open)
          {
              blah.InnerText= "it opned!!!";
          }else
          {
              blah.InnerText = "nah:(";
          }*/
        Response.Redirect("http://localhost:53523/views/admin/dashboard.aspx");
    }


    /* protected void Login_Click(object sender, EventArgs e)
     {
        if ( DBManager.CheckUser(email_box.Value, pass_box.Value))
         {
             blah.InnerText = "Login Successful";

         } else
         {
             blah.InnerText = "Login failed";
         }
     }*/
    protected void Login_Click(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        blah.InnerText = "Register";
    }
}