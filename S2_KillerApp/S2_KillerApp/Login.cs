using System;
using System.Drawing;
using System.Windows.Forms;
using KillerApp_Library.Controllers;
using KillerApp_Library.Domain_Classes;

namespace S2_KillerApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetColorPanels();
        }

        private void SetColorPanels()
        {
            tPanel_Main.BackColor = Color.FromArgb(90, tPanel_Main.BackColor.R, tPanel_Main.BackColor.G,
                tPanel_Main.BackColor.B);
            btn_Login.BackColor =
                Color.FromArgb(100, btn_Login.BackColor.R, btn_Login.BackColor.G, btn_Login.BackColor.B);
            lbl_Username.BackColor = Color.FromArgb(0, lbl_Username.BackColor.R, lbl_Username.BackColor.G,
                lbl_Username.BackColor.B);
            lbl_Password.BackColor = Color.FromArgb(0, lbl_Password.BackColor.R, lbl_Password.BackColor.G,
                lbl_Password.BackColor.B);
            lbl_NeedAccount.BackColor = Color.FromArgb(0, lbl_NeedAccount.BackColor.R, lbl_NeedAccount.BackColor.G,
                lbl_NeedAccount.BackColor.B);
            lbl_Register.BackColor = Color.FromArgb(0, lbl_Register.BackColor.R, lbl_Register.BackColor.G,
                lbl_Register.BackColor.B);
            fPanel_Register.BackColor = Color.FromArgb(0, fPanel_Register.BackColor.R, fPanel_Register.BackColor.G,
                fPanel_Register.BackColor.B);
        }

        private void btn_Login_Click(object sender, System.EventArgs e)
        {
            bool loginResult = UserController.GetInstance().Login(tBox_Username.Text, tBox_Password.Text);
            if (loginResult)
            {
                MessageBox.Show(UserController.GetInstance().User.GetUsername() + @" logged in !");
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += Form_Closed;
                mainForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show(@"Invalid user, please try again");
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            UserController.GetInstance()
                .Logout(UserController.GetInstance().User.GetUserId());
        }

        private void lbl_Register_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hide();
            Register registerForm = new Register(this);
            registerForm.FormClosed += Form_Closed;
            registerForm.Show();
        }
    }
}
