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
    public partial class Pakage : Form
    {
        public Pakage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DayHire form1 = new DayHire();
            form1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            LongHire form1 = new LongHire();
            form1.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Menu form1 = new Menu();
            form1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Rent form1 = new Rent();
            form1.Show();
            this.Hide();
        }
    }
    }

