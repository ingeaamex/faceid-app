namespace FaceIDAppVBEta
{
    partial class frmTerminalRegister
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRegTerminal = new System.Windows.Forms.Label();
            this.lblAvailTerminal = new System.Windows.Forms.Label();
            this.lbxRegTerminal = new System.Windows.Forms.ListBox();
            this.lbxAvailTerminal = new System.Windows.Forms.ListBox();
            this.btnAddTerminal = new System.Windows.Forms.Button();
            this.btnRemoveTerminal = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRegTerminal
            // 
            this.lblRegTerminal.AutoSize = true;
            this.lblRegTerminal.Location = new System.Drawing.Point(32, 19);
            this.lblRegTerminal.Name = "lblRegTerminal";
            this.lblRegTerminal.Size = new System.Drawing.Size(101, 13);
            this.lblRegTerminal.TabIndex = 0;
            this.lblRegTerminal.Text = "Registered Terminal";
            // 
            // lblAvailTerminal
            // 
            this.lblAvailTerminal.AutoSize = true;
            this.lblAvailTerminal.Location = new System.Drawing.Point(309, 19);
            this.lblAvailTerminal.Name = "lblAvailTerminal";
            this.lblAvailTerminal.Size = new System.Drawing.Size(93, 13);
            this.lblAvailTerminal.TabIndex = 1;
            this.lblAvailTerminal.Text = "Available Terminal";
            // 
            // lbxRegTerminal
            // 
            this.lbxRegTerminal.DisplayMember = "Name";
            this.lbxRegTerminal.FormattingEnabled = true;
            this.lbxRegTerminal.Location = new System.Drawing.Point(22, 52);
            this.lbxRegTerminal.Name = "lbxRegTerminal";
            this.lbxRegTerminal.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxRegTerminal.Size = new System.Drawing.Size(120, 95);
            this.lbxRegTerminal.TabIndex = 2;
            this.lbxRegTerminal.ValueMember = "ID";
            // 
            // lbxAvailTerminal
            // 
            this.lbxAvailTerminal.DisplayMember = "Name";
            this.lbxAvailTerminal.FormattingEnabled = true;
            this.lbxAvailTerminal.Location = new System.Drawing.Point(295, 52);
            this.lbxAvailTerminal.Name = "lbxAvailTerminal";
            this.lbxAvailTerminal.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxAvailTerminal.Size = new System.Drawing.Size(120, 95);
            this.lbxAvailTerminal.TabIndex = 3;
            this.lbxAvailTerminal.ValueMember = "ID";
            // 
            // btnAddTerminal
            // 
            this.btnAddTerminal.Location = new System.Drawing.Point(158, 52);
            this.btnAddTerminal.Name = "btnAddTerminal";
            this.btnAddTerminal.Size = new System.Drawing.Size(121, 23);
            this.btnAddTerminal.TabIndex = 4;
            this.btnAddTerminal.Text = "Add Terminal(s)";
            this.btnAddTerminal.UseVisualStyleBackColor = true;
            this.btnAddTerminal.Click += new System.EventHandler(this.btnAddTerminal_Click);
            // 
            // btnRemoveTerminal
            // 
            this.btnRemoveTerminal.Location = new System.Drawing.Point(158, 82);
            this.btnRemoveTerminal.Name = "btnRemoveTerminal";
            this.btnRemoveTerminal.Size = new System.Drawing.Size(121, 23);
            this.btnRemoveTerminal.TabIndex = 5;
            this.btnRemoveTerminal.Text = "Remove Terminal(s)";
            this.btnRemoveTerminal.UseVisualStyleBackColor = true;
            this.btnRemoveTerminal.Click += new System.EventHandler(this.btnRemoveTerminal_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(142, 165);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Finish";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmTerminalRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 207);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnRemoveTerminal);
            this.Controls.Add(this.btnAddTerminal);
            this.Controls.Add(this.lbxAvailTerminal);
            this.Controls.Add(this.lbxRegTerminal);
            this.Controls.Add(this.lblAvailTerminal);
            this.Controls.Add(this.lblRegTerminal);
            this.Name = "frmTerminalRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTerminalRegister";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTerminalRegister_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegTerminal;
        private System.Windows.Forms.Label lblAvailTerminal;
        private System.Windows.Forms.ListBox lbxRegTerminal;
        private System.Windows.Forms.ListBox lbxAvailTerminal;
        private System.Windows.Forms.Button btnAddTerminal;
        private System.Windows.Forms.Button btnRemoveTerminal;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}