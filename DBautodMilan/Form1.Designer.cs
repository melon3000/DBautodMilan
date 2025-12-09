namespace DBautodMilan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Avaleht = new TabControl();
            tabPage5 = new TabPage();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            tabPage1 = new TabPage();
            dgvOwners = new DataGridView();
            panel1 = new Panel();
            btnAddOwner = new Button();
            LabelNumber = new Label();
            txtOwnerPhone = new TextBox();
            labelOwner = new Label();
            btnDeleteOwner = new Button();
            txtOwnerName = new TextBox();
            tabPage2 = new TabPage();
            dgvCars = new DataGridView();
            panel2 = new Panel();
            btnAddCar = new Button();
            btnDeleteCar = new Button();
            LabelOwner2 = new Label();
            cbOwners = new ComboBox();
            LabelRegNumber = new Label();
            txtRegNumber = new TextBox();
            LabelModel = new Label();
            txtModel = new TextBox();
            LabelBrand = new Label();
            txtBrand = new TextBox();
            tabPage4 = new TabPage();
            panel4 = new Panel();
            btnAddCarService = new Button();
            btnDeleteCarService = new Button();
            label2 = new Label();
            txtMileage = new TextBox();
            label1 = new Label();
            dtServiceDate = new DateTimePicker();
            cbServiceList = new Label();
            comboBox1 = new ComboBox();
            LabelCar = new Label();
            cbCars = new ComboBox();
            dataGridView1 = new DataGridView();
            tabPage3 = new TabPage();
            dgvServices = new DataGridView();
            panel3 = new Panel();
            btnAddService = new Button();
            txtServicePrice = new TextBox();
            LabelServicePrice = new Label();
            txtServiceName = new TextBox();
            LabelServiceName = new Label();
            Avaleht.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOwners).BeginInit();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            panel2.SuspendLayout();
            tabPage4.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // Avaleht
            // 
            Avaleht.Controls.Add(tabPage5);
            Avaleht.Controls.Add(tabPage1);
            Avaleht.Controls.Add(tabPage2);
            Avaleht.Controls.Add(tabPage4);
            Avaleht.Controls.Add(tabPage3);
            Avaleht.Location = new Point(1, 0);
            Avaleht.Name = "Avaleht";
            Avaleht.SelectedIndex = 0;
            Avaleht.Size = new Size(800, 449);
            Avaleht.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.BackgroundImage = Properties.Resources.avaleht;
            tabPage5.Controls.Add(label5);
            tabPage5.Controls.Add(label4);
            tabPage5.Controls.Add(label3);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(792, 421);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Avaleht";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(642, 402);
            label5.Name = "label5";
            label5.Size = new Size(147, 15);
            label5.TabIndex = 2;
            label5.Text = "© Milan Petrovski TarPV24";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(41, 204);
            label4.Name = "label4";
            label4.Size = new Size(218, 20);
            label4.TabIndex = 1;
            label4.Text = "Vali midagi navigeermise menüüs";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Vivaldi", 72F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(18, 110);
            label3.Name = "label3";
            label3.Size = new Size(473, 114);
            label3.TabIndex = 0;
            label3.Text = "Autoteenindus";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvOwners);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Omanikud";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvOwners
            // 
            dgvOwners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOwners.Location = new Point(0, 0);
            dgvOwners.Name = "dgvOwners";
            dgvOwners.Size = new Size(604, 421);
            dgvOwners.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnAddOwner);
            panel1.Controls.Add(LabelNumber);
            panel1.Controls.Add(txtOwnerPhone);
            panel1.Controls.Add(labelOwner);
            panel1.Controls.Add(btnDeleteOwner);
            panel1.Controls.Add(txtOwnerName);
            panel1.Location = new Point(610, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(185, 420);
            panel1.TabIndex = 2;
            // 
            // btnAddOwner
            // 
            btnAddOwner.AccessibleName = "";
            btnAddOwner.Location = new Point(6, 357);
            btnAddOwner.Name = "btnAddOwner";
            btnAddOwner.Size = new Size(80, 56);
            btnAddOwner.TabIndex = 11;
            btnAddOwner.Text = "Lisa";
            btnAddOwner.UseVisualStyleBackColor = true;
            btnAddOwner.Click += btnAddOwner_Click;
            // 
            // LabelNumber
            // 
            LabelNumber.AutoSize = true;
            LabelNumber.Location = new Point(3, 46);
            LabelNumber.Name = "LabelNumber";
            LabelNumber.Size = new Size(94, 15);
            LabelNumber.TabIndex = 10;
            LabelNumber.Text = "Telefoni number";
            // 
            // txtOwnerPhone
            // 
            txtOwnerPhone.BorderStyle = BorderStyle.FixedSingle;
            txtOwnerPhone.Location = new Point(3, 63);
            txtOwnerPhone.Name = "txtOwnerPhone";
            txtOwnerPhone.Size = new Size(169, 23);
            txtOwnerPhone.TabIndex = 9;
            // 
            // labelOwner
            // 
            labelOwner.AutoSize = true;
            labelOwner.Location = new Point(3, 2);
            labelOwner.Name = "labelOwner";
            labelOwner.Size = new Size(51, 15);
            labelOwner.TabIndex = 8;
            labelOwner.Text = "Täisnimi";
            // 
            // btnDeleteOwner
            // 
            btnDeleteOwner.Location = new Point(94, 357);
            btnDeleteOwner.Name = "btnDeleteOwner";
            btnDeleteOwner.Size = new Size(80, 56);
            btnDeleteOwner.TabIndex = 7;
            btnDeleteOwner.Text = "Kustuta";
            btnDeleteOwner.UseVisualStyleBackColor = true;
            btnDeleteOwner.Click += btnDeleteOwner_Click;
            // 
            // txtOwnerName
            // 
            txtOwnerName.BorderStyle = BorderStyle.FixedSingle;
            txtOwnerName.Location = new Point(3, 20);
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.Size = new Size(169, 23);
            txtOwnerName.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvCars);
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Autod";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCars
            // 
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(0, 0);
            dgvCars.Name = "dgvCars";
            dgvCars.Size = new Size(604, 421);
            dgvCars.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSteelBlue;
            panel2.Controls.Add(btnAddCar);
            panel2.Controls.Add(btnDeleteCar);
            panel2.Controls.Add(LabelOwner2);
            panel2.Controls.Add(cbOwners);
            panel2.Controls.Add(LabelRegNumber);
            panel2.Controls.Add(txtRegNumber);
            panel2.Controls.Add(LabelModel);
            panel2.Controls.Add(txtModel);
            panel2.Controls.Add(LabelBrand);
            panel2.Controls.Add(txtBrand);
            panel2.Location = new Point(610, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(185, 420);
            panel2.TabIndex = 0;
            // 
            // btnAddCar
            // 
            btnAddCar.Location = new Point(7, 358);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(80, 56);
            btnAddCar.TabIndex = 8;
            btnAddCar.Text = "Lisa auto";
            btnAddCar.UseVisualStyleBackColor = true;
            btnAddCar.Click += btnAddCar_Click;
            // 
            // btnDeleteCar
            // 
            btnDeleteCar.Location = new Point(93, 358);
            btnDeleteCar.Name = "btnDeleteCar";
            btnDeleteCar.Size = new Size(80, 56);
            btnDeleteCar.TabIndex = 2;
            btnDeleteCar.Text = "Kustuta auto";
            btnDeleteCar.UseVisualStyleBackColor = true;
            btnDeleteCar.Click += btnDeleteCar_Click;
            // 
            // LabelOwner2
            // 
            LabelOwner2.AutoSize = true;
            LabelOwner2.Location = new Point(3, 141);
            LabelOwner2.Name = "LabelOwner2";
            LabelOwner2.Size = new Size(49, 15);
            LabelOwner2.TabIndex = 7;
            LabelOwner2.Text = "Omanik";
            // 
            // cbOwners
            // 
            cbOwners.FormattingEnabled = true;
            cbOwners.Location = new Point(3, 160);
            cbOwners.Name = "cbOwners";
            cbOwners.Size = new Size(173, 23);
            cbOwners.TabIndex = 6;
            // 
            // LabelRegNumber
            // 
            LabelRegNumber.AutoSize = true;
            LabelRegNumber.Location = new Point(3, 95);
            LabelRegNumber.Name = "LabelRegNumber";
            LabelRegNumber.Size = new Size(72, 15);
            LabelRegNumber.TabIndex = 5;
            LabelRegNumber.Text = "Reg number";
            // 
            // txtRegNumber
            // 
            txtRegNumber.BorderStyle = BorderStyle.FixedSingle;
            txtRegNumber.Location = new Point(3, 113);
            txtRegNumber.Name = "txtRegNumber";
            txtRegNumber.Size = new Size(173, 23);
            txtRegNumber.TabIndex = 4;
            // 
            // LabelModel
            // 
            LabelModel.AutoSize = true;
            LabelModel.Location = new Point(3, 48);
            LabelModel.Name = "LabelModel";
            LabelModel.Size = new Size(41, 15);
            LabelModel.TabIndex = 3;
            LabelModel.Text = "Model";
            // 
            // txtModel
            // 
            txtModel.BorderStyle = BorderStyle.FixedSingle;
            txtModel.Location = new Point(3, 66);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(173, 23);
            txtModel.TabIndex = 2;
            // 
            // LabelBrand
            // 
            LabelBrand.AutoSize = true;
            LabelBrand.Location = new Point(3, 3);
            LabelBrand.Name = "LabelBrand";
            LabelBrand.Size = new Size(38, 15);
            LabelBrand.TabIndex = 1;
            LabelBrand.Text = "Brand";
            // 
            // txtBrand
            // 
            txtBrand.BorderStyle = BorderStyle.FixedSingle;
            txtBrand.Location = new Point(3, 21);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(173, 23);
            txtBrand.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(panel4);
            tabPage4.Controls.Add(dataGridView1);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(792, 421);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Hooldus";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightSteelBlue;
            panel4.Controls.Add(btnAddCarService);
            panel4.Controls.Add(btnDeleteCarService);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtMileage);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(dtServiceDate);
            panel4.Controls.Add(cbServiceList);
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(LabelCar);
            panel4.Controls.Add(cbCars);
            panel4.Location = new Point(610, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(185, 420);
            panel4.TabIndex = 1;
            // 
            // btnAddCarService
            // 
            btnAddCarService.Location = new Point(7, 359);
            btnAddCarService.Name = "btnAddCarService";
            btnAddCarService.Size = new Size(80, 56);
            btnAddCarService.TabIndex = 9;
            btnAddCarService.Text = "Lisa hooldus";
            btnAddCarService.UseVisualStyleBackColor = true;
            btnAddCarService.Click += btnAddCarService_Click;
            // 
            // btnDeleteCarService
            // 
            btnDeleteCarService.Location = new Point(93, 359);
            btnDeleteCarService.Name = "btnDeleteCarService";
            btnDeleteCarService.Size = new Size(80, 56);
            btnDeleteCarService.TabIndex = 8;
            btnDeleteCarService.Text = "Kustuta hooldus";
            btnDeleteCarService.UseVisualStyleBackColor = true;
            btnDeleteCarService.Click += btnDeleteCarService_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 161);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 7;
            label2.Text = "Läbisõit";
            // 
            // txtMileage
            // 
            txtMileage.BorderStyle = BorderStyle.FixedSingle;
            txtMileage.Location = new Point(3, 179);
            txtMileage.Name = "txtMileage";
            txtMileage.Size = new Size(170, 23);
            txtMileage.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 108);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 5;
            label1.Text = "Kuupaev";
            // 
            // dtServiceDate
            // 
            dtServiceDate.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 186);
            dtServiceDate.Format = DateTimePickerFormat.Short;
            dtServiceDate.Location = new Point(3, 126);
            dtServiceDate.MaxDate = new DateTime(2028, 12, 31, 0, 0, 0, 0);
            dtServiceDate.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtServiceDate.Name = "dtServiceDate";
            dtServiceDate.Size = new Size(170, 22);
            dtServiceDate.TabIndex = 4;
            // 
            // cbServiceList
            // 
            cbServiceList.AutoSize = true;
            cbServiceList.Location = new Point(3, 54);
            cbServiceList.Name = "cbServiceList";
            cbServiceList.Size = new Size(44, 15);
            cbServiceList.TabIndex = 3;
            cbServiceList.Text = "Teenus";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 72);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(170, 23);
            comboBox1.TabIndex = 2;
            // 
            // LabelCar
            // 
            LabelCar.AutoSize = true;
            LabelCar.Location = new Point(3, 3);
            LabelCar.Name = "LabelCar";
            LabelCar.Size = new Size(33, 15);
            LabelCar.TabIndex = 1;
            LabelCar.Text = "Auto";
            // 
            // cbCars
            // 
            cbCars.FormattingEnabled = true;
            cbCars.Location = new Point(3, 21);
            cbCars.Name = "cbCars";
            cbCars.Size = new Size(170, 23);
            cbCars.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(604, 421);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvServices);
            tabPage3.Controls.Add(panel3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 421);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Teenus";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvServices
            // 
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Location = new Point(0, 0);
            dgvServices.Name = "dgvServices";
            dgvServices.Size = new Size(604, 421);
            dgvServices.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSteelBlue;
            panel3.Controls.Add(btnAddService);
            panel3.Controls.Add(txtServicePrice);
            panel3.Controls.Add(LabelServicePrice);
            panel3.Controls.Add(txtServiceName);
            panel3.Controls.Add(LabelServiceName);
            panel3.Location = new Point(610, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(185, 421);
            panel3.TabIndex = 0;
            // 
            // btnAddService
            // 
            btnAddService.Location = new Point(5, 370);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(173, 47);
            btnAddService.TabIndex = 4;
            btnAddService.Text = "Lisa teenus";
            btnAddService.UseVisualStyleBackColor = true;
            btnAddService.Click += btnAddService_Click;
            // 
            // txtServicePrice
            // 
            txtServicePrice.BorderStyle = BorderStyle.FixedSingle;
            txtServicePrice.Location = new Point(3, 72);
            txtServicePrice.Name = "txtServicePrice";
            txtServicePrice.Size = new Size(173, 23);
            txtServicePrice.TabIndex = 3;
            // 
            // LabelServicePrice
            // 
            LabelServicePrice.AutoSize = true;
            LabelServicePrice.Location = new Point(3, 54);
            LabelServicePrice.Name = "LabelServicePrice";
            LabelServicePrice.Size = new Size(77, 15);
            LabelServicePrice.TabIndex = 2;
            LabelServicePrice.Text = "Teenuse hind";
            // 
            // txtServiceName
            // 
            txtServiceName.BorderStyle = BorderStyle.FixedSingle;
            txtServiceName.Location = new Point(3, 21);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(173, 23);
            txtServiceName.TabIndex = 1;
            // 
            // LabelServiceName
            // 
            LabelServiceName.AutoSize = true;
            LabelServiceName.Location = new Point(3, 3);
            LabelServiceName.Name = "LabelServiceName";
            LabelServiceName.Size = new Size(77, 15);
            LabelServiceName.TabIndex = 0;
            LabelServiceName.Text = "Teenuse nimi";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Avaleht);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Avaleht.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOwners).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabPage4.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl Avaleht;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvOwners;
        private TextBox txtOwnerPhone;
        private Label labelOwner;
        private Button btnDeleteOwner;
        private TextBox txtOwnerName;
        private Label LabelNumber;
        private Button btnAddOwner;
        private DataGridView dgvCars;
        private Label LabelBrand;
        private TextBox txtBrand;
        private Label LabelModel;
        private TextBox txtModel;
        private Label LabelOwner2;
        private ComboBox cbOwners;
        private Label LabelRegNumber;
        private TextBox txtRegNumber;
        private Button btnAddCar;
        private Button btnDeleteCar;
        private DataGridView dgvServices;
        private TextBox txtServicePrice;
        private Label LabelServicePrice;
        private TextBox txtServiceName;
        private Label LabelServiceName;
        private Button btnAddService;
        private TabPage tabPage4;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Button btnDeleteCarService;
        private Label label2;
        private TextBox txtMileage;
        private Label label1;
        private DateTimePicker dtServiceDate;
        private Label cbServiceList;
        private ComboBox comboBox1;
        private Label LabelCar;
        private ComboBox cbCars;
        private Button btnAddCarService;
        private TabPage tabPage5;
        private Label label4;
        private Label label3;
        private Label label5;
    }
}
