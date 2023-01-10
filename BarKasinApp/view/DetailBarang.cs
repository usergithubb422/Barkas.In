using BarKasinApp.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BarKasinApp.model;

namespace BarKasinApp
{
    public partial class DetailBarang : Form
    {
        public DetailBarang(string index)
        {
            InitializeComponent();
            
        }

        public static MySqlConnection GetConnection()
        {
            string sql = "server=localhost;username=root;password=;database=barkas;sslMode=none";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Koneksi Buruk ! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        private void DetailBarang_Load(object sender, EventArgs e)
        {
            string sql = "SELECT nama, banyak_barang, harga, kategori, alamat from stuff WHERE ID =@ ID ";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            //cmd.CommandType = CommandType.Text;

            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                txtName.Text = rdr.GetValue(0).ToString();
                
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
