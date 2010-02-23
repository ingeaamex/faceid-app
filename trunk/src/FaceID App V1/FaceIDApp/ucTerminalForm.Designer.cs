namespace FaceIDAppVBEta
{
    partial class ucTerminalForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvTerminal = new System.Windows.Forms.DataGridView();
            this.TerminalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDgvTerminal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TerminalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxAction = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTerminalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipcTerminalIP = new IPAddressControlLib.IPAddressControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).BeginInit();
            this.cmnDgvTerminal.SuspendLayout();
            this.gBoxAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terminal Management";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(35, 91);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Add/Update";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(116, 91);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dgvTerminal
            // 
            this.dgvTerminal.AllowUserToAddRows = false;
            this.dgvTerminal.AllowUserToDeleteRows = false;
            this.dgvTerminal.AllowUserToOrderColumns = true;
            this.dgvTerminal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTerminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TerminalID,
            this.TerminalName,
            this.IPAddress,
            this.TerminalStatus});
            this.dgvTerminal.Location = new System.Drawing.Point(36, 78);
            this.dgvTerminal.Name = "dgvTerminal";
            this.dgvTerminal.Size = new System.Drawing.Size(772, 384);
            this.dgvTerminal.TabIndex = 4;
            this.dgvTerminal.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTerminal_CellMouseEnter);
            // 
            // TerminalID
            // 
            this.TerminalID.ContextMenuStrip = this.cmnDgvTerminal;
            this.TerminalID.DataPropertyName = "ID";
            this.TerminalID.HeaderText = "ID";
            this.TerminalID.Name = "TerminalID";
            this.TerminalID.ReadOnly = true;
            this.TerminalID.Visible = false;
            // 
            // cmnDgvTerminal
            // 
            this.cmnDgvTerminal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmnDgvTerminal.Name = "cMnSaction";
            this.cmnDgvTerminal.Size = new System.Drawing.Size(110, 48);
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
            // TerminalName
            // 
            this.TerminalName.ContextMenuStrip = this.cmnDgvTerminal;
            this.TerminalName.DataPropertyName = "Name";
            this.TerminalName.HeaderText = "Terminal Name";
            this.TerminalName.Name = "TerminalName";
            this.TerminalName.ReadOnly = true;
            // 
            // IPAddress
            // 
            this.IPAddress.ContextMenuStrip = this.cmnDgvTerminal;
            this.IPAddress.DataPropertyName = "IPAddress";
            this.IPAddress.HeaderText = "IP Address";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // TerminalStatus
            // 
            this.TerminalStatus.ContextMenuStrip = this.cmnDgvTerminal;
            this.TerminalStatus.DataPropertyName = "Status";
            this.TerminalStatus.HeaderText = "Status";
            this.TerminalStatus.Name = "TerminalStatus";
            this.TerminalStatus.ReadOnly = true;
            this.TerminalStatus.Visible = false;
            // 
            // gBoxAction
            // 
            this.gBoxAction.Controls.Add(this.ipcTerminalIP);
            this.gBoxAction.Controls.Add(this.label3);
            this.gBoxAction.Controls.Add(this.txtTerminalName);
            this.gBoxAction.Controls.Add(this.label2);
            this.gBoxAction.Controls.Add(this.btnSubmit);
            this.gBoxAction.Controls.Add(this.btnCancel);
            this.gBoxAction.Location = new System.Drawing.Point(36, 493);
            this.gBoxAction.Name = "gBoxAction";
            this.gBoxAction.Size = new System.Drawing.Size(772, 135);
            this.gBoxAction.TabIndex = 5;
            this.gBoxAction.TabStop = false;
            this.gBoxAction.Text = "Add New Terminal / Update Terminal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP Address";
            // 
            // txtTerminalName
            // 
            this.txtTerminalName.Location = new System.Drawing.Point(105, 27);
            this.txtTerminalName.Name = "txtTerminalName";
            this.txtTerminalName.Size = new System.Drawing.Size(100, 20);
            this.txtTerminalName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Terminal Name";
            // 
            // ipcTerminalIP
            // 
            this.ipcTerminalIP.AllowInternalTab = false;
            this.ipcTerminalIP.AutoHeight = true;
            this.ipcTerminalIP.BackColor = System.Drawing.SystemColors.Window;
            this.ipcTerminalIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipcTerminalIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipcTerminalIP.Location = new System.Drawing.Point(105, 53);
            this.ipcTerminalIP.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipcTerminalIP.Name = "ipcTerminalIP";
            this.ipcTerminalIP.ReadOnly = false;
            this.ipcTerminalIP.Size = new System.Drawing.Size(100, 20);
            this.ipcTerminalIP.TabIndex = 17;
            this.ipcTerminalIP.Text = "...";
            // 
            // ucTerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTerminal);
            this.Controls.Add(this.gBoxAction);
            this.Controls.Add(this.label1);
            this.Name = "ucTerminalForm";
            this.Size = new System.Drawing.Size(845, 662);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).EndInit();
            this.cmnDgvTerminal.ResumeLayout(false);
            this.gBoxAction.ResumeLayout(false);
            this.gBoxAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvTerminal;
        private System.Windows.Forms.GroupBox gBoxAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTerminalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmnDgvTerminal;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalID;
        private IPAddressControlLib.IPAddressControl ipcTerminalIP;
    }
}
