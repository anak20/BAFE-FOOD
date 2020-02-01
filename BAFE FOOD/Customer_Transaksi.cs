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
    public partial class Customer_Transaksi : Form
    {
        public Customer_Transaksi()
        {
            InitializeComponent();
        }


        koneksi konn = new koneksi();
        
        public static string res;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "update Transaksi_Pemesanan set ID_Restoran = (select ID_Restoran from Restoran where Nama_Restoran = @r1) where ID_Transaksi = '" + list_Restoran.id + "'";
            string query1 = "delete from Mengambil_Data where ID_Transaksi = '" + list_Restoran.id+"'";
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", res);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(query1, conn);
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



        }



        public void loadmenu() {
            String query = "select * from Menu_Makanan s join Kategori_Makanan k on s.Kategori= k.Kategori where ID_Restoran = (select ID_Restoran from Restoran where ID_Restoran = '" + list_Restoran.idres+"') ";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView8.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader["ID_Makanan"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["ID_Makanan"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Makanan"].ToString());
                            listViewItem.SubItems.Add(reader["Harga"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Kategori"].ToString());
                            listView8.Items.Add(listViewItem);

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
        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView8.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView8.Items[row[0]];
                id = item.SubItems[0].Text;
                Detail_Pesanan a = new Detail_Pesanan(this);
                a.Show();
                this.Enabled = false;
            }
           
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Keranjang k = new Keranjang(this);
            k.Show();
            this.Hide();
        }

        private void Customer_Transaksi_Load(object sender, EventArgs e)
        {
            loadmenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "delete Transaksi_Pemesanan where ID_Transaksi = '" + list_Restoran.id + "'";
                string queryDelete2 = "delete Mengambil_Data where ID_Transaksi = '" + list_Restoran.id + "'";
                SqlCommand cmd = new SqlCommand(queryDelete2, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Di Keranjang Akan Dihapus");
                list_Restoran a = new list_Restoran();
                a.Show();
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
    }
}
