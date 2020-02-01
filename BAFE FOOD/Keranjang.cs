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
    public partial class Keranjang : Form
    {

        Customer_Transaksi a;
        public Keranjang(Customer_Transaksi b)
        {
            InitializeComponent();
            a = b;
        }


        koneksi konn = new koneksi();
        public int jum;
        public void keranjang() {
            String query = "select * from Mengambil_Data m join Menu_Makanan e on e.ID_Makanan = m.ID_Makanan where ID_Transaksi = '"+ list_Restoran.id +"'";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView9.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Makanan"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Makanan"].ToString());
                        listViewItem.SubItems.Add(reader["Harga"].ToString());
                        listViewItem.SubItems.Add(reader["Jumlah_Makanan"].ToString());
                        listView9.Items.Add(listViewItem);
                        jum += int.Parse(reader["Harga"].ToString()) * int.Parse(reader["Jumlah_Makanan"].ToString());
                    }
                    reader.Close();
                    label2.Text = jum.ToString();
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

        private void Keranjang_Load(object sender, EventArgs e)
        {
            keranjang();
            metode();
        }

        private void metode()
        {
            string query = "Select * from Metode_Pembayaran";
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
                        if(!reader["Nama_Metode"].ToString().Equals("0"))
                        comboBox4.Items.Add(reader["Nama_Metode"].ToString());
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

        private void listView9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "update Transaksi_Pemesanan set ID_Metode = (select ID_Metode from Metode_Pembayaran where Nama_Metode = @r1) where ID_Transaksi = '" + list_Restoran.id + "'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", comboBox4.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }




            Konfirmasi a = new Konfirmasi();
            a.Show();
            this.Hide();
        }
    }


}
