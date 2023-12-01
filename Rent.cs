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
    public partial class Rent : Form
    {
        int td, m, w, d, mlr, wlr, dlr, vr, p, tp, dr;
        string ci, di, vi, driver;

        private void xit(object sender, EventArgs e)
        {
            Menu form1 = new Menu();
            form1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtVi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCi.Clear();
            txtDi.Clear();
            txtVi.Clear();
            txtMlr.Clear();
            txtWlr.Clear();
            txtDlr.Clear();
            txtVr.Clear();
            txtDriver.Clear();
            txtDr.Clear();
            txtTp.Clear();
            chkWith.Checked = false;
            chkWithout.Checked = false;
            txtCi.Focus();

        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");


        TimeSpan ts;
        DateTime sd, ed;

        public Rent()
        {
            InitializeComponent();
        }
        

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Rent values (@CustomerId,@DriverId,@VehicleId,@Renteddate,@Returneddate,@Monthlyrate,@Weeklyrate,@Dailyrate,@Vehiclerate,@Driver,@Driverrate,@Totalpayment)", con);
            cmd.Parameters.AddWithValue("@CustomerId", txtDi.Text);
            cmd.Parameters.AddWithValue("@DriverId", txtDi.Text);
            cmd.Parameters.AddWithValue("@VehicleId", txtVi.Text);
            cmd.Parameters.AddWithValue("@Renteddate",DateTime.Parse( dtpSd.Text));
            cmd.Parameters.AddWithValue("@Returneddate",DateTime.Parse( dtpEd.Text));
            cmd.Parameters.AddWithValue("@Monthlyrate", int.Parse(txtMlr.Text));
            cmd.Parameters.AddWithValue("@Weeklyrate", int.Parse(txtWlr.Text));
            cmd.Parameters.AddWithValue("@Dailyrate", int.Parse(txtDlr.Text));
            cmd.Parameters.AddWithValue("@Vehiclerate", int.Parse(txtVr.Text));
            cmd.Parameters.AddWithValue("@Driver", txtDriver.Text);
            cmd.Parameters.AddWithValue("@Driverrate", int.Parse(txtDr.Text));
            cmd.Parameters.AddWithValue("@Totalpayment", int.Parse(txtTp.Text));
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted");


        }

        private void txtCi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTp_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void txtDrLeave(object sender, EventArgs e)
        {
            ci = txtCi.Text;
            di = txtDi.Text;
            vi = txtVi.Text;
            mlr = int.Parse(txtMlr.Text);
            wlr = int.Parse(txtWlr.Text);
            dlr = int.Parse(txtDlr.Text);
            vr = int.Parse(txtVr.Text);
            driver = txtDriver.Text;
            dr = int.Parse(txtDr.Text);
            sd = dtpSd.Value.Date;
            ed = dtpEd.Value.Date;
        }

        private void btnTp_Click(object sender, EventArgs e)
        {
            ts = ed - sd;
            td = ts.Days;
            m = td / 30;
            w = (td % 30) / 7;
            d = (td % 30) % 7;
            p = (m * mlr) + (w * wlr) + (d * dlr) + vr;
            if (chkWithout.Checked == true && chkWith.Checked == false)
            {
                tp = p;
            }
            else if (chkWith.Checked == true && chkWithout.Checked == false)
            {
                tp = p + dr;
            }
            else
            {
                MessageBox.Show("Choose With or Without for driver");
            }
            txtTp.Text = tp.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (chkWith.Checked == true && chkWithout.Checked == false)
            {
                txtDriver.Text = "With";
            }
            else if (chkWith.Checked == false && chkWithout.Checked == true)
            {
                txtDriver.Text = "Without";
            }
            else
            {
                MessageBox.Show("Choose With or Without for driver");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Rent set DriverId=@DriverId,VehicleId=@VehicleId,Renteddate=@Renteddate,Returneddate=@Returneddate,Monthlyrate=@Monthlyrate,Weeklyrate=@Weeklyrate,Dailyrate=@Dailyrate,Vehiclerate=@Vehiclerate,Driver=@Driver,Driverrate=@Driverrate,Totalpayment=@Totalpayment Where CustomerId=@CustomerId" ,con);
            cmd.Parameters.AddWithValue("@CustomerId", txtDi.Text);
            cmd.Parameters.AddWithValue("@DriverId", txtDi.Text);
            cmd.Parameters.AddWithValue("@VehicleId", txtVi.Text);
            cmd.Parameters.AddWithValue("@Renteddate", DateTime.Parse(dtpSd.Text));
            cmd.Parameters.AddWithValue("@Returneddate", DateTime.Parse(dtpEd.Text));
            cmd.Parameters.AddWithValue("@Monthlyrate", int.Parse(txtMlr.Text));
            cmd.Parameters.AddWithValue("@Weeklyrate", int.Parse(txtWlr.Text));
            cmd.Parameters.AddWithValue("@Dailyrate", int.Parse(txtDlr.Text));
            cmd.Parameters.AddWithValue("@Vehiclerate", int.Parse(txtVr.Text));
            cmd.Parameters.AddWithValue("@Driver", txtDriver.Text);
            cmd.Parameters.AddWithValue("@Driverrate", int.Parse(txtDr.Text));
            cmd.Parameters.AddWithValue("@Totalpayment", int.Parse(txtTp.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updateded");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Rent where CustomerId=@CustomerId", con);
            cmd.Parameters.AddWithValue("@CustomerId", txtCi.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Rent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Searched");
        }
    }
}
