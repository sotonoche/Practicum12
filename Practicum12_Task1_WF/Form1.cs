using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicum12_Task1_WF
{
    public partial class Form1 : Form
    {
        Money money;
        int nomination, value, sum, price;

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = money.isEnoughMoney(sum);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = money.quantityOfGoods(price, sum);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                money.First = (int)numericUpDown5.Value;
                money.Second = (int)numericUpDown6.Value;
                if (money.First <= 0 || money.Second <= 0) throw new Exception("Значение не может быть меньше или равно нулю!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show($"Значение номинала равно {money.First}\nЗначение кол-ва купюр равно {money.Second}\n" +
                $"Сумма денег равна {money.Sum}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int indx = 0;
            try
            {
                indx = (int)numericUpDown7.Value;
                money[indx] = (int)numericUpDown8.Value;
                if (money[indx] < 0) throw new Exception("Значение не может быть меньше нуля!");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Индекс должен быть равен 0 или 1", "Ошибка!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
                return;
            }
            MessageBox.Show($"Значение изменено!\nТеперь оно равно {money[indx]}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            money++;
            MessageBox.Show(money.outInfo());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            money--;
            MessageBox.Show(money.outInfo());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!money) MessageBox.Show($"Поле second({money.Second}) не нулевое");
            else MessageBox.Show($"Значение поля second({money.Second}) равно нулю");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int scal = 0;
            try
            {
                scal = (int)numericUpDown9.Value;
                if (scal < 0) throw new Exception("Скаляр не может иметь отрицательное значение!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            money += scal;
            MessageBox.Show($"Значение успешно изменено!\nЗначенение поля second равно {money.Second}", "Успех");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string mny = (string)money;
            MessageBox.Show(mny);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            try
            {
                Money mny1 = (Money)str;
                if (mny1 is Money) 
                {
                    MessageBox.Show($"Преобразование в класс Money успешно\n{mny1.outInfo()}", "Успех!");
                } 
                else MessageBox.Show("Преобразование неудачно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = money.outInfo();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                nomination = (int)numericUpDown1.Value;
                value = (int)numericUpDown2.Value;
                sum = (int)numericUpDown3.Value;
                price = (int)numericUpDown4.Value;
                if (nomination <= 0 || value <= 0 || sum <= 0 || price <= 0) throw new Exception("Значение не может быть меньше или равно нулю!");
                money = new Money(nomination, value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
