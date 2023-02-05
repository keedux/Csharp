using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using static System.Net.Mime.MediaTypeNames;

namespace grades
{

    public partial class Form1 : Form
    {
        private bool addbtnWasClicked = false;
        private bool delbtnWasClicked = false;
        private string host;
        private string username;
        private string password;
        private string database;
        public Form1()
        {
            ReadConfig();
            InitializeComponent();
            
        }
        
        private void ReadConfig()
        {
            if (File.Exists("config.txt")){
                string[] lines = File.ReadAllLines("config.txt");
                foreach (string line in lines)
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
                Process.Start("C:/Users/keedu/OneDrive - Chichester College Group/Csharp/Grades System/grades/config.py");
                Environment.Exit(0);
            }
        }

        public MySqlConnection sqlconn()
        {
            string connStr = $"server={host};user={username};password={password};database={database};";
            Console.WriteLine(connStr);
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

        private void addbtn_Click(object sender, EventArgs e)
        {
            candidatenum.Visible = true;
            paper1.Visible = true;
            paper2.Visible = true;
            candidatelbl.Visible = true;
            paper1lbl.Visible = true;
            paper2lbl.Visible = true;
            insertrecord.Visible = true;
            addbtnWasClicked = true;
            if (delbtnWasClicked == true)
            {
                CandidateDel_lable.Visible = false;
                CandidateDel_txtbox.Visible = false;
                DelRecord_btn.Visible = false;
            }
        }
        

        private void viewbtn_Click(object sender, EventArgs e)
        {
            recordclearbtn.Visible = true;
            
            try
            {
                MySqlConnection connection = sqlconn();
                connection.Open();
                string sql = "SELECT * FROM tblgrades";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                       using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recordviewer.Items.Add("==================");
                                recordviewer.Items.Add("Candidate Number: " + reader["candidatenum"]);
                                recordviewer.Items.Add("Paper 1: " + reader["paper1"]);
                                recordviewer.Items.Add("Paper 2: " + reader["paper2"]);
                                recordviewer.Items.Add("Final Grade: " + reader["finalgrade"]);
                                recordviewer.Items.Add("==================");
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to retrieve record");
                }
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            sqlconn();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void recordviewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void insertrecord_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = sqlconn();
            

            int tempcandidatenum = int.Parse(candidatenum.Text);
            int tempPaper1 = int.Parse(paper1.Text);
            int tempPaper2 = int.Parse(paper2.Text);
            int total = tempPaper1 + tempPaper2;
            string finalgrade = "";

            if (total == 100) 
            {
                Console.WriteLine("A*");
                 finalgrade = "A*";
            }
            else
            if (total <= 100 & total > 90) 
            { 
                Console.WriteLine("A");
                 finalgrade = "A";

            }
            else
            if (total <= 90 & total > 70)
            { 
                Console.WriteLine("B");
                 finalgrade = "B";

            }
            else
            if (total <= 70 & total > 60)
            {
                Console.WriteLine("C");
                 finalgrade = "C";

            }
            else
            if (total <= 60 & total > 40)
            {
                Console.WriteLine("D");
                 finalgrade = "D";

            }
            else
            if(total < 40)
            {
                Console.WriteLine("U");
                 finalgrade = "U";

            }
            Console.WriteLine(total);

            connection.Open();
            if (total > 100)
            {
                MessageBox.Show("the total for both papers cannot be greater than 100");
                return;
            }
            string sql = "INSERT INTO tblgrades VALUES (@candidatenum, @paper1, @paper2, @finalgrade)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@candidatenum", tempcandidatenum);
            cmd.Parameters.AddWithValue("@paper1", tempPaper1);
            cmd.Parameters.AddWithValue("@paper2", tempPaper2);
            cmd.Parameters.AddWithValue("@finalgrade", finalgrade);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added");
            candidatenum.Clear();
            paper1.Clear();
            paper2.Clear();
            recordviewer.Items.Clear();
            recordclearbtn.Visible = false;

        }

        private void recordclearbtn_Click(object sender, EventArgs e)
        {
            recordviewer.Items.Clear();
            recordclearbtn.Visible = false;
        }
        private void CandidateDel_txtbox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void DelRecord_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = sqlconn();
            
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string sql = "SELECT `candidatenum` FROM `tblgrades` WHERE `candidatenum` = " + CandidateDel_txtbox.Text;
                    Console.WriteLine(CandidateDel_txtbox.Text);
                    bool valid = false;

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (CandidateDel_txtbox.Text == reader["candidatenum"].ToString())
                                {
                                    valid = true;
                                }
                            }
                        }
                        if (valid == true)
                        {
                            sql = "DELETE FROM `tblgrades` WHERE `candidatenum` = " + CandidateDel_txtbox.Text;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted!");
                                        recordviewer.Items.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Record not found.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Record failed to delete.");
            }
        }
        private void deletedbt_Click(object sender, EventArgs e)
        {
            delbtnWasClicked = true;
            CandidateDel_lable.Visible = true;
            CandidateDel_txtbox.Visible = true;
            DelRecord_btn.Visible = true;
            
            if (addbtnWasClicked == true)
            {
                candidatenum.Visible = false;
                paper1.Visible = false;
                paper2.Visible = false;
                candidatelbl.Visible = false;
                paper1lbl.Visible = false;
                paper2lbl.Visible = false;
                insertrecord.Visible = false;
                addbtnWasClicked = false;
            }

        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
