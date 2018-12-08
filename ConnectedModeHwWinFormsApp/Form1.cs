using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ConnectedModeHwWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "salesDataDataSet.Sales". При необходимости она может быть перемещена или удалена.
            //this.salesTableAdapter.Fill(this.salesDataDataSet.Sales);
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string commandText;
            SqlConnection connection = new SqlConnection("Data Source=localhost; Initial Catalog=SalesData; Integrated Security=SSPI;");

            string selectedItem = comboBox1.SelectedItem.ToString();
            string allCustomers = "Select * from Customers";
            string allEmployees = "Select * from Employees";
            if (selectedItem == allCustomers)
            {
                commandText = allCustomers;
            }
            else if (selectedItem == allEmployees)
            {
                commandText = allEmployees;
            }
            else
            {
                commandText = "select c.CustomerName + ' ' + c.CustomerSurname Customer, e.EmployeeName + ' ' + EmployeeName Employee, s.TransactionAmount, s.TransactionDate from Customers c, Employees e, Sales s where s.CustomerId = c.Id and s.EmployeeId = e.Id";
            }

            SqlCommand command = new SqlCommand(commandText, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                textBox1.Text += "Customer\t\t\t\tEmployee\t\t\t\tTransactionAmount";
                while (reader.Read())
                {
                    textBox1.Text += Environment.NewLine + "__________________________________________________________________________________________________________________________";
                    textBox1.Text += Environment.NewLine + $"{reader[0]}\t\t\t{reader[1]}\t\t\t\t{reader[2]}";
                }
                //MessageBox.Show(text);
                //textBox1.AppendText(text);
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Graphics formGraphics = CreateGraphics();
            //string drawString = sender.ToString();
            //Font drawFont = new Font("Arial", 16);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);
            //float x = 150.0F;
            //float y = 50.0F;
            //StringFormat drawFormat = new StringFormat();
            //formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            //drawFont.Dispose();
            //drawBrush.Dispose();
            //formGraphics.Dispose();
        }
    }
}
