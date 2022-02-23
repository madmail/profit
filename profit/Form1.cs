using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace profit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = ""; // очистить поле отображения результата расчета
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                // В поле редактирования нет данных.
                // Сделать кнопку Расчёт недоступной
                button1.Enabled = false;
            else
                // Сделать кнопку Расчёт доступной
                button1.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void butten1_Click(object sender, EventArgs e)
        {
            int period; // срок
            double sum, percent, profit; // сумма, процентная ставка, доход
            try
            {
                sum = System.Convert.ToDouble(textBox1.Text);
                period = System.Convert.ToInt32(textBox2.Text);
                if (sum < 10000)
                    percent = 8.5;
                else
                    percent = 12.0;
                profit = sum * (percent / 100.0 / 12.0) * period;
                label3.Text = "Процентная ставка: " + percent.ToString("n") + "%\n" +
                "Доход: " + profit.ToString("c");
            }
            catch (FormatException exc)
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                    MessageBox.Show("Оба поля должны быть заполнены",
                    "Доход", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Ошибка в исходных данных.\n" +
                    "В поле Сумма надо ввести целое или дробное число\n" +
                    "(в качестве десятичного разделителя используйте " +
                    "запятую),\nв поле Срок - целое.", "Доход",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') // цифра
                return;
            // "Правильный" десятичный разделитель — запятая.
            // Заменим точку запятой
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',')
            {
                // Нажата запятая. Проверим,
                // может, запятая уже есть в поле редактирования
                if (textBox1.Text.IndexOf(',') != -1 || textBox1.Text.Length == 0)
                    // Запятая уже есть.
                    // Запретить ввод еще одной
                    e.Handled = true;
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    // Нажата клавиша <Enter>.
                    // Переместить курсор в поле Срок
                    textBox2.Focus();
                return;
            }
            //Остальные символы запрещены
            e.Handled = true;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //в поле Срок можно ввести только целое число
            if (e.KeyChar >= '0' && e.KeyChar <= '9') // цифра
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    // Нажата клавиша <Enter>.
                    // Переместить курсор на кнопку Расчёт
                    button1.Focus();
                return;
            }
            //остальные символы запрещены
            e.Handled = true;
        }
        // Эта функция обрабатывает событие TextChanged (изменился текст в поле
        // редактирования) обоих компонентов TextBox.
        // Сначала надо обычным образом создать функцию обработки события
        // TextChanged для компонента textBox1, а затем указать ее в качестве
        // обработчика события TextChanged для компонента textBox2
    }
}
