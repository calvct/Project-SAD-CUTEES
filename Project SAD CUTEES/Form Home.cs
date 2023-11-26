using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_SAD_CUTEES
{
    public partial class Form_Home : Form
    {
        private Form1 form1;
        public Form_Home()
        {
            InitializeComponent();

            form1 = new Form1(); 
            pict_logo.Location = new Point((panel1.Width - pict_logo.Width)/2, (panel1.Height - pict_logo.Height)/2);

            lbl_orders.Location = new Point(((panel1.Width - lbl_orders.Width)/ 2) - 600, panel1.Top + 5);
            lbl_expense.Location = new Point(((panel1.Width - lbl_expense.Width) / 2) - 250, panel1.Top + 5);
            lbl_transaction.Location = new Point(((panel1.Width - lbl_transaction.Width) / 2) + 150, panel1.Top + 5);
            lbl_inventory.Location = new Point(((panel1.Width - lbl_inventory.Width) / 2) + 550, panel1.Top + 5);

            btn_current.Location = new Point(((panel1.Width - btn_current.Width) / 2) - 597, panel1.Top + 43);

        }

        private void Form_Home_Load(object sender, EventArgs e)
        {

        }

        private void pict_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pict_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void btn_current_Click(object sender, EventArgs e)
        {

        }

        private void pict_accounticon_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Profile form_Profile = new Form_Profile();
            form_Profile.ShowDialog();
        }
    }
}
