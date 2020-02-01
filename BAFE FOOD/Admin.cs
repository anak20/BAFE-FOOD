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
     
    public partial class Admin : Form
    {
        koneksi konn = new koneksi();
        public string idC;
        public string idT;
        public string idR;
        public string idD;
        public string idM;
        public string idMet;
        public string idK;
        public Admin()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            r1.Text = "";
            r2.Text = "";
            r3.Text = "";
            r5.Text = "";
            r6.Text = "";
            r7.Text = "";
            r8.Text = "";
            r9.Text = "";
            r10.Text = "";
            r11.Text = "";
            r12.Text = "";
            r13.Text = "";
            r14.Text = "";
            r15.Text = "";
            r16.Text = "";
            r17.Text = "";
            r18.Text = "";
            r19.Text = "";
            r20.Text = "";
   
        }

        private void button12_Click(object sender, EventArgs e)
        {
            d1.Text = "";
            d2.Text = "";
            d3.Text = "";
            d4.Text = "";
            d5.Text = "";
            d6.Text = "";
            d7.Text = "";
            d8.Text = "";
            d9.Text = "";
            d10.Text = "";
            d11.Text = "";
            d12.Text = "";
            d13.Text = "";
            d14.Text = "";
            d15.Text = "";
            d16.Text = "";
            d17.Text = "";
            d18.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            m1.Text = "";
            m2.Text = "";
            m3.Text = "0";
            m4.Text = "";
            m5.Text = "";
            m6.Text = "";
        
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            updateCustomer();
            updateRestoran();
            updateDriver();
            updateMakanan();
            updateTransaksi();
            updateMetode();
            updateKategori();
            loadRestoran(); ;
            cariCustomer();
            cariRestoran();
            cariDriver();
            cariMakanan();
            cariTransaksi();
        }

        public void cariCustomer() {

            comboBox4.Items.Add("Nomor_Telepon_Customer");
            comboBox4.Items.Add("Nama_Lengkap_Customer");
        }
        public void cariRestoran()
        {

            comboBox3.Items.Add("ID_Restoran");
            comboBox3.Items.Add("Nama_Restoran");
            comboBox3.Items.Add("Alamat_Resto");
        }

        public void cariDriver()
        {

            comboBox2.Items.Add("Nomor_Telepon_Driver");
            comboBox2.Items.Add("Nama_Driver");
        }

        public void cariMakanan()
        {

            comboBox1.Items.Add("ID_Makanan");
            comboBox1.Items.Add("Nama_Makanan");
            comboBox1.Items.Add("ID_Restoran");
            comboBox1.Items.Add("Kategori");
        }

        public void cariTransaksi()
        {

            comboBox5.Items.Add("ID_Restoran");
            comboBox5.Items.Add("ID_Transaksi");
            comboBox5.Items.Add("ID_Customer");
        }


        public void updateMetode() {
            String query = "select * from Metode_Pembayaran";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView6.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader["ID_Metode"].ToString().Equals("0")) { 
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Metode"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Metode"].ToString());
                        listView6.Items.Add(listViewItem);

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
        public void updateKategori()
        {
            String query = "select * from Kategori_Makanan";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView7.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader["Kategori"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["Kategori"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Kategori"].ToString());
                            listView7.Items.Add(listViewItem);

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
        public void updateTransaksi() {
            String query = "select * from Transaksi_Pemesanan";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView5.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Transaksi"].ToString());
                        listViewItem.SubItems.Add(reader["Jam_Transaksi"].ToString());
                        listViewItem.SubItems.Add(reader["Tanggal_Transaksi"].ToString());
                        listViewItem.SubItems.Add(reader["Location_Customer"].ToString());
                        listViewItem.SubItems.Add(reader["Location_Driver"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Driver"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Metode"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Customer"].ToString());
                        listViewItem.SubItems.Add(reader["Rating_Driver"].ToString());
                        listViewItem.SubItems.Add(reader["status"].ToString());
                        listView5.Items.Add(listViewItem);

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


        public void updateMakanan() {
            String query = "select * from Menu_Makanan";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView4.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Makanan"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Makanan"].ToString());
                        listViewItem.SubItems.Add(reader["Harga"].ToString());
                        listViewItem.SubItems.Add(reader["Kategori"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Restoran"].ToString());
                        listView4.Items.Add(listViewItem);

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

        public void updateDriver() {
           
            String query = "select * from Driver";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            listView3.Items.Clear();
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
                        if (!reader["Nomor_Telepon_Driver"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["Nomor_Telepon_Driver"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Driver"].ToString());
                            listViewItem.SubItems.Add(reader["Alamat"].ToString());
                            listViewItem.SubItems.Add(reader["TTL"].ToString());
                            listViewItem.SubItems.Add(reader["Kelamin"].ToString());
                            listViewItem.SubItems.Add(reader["Masa_Berlaku_SIM"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_SIM"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_Plat"].ToString());
                            listViewItem.SubItems.Add(reader["Tahun_Pembuatan_Kendaraan"].ToString());
                            listViewItem.SubItems.Add(reader["Masa_Berlaku_STNK"].ToString());
                            listViewItem.SubItems.Add(reader["Tipe"].ToString());
                            listViewItem.SubItems.Add(reader["Merek"].ToString());
                            listViewItem.SubItems.Add(reader["CC_Kendaraan"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_KTP"].ToString());
                            listViewItem.SubItems.Add(reader["Tanggal_KTP"].ToString());
                            listViewItem.SubItems.Add(reader["Masa_Berlaku_KTP"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_Rekening"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Bank"].ToString());
                            listView3.Items.Add(listViewItem);
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

        public void updateRestoran() {

            String query = "select * from Restoran";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            listView2.Items.Clear();
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
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Jadwal_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Email_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Website_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nomor_Telepon_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Depan"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Belakang"].ToString());
                        listViewItem.SubItems.Add(reader["Alamat_Resto"].ToString());
                        listViewItem.SubItems.Add(reader["Kota_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Kecamatan_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Kelurahan_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Provinsi_Resto"].ToString());
                        listViewItem.SubItems.Add(reader["Kode_Pos_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nomor_Telepon_Penanggung_Jawab"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Penanggung_Jawab"].ToString());
                        listViewItem.SubItems.Add(reader["Email_Penanggung_Jawab"].ToString());
                        listViewItem.SubItems.Add(reader["Nomor_Telepon_Pemilik"].ToString());
                        listViewItem.SubItems.Add(reader["Email_Pemilik"].ToString());
        
                        listView2.Items.Add(listViewItem);

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


        public void updateCustomer() {

            String query = "select * from Customer";
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
                        if (!reader["Nomor_Telepon_Customer"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["Nomor_Telepon_Customer"].ToString());
                            listViewItem.SubItems.Add(reader["Email_Customer"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Lengkap_Customer"].ToString());
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

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView4.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView4.Items[row[0]];
                m1.Text = item.SubItems[0].Text; ;
                m2.Text = item.SubItems[1].Text; ;
                m3.Text = item.SubItems[2].Text; ;
                m4.Text = item.SubItems[3].Text; ;
                m5.Text = item.SubItems[4].Text; ;
                idM = item.SubItems[0].Text;
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView3.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView3.Items[row[0]];
                d1.Text = item.SubItems[0].Text;
                d2.Text = item.SubItems[1].Text;
                d3.Text = item.SubItems[2].Text;
                d4.Text = item.SubItems[3].Text;
                d5.Text = item.SubItems[4].Text;
                d6.Text = item.SubItems[5].Text;
                d7.Text = item.SubItems[6].Text;
                d8.Text = item.SubItems[7].Text;
                d9.Text = item.SubItems[8].Text;
                d10.Text = item.SubItems[9].Text;
                d11.Text = item.SubItems[10].Text;
                d12.Text = item.SubItems[11].Text;
                d13.Text = item.SubItems[12].Text;
                d14.Text = item.SubItems[13].Text;
                d15.Text = item.SubItems[14].Text;
                d16.Text = item.SubItems[15].Text;
                d17.Text = item.SubItems[16].Text;
                d18.Text = item.SubItems[17].Text;
                idD = item.SubItems[0].Text;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView2.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView2.Items[row[0]];
                r1.Text = item.SubItems[0].Text;
                r2.Text = item.SubItems[1].Text;
                r3.Text = item.SubItems[2].Text;
                r5.Text = item.SubItems[3].Text;
                r6.Text = item.SubItems[4].Text;
                r7.Text = item.SubItems[5].Text;
                r8.Text = item.SubItems[6].Text;
                r9.Text = item.SubItems[7].Text;
                r10.Text = item.SubItems[8].Text;
                r11.Text = item.SubItems[9].Text;
                r12.Text = item.SubItems[10].Text;
                r13.Text = item.SubItems[11].Text;
                r14.Text = item.SubItems[12].Text;
                r15.Text = item.SubItems[13].Text;
                r16.Text = item.SubItems[14].Text;
                r17.Text = item.SubItems[15].Text;
                r18.Text = item.SubItems[16].Text;
                r19.Text = item.SubItems[17].Text;
                r20.Text = item.SubItems[18].Text;
           
                idR = item.SubItems[0].Text;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView1.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView1.Items[row[0]];
                c1.Text = item.SubItems[0].Text; ;
                c2.Text = item.SubItems[1].Text; ;
                c3.Text = item.SubItems[2].Text; ;
       
                idC = item.SubItems[0].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "update Transaksi_Pemesanan set ID_Customer = '0' where ID_Customer = '"+ idC +"'";
                string queryDelete = "delete from customer where Nomor_Telepon_Customer = '" + idC + "'";
                SqlCommand cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil di Hapus");
                updateCustomer();
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

        private void button7_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "delete from Transaksi_Pemesanan where ID_Restoran = '" + idR + "'";
                string queryDelete4 = "delete from Mengambil_Data where ID_Restoran = '" + idR + "'";
                string queryDelete2 = "delete from Menu_Makanan where ID_Restoran = '" + idR + "'";
                string queryDelete3 = "delete from Restoran where ID_Restoran = '" + idR + "'";
                SqlCommand cmd = new SqlCommand(queryDelete4, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete2, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete3, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil di Hapus");
                updateRestoran();
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

        private void button10_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete = "delete from Driver where Nomor_Telepon_Driver = '" + idD + "'";
                string queryDelete1 = "update Transaksi_Pemesanan set ID_Driver = '0' where ID_Driver = '" + idD + "'";
                SqlCommand cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil di Hapus");
                updateDriver();
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

        private void button14_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "delete from Mengambil_Data where ID_Makanan = '" + idM + "'";
                string queryDelete = "delete from Menu_Makanan where ID_Makanan = '" + idM + "'";
                SqlCommand cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil di Hapus");
                updateMakanan();
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
            string query = "insert into Customer values(@nomor, @email, @nama)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", c1.Text);
                cmd.Parameters.AddWithValue("@email", c2.Text);
                cmd.Parameters.AddWithValue("@nama", c3.Text);
      
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateCustomer();

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

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "update Customer set Nomor_Telepon_Customer = @nomor, Email_Customer = @email, Nama_Lengkap_Customer = @nama  where Nomor_Telepon_Customer = '" + idC + "'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", c1.Text);
                cmd.Parameters.AddWithValue("@email", c2.Text);
                cmd.Parameters.AddWithValue("@nama", c3.Text);
        
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Update");
                updateCustomer();

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

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "insert into Restoran values(@r1, @r2, @r3, @r5,@r6,@r7, @r8, @r9, @r10, @r11, @r12, @r13,@r14, @r15, @r16, @r17, @r18, @r19,@r20)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", r1.Text);
                cmd.Parameters.AddWithValue("@r2", r2.Text);
                cmd.Parameters.AddWithValue("@r3", r3.Text);
                cmd.Parameters.AddWithValue("@r5", r5.Text);
                cmd.Parameters.AddWithValue("@r6", r6.Text);
                cmd.Parameters.AddWithValue("@r7", r7.Text);
                cmd.Parameters.AddWithValue("@r8", r8.Text);
                cmd.Parameters.AddWithValue("@r9", r9.Text);
                cmd.Parameters.AddWithValue("@r10", r10.Text);
                cmd.Parameters.AddWithValue("@r11", r11.Text);
                cmd.Parameters.AddWithValue("@r12", r12.Text);
                cmd.Parameters.AddWithValue("@r13", r13.Text);
                cmd.Parameters.AddWithValue("@r14", r14.Text);
                cmd.Parameters.AddWithValue("@r15", r15.Text);
                cmd.Parameters.AddWithValue("@r16", r16.Text);
                cmd.Parameters.AddWithValue("@r17", r17.Text);
                cmd.Parameters.AddWithValue("@r18", r18.Text);
                cmd.Parameters.AddWithValue("@r19", r19.Text);
                cmd.Parameters.AddWithValue("@r20", r20.Text);
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateRestoran();
                loadRestoran();

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

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "insert into Driver values(@r1, @r2, @r3, @r4, @r5,@r6,@r7, @r8, @r9, @r10, @r11, @r12, @r13,@r14, @r15, @r16, @r17, @r18)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", d1.Text);
                cmd.Parameters.AddWithValue("@r2", d2.Text);
                cmd.Parameters.AddWithValue("@r3", d3.Text);
                cmd.Parameters.AddWithValue("@r4", d4.Text);
                cmd.Parameters.AddWithValue("@r5", d5.Text);
                cmd.Parameters.AddWithValue("@r6", d6.Text);
                cmd.Parameters.AddWithValue("@r7", d7.Text);
                cmd.Parameters.AddWithValue("@r8", d8.Text);
                cmd.Parameters.AddWithValue("@r9", d9.Text);
                cmd.Parameters.AddWithValue("@r10", d10.Text);
                cmd.Parameters.AddWithValue("@r11", d11.Text);
                cmd.Parameters.AddWithValue("@r12", d12.Text);
                cmd.Parameters.AddWithValue("@r13", d13.Text);
                cmd.Parameters.AddWithValue("@r14", d14.Text);
                cmd.Parameters.AddWithValue("@r15", d15.Text);
                cmd.Parameters.AddWithValue("@r16", d16.Text);
                cmd.Parameters.AddWithValue("@r17", d17.Text);
                cmd.Parameters.AddWithValue("@r18", d18.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateDriver();

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

        private void button13_Click(object sender, EventArgs e)
        {
            string query = "insert into Menu_Makanan values(@r1, @r2, @r3, @r4, @r5)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", m1.Text);
                cmd.Parameters.AddWithValue("@r2", m2.Text);
                cmd.Parameters.AddWithValue("@r3", int.Parse(m3.Text.ToString()));
                cmd.Parameters.AddWithValue("@r4", m4.Text);
                cmd.Parameters.AddWithValue("@r5", m5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateMakanan();

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

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "update Restoran set ID_Restoran = @r1, Jadwal_Restoran = @r2, Email_Restoran = @r3, Nama_Restoran = @r5,Website_Restoran = @r6, Nomor_Telepon_Restoran = @r7, Nama_Depan = @r8, Nama_Belakang = @r9, Alamat_Resto = @r10, Kota_Restoran = @r11, Kecamatan_Restoran = @r12, Kelurahan_Restoran = @r13, Provinsi_Resto = @r14, Kode_Pos_Restoran = @r15, Nomor_Telepon_Penanggung_Jawab = @r16, Nama_Penanggung_Jawab = @r17, Email_Penanggung_Jawab = @r18,Nomor_Telepon_Pemilik = @r19, Email_Pemilik = @r20 where ID_Restoran = @con ";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", r1.Text);
                cmd.Parameters.AddWithValue("@r2", r2.Text);
                cmd.Parameters.AddWithValue("@r3", r3.Text);
                cmd.Parameters.AddWithValue("@r5", r5.Text);
                cmd.Parameters.AddWithValue("@r6", r6.Text);
                cmd.Parameters.AddWithValue("@r7", r7.Text);
                cmd.Parameters.AddWithValue("@r8", r8.Text);
                cmd.Parameters.AddWithValue("@r9", r9.Text);
                cmd.Parameters.AddWithValue("@r10", r10.Text);
                cmd.Parameters.AddWithValue("@r11", r11.Text);
                cmd.Parameters.AddWithValue("@r12", r12.Text);
                cmd.Parameters.AddWithValue("@r13", r13.Text);
                cmd.Parameters.AddWithValue("@r14", r14.Text);
                cmd.Parameters.AddWithValue("@r15", r15.Text);
                cmd.Parameters.AddWithValue("@r16", r16.Text);
                cmd.Parameters.AddWithValue("@r17", r17.Text);
                cmd.Parameters.AddWithValue("@r18", r18.Text);
                cmd.Parameters.AddWithValue("@r19", r19.Text);
                cmd.Parameters.AddWithValue("@r20", r20.Text);

                cmd.Parameters.AddWithValue("@con", idR);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateRestoran();
                loadRestoran();

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

        private void button11_Click(object sender, EventArgs e)
        {
            string query = "update Driver set Nomor_Telepon_Driver = @r1, Nama_Driver = @r2, Alamat = @r3, TTL = @r4, Kelamin = @r5, Masa_Berlaku_SIM = @r6 , Nomor_SIM = @r7, Nomor_Plat = @r8, Tahun_Pembuatan_Kendaraan = @r9, Masa_Berlaku_STNK = @r10, Tipe = @r11, Merek = @r12, CC_Kendaraan = @r13, Nomor_KTP = @r14, Tanggal_KTP = @r15, Masa_Berlaku_KTP = @r16, Nomor_Rekening = @r17, Nama_Bank = @r18  where Nomor_Telepon_Driver = @con";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", d1.Text);
                cmd.Parameters.AddWithValue("@r2", d2.Text);
                cmd.Parameters.AddWithValue("@r3", d3.Text);
                cmd.Parameters.AddWithValue("@r4", d4.Text);
                cmd.Parameters.AddWithValue("@r5", d5.Text);
                cmd.Parameters.AddWithValue("@r6", d6.Text);
                cmd.Parameters.AddWithValue("@r7", d7.Text);
                cmd.Parameters.AddWithValue("@r8", d8.Text);
                cmd.Parameters.AddWithValue("@r9", d9.Text);
                cmd.Parameters.AddWithValue("@r10", d10.Text);
                cmd.Parameters.AddWithValue("@r11", d11.Text);
                cmd.Parameters.AddWithValue("@r12", d12.Text);
                cmd.Parameters.AddWithValue("@r13", d13.Text);
                cmd.Parameters.AddWithValue("@r14", d14.Text);
                cmd.Parameters.AddWithValue("@r15", d15.Text);
                cmd.Parameters.AddWithValue("@r16", d16.Text);
                cmd.Parameters.AddWithValue("@r17", d17.Text);
                cmd.Parameters.AddWithValue("@r18", d18.Text);
                cmd.Parameters.AddWithValue("@con", idD);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateDriver();

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public string namaResto;

        private void loadRestoran()
        {
            string query = "Select * from Restoran";
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
                        m5.Items.Add(reader["ID_Restoran"].ToString());
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

        public void Resto() {
            string query = "Select * from Restoran where ID_Restoran = '"+ m5.Text.ToString()+"'";
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
                        m6.Text = reader["Nama_Restoran"].ToString();
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

            private void m5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resto();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string query = "update  Menu_Makanan set ID_Makanan =@r1, Nama_Makanan= @r2, Harga = @r3, Kategori = @r4, ID_Restoran = @r5 where ID_Makanan = '" + idM +"'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r1", m1.Text);
                cmd.Parameters.AddWithValue("@r2", m2.Text);
                cmd.Parameters.AddWithValue("@r3", int.Parse(m3.Text.ToString()));
                cmd.Parameters.AddWithValue("@r4", m4.Text);
                cmd.Parameters.AddWithValue("@r5", m5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Update");
                updateMakanan();

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

        private void button26_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox9.Text = "";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string query = "insert into Metode_Pembayaran values(@nomor, @email)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", textBox9.Text);
                cmd.Parameters.AddWithValue("@email", textBox7.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateMetode();

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

        private void button25_Click(object sender, EventArgs e)
        {
            string query = "update Metode_Pembayaran set ID_Metode = @nomor, Nama_Metode = @email  where ID_Metode = '" + idMet + "'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", textBox9.Text);
                cmd.Parameters.AddWithValue("@email", textBox7.Text);
           

                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Update");
                updateMetode();

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

        private void button24_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "update Transaksi_Pemesanan set ID_Metode = '0' where ID_Metode = '" + idMet + "'";
                string queryDelete = "delete from Metode_Pembayaran where ID_Metode = '" + idMet + "'";
                SqlCommand cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil di Hapus");
                updateMetode();
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


        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView6.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView6.Items[row[0]];
                textBox9.Text = item.SubItems[0].Text; ;
                textBox7.Text = item.SubItems[1].Text; ;
               

                idMet = item.SubItems[0].Text;
            }
        }

        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView7.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView7.Items[row[0]];
                textBox8.Text = item.SubItems[0].Text; ;
                textBox6.Text = item.SubItems[1].Text; ;


                idK = item.SubItems[0].Text;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox6.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string query = "insert into Kategori_Makanan values(@nomor, @email)";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", textBox8.Text);
                cmd.Parameters.AddWithValue("@email", textBox6.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Tambahkan");
                updateKategori();

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

        private void button28_Click(object sender, EventArgs e)
        {
            string query = "update Kategori_Makanan set Kategori = @nomor, Nama_Kategori = @email  where Kategori = '" + idK + "'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", textBox8.Text);
                cmd.Parameters.AddWithValue("@email", textBox6.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil di Update");
                updateKategori();

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

        private void button27_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "update Menu_Makanan set Kategori = '0' where Kategori = '" + idK + "'";
                string queryDelete = "delete from Kategori_Makanan where Kategori = '" + idK + "'";
                SqlCommand cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil di Hapus");
                updateKategori();
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

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection row = listView5.SelectedIndices;
            if (row.Count == 1)
            {
                ListViewItem item = listView5.Items[row[0]];
               


                idT = item.SubItems[0].Text;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string query = "update Transaksi_Pemesanan set status = 'selesai' where ID_Transaksi = '" + idT + "'";

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                updateTransaksi();

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

        private void button31_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string queryDelete1 = "delete Transaksi_Pemesanan where ID_Transaksi = '" + idT + "'";
                string queryDelete2 = "delete Mengambil_Data where ID_Transaksi = '" + idT + "'";
                SqlCommand cmd = new SqlCommand(queryDelete2, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(queryDelete1, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil di Hapus");
                updateTransaksi();
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

        private void button17_Click(object sender, EventArgs e)
        {
            updateTransaksi1();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            updateCustomer1();
        }


        public void updateTransaksi1()
        {
            String query = "select * from Transaksi_Pemesanan where "+comboBox5.Text+" like %"+ textBox1.Text +"%";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView5.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Transaksi"].ToString());
                        listViewItem.SubItems.Add(reader["Jam_Transaksi"].ToString());
                        listViewItem.SubItems.Add(reader["Tanggal_Transaksi"].ToString());
                        listViewItem.SubItems.Add(reader["Location_Customer"].ToString());
                        listViewItem.SubItems.Add(reader["Location_Driver"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Driver"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Metode"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Customer"].ToString());
                        listViewItem.SubItems.Add(reader["Rating_Driver"].ToString());
                        listViewItem.SubItems.Add(reader["status"].ToString());
                        listView5.Items.Add(listViewItem);

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


        public void updateMakanan1()
        {
            String query = "select * from Menu_Makanan where " + comboBox1.Text + " like '%" + textBox5.Text + "%'";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                listView4.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Makanan"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Makanan"].ToString());
                        listViewItem.SubItems.Add(reader["Harga"].ToString());
                        listViewItem.SubItems.Add(reader["Kategori"].ToString());
                        listViewItem.SubItems.Add(reader["ID_Restoran"].ToString());
                        listView4.Items.Add(listViewItem);

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

        public void updateDriver1()
        {

            String query = "select * from Driver where " + comboBox2.Text + " like '%" + textBox4.Text + "%'";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            listView3.Items.Clear();
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
                        if (!reader["Nomor_Telepon_Driver"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["Nomor_Telepon_Driver"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Driver"].ToString());
                            listViewItem.SubItems.Add(reader["Alamat"].ToString());
                            listViewItem.SubItems.Add(reader["TTL"].ToString());
                            listViewItem.SubItems.Add(reader["Kelamin"].ToString());
                            listViewItem.SubItems.Add(reader["Masa_Berlaku_SIM"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_SIM"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_Plat"].ToString());
                            listViewItem.SubItems.Add(reader["Tahun_Pembuatan_Kendaraan"].ToString());
                            listViewItem.SubItems.Add(reader["Masa_Berlaku_STNK"].ToString());
                            listViewItem.SubItems.Add(reader["Tipe"].ToString());
                            listViewItem.SubItems.Add(reader["Merek"].ToString());
                            listViewItem.SubItems.Add(reader["CC_Kendaraan"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_KTP"].ToString());
                            listViewItem.SubItems.Add(reader["Tanggal_KTP"].ToString());
                            listViewItem.SubItems.Add(reader["Masa_Berlaku_KTP"].ToString());
                            listViewItem.SubItems.Add(reader["Nomor_Rekening"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Bank"].ToString());
                            listView3.Items.Add(listViewItem);
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

        public void updateRestoran1()
        {

            String query = "select * from Restoran where " + comboBox3.Text + " like '%" + textBox3.Text + "%'";
            SqlDataReader reader = null;
            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            listView2.Items.Clear();
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
                        ListViewItem listViewItem = new ListViewItem(reader["ID_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Jadwal_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Email_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Website_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nomor_Telepon_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Depan"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Belakang"].ToString());
                        listViewItem.SubItems.Add(reader["Alamat_Resto"].ToString());
                        listViewItem.SubItems.Add(reader["Kota_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Kecamatan_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Kelurahan_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Provinsi_Resto"].ToString());
                        listViewItem.SubItems.Add(reader["Kode_Pos_Restoran"].ToString());
                        listViewItem.SubItems.Add(reader["Nomor_Telepon_Penanggung_Jawab"].ToString());
                        listViewItem.SubItems.Add(reader["Nama_Penanggung_Jawab"].ToString());
                        listViewItem.SubItems.Add(reader["Email_Penanggung_Jawab"].ToString());
                        listViewItem.SubItems.Add(reader["Nomor_Telepon_Pemilik"].ToString());
                        listViewItem.SubItems.Add(reader["Email_Pemilik"].ToString());

                        listView2.Items.Add(listViewItem);

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


        public void updateCustomer1()
        {

            String query = "select * from Customer where " + comboBox4.Text + " like '%" + textBox2.Text + "%'";
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
                        if (!reader["Nomor_Telepon_Customer"].ToString().Equals("0"))
                        {
                            ListViewItem listViewItem = new ListViewItem(reader["Nomor_Telepon_Customer"].ToString());
                            listViewItem.SubItems.Add(reader["Email_Customer"].ToString());
                            listViewItem.SubItems.Add(reader["Nama_Lengkap_Customer"].ToString());
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

        private void button20_Click(object sender, EventArgs e)
        {
            updateDriver1();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            updateRestoran1();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            updateMakanan1();
        }
    }
}
