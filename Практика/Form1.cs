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
    public partial class Form1 : Form
    {
        public int index = 0;
        public Form1()
        {
            InitializeComponent();
            Column1.ReadOnly = true;
            Column2.ReadOnly = true;
            Column4.ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле с названием компании партнёра");
            }
            else
            {
                int rowId = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowId];
                row.Cells["Column2"].Value = Convert.ToString(textBox1.Text);
                row.Cells["Column4"].Value = Convert.ToString(dateTimePicker1.Text);
                int n = 1;
                n = dataGridView1.Rows.Count;
                row.Cells["Column1"].Value = Convert.ToString(n - 1);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int n;
            n = dataGridView1.Rows.Count;
            MessageBox.Show("Количество строк - " + Convert.ToString(n));
        }
        private void button3_Click(object sender, EventArgs e)
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
            MessageBox.Show("Порядковый номер: " + " " + n + "; " + "Название компании: " + " " + fam + "; " + "Дата начала партнёрства: " + " " + datar);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Filter = "*.* | *.jpg";
                string fileName = openFileDialog1.FileName;
            }
        }
        static public string fam22, datar22, foto22, kom;
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("Строка не выделена");
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
            dataGridView1.CurrentCell = dataGridView1[0,0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Главное_меню Вопрос1 = new Главное_меню();
            Вопрос1.ShowDialog();
            Close();
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Stream myStream;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        StreamWriter myWritet = new StreamWriter(myStream);
                        try
                        {
                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + '^');
                                }
                                myWritet.WriteLine();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            myWritet.Close();
                        }
                        myStream.Close();
                    }
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Stream mystr = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((mystr = openFileDialog1.OpenFile()) != null)
                    {
                        StreamReader myread = new StreamReader(mystr);
                        string[] str;
                        int num = 0;
                        try
                        {
                            string[] str1 = myread.ReadToEnd().Split('\n');
                            num = str1.Count();
                            dataGridView1.RowCount = num;
                            for (int i = 0; i < num; i++)
                            {
                                str = str1[i].Split('^');
                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    try
                                    {
                                        dataGridView1.Rows[i].Cells[j].Value = str[j];
                                    }
                                    catch { }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            myread.Close();
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
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
                kom = Convert.ToString(dataGridView1.Rows[index].Cells["Column2"].Value);
                Hide();
                Form3 Вопрос1 = new Form3();
                Вопрос1.ShowDialog();
                Close();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}