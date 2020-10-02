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
using System.IO;

namespace Lombardo
{
    public partial class Form1 : Form
    {
        static string connectionString = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True"; // Строка соединения
        SqlConnection connection = new SqlConnection(connectionString); // подключение к бд
        string newSqlQuery = ""; // новый запрос для выполнения


        public Form1()
        {
            InitializeComponent();
            LoadCategory();
            LoadStatus();
            comboBoxCategory.SelectedIndex = 0;
            comboBoxStatus.SelectedIndex = 0;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lombardDataSet.Seller". При необходимости она может быть перемещена или удалена.
            this.sellerTableAdapter.Fill(this.lombardDataSet.Seller);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lombardDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.lombardDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lombardDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.lombardDataSet.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lombardDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.lombardDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lombardDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.lombardDataSet.Client);



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

        private void LoadCategory()//загрузка списка категорий
        {
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            //запрос
            SqlCommand command = new SqlCommand("select наименование from Category", con);
            sqlReader = command.ExecuteReader();
            try
            {

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

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)//обновляем список после изменения выбранной категории
        {
            string selectedCategory = comboBoxCategory.Text.ToString();
            string selectedStatus = comboBoxStatus.Text.ToString();
            newSqlQuery = "Select * from Product";
            ExecuteSql(newSqlQuery, "Select * from Product where категория='" + selectedCategory + "'and статус='" + selectedStatus + "'", dataGridViewProduct);
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)//обновляем список после изменения выбранного товара
        {
            string selectedStatus = comboBoxStatus.Text.ToString();
            string selectedCategory = comboBoxCategory.Text.ToString();
            newSqlQuery = "Select * from Product";
            ExecuteSql(newSqlQuery, "Select * from Product where статус='" + selectedStatus + "'and  категория='" + selectedCategory + "'", dataGridViewProduct);// and where категория =
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
            sqlReader = command.ExecuteReader();
            try
            {

                while (sqlReader.Read())
                {
                    comboBoxStatus.Items.Add(sqlReader[0].ToString());
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

        
        //
        //
        private void RefreshDGVWorkers()//обновляем список работников
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Seller", connection);
            adapter.Fill(ds);
            dataGridViewWorkers.DataSource = ds.Tables[0];
        }

        private void RefreshDGVClient()//обновляем список клиентов
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Client", connection);
            adapter.Fill(ds);
            dataGridViewClient.DataSource = ds.Tables[0];
        }

        private void RefreshDGVProduct()//обновляем список товаров
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Product", connection);
            adapter.Fill(ds);
            dataGridViewProduct.DataSource = ds.Tables[0];
        }
        //
        //
        private void insert_worker_button_Click(object sender, EventArgs e)//добавление сотрудника
        {
            if (textBoxLastName.Text != "" || textBoxFirstName.Text != "" || textBoxMidName.Text != "")
            {
                newSqlQuery = "Insert into Seller (фамилия,имя,отчество) values ('" + textBoxLastName.Text + "','" + textBoxFirstName.Text + "','" + textBoxMidName.Text + "');";
                ExecuteSql(newSqlQuery, "Select * from Seller", dataGridViewWorkers);
                RefreshDGVWorkers();
            }
            else
            {
                MessageBox.Show("Введены не все данные", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void update_worker_button_Click(object sender, EventArgs e)//обновление измененных данных сотрудника
        {
            if (dataGridViewWorkers.CurrentRow != null && textBoxWorkerId.Text != "" && textBoxFirstName.Text != "" && textBoxMidName.Text != "" && textBoxLastName.Text != "")
            {
                newSqlQuery = "Update Seller set фамилия = '" + textBoxLastName.Text + "', имя = '" + textBoxFirstName.Text + "', отчество = '" + textBoxMidName.Text + "' where id_сотрудника =  " + dataGridViewWorkers.CurrentRow.Cells[0].Value.ToString();
                ExecuteSql(newSqlQuery, "Select * from Seller", dataGridViewWorkers);
                RefreshDGVWorkers();
            }
            else
            {
                MessageBox.Show("Проверьте веденные данные");
            }
        }

        private void delete_worker_button_Click(object sender, EventArgs e)//удаление работника
        {
            if (dataGridViewWorkers.CurrentRow != null && textBoxFirstName.Text != "" && textBoxMidName.Text != "" && textBoxLastName.Text != "")
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить сотрудника?", "Удаление сотрудника", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    newSqlQuery = "Delete from Seller where id_сотрудника =  " + textBoxWorkerId.Text;
                    ExecuteSql(newSqlQuery, "Select * from Seller", dataGridViewWorkers);
                    RefreshDGVWorkers();
                    MessageBox.Show("Сотрудник удален");
                }

            }
            else
            {
                MessageBox.Show("Проверьте веденные данные");
            }
        }                
        //
        //
        private void insert_client_button_Click(object sender, EventArgs e)//добавляем клиента
        {
            FormNewClient newClientForm = new FormNewClient(false, "", "", "", "", "", "");


            if (newClientForm.ShowDialog() != DialogResult.OK)
            {
                RefreshDGVClient();
            }
        }

        private void update_client_button_Click(object sender, EventArgs e)//обновляем измененные данные клиента
        {
            FormNewClient newClientForm = new FormNewClient(true, dataGridViewClient.CurrentRow.Cells[0].Value.ToString(),
                dataGridViewClient.CurrentRow.Cells[1].Value.ToString(),
                dataGridViewClient.CurrentRow.Cells[2].Value.ToString(),
                dataGridViewClient.CurrentRow.Cells[3].Value.ToString(),
                dataGridViewClient.CurrentRow.Cells[4].Value.ToString(),
                dataGridViewClient.CurrentRow.Cells[5].Value.ToString());

            if (newClientForm.ShowDialog() != DialogResult.OK)
            {
                RefreshDGVClient();
            }
        }

        private void delete_client_button_Click(object sender, EventArgs e)//удаляем клиента
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                newSqlQuery = "Delete from Client where id_клиента =  " + dataGridViewClient.CurrentRow.Cells[0].Value.ToString();
                ExecuteSql(newSqlQuery, "Select * from Client", dataGridViewWorkers);
                RefreshDGVClient();
                MessageBox.Show("Клиент удален");
            }
        }
        //
        //
        private void insert_new_product_button_Click(object sender, EventArgs e)// добавляем новый товар
        {
            FormNewProduct newProduct = new FormNewProduct(false, "", "", "", "", "", "", "", "", "", "", "");

            if (newProduct.ShowDialog() != DialogResult.OK)
            {
                RefreshDGVProduct();
                comboBoxCategory.SelectedIndex = 0;
                comboBoxStatus.SelectedIndex = 0;
            }
        }

