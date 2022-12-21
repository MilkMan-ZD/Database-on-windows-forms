using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Практика
{
    public partial class Form3 : Form
    {
        public int index = 0;
        public Form3()
        {
            InitializeComponent();
            Column1.ReadOnly = true;
            Column2.ReadOnly = true;
            Column4.ReadOnly = true;
        }
        static public string fam2, datar2, foto2, kom;
        private void button2_Click_1(object sender, EventArgs e)
        {
            int n=1;
            n = dataGridView1.Rows.Count;
            MessageBox.Show("Количество строк - "+Convert.ToString(n));
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 1)
            {
                return;
            }
            int index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount - 1)
            {
                return;
            }
            if (index == dataGridView1.RowCount)
            {
                MessageBox.Show("Строка не выделена");
                return;
            }
            string fam = Convert.ToString(dataGridView1.Rows[index].Cells["Column2"].Value);
            string datar = Convert.ToString(dataGridView1.Rows[index].Cells["Column4"].Value);
            string n = Convert.ToString(dataGridView1.Rows[index].Cells["Column1"].Value);
            MessageBox.Show("Порядковый номер: " + " "+ n +"; "+ "ФИО: " +" "+ fam +"; "+ "Дата рождения: " +" "+ datar);
        }
        public int p = 0;
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Filter = "*.* | *.jpg";
                string fileName = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(fileName);
                p = p + 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <=0)
            {
                return;
            }
            int index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount)
            {
                MessageBox.Show("Строка не выделена");
                return;
            }
            if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1)
            {
                MessageBox.Show("Строка не выделена");
                return;
            }
            else
            {
                dataGridView1.Rows.RemoveAt(index);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите удалить все данные из таблицы?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
            if (result == DialogResult.No)
            {
            }
            dataGridView1.CurrentCell = dataGridView1[0, 0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 Вопрос1 = new Form1();
            Вопрос1.ShowDialog();
            Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(Form1.kom);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (p == 0 || textBox1.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox1.Text == "" && textBox2.Text == "" && p == 0 && textBox3.Text == "" || textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Вы не выбрали фотографию или не заполнили ФИО");
                return;
            }
            int rowId = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowId];
            row.Cells["Column2"].Value = Convert.ToString(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
            row.Cells["Column4"].Value = Convert.ToString(dateTimePicker1.Text);
            row.Cells["Column3"].Value = pictureBox1.Image;
            int n = 1;
            n = dataGridView1.Rows.Count;
            row.Cells["Column1"].Value = Convert.ToString(n - 1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount)
            {
                MessageBox.Show("Строка не выделена");
                return;
            }
            if (p == 0 || textBox1.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox1.Text == "" && textBox2.Text == "" && p == 0 && textBox3.Text == "" || textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Вы не выбрали фотографию или не заполнили ФИО");
                return;
            }
            if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1)
            {
                MessageBox.Show("Строка не выделена");
                return;
            }
            else
            {
                fam2 = Convert.ToString(dataGridView1.Rows[index].Cells["Column2"].Value);
                datar2 = Convert.ToString(dataGridView1.Rows[index].Cells["Column4"].Value);
                string fileName = openFileDialog1.FileName;
                foto2 = Convert.ToString(fileName);
                Hide();
                Form2 Вопрос1 = new Form2();
                Вопрос1.ShowDialog();
                Close();
            }
        }
    }
}
