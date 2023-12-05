using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_SAD_CUTEES
{
    public partial class Product_Expense : Form
    {
        public static string idvalue;
        public static string produkname;
        public static string ukuran;
        public static string warna;
        public static int qty;
        public Product_Expense()
        {
            InitializeComponent();
            pict_logo.Location = new Point((panel1.Width - pict_logo.Width) / 2, (panel1.Height - pict_logo.Height) / 2);
            pict_logo.Location = new Point((panel1.Width - pict_logo.Width) / 2, (panel1.Height - pict_logo.Height) / 2);

            lbl_orders.Location = new Point(((panel1.Width - lbl_orders.Width) / 2) - 600, panel1.Top + 5);
            lbl_expense.Location = new Point(((panel1.Width - lbl_expense.Width) / 2) - 250, panel1.Top + 5);
            lbl_transaction.Location = new Point(((panel1.Width - lbl_transaction.Width) / 2) + 150, panel1.Top + 5);
            lbl_inventory.Location = new Point(((panel1.Width - lbl_inventory.Width) / 2) + 550, panel1.Top + 5);

            //btn_current.Location = new Point(((panel1.Width - btn_current.Width) / 2) - 597, panel1.Top + 43);
            panel2.BackColor = Color.Gold;

        }

        private void Product_Expense_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Form1.sqlquery = $"select o.order_id as \"Order ID\", p.nama_produk as \"Product Name\", p.ukuran as size, p.warna as color, if(p.issablon = 1, \"Sablon\" ,\"Polos\") as \"Type\", u.nama_sablon as \"Printing Size\", p.stock as Quantity, concat('Rp. ', ifnull(p.total_modal,0)) as \"Cost of Product\", a.first_name as 'Edited By'\r\nfrom `order` o, produk p, ukuran_sablon u, accounts a, detail_order d\r\nwhere o.ORDER_ID = d.order_id and p.PRODUK_ID = d.produk_id and u.sablon_id = p.sablon_id and a.account_id = p.ACCOUNT_ID;";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dt);
            dgv.DataSource = dt;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Edit";
            buttonColumn.Text = "Edit";
            buttonColumn.Name = "editButton";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgv.Columns.Add(buttonColumn);
            DataTable jum = new DataTable();
            Form1.sqlquery = "select count(*) from `order`;";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(jum);
            lbl_jumlahorder.Text = jum.Rows[0][0].ToString() + " Orders";
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["editButton"].Index)
            {
                int rowIndex = e.RowIndex;

                // Dapatkan nilai sel yang ingin diedit (misalnya, kolom ID)
                idvalue = dgv.Rows[rowIndex].Cells["Order ID"].Value.ToString();
                produkname = dgv.Rows[rowIndex].Cells["Product Name"].Value.ToString();
                qty = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Quantity"].Value.ToString());
                ukuran = dgv.Rows[rowIndex].Cells["size"].Value.ToString();
                warna = dgv.Rows[rowIndex].Cells["color"].Value.ToString();
                Edit_Product edit_Product = new Edit_Product();
                edit_Product.Show();
                this.Close();
            }
        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
