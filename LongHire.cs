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
    public partial class LongHire : Form
    {
        string ci, di, vi, vt;
        int vr, exkr, sk, ek, pk, dr, pr, npr, tp, td, tk, exk, p;

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCi.Clear();
            txtDi.Clear();
            txtVi.Clear();
            cmbVt.SelectedIndex = -1;
            txtVr.Clear();
            txtExkr.Clear();
            txtSk.Clear();
            txtEk.Clear();
            txtPk.Clear();
            txtDr.Clear();
            txtPr.Clear();
            txtNpr.Clear();
            txtTp.Clear();
        }

        private void btnTgpd_Click(object sender, EventArgs e)
        {
            Pakage form1 = new Pakage();
            form1.Show();
            this.Hide();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete LongHire where CustomerId=@CustomerId", con);
            cmd.Parameters.AddWithValue("@CustomerId", txtCi.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =\"Ayubo Drive Final\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update LongHire set DriverId=@DriverId,VehicleId=@VehicleId,Vehicletype=@Vehicletype,Vehiclerate=@Vehiclerate,Renteddate=@Renteddate,Returneddate=@Returneddate,ExtraKmrate=@ExtraKmrate,StartKm=@StartKm,EndKm=@EndKm,PakageKm=@PackageKm,Driverrate=@Driverrate,Packagerate=@Packagerate,Nightparkraterate=@Nightparkraterate,Totalpayment=@Totalpayment where CustomerId=@CustomerId", con);
            cmd.Parameters.AddWithValue("@CustomerId", txtDi.Text);
            cmd.Parameters.AddWithValue("@DriverId", txtDi.Text);
            cmd.Parameters.AddWithValue("@VehicleId", txtVi.Text);
            cmd.Parameters.AddWithValue("@Vehicletype", cmbVt.Text);
            cmd.Parameters.AddWithValue("@Vehiclerate", cmbVt.Text);
            
            cmd.Parameters.AddWithValue("@Renteddate", DateTime.Parse(dtpSd.Text));
            cmd.Parameters.AddWithValue("@Returneddate", DateTime.Parse(dtpEd.Text));
            cmd.Parameters.AddWithValue("@ExtraKmrate", int.Parse(txtExkr.Text));
            cmd.Parameters.AddWithValue("@StartKm", int.Parse(txtSk.Text));
            cmd.Parameters.AddWithValue("@EndKm", int.Parse(txtEk.Text));
            cmd.Parameters.AddWithValue("@PackageKm", int.Parse(txtPk.Text));
            cmd.Parameters.AddWithValue("@Driverrate", int.Parse(txtDr.Text));
            cmd.Parameters.AddWithValue("@Packagerate", int.Parse(txtPr.Text));
            cmd.Parameters.AddWithValue("@Nightparkrate", int.Parse(txtNpr.Text));
            cmd.Parameters.AddWithValue("@Totalpayment", int.Parse(txtTp.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        TimeSpan ts;
        DateTime sd, ed;

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = "insert into LongHire values ('" + ci + "','" + di + "','" + vi + "','" + vt + "','" + vr + "','"
                    + sd + "','" + ed + "','" + exkr + "','" + sk + "','" + ek + "','" + pk + "','"
                    + dr + "','" + pr + "','" + npr + "','" + tp + "')";
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

        

        private void txtNpr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNpr_Leave(object sender, EventArgs e)
        {
            ci = txtCi.Text;
            di = txtDi.Text;
            vi = txtVi.Text;
            vt = cmbVt.Text;
            vr = int.Parse(txtVr.Text);
            sd = dtpSd.Value.Date;
            ed = dtpEd.Value.Date;
            exkr = int.Parse(txtExkr.Text);
            sk = int.Parse(txtSk.Text);
            ek = int.Parse(txtEk.Text);
            pk = int.Parse(txtPk.Text);
            dr = int.Parse(txtDr.Text);
            pr = int.Parse(txtPr.Text);
            npr = int.Parse(txtNpr.Text);
        }

       

        public LongHire()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog =\"Ayubo Drive Final\";Integrated Security=True");
        private void btnTp_Click(object sender, EventArgs e)
        {
            ts = ed - sd;
            td = ts.Days;
            tk = ek - sk;
            exk = tk - pk;
            p = vr + dr + pr + (exk * exkr);
            if (td > 2)
            {
                tp = p + (td - 2) * npr;
            }
            else
            {
                tp = p;
            }
            txtTp.Text = tp.ToString();

        }
    }
}
