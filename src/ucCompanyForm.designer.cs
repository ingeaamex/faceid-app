namespace FaceIDAppVBEta
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
            this.label1 = new System.Windows.Forms.Label();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            this.CompName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ActionDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).BeginInit();
            this.gBoxCompanyACtion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompany
            // 
            this.dgvCompany.AllowUserToAddRows = false;
            this.dgvCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbCompany,
            this.btEdit,
            this.btDelete});
            this.dgvCompany.Location = new System.Drawing.Point(36, 71);
            this.dgvCompany.Name = "dgvCompany";
            this.dgvCompany.ReadOnly = true;
            this.dgvCompany.Size = new System.Drawing.Size(772, 418);
            this.dgvCompany.TabIndex = 0;
            this.dgvCompany.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompany_CellClick);
            // 
            // tbCompany
            // 
            this.tbCompany.DataPropertyName = "Name";
            this.tbCompany.HeaderText = "Company Name";
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.ReadOnly = true;
            // 
            // btEdit
            // 
            this.btEdit.DataPropertyName = "CompanyID";
            this.btEdit.HeaderText = "Edit";
            this.btEdit.Name = "btEdit";
            this.btEdit.ReadOnly = true;
            this.btEdit.Text = "Edit";
            this.btEdit.UseColumnTextForButtonValue = true;
            // 
            // btDelete
            // 
            this.btDelete.DataPropertyName = "CompanyID";
            this.btDelete.HeaderText = "Delete";
            this.btDelete.Name = "btDelete";
            this.btDelete.ReadOnly = true;
            this.btDelete.Text = "Delete";
            this.btDelete.UseColumnTextForButtonValue = true;
            // 
            // gBoxCompanyACtion
            // 
            this.gBoxCompanyACtion.Controls.Add(this.btCancel);
            this.gBoxCompanyACtion.Controls.Add(this.btSubmit);
            this.gBoxCompanyACtion.Controls.Add(this.tbCompanyName);
            this.gBoxCompanyACtion.Controls.Add(this.label1);
            this.gBoxCompanyACtion.Location = new System.Drawing.Point(36, 518);
            this.gBoxCompanyACtion.Name = "gBoxCompanyACtion";
            this.gBoxCompanyACtion.Size = new System.Drawing.Size(772, 115);
            this.gBoxCompanyACtion.TabIndex = 1;
            this.gBoxCompanyACtion.TabStop = false;
            this.gBoxCompanyACtion.Text = "Add a new Company";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(175, 73);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(94, 73);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(75, 23);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Add";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(107, 32);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(208, 20);
            this.tbCompanyName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
            // CompName
            // 
            this.CompName.HeaderText = "Company Name";
            this.CompName.Name = "Name";
            // 
            // ActionEdit
            // 
            this.ActionEdit.Name = "ActionEdit";
            // 
            // ActionDelete
            // 
            this.ActionDelete.Name = "ActionDelete";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company Management";
            // 
            // ucCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCompany);
            this.Controls.Add(this.gBoxCompanyACtion);
            this.Name = "ucCompanyForm";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).EndInit();
            this.gBoxCompanyACtion.ResumeLayout(false);
            this.gBoxCompanyACtion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxCompanyACtion;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.TextBox tbCompanyName;
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
        private System.Windows.Forms.Label label2;
    }
}
