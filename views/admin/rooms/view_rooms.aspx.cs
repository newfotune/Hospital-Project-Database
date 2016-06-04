using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class views_admin_rooms_ViewRooms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loadUpTable();
    }

    private void loadUpTable()
    {
        Object theObject = DBManager.GetData("SELECT room_number, facilities, num_of_beds, room.patient_id AS PATIENT " +
                                            "FROM room LEFT JOIN patient "+ 
                                            "ON room.patient_id = patient.patient_id");
        //Building an HTML string.
        StringBuilder html = html = new StringBuilder();

        if (theObject is DataTable)
        {
            //Populating a DataTable from database.
            DataTable dt = (DataTable)theObject;

            //Table start.
            html.Append("<table>");

            //Building the Header row.
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");
        }
        else
        {
            html.Append((String)theObject);
        }

        //Append the HTML string to Placeholder.
        display.Controls.Add(new Literal { Text = html.ToString() });
    }

    protected void DeleteID(object sender, EventArgs e)
    {
        CheckSuccess(DBManager.DeleteRowID(int.Parse(delete_box.Value)));
        display.InnerHtml = "";
        loadUpTable();
    }

    private void CheckSuccess(string msg)
    {
        delete_box.Value = "";
        error.InnerHtml += msg + " <br />";
    }
}