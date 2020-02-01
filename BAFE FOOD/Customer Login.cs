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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }


   
        public static string idCus;
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            idCus = textBox1.Text;
        }
        string telp;
        koneksi konn = new koneksi();
        private void button1_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                SqlDataReader reader = null;
                string sql = "SELECT * FROM Customer WHERE Nomor_Telepon_Customer = '" + textBox1.Text + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        telp = reader["Nomor_Telepon_Customer"].ToString();
                           
                    }
                    reader.Close();
                }

            
                if (textBox1.Text.Equals(telp))
                {
                    idCus = textBox1.Text;
                    list_Restoran a = new list_Restoran();
                    a.Show();
                    this.Hide();
                }
               
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer Tidak Ada Pada Database");
            }
            finally
            {
                conn.Close();
            }


           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utama a = new Utama();
            a.Show();
            this.Hide();
        }
    }
}
