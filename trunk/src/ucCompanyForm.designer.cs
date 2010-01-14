namespace FaceIDpp
{
    partial class ucCompanyForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvCompany = new System.Windows.Forms.DataGridView();
            this.tbCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gBoxCompanyACtion = new System.Windows.Forms.GroupBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSubmit = new System.Windows.Forms.Button();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
<<<<<<< .mine
            this.label1 = new System.Windows.Forms.Label();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).BeginInit();
            this.gBoxCompanyACtion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
=======
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CompName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ActionDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
>>>>>>> .r40
            this.SuspendLayout();
            // 
            // dgvCompany
            // 
<<<<<<< .mine
            this.dgvCompany.AllowUserToAddRows = false;
            this.dgvCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbCompany,
            this.btEdit,
            this.btDelete});
            this.dgvCompany.Location = new System.Drawing.Point(14, 13);
            this.dgvCompany.Name = "dgvCompany";
            this.dgvCompany.ReadOnly = true;
            this.dgvCompany.Size = new System.Drawing.Size(485, 150);
            this.dgvCompany.TabIndex = 0;
            this.dgvCompany.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompany_CellClick);
=======
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompName,
            this.ActionEdit,
            this.ActionDelete});
            this.dataGridView1.Location = new System.Drawing.Point(14, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 150);
            this.dataGridView1.TabIndex = 0;
>>>>>>> .r40
            // 
            // tbCompany
            // 
            this.tbCompany.DataPropertyName = "Name";
            this.tbCompany.HeaderText = "Company Name";
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.ReadOnly = true;
            this.tbCompany.Width = 147;
            // 
<<<<<<< .mine
            // btEdit
=======
            // button3
>>>>>>> .r40
            // 
<<<<<<< .mine
            this.btEdit.DataPropertyName = "CompanyID";
            this.btEdit.HeaderText = "Edit";
            this.btEdit.Name = "btEdit";
            this.btEdit.ReadOnly = true;
            this.btEdit.Text = "Edit";
            this.btEdit.UseColumnTextForButtonValue = true;
            this.btEdit.Width = 148;
=======
            this.button3.Location = new System.Drawing.Point(298, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
>>>>>>> .r40
            // 
<<<<<<< .mine
            // btDelete
=======
            // button2
>>>>>>> .r40
            // 
<<<<<<< .mine
            this.btDelete.DataPropertyName = "CompanyID";
            this.btDelete.HeaderText = "Delete";
            this.btDelete.Name = "btDelete";
            this.btDelete.ReadOnly = true;
            this.btDelete.Text = "Delete";
            this.btDelete.UseColumnTextForButtonValue = true;
            this.btDelete.Width = 147;
=======
            this.button2.Location = new System.Drawing.Point(221, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
>>>>>>> .r40
            // 
            // gBoxCompanyACtion
            // 
<<<<<<< .mine
            this.gBoxCompanyACtion.Controls.Add(this.btCancel);
            this.gBoxCompanyACtion.Controls.Add(this.btSubmit);
            this.gBoxCompanyACtion.Controls.Add(this.tbCompanyName);
            this.gBoxCompanyACtion.Controls.Add(this.label1);
            this.gBoxCompanyACtion.Location = new System.Drawing.Point(14, 198);
            this.gBoxCompanyACtion.Name = "gBoxCompanyACtion";
            this.gBoxCompanyACtion.Size = new System.Drawing.Size(485, 104);
            this.gBoxCompanyACtion.TabIndex = 1;
            this.gBoxCompanyACtion.TabStop = false;
            this.gBoxCompanyACtion.Text = "Add a new Company";
=======
            this.button1.Location = new System.Drawing.Point(140, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
>>>>>>> .r40
            // 
<<<<<<< .mine
            // btCancel
=======
            // textBox1
>>>>>>> .r40
            // 
<<<<<<< .mine
            this.btCancel.Location = new System.Drawing.Point(218, 57);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
=======
            this.textBox1.Location = new System.Drawing.Point(137, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 1;
>>>>>>> .r40
            // 
<<<<<<< .mine
            // btSubmit
=======
            // label1
>>>>>>> .r40
            // 
<<<<<<< .mine
            this.btSubmit.Location = new System.Drawing.Point(137, 57);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 23);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Add";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
=======
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // Name
            // 
            this.CompName.HeaderText = "Company Name";
            this.CompName.Name = "Name";
>>>>>>> .r40
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(137, 25);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(208, 20);
            this.tbCompanyName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
<<<<<<< .mine
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
=======
>>>>>>> .r40
            // ucCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCompany);
            this.Controls.Add(this.gBoxCompanyACtion);
            this.Name = "ucCompanyForm";
            this.Size = new System.Drawing.Size(764, 349);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).EndInit();
            this.gBoxCompanyACtion.ResumeLayout(false);
            this.gBoxCompanyACtion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

<<<<<<< .mine
        private System.Windows.Forms.GroupBox gBoxCompanyACtion;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbCompanyName;
=======
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
>>>>>>> .r40
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridView dgvCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbCompany;
        private System.Windows.Forms.DataGridViewButtonColumn btEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btDelete;
        private System.Windows.Forms.ErrorProvider errProviders;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompName;
        private System.Windows.Forms.DataGridViewButtonColumn ActionEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ActionDelete;
    }
}
