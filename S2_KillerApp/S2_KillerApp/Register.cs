using System;
using System.Drawing;
using System.Windows.Forms;
using KillerApp_Library.Controllers;

namespace S2_KillerApp
{
    public partial class Register : Form
    {
        private Login loginForm;
        public Register(Login login)
        {
            InitializeComponent();
            loginForm = login;
            SetColorPanels();
        }

        private void SetColorPanels()
        {
            tPanel_Main.BackColor = Color.FromArgb(90, tPanel_Main.BackColor.R, tPanel_Main.BackColor.G,
                tPanel_Main.BackColor.B);
            btn_Register.BackColor =
                Color.FromArgb(100, btn_Register.BackColor.R, btn_Register.BackColor.G, btn_Register.BackColor.B);
            lbl_Username.BackColor = Color.FromArgb(0, lbl_Username.BackColor.R, lbl_Username.BackColor.G,
                lbl_Username.BackColor.B);
            lbl_Password.BackColor = Color.FromArgb(0, lbl_Password.BackColor.R, lbl_Password.BackColor.G,
                lbl_Password.BackColor.B);
            lbl_Email.BackColor = Color.FromArgb(0, lbl_Email.BackColor.R, lbl_Email.BackColor.G,
                lbl_Email.BackColor.B);
        }

        private void RegisterUser()
        {
            bool register = UserController.GetInstance()
                .Register(tBox_Username.Text, tBox_Password.Text, tBox_Email.Text);
            if (!register)
                MessageBox.Show(@"Could not register, please try again !");
            else
            {
                UserController.GetInstance().Login(tBox_Username.Text, tBox_Password.Text);
                MessageBox.Show(@"Could not register, please try again !");
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += MainForm_Closed;
                this.Hide();
                mainForm.Show();
            }
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void btn_Register_Click(object sender, System.EventArgs e)
        {
            RegisterUser();
        }
    }
}
