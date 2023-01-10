using BarKasinApp.controller;
using BarKasinApp.model;
using BarKasinApp.view;

namespace BarKasinApp
{
    public partial class Menu : Form
    {
        AddStuff stuff;
        public Menu()
        {
            InitializeComponent();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
        }

        public void Display()
        {
            ControllerStuff.DisplayAndSearch("Select ID, nama, banyak_barang, harga, tanggal FROM stuff", dataGridView);
        }

        //TOMBOL TAMBAH BARANG
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStuff stuff = new AddStuff(this);
            stuff.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {  
            Display();
        }

        //METHOD SEARCH
        private void search_TextChanged(object sender, EventArgs e)
        {
            ControllerStuff.DisplayAndSearch("Select ID, nama, banyak_barang, harga, tanggal FROM stuff WHERE ID LIKE '%"+ search.Text + "%'", dataGridView); 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string Index = dataGridView.SelectedRows[0].ToString();
                DetailBarang detail = new DetailBarang(Index);
                detail.ShowDialog();
            }
        }


        //TOMBOL RESET ID DATABASE
        private void button3_Click(object sender, EventArgs e)
        {
            ControllerStuff.ResetID();
        }

        //TOMBOL HAPUS
        private void btnDel_Click(object sender, EventArgs e)
        {
            ControllerStuff.DeleteStuff(search.Text);
            search.Text = String.Empty;
        }

        //TOMBOL UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateStuff stuff = new UpdateStuff(this);
            stuff.ShowDialog();
        }
    }

}