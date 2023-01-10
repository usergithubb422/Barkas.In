using BarKasinApp.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BarKasinApp.controller
{
    class ControllerStuff
    {
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

        public static void NewStuff(Stuff stf)
        {
            string sql = "INSERT INTO stuff(nama, banyak_barang, alamat, harga, alasan) VALUES (@stfName, @stfQty, @stfAddress, @stfPrice, @stfReason)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            
            
            cmd.Parameters.Add("@stfName", MySqlDbType.VarChar).Value = stf.Nama;
            cmd.Parameters.Add("@stfQty", MySqlDbType.VarChar).Value = stf.BanyakBarang;
            cmd.Parameters.Add("@stfAddress", MySqlDbType.VarChar).Value = stf.Alamat;
            cmd.Parameters.Add("@stfPrice", MySqlDbType.VarChar).Value = stf.Harga;
            cmd.Parameters.Add("@stfReason", MySqlDbType.VarChar).Value = stf.Alasan;


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch (MySqlException ex)
            {
                MessageBox.Show("Adding Failed!! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateStuff(Stuff stf, string id)
        {
            string sql = "UPDATE stuff SET nama = @stfName, banyak_barang = @stfQty, alamat = @stfAddress, harga = @stfPrice, alasan = @stfReason WHERE ID = @stfID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@stfID", MySqlDbType.Int64).Value = id;
            
            cmd.Parameters.Add("@stfName", MySqlDbType.VarChar).Value = stf.Nama;
            
            cmd.Parameters.Add("@stfQty", MySqlDbType.VarChar).Value = stf.BanyakBarang;

            cmd.Parameters.Add("@stfAddress", MySqlDbType.VarChar).Value = stf.Alamat;

            cmd.Parameters.Add("@stfPrice", MySqlDbType.VarChar).Value = stf.Harga;

            cmd.Parameters.Add("@stfReason", MySqlDbType.VarChar).Value = stf.Alasan;                
            

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Updating Failed!! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DeleteStuff(string id)
        {
            string sql = "DELETE FROM stuff WHERE ID = @stfID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@stfID", MySqlDbType.Int64).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Deleting Failed!! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ResetID();
            con.Close();
        }

        public static void ResetID()
        {
            string sql = "ALTER TABLE stuff AUTO_INCREMENT=1";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            //cmd.Parameters.Add("@stfID", MySqlDbType.Int64).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Deleting Failed!! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            dgv.DataSource = table;
            con.Close();
        }
        
    }
}
