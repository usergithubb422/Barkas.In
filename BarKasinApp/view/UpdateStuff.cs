using BarKasinApp.controller;
using BarKasinApp.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarKasinApp.view
{
    public partial class UpdateStuff : Form
    {
        private readonly Menu _customer;
        public UpdateStuff(Menu customer)
        {
            InitializeComponent();
            _customer = customer;
        }
        public void Clear()
        {
            txtID.Text = txtName.Text = txtQty.Text = txtReason.Text = txtPrc.Text = String.Empty;
        }
        private void UpdateStuff_Load(object sender, EventArgs e)
        {

        }

        //TOMBOL UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Stuff stf = new Stuff(txtName.Text.Trim(), txtQty.Text.Trim(), txtAddress.Text.Trim(), txtReason.Text.Trim(), txtPrc.Text.Trim());
            ControllerStuff.UpdateStuff(stf, txtID.Text);
            Clear();

            _customer.Display();
            this.Close();
        }

        private void addReason_TextChanged(object sender, EventArgs e)
        {

        }

        private void addPrcStuff_TextChanged(object sender, EventArgs e)
        {

        }

        private void addAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void addQtyStuff_TextChanged(object sender, EventArgs e)
        {

        }

        private void addNameStuff_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
