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
            this.dgvWorkingCalendar = new System.Windows.Forms.DataGridView();
            this.btnAddWorkingCalendar = new System.Windows.Forms.Button();
            this.btnUpdateWorkingCalendar = new System.Windows.Forms.Button();
            this.btnDeleteWorkingCalendar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkingCalendar
            // 
            this.dgvWorkingCalendar.AllowUserToAddRows = false;
            this.dgvWorkingCalendar.AllowUserToDeleteRows = false;
            this.dgvWorkingCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWorkingCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkingCalendar.Location = new System.Drawing.Point(20, 35);
            this.dgvWorkingCalendar.MultiSelect = false;
            this.dgvWorkingCalendar.Name = "dgvWorkingCalendar";
            this.dgvWorkingCalendar.ReadOnly = true;
            this.dgvWorkingCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkingCalendar.Size = new System.Drawing.Size(598, 150);
            this.dgvWorkingCalendar.TabIndex = 0;
            this.dgvWorkingCalendar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkingCalendar_CellClick);
            // 
            // btnAddWorkingCalendar
            // 
            this.btnAddWorkingCalendar.Location = new System.Drawing.Point(20, 192);
            this.btnAddWorkingCalendar.Name = "btnAddWorkingCalendar";
            this.btnAddWorkingCalendar.Size = new System.Drawing.Size(200, 23);
            this.btnAddWorkingCalendar.TabIndex = 1;
            this.btnAddWorkingCalendar.Text = "Add new Working Calendar";
            this.btnAddWorkingCalendar.UseVisualStyleBackColor = true;
            this.btnAddWorkingCalendar.Click += new System.EventHandler(this.btnAddWorkingCalendar_Click);
            // 
            // btnUpdateWorkingCalendar
            // 
            this.btnUpdateWorkingCalendar.Location = new System.Drawing.Point(226, 192);
            this.btnUpdateWorkingCalendar.Name = "btnUpdateWorkingCalendar";
            this.btnUpdateWorkingCalendar.Size = new System.Drawing.Size(200, 23);
            this.btnUpdateWorkingCalendar.TabIndex = 2;
            this.btnUpdateWorkingCalendar.Text = "Edit Selected Working Calendar";
            this.btnUpdateWorkingCalendar.UseVisualStyleBackColor = true;
            this.btnUpdateWorkingCalendar.Click += new System.EventHandler(this.btnUpdateWorkingCalendar_Click);
            // 
            // btnDeleteWorkingCalendar
            // 
            this.btnDeleteWorkingCalendar.Location = new System.Drawing.Point(433, 192);
            this.btnDeleteWorkingCalendar.Name = "btnDeleteWorkingCalendar";
            this.btnDeleteWorkingCalendar.Size = new System.Drawing.Size(185, 23);
            this.btnDeleteWorkingCalendar.TabIndex = 3;
            this.btnDeleteWorkingCalendar.Text = "Delete Selected Working Calendar";
            this.btnDeleteWorkingCalendar.UseVisualStyleBackColor = true;
            this.btnDeleteWorkingCalendar.Click += new System.EventHandler(this.btnDeleteWorkingCalendar_Click);
            // 
            // ucWorkingCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteWorkingCalendar);
            this.Controls.Add(this.btnUpdateWorkingCalendar);
            this.Controls.Add(this.btnAddWorkingCalendar);
            this.Controls.Add(this.dgvWorkingCalendar);
            this.Name = "ucWorkingCalendar";
            this.Size = new System.Drawing.Size(822, 304);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingCalendar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkingCalendar;
        private System.Windows.Forms.Button btnAddWorkingCalendar;
        private System.Windows.Forms.Button btnUpdateWorkingCalendar;
        private System.Windows.Forms.Button btnDeleteWorkingCalendar;
    }
}
