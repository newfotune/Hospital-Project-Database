using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_admin_info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = Request.QueryString["query"];
        int ID = 0;

        if (int.TryParse(query, out ID))
        {
            SearchID(ID);
        } 
        else if (query is String)
        {
            SearchEmail(query);
        }

    }

    private void SearchEmail(string email)
    {

    }

    private void SearchID(int ID)
    {
        
        /*string theSql = "SELECT * FROM person where person_id = ?theID;";
        MySqlCommand cmd = new MySqlCommand(theSql);

        cmd.Parameters.Add("?theID", MySqlDbType.Int64).Value = ID;

        Object theTable = DBManager.GetDataReader(cmd);

        if (theTable is string)
        {
            error.InnerText = (string)theTable;
        }
        else
        {
            MySqlDataReader reader = (MySqlDataReader)theTable;
            if (!reader.HasRows)
            {
                result.InnerHtml = "Person Doesnt Exist in database";
            }
            else
            {
                result.InnerHtml = reader.GetString("first_name");
            }
        }*/
    }

    public void GoBack(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53523/views/admin/dashboard.aspx");
    }
}