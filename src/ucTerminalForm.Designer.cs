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
            this.btAdd = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dgvTerminal = new System.Windows.Forms.DataGridView();
            this.cMnSaction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBoxAction = new System.Windows.Forms.GroupBox();
            this.mtbIpAddess = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTerminalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errProviders = new System.Windows.Forms.ErrorProvider(this.components);
            this.TerminaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TerminalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerminal)).BeginInit();
            this.cMnSaction.SuspendLayout();
            this.gBoxAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).BeginInit();
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
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(35, 91);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(35, 91);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 2;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(116, 91);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dgvTerminal
            // 
            this.dgvTerminal.AllowUserToAddRows = false;
            this.dgvTerminal.AllowUserToDeleteRows = false;
            this.dgvTerminal.AllowUserToOrderColumns = true;
            this.dgvTerminal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTerminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerminal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TerminaleID,
            this.TerminalName,
            this.IPAddress,
            this.TerminalStatus});
            this.dgvTerminal.Location = new System.Drawing.Point(36, 78);
            this.dgvTerminal.Name = "dgvTerminal";
            this.dgvTerminal.Size = new System.Drawing.Size(772, 384);
            this.dgvTerminal.TabIndex = 4;
            this.dgvTerminal.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTerminal_CellMouseEnter);
            // 
            // cMnSaction
            // 
            this.cMnSaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cMnSaction.Name = "cMnSaction";
            this.cMnSaction.Size = new System.Drawing.Size(110, 48);
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
            // gBoxAction
            // 
            this.gBoxAction.Controls.Add(this.mtbIpAddess);
            this.gBoxAction.Controls.Add(this.label3);
            this.gBoxAction.Controls.Add(this.tbTerminalName);
            this.gBoxAction.Controls.Add(this.label2);
            this.gBoxAction.Controls.Add(this.btAdd);
            this.gBoxAction.Controls.Add(this.btUpdate);
            this.gBoxAction.Controls.Add(this.btCancel);
            this.gBoxAction.Location = new System.Drawing.Point(36, 493);
            this.gBoxAction.Name = "gBoxAction";
            this.gBoxAction.Size = new System.Drawing.Size(772, 135);
            this.gBoxAction.TabIndex = 5;
            this.gBoxAction.TabStop = false;
            this.gBoxAction.Text = "Add New Terminal / Update Terminal";
            // 
            // mtbIpAddess
            // 
            this.mtbIpAddess.Location = new System.Drawing.Point(105, 53);
            this.mtbIpAddess.Mask = "000.000.000.000";
            this.mtbIpAddess.Name = "mtbIpAddess";
            this.mtbIpAddess.Size = new System.Drawing.Size(100, 20);
            this.mtbIpAddess.TabIndex = 8;
            this.mtbIpAddess.ValidatingType = typeof(System.DateTime);
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
            // tbTerminalName
            // 
            this.tbTerminalName.Location = new System.Drawing.Point(105, 27);
            this.tbTerminalName.Name = "tbTerminalName";
            this.tbTerminalName.Size = new System.Drawing.Size(100, 20);
            this.tbTerminalName.TabIndex = 5;
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
            // errProviders
            // 
            this.errProviders.ContainerControl = this;
            // 
            // TerminaleID
            // 
            this.TerminaleID.ContextMenuStrip = this.cMnSaction;
            this.TerminaleID.DataPropertyName = "ID";
            this.TerminaleID.HeaderText = "ID";
            this.TerminaleID.Name = "TerminalID";
            this.TerminaleID.ReadOnly = true;
            this.TerminaleID.Visible = false;
            // 
            // TerminalName
            // 
            this.TerminalName.ContextMenuStrip = this.cMnSaction;
            this.TerminalName.DataPropertyName = "Name";
            this.TerminalName.HeaderText = "Terminal Name";
            this.TerminalName.Name = "TerminalName";
            this.TerminalName.ReadOnly = true;
            // 
            // IPAddress
            // 
            this.IPAddress.ContextMenuStrip = this.cMnSaction;
            this.IPAddress.DataPropertyName = "IPAddress";
            this.IPAddress.HeaderText = "IP Address";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            // 
            // TerminalStatus
            // 
            this.TerminalStatus.ContextMenuStrip = this.cMnSaction;
            this.TerminalStatus.DataPropertyName = "Status";
            this.TerminalStatus.HeaderText = "Status";
            this.TerminalStatus.Name = "TerminalStatus";
            this.TerminalStatus.ReadOnly = true;
            this.TerminalStatus.Visible = false;
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
            this.cMnSaction.ResumeLayout(false);
            this.gBoxAction.ResumeLayout(false);
            this.gBoxAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.DataGridView dgvTerminal;
        private System.Windows.Forms.GroupBox gBoxAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTerminalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mtbIpAddess;
        private System.Windows.Forms.ErrorProvider errProviders;
        private System.Windows.Forms.ContextMenuStrip cMnSaction;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalStatus;
    }
}
