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

namespace TestSvel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        public void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var array1 = new AutoCompleteStringCollection();
            array1.AddRange(File.ReadAllLines("dictionary.txt", Encoding.UTF8));
            switch (toolStripComboBox1.Text)
            {

                case "Создание словаря":
                    textBox1.AutoCompleteCustomSource = array1;                   
                    break;
                case "Обновление словаря":
                    array1.Add(textBox1.Text);
                    textBox1.AutoCompleteCustomSource = array1;
                    File.AppendAllText("dictionary.txt", "\n" + textBox1.Text);
                    textBox1.Text = "";
                    break;
                case "Очистить словарь":
                    textBox1.AutoCompleteCustomSource.Clear();
                    break;
            }
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
