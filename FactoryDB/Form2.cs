using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryDB
{
    public partial class Form2 : Form
    {
        Швейная_фабрикаEntities2 db = new Швейная_фабрикаEntities2();
        public Form2()
        {
            InitializeComponent();
            label7.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != textBox2.Text)
            {
                label7.Show();
            }
            else
            {
                label7.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
            {
                if (textBox3.Text != textBox2.Text)
                {
                    label7.Show();
                    return;
                }
                else
                {
                    label7.Hide();
                    Пользователь user = db.Пользователь.Find(textBox1.Text);
                    if (user != null)
                    {
                        MessageBox.Show("Пользователль с таким логином уже есть!");
                        return;
                    }
                    user = new Пользователь();
                    user.Логин = textBox1.Text;
                    user.Пароль = textBox2.Text;
                    user.Почта = textBox3.Text;
                    user.Роль = "Заказчик";
                    if (textBox5.Text != "")
                    {
                        user.Наименование = textBox5.Text;
                    }
                    else
                    {
                        user.Наименование = textBox1.Text;
                    }
                    db.Пользователь.Add(user);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    MessageBox.Show($"Пользователь {user.Логин} зарегистрирован!");
                }
            }
        }
    }
}
