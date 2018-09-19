namespace S2_KillerApp
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tLayout_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.tBox_Username = new System.Windows.Forms.TextBox();
            this.tBox_Password = new System.Windows.Forms.TextBox();
            this.btn_Register = new System.Windows.Forms.Button();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.tBox_Email = new System.Windows.Forms.TextBox();
            this.tLayout_Main.SuspendLayout();
            this.tPanel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tLayout_Main
            // 
            this.tLayout_Main.BackgroundImage = global::S2_KillerApp.Properties.Resources.HK_HD_Background;
            this.tLayout_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tLayout_Main.ColumnCount = 3;
            this.tLayout_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLayout_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tLayout_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLayout_Main.Controls.Add(this.tPanel_Main, 1, 1);
            this.tLayout_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLayout_Main.Location = new System.Drawing.Point(0, 0);
            this.tLayout_Main.Name = "tLayout_Main";
            this.tLayout_Main.RowCount = 3;
            this.tLayout_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tLayout_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLayout_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLayout_Main.Size = new System.Drawing.Size(978, 944);
            this.tLayout_Main.TabIndex = 1;
            // 
            // tPanel_Main
            // 
            this.tPanel_Main.ColumnCount = 3;
            this.tPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tPanel_Main.Controls.Add(this.lbl_Username, 0, 1);
            this.tPanel_Main.Controls.Add(this.lbl_Password, 0, 2);
            this.tPanel_Main.Controls.Add(this.tBox_Username, 1, 1);
            this.tPanel_Main.Controls.Add(this.tBox_Password, 1, 2);
            this.tPanel_Main.Controls.Add(this.btn_Register, 1, 4);
            this.tPanel_Main.Controls.Add(this.lbl_Email, 0, 3);
            this.tPanel_Main.Controls.Add(this.tBox_Email, 1, 3);
            this.tPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tPanel_Main.Location = new System.Drawing.Point(195, 283);
            this.tPanel_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tPanel_Main.Name = "tPanel_Main";
            this.tPanel_Main.RowCount = 5;
            this.tPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tPanel_Main.Size = new System.Drawing.Size(586, 472);
            this.tPanel_Main.TabIndex = 0;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Username.Font = new System.Drawing.Font("Helvetica", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.Location = new System.Drawing.Point(3, 168);
            this.lbl_Username.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(228, 64);
            this.lbl_Username.TabIndex = 0;
            this.lbl_Username.Text = "Username:";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Password.Font = new System.Drawing.Font("Helvetica", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(3, 238);
            this.lbl_Password.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(228, 64);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Password:";
            this.lbl_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_Username
            // 
            this.tBox_Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBox_Username.Font = new System.Drawing.Font("Helvetica", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_Username.Location = new System.Drawing.Point(237, 184);
            this.tBox_Username.Name = "tBox_Username";
            this.tBox_Username.Size = new System.Drawing.Size(287, 31);
            this.tBox_Username.TabIndex = 2;
            // 
            // tBox_Password
            // 
            this.tBox_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBox_Password.Font = new System.Drawing.Font("Helvetica", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_Password.Location = new System.Drawing.Point(237, 254);
            this.tBox_Password.Name = "tBox_Password";
            this.tBox_Password.PasswordChar = '*';
            this.tBox_Password.Size = new System.Drawing.Size(287, 31);
            this.tBox_Password.TabIndex = 3;
            // 
            // btn_Register
            // 
            this.btn_Register.Location = new System.Drawing.Point(234, 375);
            this.btn_Register.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(112, 44);
            this.btn_Register.TabIndex = 6;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = true;
            this.btn_Register.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Email.Font = new System.Drawing.Font("Helvetica", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(3, 308);
            this.lbl_Email.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(228, 64);
            this.lbl_Email.TabIndex = 7;
            this.lbl_Email.Text = "Email:";
            this.lbl_Email.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_Email
            // 
            this.tBox_Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tBox_Email.Font = new System.Drawing.Font("Helvetica", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_Email.Location = new System.Drawing.Point(237, 324);
            this.tBox_Email.Name = "tBox_Email";
            this.tBox_Email.Size = new System.Drawing.Size(287, 31);
            this.tBox_Email.TabIndex = 8;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 944);
            this.Controls.Add(this.tLayout_Main);
            this.Name = "Register";
            this.Text = "Register";
            this.tLayout_Main.ResumeLayout(false);
            this.tPanel_Main.ResumeLayout(false);
            this.tPanel_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLayout_Main;
        private System.Windows.Forms.TableLayoutPanel tPanel_Main;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tBox_Username;
        private System.Windows.Forms.TextBox tBox_Password;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox tBox_Email;
    }
}