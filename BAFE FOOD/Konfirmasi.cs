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

namespace BAFE_FOOD
{
    public partial class Konfirmasi : Form
    {
        public Konfirmasi()
        {
            InitializeComponent();
        }

        private void Konfirmasi_Load(object sender, EventArgs e)
        {
            driver();
        }

        koneksi konn = new koneksi();
        public void driver()
        {
            string query = "Select * from Transaksi_Pemesanan t join Driver d on t.ID_Driver = d.Nomor_Telepon_Driver where ID_Transaksi = '"+list_Restoran.id+"'";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();

                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        label4.Text = reader["Nama_Driver"].ToString();
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "update Transaksi_Pemesanan set status = 'proses' , Rating_Driver = @r1 where ID_Transaksi = '" + list_Restoran.id + "'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", numericUpDown1.Value.ToString());
                cmd.ExecuteNonQuery();
                this.Hide();
                list_Restoran a = new list_Restoran();
                a.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
