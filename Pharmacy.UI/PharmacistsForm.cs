using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Pharmacy.UI
{
    public partial class PharmacistsForm : MaterialForm
    {
        // Основные Sql параметры
        SqlConnection SqlConnection;
        public PharmacistsForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, 
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private async void PharmacistsForm_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Accounting"].ConnectionString); // строка подключения
            await SqlConnection.OpenAsync(); // открыли подключение к БД
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Pharmacists] ", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["PharmacistId"]) + "   " + Convert.ToString(sqlReader["PharmacistName"]));
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
            if (label2.Visible)
                label2.Visible = false;
            if (!string.IsNullOrEmpty(PharmacistNameTb.Text) && !string.IsNullOrWhiteSpace(PharmacistNameTb.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Pharmacists] (PharmacistName) " +
                    "VALUES(@PharmacistName)", SqlConnection);
                command.Parameters.AddWithValue("PharmacistName", PharmacistNameTb.Text);                

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Поле: Фармацевт должно быть заполнено!";
            }
        }

        private async void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Pharmacists] ", SqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["PharmacistId"]) + "   " + Convert.ToString(sqlReader["PharmacistName"]));
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

        private async void EditBtn_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;
            if (!string.IsNullOrEmpty(IDTb.Text) && !string.IsNullOrWhiteSpace(IDTb.Text) &&
               !string.IsNullOrEmpty(PharmacistNameTextBox.Text) && !string.IsNullOrWhiteSpace(PharmacistNameTextBox.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Pharmacists] SET [PharmacistName]=@PharmacistName " +
                    "WHERE [PharmacistId] =@Id", SqlConnection);
                command.Parameters.AddWithValue("Id", IDTb.Text);
                command.Parameters.AddWithValue("PharmacistName", PharmacistNameTextBox.Text);         


                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(IDTb.Text) && !string.IsNullOrWhiteSpace(IDTb.Text))
            {
                label5.Visible = true;
                label5.Text = "Поле: Фармацевт должно быть заполнено!";
            }
            else
            {
                label5.Visible = true;
                label5.Text = "Id должен быть заполнен!";
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(IDTextBox.Text) && !string.IsNullOrWhiteSpace(IDTextBox.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Pharmacists] WHERE [PharmacistId]=@Id", SqlConnection); // sql комманда удаление
                command.Parameters.AddWithValue("Id", IDTextBox.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Id должен быть заполнен!";
            }
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
