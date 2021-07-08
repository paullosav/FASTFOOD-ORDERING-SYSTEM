using System;
using System.Data;
using System.Windows.Forms;

namespace FASTFOOD_ORDERING_SYSTEM3
{

    public partial class Form1 : Form 
    {
        string[,] menuItems = new string[3, 2]{
                {"Menu 1", "10"},
                {"Menu 2", "20"},
                {"Menu 3", "30"}
            };
        double totalAmount = 0.0;
        int qty;
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
            int currentItemQty = Convert.ToInt32(numericUpDown1.Value);
            if (comboBox1.SelectedIndex > -1 )
            {
                if (currentItemQty > 0)
                {
                    qty = currentItemQty;

                    if (qty > 0)
                    {
                        String menuName = menuItems[comboBox1.SelectedIndex, 0];
                        String menuAmount = menuItems[comboBox1.SelectedIndex, 1];
                        totalAmount += Convert.ToInt32(menuAmount) * qty;
                        this.dataGridView1.Rows.Add(menuName, menuAmount, qty, Convert.ToInt32(menuAmount) * qty);

                    }
                }
                
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && qty > 0)
            {
                Form2 frm2 = new Form2(totalAmount, dataGridView1);
                frm2.ShowDialog();
            }

                
        }


        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

    }
}
