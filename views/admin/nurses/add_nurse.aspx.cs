using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_Admin_Nurses_admin_nurses_add : System.Web.UI.Page
{
    private DBManager manager;
    protected void Page_Load(object sender, EventArgs e)
    {
        manager = new DBManager();
        if (!IsPostBack)
        {
            LoadUpDropDowns();
        }
    }

    private void LoadUpDropDowns()
    {
        //List<ListItem> items = new List<ListItem>();
        gender.Items.Add(new ListItem("Male"));
        gender.Items.Add(new ListItem("Female"));
        gender.Items.Add(new ListItem("Dont Wish to answer"));

        string[] theStates = {
                "Alabama","Alaska","Arizona","Arkansas","California","Colorado","Connecticut","Delaware","Florida","Georgia","Hawaii","Idaho",
                "Illinois","Indiana","Iowa","Kansas","Kentucky","Louisiana","Maine","Maryland","Massachusetts","Michigan","Minnesota","Mississippi",
                "Missouri","Montana","Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","New York","North Carolina",
                "North Dakota","Ohio","Oklahoma","Oregon","Pennsylvania","Rhode Island","South Carolina","South Dakota","Tennessee","Texas","Utah",
                "Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming"};

        foreach (string a in theStates)
        {
            states.Items.Add(new ListItem(a));
        }
    }

    protected void add_click(object sender, EventArgs e)
    {
        string _fname = f_name.Value;
        string _lname = l_name.Value;
        string _email = email.Text;
        char _gender = gender.SelectedValue[0];

        string[] dateString = DOB.Text.Split('-');
        DateTime _DOB = new DateTime(int.Parse(dateString[0]), int.Parse(dateString[1]), int.Parse(dateString[2]));
        string _phone = phone.Value;

        string[] hireDateString = hiredate.Value.Split('-');
        DateTime _hireDate = new DateTime(int.Parse(hireDateString[0]), int.Parse(hireDateString[1]), int.Parse(hireDateString[2]));

        int _salary = int.Parse(salary.Value);
        string _address = address.Text;

        string _state = states.Text;
        string _qualification = qualifications.Value;
        string _city = city.Value;

        error.InnerHtml = "";
        CheckSuccess(DBManager.AddPerson(_fname, _lname, _gender, 1, _DOB, _phone, _email, _address), "Person");
        // DBManager.fixAutoIncreament();
        CheckSuccess(DBManager.AddEmployee(_hireDate, _salary, 2), "Employee");
        // DBManager.fixAutoIncreament();
        CheckSuccess(DBManager.AddNurse(_qualification), "Nurse");
        // DBManager.fixAutoIncreament();
        CheckSuccess(DBManager.AddAddress(_city, _state), "Address");
    }

    private void CheckSuccess(string msg, string adder)
    {
        error.InnerHtml += msg + " <br />";
    }
}