        private void update_product_button_Click(object sender, EventArgs e) // кнопка обновление товара
        {
            FormNewProduct newProduct = new FormNewProduct(true, dataGridViewProduct.CurrentRow.Cells[0].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[1].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[2].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[3].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[4].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[5].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[6].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[7].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[8].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[9].Value.ToString(),
                dataGridViewProduct.CurrentRow.Cells[10].Value.ToString());

            if (newProduct.ShowDialog() != DialogResult.OK)
            {
                RefreshDGVProduct();
                comboBoxCategory.SelectedIndex = 0;
                comboBoxStatus.SelectedIndex = 0;
            }
        }

        private void dataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e)//удаляем товар
        {
            //подключение к базе данных
            string sqlCon = @"Data Source=DESKTOP-69F0QS6\SQLEXPRESS;Initial Catalog=Lombard;Integrated Security=True";
            SqlConnection con = new SqlConnection(sqlCon);
            //объявление переменной для чтения
            SqlDataReader sqlReader = null;
            string summaryMoney;

            con.Open();
            //запрос
            SqlCommand command;
            command = new SqlCommand("select SUM(стоимость) from Product where id_клиента='" + dataGridViewClient.CurrentRow.Cells[0].Value.ToString() + "'", con);
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                labelSum.Text = Convert.ToString(sqlReader[0]);
            }          

