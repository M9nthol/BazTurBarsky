using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YourNamespace
{
    public partial class Form3 : Form
    {
       
        string connectionString = "server=212.193.27.187;uid=gen_user;pwd=|}@UM#a&Qv&1ht;database=default_db";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            LoadDataFromDatabase();
            dataGridView1.ReadOnly = true;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Tour";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
