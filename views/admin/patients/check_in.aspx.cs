using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_Admin_Patients_admin_patient_remove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {}

    protected void add_click(object sender, EventArgs e)
    {
        int _docAssigned = int.Parse(DoctorAssigned.Value);

        string[] date = DateAdmitted.Value.Split('-');
        DateTime _admitted = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));

        int _room = int.Parse(RoomAssigned.Value);
        int _nurse = int.Parse(nurse.Value);

        error.InnerHtml = "";
        CheckSuccess(DBManager.AddPatientRecord(int.Parse(id.Value), _docAssigned,_nurse, _admitted));
        CheckSuccess(DBManager.AssignRoom(int.Parse(id.Value), _room));
    }

    private void CheckSuccess(string msg)
    {
        error.InnerHtml += msg + " <br />";
    }
}