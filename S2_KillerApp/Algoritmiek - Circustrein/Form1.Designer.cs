namespace Algoritmiek___Circustrein
{
    partial class Form1
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lBox_Animals = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tBox_AnimalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBox_AnimalWeight = new System.Windows.Forms.ComboBox();
            this.cBox_Vegetarian = new System.Windows.Forms.ComboBox();
            this.btn_AddAnimal = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(888, 762);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lBox_Animals, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 759);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lBox_Animals
            // 
            this.lBox_Animals.FormattingEnabled = true;
            this.lBox_Animals.ItemHeight = 19;
            this.lBox_Animals.Location = new System.Drawing.Point(3, 306);
            this.lBox_Animals.Name = "lBox_Animals";
            this.lBox_Animals.Size = new System.Drawing.Size(436, 365);
            this.lBox_Animals.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.tBox_AnimalName);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.cBox_AnimalWeight);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.cBox_Vegetarian);
            this.flowLayoutPanel2.Controls.Add(this.btn_AddAnimal);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(436, 297);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Helvetica", 12F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Animal Name:";
            // 
            // tBox_AnimalName
            // 
            this.tBox_AnimalName.Font = new System.Drawing.Font("Helvetica", 14F);
            this.tBox_AnimalName.Location = new System.Drawing.Point(170, 3);
            this.tBox_AnimalName.Name = "tBox_AnimalName";
            this.tBox_AnimalName.Size = new System.Drawing.Size(255, 40);
            this.tBox_AnimalName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Helvetica", 12F);
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Animal Weight:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Helvetica", 12F);
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vegetarian";
            // 
            // cBox_AnimalWeight
            // 
            this.cBox_AnimalWeight.Font = new System.Drawing.Font("Helvetica", 12F);
            this.cBox_AnimalWeight.FormattingEnabled = true;
            this.cBox_AnimalWeight.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Heavy"});
            this.cBox_AnimalWeight.Location = new System.Drawing.Point(181, 49);
            this.cBox_AnimalWeight.Name = "cBox_AnimalWeight";
            this.cBox_AnimalWeight.Size = new System.Drawing.Size(244, 35);
            this.cBox_AnimalWeight.TabIndex = 5;
            // 
            // cBox_Vegetarian
            // 
            this.cBox_Vegetarian.Font = new System.Drawing.Font("Helvetica", 12F);
            this.cBox_Vegetarian.FormattingEnabled = true;
            this.cBox_Vegetarian.Items.AddRange(new object[] {
            "Meat Eater",
            "Vegetarian"});
            this.cBox_Vegetarian.Location = new System.Drawing.Point(135, 90);
            this.cBox_Vegetarian.Name = "cBox_Vegetarian";
            this.cBox_Vegetarian.Size = new System.Drawing.Size(244, 35);
            this.cBox_Vegetarian.TabIndex = 6;
            // 
            // btn_AddAnimal
            // 
            this.btn_AddAnimal.Font = new System.Drawing.Font("Helvetica", 12F);
            this.btn_AddAnimal.Location = new System.Drawing.Point(3, 131);
            this.btn_AddAnimal.Name = "btn_AddAnimal";
            this.btn_AddAnimal.Size = new System.Drawing.Size(107, 41);
            this.btn_AddAnimal.TabIndex = 7;
            this.btn_AddAnimal.Text = "Add";
            this.btn_AddAnimal.UseVisualStyleBackColor = true;
            this.btn_AddAnimal.Click += new System.EventHandler(this.btn_AddAnimal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 785);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Helvetica", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lBox_Animals;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBox_AnimalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBox_AnimalWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBox_Vegetarian;
        private System.Windows.Forms.Button btn_AddAnimal;
    }
}

