using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for DBManager
/// </summary>
public class DBManager
{
    private static ConnectionManager connManager = ConnectionManager.getInstance();
    private static MySqlConnection conn = connManager.getConnection();
    private static MySqlCommand cmd = new MySqlCommand();
    private static int lastPersonId;

    public DBManager()
    {
        /*cmd.CommandText = "SELECT count(person_id) AS number_of_people FROM PERSON";
        cmd.Connection = conn;
        using(conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    MySqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    person_id = reader.GetInt32("number_of_people");
                    person_id++;
                }
            } catch(MySqlException ex)
            {
                Console.WriteLine("Count person error, details: " + ex.Message);
            }
        }*/
    }

    public static void fixAutoIncreament()
    {
        cmd.Parameters.Clear();
        cmd.CommandText = " ALTER TABLE person AUTO_INCREMENT = ?person_count";// + person_id;
        cmd.Connection = conn;
        conn.Open();

        using (conn)
        {
            try
            {
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("?person_count", MySqlDbType.Int64).Value = lastPersonId;
                    cmd.ExecuteNonQuery();
                }
            } catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public static string AddPerson(string fname, string lname, char gender, int person_role, DateTime DOB, string phone, string email, string address)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "Insert into PERSON (person_role_id, first_name, last_name, gender, DOB, phone, email, address)" +
                "values (?role, ?first, ?last, ?gender, ?dob, ?ph, ?email, ?addr)";
        cmd.Connection = conn;
        conn.Open();
        string failedMessage = "";
        using (conn)
        {
            try
            {
                using (cmd)
                {

                    cmd.Parameters.Add("?role", MySqlDbType.Int32).Value = person_role;
                    cmd.Parameters.Add("?first", MySqlDbType.VarChar).Value = fname;
                    cmd.Parameters.Add("?last", MySqlDbType.VarChar).Value = lname;
                    cmd.Parameters.Add("?gender", MySqlDbType.VarChar).Value = gender;

                    cmd.Parameters.Add("?dob", MySqlDbType.Date).Value = DOB.Date;
                    cmd.Parameters.Add("?ph", MySqlDbType.VarChar).Value = phone;
                    cmd.Parameters.Add("?email", MySqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("?addr", MySqlDbType.VarChar).Value = address;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert in person details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            lastPersonId = getPersonID(email);
            return "Successfully added to person table";
        }
        else
        {
            return failedMessage;
        }
    }

    private static int getPersonID(string email)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "SELECT person_id FROM person WHERE email = ?theEmail";
        cmd.Connection = conn;
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?theEmail", MySqlDbType.VarChar).Value = email;
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();

                        lastPersonId = int.Parse(reader.GetString(0));
                    }
                }
                  
            } catch(MySqlException ex)
            {
                string error = ex.Message;
            }
        }
        return lastPersonId;
    }

    public static string AddDoctor(string position)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO Doctor (doctor_id, the_position)" +
            "VALUES (?doctor_id, ?position)";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?doctor_id", MySqlDbType.Int64).Value = lastPersonId;
                    cmd.Parameters.Add("?position", MySqlDbType.VarChar).Value = position;

                    cmd.ExecuteNonQuery();
                }
            } catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully added to Doctor table";
        }
        else
        {
            return failedMessage;
        }
    }

    /**
     * This should only be called after adding a person. else foreign key constraint will fail.
     * */
    public static string AddEmployee(DateTime hireDate, int salary, int employee_role_id)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO EMPLOYEE (employee_id, employee_role_id, hire_date, salary)" +
            "VALUES (?person_id, ?employee_role_id, ?hire_date, ?salary)";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
           try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?person_id", MySqlDbType.Int64).Value = lastPersonId;
                    cmd.Parameters.Add("?employee_role_id", MySqlDbType.VarChar).Value = employee_role_id;
                    cmd.Parameters.Add("?hire_date", MySqlDbType.Date).Value = hireDate.Date;
                    cmd.Parameters.Add("?salary", MySqlDbType.Int32).Value = salary;
              
                    cmd.ExecuteNonQuery();
                }
            }catch(MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully added to employee table";
        }
        else
        {
            return failedMessage;
        }
    }

    public static string AddAddress(string city, string state)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO Address (person_id, city, state)" +
           "VALUES (?id, ?city, ?state)";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?id", MySqlDbType.Int64).Value = lastPersonId;
                    cmd.Parameters.Add("?city", MySqlDbType.VarChar).Value = city;
                    cmd.Parameters.Add("?state", MySqlDbType.VarChar).Value = state;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully added Person's address";
        }
        else
        {
            return failedMessage;
        }
    }

    public static string AddPatient(float height, float weight)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO patient (patient_id, height_inches, weight_Pounds)" +
           "VALUES (?patient_id, ?height, ?weight)";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?patient_id", MySqlDbType.Int64).Value = lastPersonId;
                    cmd.Parameters.Add("?height", MySqlDbType.Float).Value = height;
                    cmd.Parameters.Add("?weight", MySqlDbType.Float).Value = weight;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully added to Patient table";
        }
        else
        {
            return failedMessage;
        }
    }

    public static string AddNurse(string qualification)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO Nurse (nurse_id, qualification)" +
           "VALUES (?nurse_id, ?qualification)";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?nurse_id", MySqlDbType.Int64).Value = lastPersonId;
                    cmd.Parameters.Add("?qualification", MySqlDbType.VarChar).Value = qualification;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully added to Nurse table";
        }
        else
        {
            return failedMessage;
        }
    }

    public static string AddPatientRecord(int patientID, int doc, int nurse, DateTime dateEntered)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO PATIENT_RECORD (patient_id, date_admitted, nurse_visited_id, doctor_visited_id)" +
           "VALUES (?patient_id, ?date, ?nurse_id, ?doc_id)";
        cmd.Connection = conn;
        string failedMessage = "";

        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?patient_id", MySqlDbType.Int64).Value = patientID;
                    cmd.Parameters.Add("?date", MySqlDbType.Date).Value = dateEntered.Date;
                    cmd.Parameters.Add("?nurse_id", MySqlDbType.Int64).Value = nurse;
                    cmd.Parameters.Add("?doc_id", MySqlDbType.Int64).Value = doc;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully created patient record";
        }
        else
        {
            return failedMessage;
        }
    }

    public static string AssignRoom(int patientID, int room)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "UPDATE ROOM SET patient_id = ?new_patient WHERE room_number = ?room;";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?new_patient", MySqlDbType.Int64).Value = patientID;
                    cmd.Parameters.Add("?room", MySqlDbType.Int16).Value = room;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully updated room record";
        }
        else
        {
            return failedMessage;
        }
    }

    public static string AddRoom(string facilities, int numBeds)
    {
        cmd.Parameters.Clear();
        cmd.CommandText = "INSERT INTO room (facilities, num_of_beds)" +
           "VALUES (?facili, ?beds)";
        cmd.Connection = conn;
        string failedMessage = "";

        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?facili", MySqlDbType.VarChar).Value = facilities;
                    cmd.Parameters.Add("?beds", MySqlDbType.Int16).Value = numBeds;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully added Bed table";
        }
        else
        {
            return failedMessage;
        }
    }

    /**
     * Runs the sql query in dataText and returns the table in a data table.
     * If the sql query fails, it returns the failed message.
     * */
    public static object GetData(string dataText)
    {
        cmd.CommandText = dataText;
        cmd.Connection = conn;
        DataTable dt = new DataTable();
        string error ="";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (dt)
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch(MySqlException ex)
            {
                error = ex.Message;
            }
        }
        if (dt.Rows.Count == 0) { return error; }
        else { return dt; }
       
    }


    public static string DeleteRowID(int id)
    {
        cmd.Parameters.Clear();

        cmd.CommandText = "DELETE FROM person where person_id = ?the_ID;";
        cmd.Connection = conn;
        string failedMessage = "";
        using (conn)
        {
            conn.Open();
            try
            {
                using (cmd)
                {
                    cmd.Parameters.Add("?the_ID", MySqlDbType.Int64).Value = id;
                   
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                failedMessage = "failed insert details: " + ex.Message;
            }
        }
        if (failedMessage.Count() == 0)
        {
            return "Successfully deleted person " + id;
        }
        else
        {
            return failedMessage;
        }
    }

}
