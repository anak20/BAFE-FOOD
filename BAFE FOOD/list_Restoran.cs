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
    public partial class list_Restoran : Form
    {
        public list_Restoran()
        {
            InitializeComponent();
        }

        koneksi konn = new koneksi();
        private void list_Restoran_Load(object sender, EventArgs e)
        {
            updateRestoran();
        }

        public void updateRestoran()
        {

            String query = "select * from Restoran";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            listView1.Items.Clear();
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
                        if (!reader["ID_Restoran"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["ID_Restoran"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Restoran"].ToString());
                            listViewItem.SubItems.Add(reader["Alamat_Resto"].ToString());
                            listViewItem.SubItems.Add(reader["Jadwal_Restoran"].ToString());
                            listView1.Items.Add(listViewItem);
                        }
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

        public static string id;
        public static string idres;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView1.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView1.Items[row[0]];
                idres = item.SubItems[0].Text;

                string query = "insert into Transaksi_Pemesanan (Jam_Transaksi, Tanggal_Transaksi, ID_Customer, ID_Driver, ID_Restoran, ID_Metode, Location_Driver, Location_Customer) values(convert(varchar, getdate(), 8), convert(varchar, getdate(), 23),@r3, (select top 1 Nomor_Telepon_Driver from Driver where Nomor_Telepon_Driver NOT IN(select ID_Driver from Transaksi_Pemesanan where status = 'proses') and Nomor_Telepon_Driver != '0'), @r2, (select top 1 ID_Metode from Metode_Pembayaran), 'Lokasi satu', 'Lokasi dua')";

                System.Data.SqlClient.SqlConnection conn = konn.GetConn();
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@r3", Customer.idCus);
                    cmd.Parameters.AddWithValue("@r2", idres);
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



                String query1 = "select top 1 ID_Transaksi from Transaksi_Pemesanan where ID_Customer = '" + Customer.idCus + "' and Tanggal_Transaksi = (select convert(varchar, getdate(), 23)) ORDER BY ID_Transaksi DESC";
                SqlDataReader reader = null;
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query1, conn);
                    command.ExecuteNonQuery();
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            id = reader["ID_Transaksi"].ToString();
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


                Customer_Transaksi a = new Customer_Transaksi();
                a.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer a = new Customer();
            a.Show();
            this.Hide();
            
        }
    }
}
