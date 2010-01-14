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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WorkingCalendarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkingCalendarName,
            this.EditAction,
            this.DeleteAction});
            this.dataGridView1.Location = new System.Drawing.Point(17, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(598, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // WorkingCalendarName
            // 
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add new Working Calendar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ucWorkingCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucWorkingCalendar";
            this.Size = new System.Drawing.Size(822, 304);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingCalendarName;
        private System.Windows.Forms.DataGridViewButtonColumn EditAction;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteAction;
        private System.Windows.Forms.Button button1;
    }
}
