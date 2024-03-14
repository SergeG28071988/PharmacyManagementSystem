using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy.UI
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Accounting"].ConnectionString);

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Populate()
        {
            conn.Open();
            string query = "select * from Customers";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from Customers where CustomerId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные о покупателях удалены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }

        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomersDGV.SelectedRows[0].Cells[0].Value.ToString();
            CustomerTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustomerTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Customers  values (" + IdTb.Text + ", '" + CustomerTb.Text + "', '" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные о покупателях добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustomerTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Customers set CustomerName='" + CustomerTb.Text + "', Phone='" + PhoneTb.Text + "' where CustomerId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные о покупателях обновлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
