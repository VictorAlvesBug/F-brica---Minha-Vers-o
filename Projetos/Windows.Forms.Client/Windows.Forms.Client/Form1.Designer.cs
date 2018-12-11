namespace Windows.Forms.Client
{
    partial class frmPostman
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtDadosEnviados = new System.Windows.Forms.TextBox();
            this.txtDadosRecebidos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUrl.Location = new System.Drawing.Point(159, 17);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(765, 23);
            this.txtUrl.TabIndex = 0;
            // 
            // cmbMethod
            // 
            this.cmbMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "Get",
            "Post",
            "Put",
            "Delete"});
            this.cmbMethod.Location = new System.Drawing.Point(12, 12);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(140, 33);
            this.cmbMethod.TabIndex = 1;
            this.cmbMethod.Text = "Get";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(931, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(89, 35);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtDadosEnviados
            // 
            this.txtDadosEnviados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDadosEnviados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDadosEnviados.Location = new System.Drawing.Point(12, 53);
            this.txtDadosEnviados.Multiline = true;
            this.txtDadosEnviados.Name = "txtDadosEnviados";
            this.txtDadosEnviados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDadosEnviados.Size = new System.Drawing.Size(1008, 184);
            this.txtDadosEnviados.TabIndex = 3;
            // 
            // txtDadosRecebidos
            // 
            this.txtDadosRecebidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDadosRecebidos.Location = new System.Drawing.Point(12, 243);
            this.txtDadosRecebidos.Multiline = true;
            this.txtDadosRecebidos.Name = "txtDadosRecebidos";
            this.txtDadosRecebidos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDadosRecebidos.Size = new System.Drawing.Size(1008, 320);
            this.txtDadosRecebidos.TabIndex = 4;
            // 
            // frmPostman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 575);
            this.Controls.Add(this.txtDadosRecebidos);
            this.Controls.Add(this.txtDadosEnviados);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.txtUrl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPostman";
            this.Text = "Postman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtDadosEnviados;
        private System.Windows.Forms.TextBox txtDadosRecebidos;
    }
}

