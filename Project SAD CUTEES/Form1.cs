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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Select();

            txt_email.Text = "Email";
            txt_password.Text = "Password";

            txt_password.ForeColor = txt_email.ForeColor = Color.DarkGray;

            txt_email.GotFocus += RemoveText;
            txt_password.GotFocus += RemoveText2;

            txt_email.LostFocus += AddText;
            txt_password.LostFocus += AddText2;
            
            panel_login.Location = new Point((this.Width - panel_login.Width) / 2, (this.Height - panel_login.Height) / 2);
            pict_userlogin.Location = new Point((panel_login.Width - pict_userlogin.Width) / 2, (panel_login.Height - 400));
            txt_email.Location = new Point((panel_login.Width - txt_email.Width) / 2, (panel_login.Height - 300));
            txt_password.Location = new Point((panel_login.Width - txt_password.Width) / 2, (panel_login.Height - 230));
            btn_login.Location = new Point((panel_login.Width - btn_login.Width) / 2, (panel_login.Height - 150));
            lbl_signup.Location = new Point((panel_login.Width - lbl_signup.Width) / 2, (panel_login.Height - 70));


        }

        //remove and add text
        #region
        public void RemoveText(object sender, EventArgs e)
        {
            if (txt_email.Text == "Email")
            {
                txt_email.Text = "";
                txt_email.ForeColor = Color.Black;
            }
        }

        public void RemoveText2(object sender, EventArgs e)
        {
            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";
                txt_password.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_email.Text))
            {
                txt_email.Text = "Email";
                txt_email.ForeColor = Color.DarkGray;
            }
        }

        public void AddText2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.DarkGray;
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //mouse hover and mouse leave
        #region
        private void lbl_signup_MouseHover(object sender, EventArgs e)
        {
            lbl_signup.ForeColor = Color.Blue;
        }

        private void lbl_signup_MouseLeave(object sender, EventArgs e)
        {
            lbl_signup.ForeColor = Color.Black;
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Sign_Up form_Sign_Up = new Form_Sign_Up();
            form_Sign_Up.ShowDialog();
            
        }
        #endregion

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Home form_Home = new Form_Home();
            form_Home.ShowDialog();
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
