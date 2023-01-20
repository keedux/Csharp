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

namespace Login_Screen
{
    public partial class signup : Form
    {
        public signup()
        {
            
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string needID = "UserID";
            string needPassword = " Password";
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Must input a " + needID + " and" + needPassword);
                Console.WriteLine("Need UID and password");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Must input a " + needID);
                Console.WriteLine("Need UID");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Must input a" + needPassword);
                Console.WriteLine("Need Password");

            }
            else if (textBox2.TextLength < 8)
            {
                MessageBox.Show("password must be longer than 8 characters");
            }
            else if (!textBox2.Text.Any(char.IsUpper))
            {
                MessageBox.Show("Must contain at least one upper case character");
            }
            else if (textBox2.Text.Any(char.IsWhiteSpace))
            {
                MessageBox.Show("must not contain spaces");
            }
            else if (!textBox2.Text.Any(Char.IsDigit))
            {
                MessageBox.Show("must contain at least one number");
            }
            else if (!textBox2.Text.Any(Char.IsPunctuation))
            {
                MessageBox.Show("must contain at least one Special character");
            }
            else
            {
                string connStr = "server=localhost;user=root;database=dbsignup;port=3306;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();
                        string sql = "INSERT INTO `tblusers`(`userid`, `password`) VALUES (@userid, @password)";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@userid", textBox1.Text);
                            cmd.Parameters.AddWithValue("@password", textBox2.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Welcome!");
                                Console.WriteLine("Entering Main Screen");
                                this.Hide();
                                MainScreen frm2 = new MainScreen();
                                frm2.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Entering Main Screen");
            this.Hide();
            login frm3 = new login();
            frm3.Show();
        }
    }
}
