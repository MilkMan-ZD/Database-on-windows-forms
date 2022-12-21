using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(Form3.fam2);
            label3.Text = Convert.ToString(Form3.datar2);
            pictureBox1.Image = Image.FromFile(Form3.foto2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 Вопрос1 = new Form3();
            Вопрос1.ShowDialog();
            Close();
        }
    }
}
