namespace FaceIDAppVBEta
{
    partial class ucWorkingCalendar
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
            this.dgvWorkingCalendar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddWorkingCalendar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmnDgvWorkingCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingCalendar)).BeginInit();
            this.cmnDgvWorkingCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWorkingCalendar
            // 
            this.dgvWorkingCalendar.AllowUserToAddRows = false;
            this.dgvWorkingCalendar.AllowUserToDeleteRows = false;
            this.dgvWorkingCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWorkingCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkingCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvWorkingCalendar.ContextMenuStrip = this.cmnDgvWorkingCalendar;
            this.dgvWorkingCalendar.Location = new System.Drawing.Point(36, 107);
            this.dgvWorkingCalendar.MultiSelect = false;
            this.dgvWorkingCalendar.Name = "dgvWorkingCalendar";
            this.dgvWorkingCalendar.ReadOnly = true;
            this.dgvWorkingCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkingCalendar.Size = new System.Drawing.Size(772, 522);
            this.dgvWorkingCalendar.TabIndex = 0;
            this.dgvWorkingCalendar.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkingCalendar_CellMouseEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Work On";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Working Hours";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnAddWorkingCalendar
            // 
            this.btnAddWorkingCalendar.Location = new System.Drawing.Point(36, 78);
            this.btnAddWorkingCalendar.Name = "btnAddWorkingCalendar";
            this.btnAddWorkingCalendar.Size = new System.Drawing.Size(146, 23);
            this.btnAddWorkingCalendar.TabIndex = 1;
            this.btnAddWorkingCalendar.Text = "Add new Working Calendar";
            this.btnAddWorkingCalendar.UseVisualStyleBackColor = true;
            this.btnAddWorkingCalendar.Click += new System.EventHandler(this.btnAddWorkingCalendar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Working Calendar Management";
            // 
            // cmnDgvWorkingCalendar
            // 
            this.cmnDgvWorkingCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmnDgvWorkingCalendar.Name = "cmnDgvWorkingCalendar";
            this.cmnDgvWorkingCalendar.Size = new System.Drawing.Size(113, 70);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ucWorkingCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddWorkingCalendar);
            this.Controls.Add(this.dgvWorkingCalendar);
            this.Name = "ucWorkingCalendar";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingCalendar)).EndInit();
            this.cmnDgvWorkingCalendar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkingCalendar;
        private System.Windows.Forms.Button btnAddWorkingCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmnDgvWorkingCalendar;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
    }
}
