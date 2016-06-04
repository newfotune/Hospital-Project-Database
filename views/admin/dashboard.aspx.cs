using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class views_admin_dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Dashboard";

    } 
    public void SearchQuery(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:53523/views/admin/info.aspx?query="+query.Value);
    }
}