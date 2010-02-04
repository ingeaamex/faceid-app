namespace FaceIDAppVBEta
{
    partial class ucDepartmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDepartmentForm));
            this.tvDepartment = new System.Windows.Forms.TreeView();
            this.groupBoxDepartment = new System.Windows.Forms.GroupBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.cbxSupDepartment = new System.Windows.Forms.ComboBox();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsTreeAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxDepartment.SuspendLayout();
            this.cmsTreeAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // tvDepartment
            // 
            this.tvDepartment.Location = new System.Drawing.Point(36, 83);
            this.tvDepartment.Name = "tvDepartment";
            this.tvDepartment.Size = new System.Drawing.Size(772, 362);
            this.tvDepartment.TabIndex = 0;
            this.tvDepartment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tvDepartment_MouseClick);
            this.tvDepartment.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvDepartment_AfterExpand);
            // 
            // groupBoxDepartment
            // 
            this.groupBoxDepartment.Controls.Add(this.btCancel);
            this.groupBoxDepartment.Controls.Add(this.btnSubmit);
            this.groupBoxDepartment.Controls.Add(this.txtDepartmentName);
            this.groupBoxDepartment.Controls.Add(this.cbxSupDepartment);
            this.groupBoxDepartment.Controls.Add(this.cbxCompany);
            this.groupBoxDepartment.Controls.Add(this.label3);
            this.groupBoxDepartment.Controls.Add(this.label2);
            this.groupBoxDepartment.Controls.Add(this.label1);
            this.groupBoxDepartment.Location = new System.Drawing.Point(36, 477);
            this.groupBoxDepartment.Name = "groupBoxDepartment";
            this.groupBoxDepartment.Size = new System.Drawing.Size(772, 148);
            this.groupBoxDepartment.TabIndex = 1;
            this.groupBoxDepartment.TabStop = false;
            this.groupBoxDepartment.Text = "Add a Department";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(121, 103);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(40, 103);
            this.btnSubmit.Name = "btSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Add";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(120, 77);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(121, 20);
            this.txtDepartmentName.TabIndex = 5;
            // 
            // cbxSupDepartment
            // 
            this.cbxSupDepartment.DisplayMember = "Name";
            this.cbxSupDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupDepartment.FormattingEnabled = true;
            this.cbxSupDepartment.Location = new System.Drawing.Point(120, 50);
            this.cbxSupDepartment.Name = "cbxSupDepartment";
            this.cbxSupDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxSupDepartment.TabIndex = 4;
            this.cbxSupDepartment.ValueMember = "ID";
            // 
            // cbxCompany
            // 
            this.cbxCompany.DisplayMember = "Name";
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxCompany.Location = new System.Drawing.Point(120, 23);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 3;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sup - Department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company";
            // 
            // cmsTreeAction
            // 
            this.cmsTreeAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsTreeAction.Name = "cmsTreeAction";
            this.cmsTreeAction.Size = new System.Drawing.Size(110, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "error");
            this.imageList1.Images.SetKeyName(1, "ok");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Department Management";
            // 
            // ucDepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBoxDepartment);
            this.Controls.Add(this.tvDepartment);
            this.Name = "ucDepartmentForm";
            this.Size = new System.Drawing.Size(845, 662);
            this.groupBoxDepartment.ResumeLayout(false);
            this.groupBoxDepartment.PerformLayout();
            this.cmsTreeAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvDepartment;
        private System.Windows.Forms.GroupBox groupBoxDepartment;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.ComboBox cbxSupDepartment;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsTreeAction;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errProviders;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
    }
}
