using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for ConnectionManager
/// </summary>
/// 
 /*  SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=SampleDatabase; user=sa; password=fortune1566");
        conn.Open();
        if (conn.State==System.Data.ConnectionState.Open)
        {
            blah.InnerText= "it opned!!!";
        }else
        {
            blah.InnerText = "nah:(";
        }*/
public class ConnectionManager
{
    private static ConnectionManager instance = null;
    private MySqlConnection conn;
    
    //singletons cant be created outside this class.
    private ConnectionManager(){}
    
    /**
     * returns the connection instance.
     * */
    public static ConnectionManager getInstance()
    {
        if (instance == null)
            instance = new ConnectionManager();

        return instance;
    }

    /**
     * Returns true if the connection is open adn false otherwise
     * */
    private void setUpConnection()
    {
        try
        {
            conn = new MySqlConnection("server = localhost; user id = root; pwd = fortune1566; database = nwoke_chiemeziem_db");

        } catch(MySqlException e)
        {
            e.Message.ToString();
        }
    }

    /**
     * This opens and gets our current SQL conection. 
     *
     * */
    public MySqlConnection getConnection()
    {
        setUpConnection();
        return conn;
    }

    public void close()
    {
        try
        {
            conn.Close();
        } catch(MySqlException e)
        {
            e.Message.ToString();
        }
    }
}