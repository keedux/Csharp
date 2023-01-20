using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Screen
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            this.BackgroundImage = Properties.Resources.pop;
            InitializeComponent();
            var timer = new Timer();
            //change the background image every second  
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //add image in list from resource file.  
            List<Bitmap> lisimage = new List<Bitmap>();
            lisimage.Add(Properties.Resources.pop);
            var indexbackimage = DateTime.Now.Second % lisimage.Count;
            this.BackgroundImage = lisimage[indexbackimage];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Entering Form 3");
            this.Hide();
            login frm2 = new login();
            frm2.Show();
        }
    }
}
