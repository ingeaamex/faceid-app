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
            this.WorkingCalendarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteAction = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWorkingCalendar
            // 
            this.dgvWorkingCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkingCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkingCalendarName,
            this.EditAction,
            this.DeleteAction});
            this.dgvWorkingCalendar.Location = new System.Drawing.Point(17, 16);
            this.dgvWorkingCalendar.Name = "dgvWorkingCalendar";
            this.dgvWorkingCalendar.Size = new System.Drawing.Size(598, 150);
            this.dgvWorkingCalendar.TabIndex = 0;
            // 
            // btnAddWorkingCalendar
            // 
            this.btnAddWorkingCalendar.Location = new System.Drawing.Point(17, 173);
            this.btnAddWorkingCalendar.Name = "btnAddWorkingCalendar";
            this.btnAddWorkingCalendar.Size = new System.Drawing.Size(324, 23);
            this.btnAddWorkingCalendar.TabIndex = 1;
            this.btnAddWorkingCalendar.Text = "Add new Working Calendar";
            this.btnAddWorkingCalendar.UseVisualStyleBackColor = true;
            this.btnAddWorkingCalendar.Click += new System.EventHandler(this.btnAddWorkingCalendar_Click);
            // 
            // WorkingCalendarName
            // 
            this.WorkingCalendarName.DataPropertyName = "Name";
            this.WorkingCalendarName.HeaderText = "Working Calendar Name";
            this.WorkingCalendarName.Name = "WorkingCalendarName";
            this.WorkingCalendarName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EditAction
            // 
            this.EditAction.HeaderText = "Edit";
            this.EditAction.Name = "EditAction";
            // 
            // DeleteAction
            // 
            this.DeleteAction.HeaderText = "Delete";
            this.DeleteAction.Name = "DeleteAction";
            this.DeleteAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ucWorkingCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingCalendarName;
        private System.Windows.Forms.DataGridViewButtonColumn EditAction;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteAction;
    }
}
