using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Lombardo
{
    public partial class FormNewCategory : Form
    {

        static string connectionString = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True"; // Строка соединения
        SqlConnection connection = new SqlConnection(connectionString); // подключение к бд
        string newSqlQuery = ""; // новый запрос для выполнения

        public FormNewCategory()
        {
            InitializeComponent();
        }

        private void FormNewCategory_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lombardDataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.lombardDataSet.Category);

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

        private void RefreshDGVCategory()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Category", connection);
            adapter.Fill(ds);
            dataGridViewCategory.DataSource = ds.Tables[0];
        }


        private void buttonAddNewCategory_Click(object sender, EventArgs e)
        {
            if (textBoxAddNewCategory.Text != "")
            {
                newSqlQuery = "Insert into Category (наименование) values ('" + textBoxAddNewCategory.Text + "');";
                ExecuteSql(newSqlQuery, "Select * from Category", dataGridViewCategory);
                RefreshDGVCategory();
            }
            else
            {
                MessageBox.Show("Введены не все данные", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (textBoxAddNewCategory.Text != "")
            {
                newSqlQuery = "Update Category set наименование = '" + textBoxAddNewCategory.Text + "' where id_категории =  " + dataGridViewCategory.CurrentRow.Cells[0].Value.ToString();
                ExecuteSql(newSqlQuery, "Select * from Category", dataGridViewCategory);
                RefreshDGVCategory();
            }
            else
            {
                MessageBox.Show("Проверьте веденные данные");
            }
        }
    }
}
