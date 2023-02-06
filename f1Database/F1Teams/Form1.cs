using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace F1Teams
{
    public partial class MainMenu : Form
    {
        private string host;
        private string username;
        private string password;
        private string database;
        // Tables
        Dictionary <string, int> teams = new Dictionary<string, int> { { "Mercedes", 1 }, { "Redbull", 2 }, { "Ferrari", 3 }, { "Alphatauri", 4 }, { "Aston Martin", 5 }, { "Haas", 6 }, { "Alpine", 7 },  { "Mclaren", 8 }, { "Alfa Romeo", 9 }, { "Williams", 10 } };
        Dictionary<string, int> drivers = new Dictionary<string, int> {
{ "Lewis Hamilton", 1 }, {"George Russell", 1 }, // Mercedes Drivers
{ "Max Verstappen", 2 }, {"Sergio Perez", 2 }, // Redbull Drivers
{ "Charles Leclerc", 3 },{ "Carlos Sainz", 3 }, // Ferrari Drivers
{ "Nyck De Vris", 4 },{ "Yuki Tsunoda", 4 }, // Alphatauri Drivers
{ "Fernando Alonso", 5 }, { "Lance Stroll", 5 }, // Aston Martin Drivers
{ "Kevin Megnussen", 6 } , { "Nico Hulkenburg", 6 }, // Haas Drivers
{ "Pierre Galsy", 7 }, { "Esteban Ocon", 7 }, // Alpine Drivers
{ "Oscar Piestri", 8 }, {"Lando Norris", 8 }, // Mclaren Drivers
{ "Valtteri Bottas", 9 }, { "Guanyu Zhou",  9 }, // Alfa Romeo Drivers
{ "Alexander Albon", 10 }, { "Logan Sargeant", 10 } // Williams Drivers
};

        public MainMenu()
        {
            ReadConfig();
            dbcreation();
            InitializeComponent();
        }
        private void ReadConfig()
        {
            if (File.Exists("config.txt"))
            {  
                string[] lines = File.ReadAllLines("config.txt");
                foreach(string line in lines)
                {
                    if (line.StartsWith("host="))
                    {
                        host = line.Substring(5);
                    }
                    else if (line.StartsWith("username="))
                    {
                        username = line.Substring(9);
                    }
                    else if (line.StartsWith("password="))
                    {
                        password = line.Substring(9);
                    }
                    else if (line.StartsWith("database="))
                    {
                        database = line.Substring(9);
                    }
                }
            }
            else
            {
                Process.Start("C:/Users/s242534.CENTRALSUSSEX/OneDrive - Chichester College Group/Csharp/config.py");
                Environment.Exit(0);
            }
        }
        private MySqlConnection sqlconn()
        {
            string connStr = $"server={host};user={username};password={password};database={database}";
            using (MySqlConnection gradesconn = new MySqlConnection(connStr))
            {
                try
                {
                    gradesconn.Open();
                    Console.WriteLine("Connected");
                }
                catch
                {
                    MessageBox.Show("Connection Failed");
                }
                return gradesconn;
            }
        }
        private void dbcreation()
        {
            MySqlConnection f1conn = sqlconn();
            
            // Create first table
            string query1 = "CREATE TABLE IF NOT EXISTS f1teams(id int, team varchar(25), CONSTRAINT pk_id PRIMARY KEY(id))";
            using (MySqlCommand command = new MySqlCommand(query1, f1conn))
            {
                f1conn.Open();
                try
                {
                    
                    command.ExecuteNonQuery();
                    Console.WriteLine("f1teams Created");
                }
                catch
                {
                    MessageBox.Show("Failed To f1teams Table");
                }
            }
            // Create Second table
            string query2 = "CREATE TABLE IF NOT EXISTS f1drivers(id int, driver varchar(25), CONSTRAINT pk_id PRIMARY KEY(id))";
            using (MySqlCommand command = new MySqlCommand(query2, f1conn))
            {
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("f1driver Created");
                }
                catch
                {
                    MessageBox.Show("Failed To f1drivers Table");
                }
            }
            // Create Third table
            string query3 = "CREATE TABLE IF NOT EXISTS f1table(id int, drivers varchar(25), team varchar(25), driverpoints int, constructorpoints int, fastestlap bool,  CONSTRAINT pk_id PRIMARY KEY(id))";
            using (MySqlCommand command = new MySqlCommand(query3, f1conn))
            {
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("f1table Created");
                }
                catch
                {
                    MessageBox.Show("Failed To f1 Table");
                }
            }
        }

        private void TestConn_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection f1conn = sqlconn();
            f1conn.Open();
            
        }

        private void ViewRec_btn_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> driver in drivers)
            {
                foreach (KeyValuePair<string, int> team in teams)
                {
                    if (driver.Value == team.Value)
                    {
                        Console.WriteLine(driver.Key + " - " + team.Key);
                        break;
                    }
                }
            }
        }


        private void AddRec_btn_Click(object sender, EventArgs e)
        {

        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
