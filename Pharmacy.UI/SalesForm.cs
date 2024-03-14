using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Pharmacy.UI
{
    public partial class SalesForm : Form
    {
        // Основные Sql параметры
        SqlConnection SqlConnection;
        public SalesForm()
        {
            InitializeComponent();            
        }

        private async void SalesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pharmacyDBDataSet.Pharmacists". При необходимости она может быть перемещена или удалена.
            this.pharmacistsTableAdapter.Fill(this.pharmacyDBDataSet.Pharmacists);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pharmacyDBDataSet.Medications". При необходимости она может быть перемещена или удалена.
            this.medicationsTableAdapter.Fill(this.pharmacyDBDataSet.Medications);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pharmacyDBDataSet.Customers". При необходимости она может быть перемещена или удалена.
            this.customersTableAdapter.Fill(this.pharmacyDBDataSet.Customers);

            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Accounting"].ConnectionString); // строка подключения
            await SqlConnection.OpenAsync(); // открыли подключение к БД
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Sales] ", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["SaleId"]) + "   " + Convert.ToString(sqlReader["Date"]) +
                        "  " + Convert.ToString(sqlReader["CustomerName"]) + "   " + Convert.ToString(sqlReader["MedicineName"]) +
                        "   " + Convert.ToString(sqlReader["PharmacistName"]) + "  " + Convert.ToString(sqlReader["Quantity"]) + 
                        "  " + Convert.ToString(sqlReader["Price"]) +  "  " + Convert.ToString(sqlReader["Amount"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlReader?.Close(); // закрыли подключение к БД
            }

        }

        private async void ADDguna2Btn_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;
            if (!string.IsNullOrEmpty(dateTimePicker1.Text) && !string.IsNullOrWhiteSpace(dateTimePicker1.Text) &&
               !string.IsNullOrEmpty(CustomerNameCb.Text) && !string.IsNullOrWhiteSpace(CustomerNameCb.Text) &&
               !string.IsNullOrEmpty(MedicineNameCb.Text) && !string.IsNullOrWhiteSpace(MedicineNameCb.Text) &&
               !string.IsNullOrEmpty(PharmacistNameCb.Text) && !string.IsNullOrWhiteSpace(PharmacistNameCb.Text) &&
               !string.IsNullOrEmpty(QuantityTb.Text) && !string.IsNullOrWhiteSpace(QuantityTb.Text) && 
               !string.IsNullOrEmpty(PriceTb.Text) && !string.IsNullOrWhiteSpace(PriceTb.Text) && 
               !string.IsNullOrEmpty(AmountTb.Text) && !string.IsNullOrWhiteSpace(AmountTb.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Sales] (Date, CustomerName, " +
                    "MedicineName, PharmacistName, Quantity, Price, Amount) " +
                    "VALUES(@Date, @CustomerName, @MedicineName, @PharmacistName, @Quantity, @Price, @Amount)", SqlConnection);
                command.Parameters.AddWithValue("Date", dateTimePicker1.Text);
                command.Parameters.AddWithValue("CustomerName", CustomerNameCb.Text);
                command.Parameters.AddWithValue("MedicineName", MedicineNameCb.Text);
                command.Parameters.AddWithValue("PharmacistName", PharmacistNameCb.Text);
                command.Parameters.AddWithValue("Quantity", QuantityTb.Text);
                command.Parameters.AddWithValue("Price", PriceTb.Text);
                command.Parameters.AddWithValue("Amount", AmountTb.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Поля: Количество, Цена, Сумма должны быть заполнены!";
            }
        }

        private async void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Sales] ", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["SaleId"]) + "   " + Convert.ToString(sqlReader["Date"]) +
                        "  " + Convert.ToString(sqlReader["CustomerName"]) + "   " + Convert.ToString(sqlReader["MedicineName"]) +
                        "   " + Convert.ToString(sqlReader["PharmacistName"]) + "  " + Convert.ToString(sqlReader["Quantity"]) +
                        "  " + Convert.ToString(sqlReader["Price"]) + "  " + Convert.ToString(sqlReader["Amount"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlReader?.Close(); // закрыли подключение к БД
            }
        }

        private void CALCguna2Button5_Click(object sender, EventArgs e)
        {
            double quantity;
            double price;

            quantity = Convert.ToDouble(QuantityTb.Text);
            price = Convert.ToDouble(PriceTb.Text);

            switch (comboBox4.Text)
            {
                case "*":
                    AmountTb.Text = Convert.ToString(quantity * price);
                    break;
            }
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private async void EDITguna2Button2_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
                label10.Visible = false;
            if (!string.IsNullOrEmpty(IDTb.Text) && !string.IsNullOrWhiteSpace(IDTb.Text) &&
               !string.IsNullOrEmpty(DatedateTimePicker2.Text) && !string.IsNullOrWhiteSpace(DatedateTimePicker2.Text) &&
               !string.IsNullOrEmpty(CustomerCb.Text) && !string.IsNullOrWhiteSpace(CustomerCb.Text) &&
               !string.IsNullOrEmpty(MedicineCb.Text) && !string.IsNullOrWhiteSpace(MedicineCb.Text) &&
               !string.IsNullOrEmpty(PharmacistCb.Text) && !string.IsNullOrWhiteSpace(PharmacistCb.Text) &&
               !string.IsNullOrEmpty(QuantityTextBox.Text) && !string.IsNullOrWhiteSpace(QuantityTextBox.Text) &&
               !string.IsNullOrEmpty(PriceTextBox.Text) && !string.IsNullOrWhiteSpace(PriceTextBox.Text) &&
               !string.IsNullOrEmpty(AmountTextbox.Text) && !string.IsNullOrWhiteSpace(AmountTextbox.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Sales] SET [Date]=@Date, " +
                    "[CustomerName]=@CustomerName, [MedicineName]=@MedicineName, [PharmacistName]=@PharmacistName, " +
                    "[Quantity]=@Quantity, [Price]=@Price, [Amount]=@Amount " +
                    "WHERE [SaleId]=@Id", SqlConnection);
                command.Parameters.AddWithValue("Id", IDTb.Text);
                command.Parameters.AddWithValue("Date", DatedateTimePicker2.Text);
                command.Parameters.AddWithValue("CustomerName", CustomerCb.Text);
                command.Parameters.AddWithValue("MedicineName", MedicineCb.Text);
                command.Parameters.AddWithValue("PharmacistName", PharmacistCb.Text);
                command.Parameters.AddWithValue("Quantity", QuantityTextBox.Text);
                command.Parameters.AddWithValue("Price", PriceTextBox.Text);
                command.Parameters.AddWithValue("Amount", AmountTextbox.Text);


                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(IDTb.Text) && !string.IsNullOrWhiteSpace(IDTb.Text))
            {
                label10.Visible = true;
                label10.Text = "Поля: Количество, Цена, Сумма должны быть заполнены!";
            }
            else
            {
                label10.Visible = true;
                label10.Text = "Id должен быть заполнен!";
            }
        }

        private void CALCULATEguna2Button1_Click(object sender, EventArgs e)
        {
            double quantity;
            double price;

            quantity = Convert.ToDouble(QuantityTextBox.Text);
            price = Convert.ToDouble(PriceTextBox.Text);

            switch (comboBox1.Text)
            {
                case "*":
                    AmountTextbox.Text = Convert.ToString(quantity * price);
                    break;
            }
        }

        private async void DELETEguna2Button1_Click(object sender, EventArgs e)
        {
            if (label19.Visible)
                label19.Visible = false;
            if (!string.IsNullOrEmpty(IDTextBox.Text) && !string.IsNullOrWhiteSpace(IDTextBox.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Sales] WHERE [SaleId]=@Id", SqlConnection); // sql комманда удаление
                command.Parameters.AddWithValue("Id", IDTextBox.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label19.Visible = true;
                label19.Text = "Id должен быть заполнен!";
            }
        }
    }
}
