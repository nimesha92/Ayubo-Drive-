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
using static System.Net.Mime.MediaTypeNames;

namespace Ayubo_drive_Final
{
    public partial class DayHire : Form
    {
        string ci, di, vi, pty;
        int pr, sk, ek, pk, exk, st, et, pt, ext, tk, tt, extr, exkr, dr, vr, tp;

        private void button1_Click(object sender, EventArgs e)
        {
            Pakage form1 = new Pakage();
            form1.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCi.Clear();
            txtDi.Clear();
            txtVi.Clear();
            cmbPt.SelectedIndex = -1;
            txtPr.Clear();
            txtSk.Clear();
            txtEk.Clear();
            txtPk.Clear();
            txtSt.Clear();
            txtEt.Clear();
            txtPt.Clear();
            txtExtr.Clear();
            txtExkr.Clear();
            txtDr.Clear();
            txtVr.Clear();
            txtTp.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update DayHire set DriverId=@DriverId,VehicleId=@VehicleId,Packagetype=@Packagetype,Packagerate=@Packagerate,StartKm=@StartKm,EndKm=@EndKm,PackageKm=@PackageKm,Starttime=@Starttime,Endtime=@Endtime,Packagetime=@Packagetime,Extratimerate=@Extratimerate,ExtraKmrate=@ExtraKmrate,Driverrate=@Driverrate,Vehiclerate=@Vehiclerate,Totalpayment=@Totalpayment where CustomerId=@CustomerId", con);
            cmd.Parameters.AddWithValue("@CustomerId", txtDi.Text);
            cmd.Parameters.AddWithValue("@DriverId", txtDi.Text);
            cmd.Parameters.AddWithValue("@VehicleId", txtVi.Text);
            cmd.Parameters.AddWithValue("@Packagetype", cmbPt.Text);
            cmd.Parameters.AddWithValue("@Packagerate",int.Parse(txtPr.Text));
            cmd.Parameters.AddWithValue("@StartKm", int.Parse(txtSk.Text));
            cmd.Parameters.AddWithValue("@EndKm", int.Parse(txtEk.Text));
            cmd.Parameters.AddWithValue("@PackageKm", int.Parse(txtPk.Text));
            cmd.Parameters.AddWithValue("@Starttime", int.Parse(txtSt.Text));
            cmd.Parameters.AddWithValue("@Endtime", int.Parse(txtEt.Text));
            cmd.Parameters.AddWithValue("@Packagetime", int.Parse(txtPt.Text));
            cmd.Parameters.AddWithValue("@Extratimerate", int.Parse(txtExtr.Text));
            cmd.Parameters.AddWithValue("@ExtraKmrate", int.Parse(txtExkr.Text));
            cmd.Parameters.AddWithValue("@Driverrate", int.Parse(txtDr.Text));
            cmd.Parameters.AddWithValue("@Vehiclerate", int.Parse(txtVr.Text));
            cmd.Parameters.AddWithValue("@Totalpayment", int.Parse(txtTp.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete DayHire where CustomerId=@CustomerId", con);
            cmd.Parameters.AddWithValue("@CustomerId", txtCi.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

        }

        private void txtCi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from DayHire", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = "insert into DayHire values ('" + ci + "','" + di + "','" + vi + "','" + pty + "','"
                    + pr + "','" + sk + "','" + ek + "','" + pk + "','" + st + "','" + et + "','" + pt + "','"
                    + extr + "','" + exkr + "','" + dr + "','" + vr + "','" + tp + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted successfully");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting..." + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void txtVr_Leave(object sender, EventArgs e)
        {
            ci = txtCi.Text;
            di = txtDi.Text;
            vi = txtVi.Text;
            pty = cmbPt.Text;
            pr = int.Parse(txtPr.Text);
            sk = int.Parse(txtSk.Text);
            ek = int.Parse(txtEk.Text);
            pk = int.Parse(txtPk.Text);
            st = int.Parse(txtSt.Text);
            et = int.Parse(txtEt.Text);
            pt = int.Parse(txtPt.Text);
            extr = int.Parse(txtExtr.Text);
            exkr = int.Parse(txtExkr.Text);
            dr = int.Parse(txtDr.Text);
            vr = int.Parse(txtVr.Text);
        }

        private void txt(object sender, EventArgs e)
        {
           
        }

        private void txtVr_TextChanged(object sender, EventArgs e)
        {

        }

        public DayHire()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"Ayubo Drive Final\";Integrated Security=True");

        private void btnTp_Click(object sender, EventArgs e)
        {
            tk = ek - sk;
            exk = tk - pk;
            tt = et - st;
            ext = tt - pt;
            tp = pr + dr + vr + (exk * exkr) + (ext * extr);
            txtTp.Text = tp.ToString();
        }
    }
}