            con.Close();



        }              

        private void pictureBox1_Click(object sender, EventArgs e)//добавляем фото товара
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;

            newSqlQuery = "Insert into Photo (id_товара,path) values ('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + filename + "');";
            ExecuteSql(newSqlQuery, "Select * from Client", dataGridViewClient);


        }

        int idSlide = 0; // текущий слайд
        List<string> collImages = new List<string>(); // коллекция изображений выбранной недвижимости

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//щелчок на ячейку 
        {
            PictureBox newPictureBox = sender as PictureBox;
            var conn = new SqlConnection(connectionString);

            var cmd = new SqlCommand("Select path from Photo where id_товара = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", conn);
            conn.Open();

            var newReader = cmd.ExecuteReader();
            collImages.Clear();
            while (newReader.Read())
            {
                collImages.Add(newReader.GetValue(0).ToString());// добавление всех полученных фотографий в лист 
            }
            if (collImages.Count > 0)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(collImages[0]);

            }

            idSlide = 0;
            conn.Close();
        }
        

        private void pictureBoxProduct_Click(object sender, EventArgs e)//добавление фото товара
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;

            newSqlQuery = "Insert into Photo (id_товара,path) values ('" + dataGridViewProduct.CurrentRow.Cells[0].Value.ToString() + "','" + filename + "');";
            ExecuteSql(newSqlQuery, "Select * from Product", dataGridViewProduct);
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)//выбор товара и вывод данных товара
        {
            PictureBox newPictureBox = sender as PictureBox;
            // pictureBox1.Tag = newPictureBox.Tag.ToString();
            var conn = new SqlConnection(connectionString);

            var cmd = new SqlCommand("Select path from Photo where id_товара = '" + dataGridViewProduct.CurrentRow.Cells[0].Value.ToString() + "'", conn);
            conn.Open();

            var newReader = cmd.ExecuteReader();
            collImages.Clear();
            while (newReader.Read())
            {
                collImages.Add(newReader.GetValue(0).ToString());// добавление всех полученных фотографий в лист 
            }
            if (collImages.Count > 0)
            {
                pictureBoxProduct.Image = System.Drawing.Image.FromFile(collImages[0]);

            }

            idSlide = 0;
            conn.Close();
        }

        private void buttonNextPhotoProduct_Click(object sender, EventArgs e)//листаем фото
        {
            if (collImages.Count() > 0)
            {


                if (idSlide < collImages.Count())
                {
                    pictureBoxProduct.Image = System.Drawing.Image.FromFile(collImages[idSlide]);
                }
                else
                {
                    idSlide = 0;
                    pictureBoxProduct.Image = System.Drawing.Image.FromFile(collImages[idSlide]);
                }
                idSlide++;

            }
        }

        private void buttonAddNewCategory_Click(object sender, EventArgs e) // открытие формы категорий
        {
            FormNewCategory newCategoryForm = new FormNewCategory();

            if (newCategoryForm.ShowDialog() != DialogResult.OK)
            {
                RefreshDGVClient();
            }
        }

        private void button_Results_Click(object sender, EventArgs e) //вывод отчета
        {       

            newSqlQuery = "Select * from Product";
            //ExecuteSql(newSqlQuery, "Select * from Product where дата_принятия between'" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value +  "'", dataGridViewResults);
            ExecuteSql(newSqlQuery, "Select * from Product where DateDiff(day, дата_принятия, '" + DateTime.Today + "' ) <= срок_хранения", dataGridViewResults);
            //ExecuteSql(newSqlQuery, "Select * from Product where DateAdd(day, дата_принятия , '" + DateTime.Now + "') <= срок_хранения", dataGridViewResults);


        }
    }
}
