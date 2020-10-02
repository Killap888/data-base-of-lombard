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
    public partial class FormNewProduct : Form
    {
        static string connectionString = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True"; // Строка соединения
        SqlConnection connection = new SqlConnection(connectionString); // подключение к бд
        public bool updateDataProduct = false;
        string idDataClient;
        string idDataSeller;

        private void FormNewProduct_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadStatus();
            LoadIdClient();
            LoadIdSeller();
            comboBoxCategory.SelectedIndex = 0;
            comboBoxIdClient.SelectedIndex = 0;
            comboBoxIdSeller.SelectedIndex = 0;
            comboBoxProductStatus.SelectedIndex = 0;
        }

        public FormNewProduct(bool updateProduct, string ProductID, string productCategory, string productName, string productDiscription, string productDefects, string productPrice, string productDateBuying, string idClient, string idSeller, string productDateStorage, string productStatus)
        {
            InitializeComponent();
            updateDataProduct = updateProduct;
            textBoxIdNewProduct.Text = ProductID;
            comboBoxCategory.Text = productCategory;
            textBoxNameNewProduct.Text = productName;
            textBoxDescriptionNewProduct.Text = productDiscription;
            textBoxDefectsNewProduct.Text = productDefects;
            textBoxPriceNewProduct.Text = productPrice;
            maskedTextBoxDateBuyNewProduct.Text = productDateBuying;
            //comboBoxIdClient.Text = OutputClient(idClient);
            //OutputSeller(idSeller);
            //idDataClient = idClient;
            //idDataSeller = idSeller; 
            comboBoxStorageDateNewProduct.Text = productDateStorage;
            //comboBoxProductStatus.Text = productStatus;

        }

        private void LoadCategory()
        {
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            //запрос
            SqlCommand command = new SqlCommand("select наименование from Category", con);

            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBoxCategory.Items.Add(sqlReader[0].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    con.Close();
                }
            }
        }

        private void LoadStatus()
        {
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            //запрос
            SqlCommand command = new SqlCommand("select статус from Status", con);

            try
            {
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    comboBoxProductStatus.Items.Add(sqlReader[0].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    con.Close();
                }
            }
        }

        private void LoadIdClient()
        {
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            //запрос
            SqlCommand command = new SqlCommand("select фамилия, имя, отчество from Client", con);

            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                string lineName = sqlReader[0].ToString() + " " + sqlReader[1].ToString() + " " + sqlReader[2].ToString();
                comboBoxIdClient.Items.Add(lineName);
            }

            con.Close();
        }

        private void LoadIdSeller()
        {

            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            //запрос
            SqlCommand command = new SqlCommand("select фамилия, имя, отчество from Seller", con);

            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                string lineName = sqlReader[0].ToString() + " " + sqlReader[1].ToString() + " " + sqlReader[2].ToString();
                comboBoxIdSeller.Items.Add(lineName);
            }

            con.Close();
        }

        private string OutputClient(string clientID)
        {
            //подключение к базе данных
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            try
            {
                con.Open();
                //запрос
                SqlCommand command;
                string[] clientFIO = comboBoxIdClient.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                command = new SqlCommand("select id_клиента from Client where фамилия='" +
                    clientFIO[0] + "' and имя = '" + clientFIO[1] + "'and отчество='" + clientFIO[2] + "'", con);
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    clientID = Convert.ToString(sqlReader[0]);
                }
                return clientID;



            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    con.Close();

                }
            }

        }

        private string OutputSeller(string sellerID)
        {
            //подключение к базе данных
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            try
            {
                con.Open();
                //запрос
                SqlCommand command;
                string[] sellerFIO = comboBoxIdSeller.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                command = new SqlCommand("select id_сотрудника from Seller where фамилия = '" +
                    sellerFIO[0] + "' and имя = '" + sellerFIO[1] + "' and отчество = '" + sellerFIO[2] + "'", con);
                sqlReader = command.ExecuteReader();
                while (sqlReader.Read())
                {
                    sellerID = Convert.ToString(sqlReader[0]);
                }
                return sellerID;
            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                    con.Close();
                }
            }

        }

        private void button_save_new_product_Click(object sender, EventArgs e)
        {
            if(updateDataProduct == false)
            {
                if (textBoxNameNewProduct.Text != "" &&
               textBoxPriceNewProduct.Text != "" && maskedTextBoxDateBuyNewProduct.Text != "" &&
               comboBoxStorageDateNewProduct.Text.ToString() != "")
                {
                    connection.Open();

                    string ClientIDQuery = OutputClient(comboBoxIdClient.SelectedItem.ToString());
                    string SellerIDQuery = OutputSeller(comboBoxIdSeller.SelectedItem.ToString());

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into Product (категория,наименование,описание,дефекты,стоимость,дата_принятия,id_клиента,id_продавца,срок_хранения,статус) " +
                        "values ('" + comboBoxCategory.Text + "','" +
                        textBoxNameNewProduct.Text + "','" +
                        textBoxDescriptionNewProduct.Text + "','" +
                        textBoxDefectsNewProduct.Text.ToString() + "','" +
                        textBoxPriceNewProduct.Text.ToString() + "','" +
                        maskedTextBoxDateBuyNewProduct.Text + "','" +
                        ClientIDQuery + "','" +
                        SellerIDQuery + "','" +
                        comboBoxStorageDateNewProduct.Text + "','" +
                        comboBoxProductStatus.Text + "');";

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные");
                }
                Close();
            }
            else
            {
                if (textBoxNameNewProduct.Text != "" &&
               textBoxPriceNewProduct.Text != "" && maskedTextBoxDateBuyNewProduct.Text != "" &&
               comboBoxStorageDateNewProduct.Text.ToString() != "")
                {
                    connection.Open();

                    string ClientIDQuery = OutputClient(comboBoxIdClient.SelectedItem.ToString());
                    string SellerIDQuery = OutputSeller(comboBoxIdSeller.SelectedItem.ToString());

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Update Product set категория = '" + comboBoxCategory.Text + 
                        "', наименование = '" + textBoxNameNewProduct.Text + 
                        "', описание = '" + textBoxDescriptionNewProduct.Text +
                        "', дефекты = '" + textBoxDefectsNewProduct.Text.ToString() + 
                        "', стоимость = '" + textBoxPriceNewProduct.Text.ToString() + 
                        "', id_клиента = '" + ClientIDQuery +
                        "', id_продавца = '" + SellerIDQuery +
                        "', срок_хранения = '" + comboBoxStorageDateNewProduct.Text +
                        "', статус = '" + comboBoxProductStatus.Text +
                        "' where id_товара =  " + textBoxIdNewProduct.Text;                  

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

        private void button_close_FormNewProduct_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxProductPrice_TextChanged(object sender, EventArgs e)
        {
            if(textBoxProductPrice.TextLength >= 1)
            {
                double productPrice = 0;
                productPrice = Convert.ToInt32(textBoxProductPrice.Text.ToString()) * 1.3;
                textBoxPriceNewProduct.Text = Convert.ToString(productPrice);
            }  
            else
            {

            }

        }
    }
}
