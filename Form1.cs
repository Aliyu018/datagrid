using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_DataGrid
{
    public partial class Form1 : Form
    {
        private int AutoID;
        BindingList<Items> Dictionary = new BindingList<Items>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoID = 1;
            dataGridView1.DataSource = Dictionary;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
                {
                   for (int i = 0; i < Dictionary.Count; i++)
                        if (textBox1.Text == Dictionary[i].word && textBox2.Text == Dictionary[i].mean)
                        {
                            MessageBox.Show("The Item already exists!");
                            return;
                        }
                    Dictionary.Add(new Items { id = AutoID, word = textBox1.Text, mean = textBox2.Text });
                    textBox1.Text = "";
                    textBox2.Text = "";
                    AutoID++;
                }
                else
                    MessageBox.Show("PLease fill the boxes");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString()) - 1;
            Dictionary[index].word = textBox1.Text;
            Dictionary[index].mean = textBox2.Text;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = int.Parse(dataGridView1.SelectedCells[0].Value.ToString()) - 1;
            Dictionary.RemoveAt(index);
            for (int i = index; i < Dictionary.Count; i++)
                Dictionary[i].id--;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "Meaning: ";
            for (int i = 0; i < Dictionary.Count; i++)
                if (textBox3.Text == Dictionary[i].word)
                {
                    label4.Text += Dictionary[i].mean;
                    return;
                }
            MessageBox.Show("Not Found!");

        }
    }
}
