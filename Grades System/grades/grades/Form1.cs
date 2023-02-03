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
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace grades
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public static MySqlConnection sqlconn()
        {
            string connStr = "server=localhost;user=root;database=grades";
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

        private void deletedbt_Click(object sender, EventArgs e)
        {
            string[] separators = new string[] { ",", ".", "!", "\'", " ", "\'s" };
            string text = recordviewer.GetItemText(recordviewer.SelectedItem);

            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string wordnew = (words[words.Length - 1]);
            Console.WriteLine(wordnew);

            MySqlConnection connection = sqlconn();
            
                try
                {
                    connection.Open();
                    if(connection.State == ConnectionState.Open)
                    {
                    string sql = "DELETE FROM `tblgrades` WHERE `candidatenum` = " + wordnew;
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    Console.WriteLine(wordnew);
                    bool valid = false;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            if (wordnew == reader["candidatenum"].ToString())
                            {
                                valid = true;
                            }
                            
                        }
                    }
                    if (valid == true)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Record not exist ig");
                    }


                }
            }
                catch
                {
                    MessageBox.Show("Record failed to delete");
                }
            
            

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            
        }

    }
}
