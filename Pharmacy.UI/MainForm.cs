using System;
using System.Windows.Forms;

namespace Pharmacy.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MedicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicinesWindow medicinesWindow = new MedicinesWindow();
            medicinesWindow.Show();
            Hide();
        }

        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.Show();
            Hide();
        }

        private void PharmacistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PharmacistsForm pharmacistsForm = new PharmacistsForm();
            pharmacistsForm.Show();
            Hide(); 
        }

        private void SalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.Show();
            Hide();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы АИС Аптека: ...... ., \nДата релиза: 05.04.2023 г., \nEmail:  ", "Внимание!!");
        }
    }
}
