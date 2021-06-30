using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FASTFOOD_ORDERING_SYSTEM3
{
    public partial class Form1 : Form
    {
        string[,] menuItems = new string[3, 2]{
                {"Menu 1", "10"},
                {"Menu 2", "4"},
                {"Menu 3", "5"}
            };
        
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < menuItems.GetLength(0); i++)
            {
                comboBox1.Items.Add(new { Text = menuItems[i, 0], Key = Convert.ToInt16(menuItems[i, 1]) });
            }

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String menuName = menuItems[comboBox1.SelectedIndex, 0];
            String menuAmount = menuItems[comboBox1.SelectedIndex, 1];
            int qty = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            int total = Convert.ToInt32(menuAmount) * qty;
            this.dataGridView1.Rows.Add(menuName, menuAmount, qty, total);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
