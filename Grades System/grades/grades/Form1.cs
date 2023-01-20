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
            main();
        }

        private static void main()
        {
            string connStr = "server=localhost;user=root;database=grades";
            using (MySqlConnection gradesconn = new MySqlConnection(connStr))
            {
                try
                {
                    gradesconn.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS tblgrades(candidatenum int, paper1 int, paper2 int, finalgrade char, CONSTRAINT pk_candidatenum PRIMARY KEY(candidatenum))";
                    using(MySqlCommand cmd = new MySqlCommand(sql, gradesconn))
                    {
                        cmd.ExecuteNonQuery();
                    }                   
                }
                catch
                {
                    MessageBox.Show("Table Failed Creation");
                }
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
            string connStr = "server=localhost;user=root;database=grades";
            using (MySqlConnection gradesconn = new MySqlConnection(connStr))
            {
                try
                {
                    gradesconn.Open();
                    string sql = "SELECT * FROM tblgrades";
                    using (MySqlCommand cmd = new MySqlCommand(sql, gradesconn))
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
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;";
            using (MySqlConnection gradesconn = new MySqlConnection(connStr))
            {
                try
                {
                    gradesconn.Open();
                    if (gradesconn.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Connection Successful");
                    }
                    string sql = "CREATE DATABASE IF NOT EXISTS grades";
                    using (MySqlCommand cmd = new MySqlCommand(sql, gradesconn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Connection Failed");
                }
            }
            
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
            string tblconnection = "server=localhost;user=root;database=grades";

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

            string connStr = tblconnection;
            MySqlConnection gradesconn = new MySqlConnection(connStr);
            gradesconn.Open();
          if (total > 100)
            {
                MessageBox.Show("the total for both papers cannot be greater than 100");
                return;
            }
            string sql = "INSERT INTO tblgrades VALUES (@candidatenum, @paper1, @paper2, @finalgrade)";
            MySqlCommand cmd = new MySqlCommand(sql, gradesconn);
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

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connStr = "server=localhost; user=root;database=grades";
            using (MySqlConnection gradesconn = new MySqlConnection(connStr))
            {
                try
                {
                    gradesconn.Open();
                    if()
                    {

                    }
                    else
                    {

                    }
                }
                catch
                {

                }
            }
        }
    }
}
