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

namespace Ayubo_drive_Final
{
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Drivers values (@ID,@FirstName,@LastName,@Address,@VehicleType,@Telephone)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@FirstName", txtNam1.Text);
            cmd.Parameters.AddWithValue("@LastName", txtNam2.Text);
            cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
            cmd.Parameters.AddWithValue("@VehicleType", cmbVt.Text);
            cmd.Parameters.AddWithValue("@Telephone", int.Parse(txtTele.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Drivers set FirstName=@FirstName,LastName=@LastName,Address=@Address,VehicleType=@VehicleType,Telephone=@Telephone where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
            cmd.Parameters.AddWithValue("@FirstName", txtNam1.Text);
            cmd.Parameters.AddWithValue("@LastName", txtNam2.Text);
            cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
            cmd.Parameters.AddWithValue("@VehicleType", cmbVt.Text);
            cmd.Parameters.AddWithValue("@Telephone", int.Parse(txtTele.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Drivers where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", txtID.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Drivers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Menu form1 = new Menu();
            form1.Show();
            this.Hide();
        }
    }
}
