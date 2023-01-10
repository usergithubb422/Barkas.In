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

namespace BarKasinApp
{
    public partial class AddStuff : Form
    {
        private readonly Menu _customer;
        public AddStuff(Menu customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        public void Clear()
        {
            addNameStuff.Text = addQtyStuff.Text = addAddress.Text = addPrcStuff.Text = addReason.Text = String.Empty;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

            Stuff barang = new Stuff(addNameStuff.Text.Trim(), addQtyStuff.Text.Trim(), addAddress.Text.Trim(), addReason.Text.Trim(),addPrcStuff.Text.Trim());
            ControllerStuff.NewStuff(barang); 
            Clear();
            
            
            _customer.Display();
            this.Close();
            
        }
    }
}
