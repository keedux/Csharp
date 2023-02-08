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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

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
{ "Alexander Albon", 10 }, { "Logan Sargeant", 10 }, // Williams Drivers

};
        



        public MainMenu()
        {
            ReadConfig();
            dbcreation();
            sqlAutoUpdate();
            dictInserts();
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (KeyValuePair<string, int> driver in drivers)
            {
                comboBox1.Items.Add(driver.Key);
            }
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
            string query1 = "CREATE TABLE IF NOT EXISTS f1teams(id int, team varchar(25), constructorpoints int DEFAULT 0, CONSTRAINT pk_id PRIMARY KEY(id));";
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
            string query2 = "CREATE TABLE IF NOT EXISTS f1drivers(id int, driver varchar(25), teamid int, driverpoints int DEFAULT 0, CONSTRAINT pk_id PRIMARY KEY(id))";
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
        private void dictInserts()
        {
            MySqlConnection f1conn = sqlconn();
            f1conn.Open();
            foreach (KeyValuePair<string, int> team in teams)
            {
                try
                {
                    bool teamExists = false;
                    using (MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM f1teams WHERE team = @teamname", f1conn))
                    {
                        selectCommand.Parameters.AddWithValue("@teamname", team.Key);
                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                teamExists = true;
                            }
                        }
                    }

                    if (!teamExists)
                    {
                        using (MySqlCommand insertCommand = new MySqlCommand("INSERT INTO f1teams(id, team) VALUES(@teamid, @teamname)", f1conn))
                        {
                            insertCommand.Parameters.AddWithValue("@teamid", team.Value);
                            insertCommand.Parameters.AddWithValue("@teamname", team.Key);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


            int driverNumber = 1;
            foreach (KeyValuePair<string, int> driver in drivers)
            {
                try
                {
                    bool alreadyExists = false;
                    using (MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM f1drivers WHERE driver = @drivername", f1conn))
                    {
                        selectCommand.Parameters.AddWithValue("@drivername", driver.Key);
                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                alreadyExists = true;
                            }
                        }
                    }

                    if (!alreadyExists)
                    {
                        using (MySqlCommand insertCommand = new MySqlCommand("INSERT INTO f1drivers(id, driver, teamid) VALUES(@driverid, @drivername, @teamid)", f1conn))
                        {
                            insertCommand.Parameters.AddWithValue("@driverid", driverNumber);
                            insertCommand.Parameters.AddWithValue("@drivername", driver.Key);
                            insertCommand.Parameters.AddWithValue("@teamid", driver.Value);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                driverNumber++;
            }
        }
        private void sqlAutoUpdate()
        {
            MySqlConnection f1conn = sqlconn();
            f1conn.Open();
            string f1table = "INSERT INTO f1table(id, drivers, team, driverpoints, constructorpoints) SELECT f1drivers.id, f1drivers.driver, f1teams.team, 0 as driverpoints, 0 as constructorpoints FROM f1teams, f1drivers WHERE f1teams.id = f1drivers.teamid ORDER BY f1drivers.id ON DUPLICATE KEY UPDATE drivers = VALUES(drivers), team = VALUES(team), driverpoints = VALUES(driverpoints), constructorpoints = VALUES(constructorpoints)";
            try
            {
                using (MySqlCommand command = new MySqlCommand(f1table, f1conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("f1Table Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void TestConn_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection f1conn = sqlconn();
            f1conn.Open();
            sqlAutoUpdate();

        }

        private void ViewRec_btn_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection connection = sqlconn();
                connection.Open();
                string sql = "SELECT * FROM f1table";
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecViewer.Items.Add("==================");
                            RecViewer.Items.Add("Driver: " + reader["drivers"]);
                            RecViewer.Items.Add("Team: " + reader["team"]);
                            RecViewer.Items.Add("Driver Points: " + reader["driverpoints"]);
                            RecViewer.Items.Add("Constructor Points: " + reader["constructorpoints"]);
                            RecViewer.Items.Add("==================");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to retrieve record");
            }


        }


        private void AddRec_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection f1conn = sqlconn();
            f1conn.Open();



            using (MySqlCommand command = new MySqlCommand("UPDATE f1drivers SET driverpoints = driverpoints + @points WHERE f1drivers.driver = @driver", f1conn))
            {
                command.Parameters.AddWithValue("@points", textBox1.Text);
                command.Parameters.AddWithValue("@driver", comboBox1.Text);

                command.ExecuteNonQuery();
                Console.WriteLine("Driver Points Updated");
            }



            Console.WriteLine(comboBox1.Text);
            Console.WriteLine(textBox1.Text);
            string updateDriverPoints = "UPDATE f1table SET driverpoints = (SELECT driverpoints FROM f1drivers WHERE f1drivers.driver = f1table.drivers)";
            try
            {
                using (MySqlCommand command = new MySqlCommand(updateDriverPoints, f1conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Driver Points Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            string updateConstructorPoints = "UPDATE f1teams SET constructorpoints = (SELECT SUM(driverpoints) FROM f1drivers WHERE f1drivers.teamid = f1teams.id)";
            try
            {
                using (MySqlCommand command = new MySqlCommand(updateConstructorPoints, f1conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Constructor points updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            string tableConstructorPoints = "UPDATE f1table SET constructorpoints = (SELECT constructorpoints FROM f1teams WHERE f1teams.team = f1table.team)";
            try
            {
                using (MySqlCommand command = new MySqlCommand(tableConstructorPoints, f1conn))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("f1table Constructor Points Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
