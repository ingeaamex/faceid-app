namespace FaceIDAppVBEta
{
    partial class frmServerConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerConnect));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerComputerName = new System.Windows.Forms.TextBox();
            this.ipcServerIPAdress = new IPAddressControlLib.IPAddressControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server\'s Computer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server\'s IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Please enter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "OR";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(93, 119);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerComputerName
            // 
            this.txtServerComputerName.Location = new System.Drawing.Point(146, 36);
            this.txtServerComputerName.Name = "txtServerComputerName";
            this.txtServerComputerName.Size = new System.Drawing.Size(100, 20);
            this.txtServerComputerName.TabIndex = 5;
            // 
            // ipcServerIPAdress
            // 
            this.ipcServerIPAdress.AllowInternalTab = false;
            this.ipcServerIPAdress.AutoHeight = true;
            this.ipcServerIPAdress.BackColor = System.Drawing.SystemColors.Window;
            this.ipcServerIPAdress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipcServerIPAdress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipcServerIPAdress.Location = new System.Drawing.Point(146, 81);
            this.ipcServerIPAdress.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipcServerIPAdress.Name = "ipcServerIPAdress";
            this.ipcServerIPAdress.ReadOnly = false;
            this.ipcServerIPAdress.Size = new System.Drawing.Size(100, 20);
            this.ipcServerIPAdress.TabIndex = 10;
            this.ipcServerIPAdress.Text = "10.0.0.5";
            // 
            // frmServerConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 158);
            this.Controls.Add(this.ipcServerIPAdress);
            this.Controls.Add(this.txtServerComputerName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServerConnect";
            this.Text = "Connect to Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerComputerName;
        private IPAddressControlLib.IPAddressControl ipcServerIPAdress;
    }
}