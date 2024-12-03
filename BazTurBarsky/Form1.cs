using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace BazTurBarsky
{
    public partial class Form1 : Form
    {
        string connectionString = "server=212.193.27.187;uid=gen_user;pwd=|}@UM#a&Qv&1ht;database=default_db";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void buttonOpenInterface_Click(object sender, EventArgs e)
        {



        }

        private bool ValidateFields()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string priceStr = textBox3.Text.Trim();
            priceStr = priceStr.Replace(',', '.');

            if (!Regex.IsMatch(priceStr, @"^\d+(\.\d{1,2})?$"))
            {
                MessageBox.Show("Неверный формат цены. Допускаются только числа с не более чем двумя десятичными знаками.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            decimal price = decimal.Parse(priceStr);

            int durationDays;
            if (!int.TryParse(textBox4.Text.Trim(), out durationDays))
            {
                MessageBox.Show("Неверный формат продолжительности. Введите целое число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int rating;
            if (!int.TryParse(textBox8.Text.Trim(), out rating))
            {
                MessageBox.Show("Неверный формат рейтинга. Введите целое число.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = @"INSERT INTO Tour (name, description, price, durationdays, country, city, hotel_name, rating) 
                                 VALUES (@name, @description, @price, @durationdays, @country, @city, @hotel_name, @rating)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", textBox1.Text);
                            cmd.Parameters.AddWithValue("@description", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price", decimal.Parse(textBox3.Text.Replace(',', '.')));
                            cmd.Parameters.AddWithValue("@durationdays", int.Parse(textBox4.Text));
                            cmd.Parameters.AddWithValue("@country", textBox5.Text);
                            cmd.Parameters.AddWithValue("@city", textBox6.Text);
                            cmd.Parameters.AddWithValue("@hotel_name", textBox7.Text);
                            cmd.Parameters.AddWithValue("@rating", int.Parse(textBox8.Text));

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Тур успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextBoxes();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }


    }
}

