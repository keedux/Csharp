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

        public MainMenu()
        {
            ReadConfig();
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

        private void TestConn_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection f1conn = sqlconn();
            f1conn.Open();
            
        }

        private void ViewRec_btn_Click(object sender, EventArgs e)
        {

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
