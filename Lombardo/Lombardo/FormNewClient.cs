using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lombardo
{
    public partial class FormNewClient : Form
    {
        static string connectionString = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True"; // Строка соединения
        SqlConnection connection = new SqlConnection(connectionString); // подключение к бд
        public bool updateDataClient = false;

        public FormNewClient(bool updateClient, string idClient, string LastName, string FirstName, string MidName, string PasswordData, string PhoneNumber)
        {
            InitializeComponent();
            updateDataClient = updateClient;
            textBoxIdClient.Text = idClient;
            textBoxClientLastName.Text = LastName;
            textBoxClientFirstName.Text = FirstName;
            textBoxClientMidName.Text = MidName;
            maskedTextBoxClientPassport.Text = PasswordData;
            maskedTextBoxClientTel.Text = PhoneNumber;
        }

        private void ExecuteSql(string sqlQuery, string sqlSelect, DataGridView dvg)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection);
                adapter.Fill(ds);
                dvg.DataSource = ds.Tables[0];

            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e);
            }
            finally
            {
                connection.Close();
                dvg.Refresh();
            }
        }

        private void button_save_new_client_Click(object sender, EventArgs e)
        {
            if (updateDataClient == false)
            {
                if (textBoxClientLastName.Text != "" &&
               textBoxClientFirstName.Text != "" && textBoxClientMidName.Text != "" &&
               maskedTextBoxClientPassport.Text.ToString() != "" && maskedTextBoxClientTel.Text != "" &&
               maskedTextBoxClientPassport.Text.Length == 11 && maskedTextBoxClientTel.Text.Length == 15)
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();                   
                    cmd.CommandText = "Insert into Client(фамилия, имя, отчество, серия_номер_паспорта, номер_телефона) " +
                        "values ('" + textBoxClientLastName.Text + "','" +
                        textBoxClientFirstName.Text + "','" +
                        textBoxClientMidName.Text + "','" +
                        maskedTextBoxClientPassport.Text.ToString() + "','" +
                        maskedTextBoxClientTel.Text.ToString() + "');";

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные");
                }
                Close();

            }
            else
            {
                if (textBoxClientLastName.Text != "" &&
               textBoxClientFirstName.Text != "" && textBoxClientMidName.Text != "" &&
               maskedTextBoxClientPassport.Text.ToString() != "" && maskedTextBoxClientTel.Text != "" && maskedTextBoxClientPassport.Text.Length == 11 && maskedTextBoxClientTel.Text.Length == 15)
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Update Client set фамилия = '" + textBoxClientLastName.Text + "', имя = '" +
                        textBoxClientFirstName.Text + "', отчество = '" +
                        textBoxClientMidName.Text + "', серия_номер_паспорта = '" +
                        maskedTextBoxClientPassport.Text + "', номер_телефона = '" +
                        maskedTextBoxClientTel.Text + "' where id_клиента =  " +
                        textBoxIdClient.Text;

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные");
                }

                Close();
            }

        }

        private void button_close_form_NewClient_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
