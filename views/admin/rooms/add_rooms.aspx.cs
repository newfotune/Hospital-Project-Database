using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_admin_rooms_add_rooms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void add_click(object sender, EventArgs e)
    {
        string _description = description.Text;
        int _num_of_beds = int.Parse(numBeds.Value);

        error.InnerHtml = "";
        CheckSuccess(DBManager.AddRoom(_description,_num_of_beds), "Rooms");
    }

    private void CheckSuccess(string msg, string adder)
    {
        error.InnerHtml += msg + " <br />";
    }
}