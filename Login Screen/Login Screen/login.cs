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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string tempPassword;
            MySqlConnection connection;

            string myConnectionString;
            myConnectionString = @"server=localhost;user=root;database=dbsignup";

            connection = new MySql.Data.MySqlClient.MySqlConnection();
            connection.ConnectionString = myConnectionString;
            connection.Open();

            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT password FROM tblusers WHERE userid = ?";

            {
                if (connection.State == ConnectionState.Open)
                {
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    try
                    {
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        dataReader.Read();
                        tempPassword = dataReader["Password"].ToString();
                        connection.Close();
                        if (tempPassword == textBox2.Text)
                        {
                            MessageBox.Show("Welcome!");
                            Console.WriteLine("Entering Main Screen");
                            this.Hide();
                            MainScreen frm2 = new MainScreen();
                            frm2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password/User Error");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }


                }
            }
        }
    }
}
