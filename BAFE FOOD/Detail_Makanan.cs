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
    public partial class Detail_Pesanan : Form
    {
        Customer_Transaksi a;
        public Detail_Pesanan(Customer_Transaksi b)
        {
            InitializeComponent();
            a = b;
        }

        koneksi konn = new koneksi();
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "insert into Mengambil_Data values(@r1, @r2, (select ID_Restoran from Restoran where ID_Restoran = @r3), @r4)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1",list_Restoran.id);
                cmd.Parameters.AddWithValue("@r2", Customer_Transaksi.id);
                cmd.Parameters.AddWithValue("@r3", list_Restoran.idres);
                cmd.Parameters.AddWithValue("@r4", int.Parse(n1.Text.ToString()));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                a.Enabled = true;
                this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            a.Enabled = true;
            this.Hide();

        }
    }
}
