using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ayubo_drive_Final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String UserName, Password;

            UserName = txtUn.Text;
            Password = txtPw.Text;


            try
            {
                string querry = "SELECT *FROM Login where UserName='" + txtUn.Text + "'AND Password='" + txtPw.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    UserName = txtUn.Text;
                    Password = txtPw.Text;
                    MessageBox.Show("Successfully Logged");

                    Menu form2 = new Menu();
                    form2.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
               con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUn.Clear();
            txtPw.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void txtUn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
