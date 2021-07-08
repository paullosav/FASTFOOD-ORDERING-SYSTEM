using System;
using System.Windows.Forms;

namespace FASTFOOD_ORDERING_SYSTEM3
{
    public partial class Form2 : Form
    {
        double change;
        double cashTendered;
        double totalAmount;
        private DataGridView menuList;

        public Form2(double total, DataGridView finalOrders)
        {
            InitializeComponent();
            totalAmount = total;

            menuList = finalOrders;
            label1.Text = totalAmount.ToString();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cashTendered = Convert.ToDouble(maskedTextBox1.Text);
            change = cashTendered - totalAmount;
            label2.Text = change.ToString();

            //int i = menuList.RowCount;
            //Console.WriteLine(menuList.Rows[i].ToString());

            //for (int a = 1; a > i; a++)
            //{
            //    textBox1.AppendText(menuList.Rows[a].Cells[1].Value.ToString());
            //}

            foreach (DataGridViewRow row in menuList.Rows)
            {
                Console.WriteLine(row.DataBoundItem);
            }
        }

    }
}
