using MySql.Data.MySqlClient;
using System.Data;

public class DBOldSchool
{

    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;
    private string connectionString;



    //Constructor
    public DBOldSchool()
    {
        Initialize();
    }
    public DBOldSchool(string server, string database, string uid, string password)
    {
        Initialize(server, database, uid, password);
    }

    //Initialize values
    private void Initialize()
    {

        server = "178.128.202.96";
        database = "Testas";
        uid = "TestUser";
        password = "TestasTesta5";
        connectionString = "SERVER=" + server + ";port=3306;" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Convert Zero Datetime=true;default command timeout=999;";

        connection = new MySqlConnection(connectionString);

    }
    private void Initialize(string server, string database, string uid, string password)
    {
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Convert Zero Datetime=true;default command timeout=999;";

        connection = new MySqlConnection(connectionString);

    }

    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public void OpenConnectionlong()
    {
        try
        {
            connection.Open();
        }
        catch
        {

        }
    }

    public DataSet SelectAll(string table)
    {
        string query = "SELECT * FROM " + table;

        MySqlDataAdapter adpt = new MySqlDataAdapter(query, connection);
        DataSet dset = new DataSet();
        adpt.Fill(dset);
        return dset;
    }

}