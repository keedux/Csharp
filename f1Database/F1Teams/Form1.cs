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

namespace F1Teams
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void TestConn_btn_Click(object sender, EventArgs e)
        {
            string databaseconn = "server=localhost;user=root;";
            using (MySqlConnection f1conn = new MySqlConnection(databaseconn))
            {
                try
                {
                    f1conn.Open();
                    MessageBox.Show("Connected");
                }
                catch
                {
                    MessageBox.Show("Connection failed");
                }
            }
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
