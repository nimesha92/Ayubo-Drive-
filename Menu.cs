using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_drive_Final
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pakage form1 = new Pakage();
            form1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            form1.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customers form1 = new Customers();
            form1.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vehicles form1 = new Vehicles();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drivers form1 = new Drivers();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Maintenance form1 = new Maintenance();
            form1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Rent form1 = new Rent();
            form1.Show();
            this.Hide();
        }
    }
}
