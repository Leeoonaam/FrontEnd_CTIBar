namespace lsOPCTIBar
{
    partial class frmliberacao_zendesk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmliberacao_zendesk));
            this.label1 = new System.Windows.Forms.Label();
            this.txtmotivo = new System.Windows.Forms.TextBox();
            this.cmdcancelar = new System.Windows.Forms.Button();
            this.cmdok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbmotivo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Informe a Justificativa da Liberação:";
            // 
            // txtmotivo
            // 
            this.txtmotivo.Location = new System.Drawing.Point(12, 112);
            this.txtmotivo.Multiline = true;
            this.txtmotivo.Name = "txtmotivo";
            this.txtmotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtmotivo.Size = new System.Drawing.Size(615, 120);
            this.txtmotivo.TabIndex = 1;
            // 
            // cmdcancelar
            // 
            this.cmdcancelar.Location = new System.Drawing.Point(507, 238);
            this.cmdcancelar.Name = "cmdcancelar";
            this.cmdcancelar.Size = new System.Drawing.Size(120, 40);
            this.cmdcancelar.TabIndex = 3;
            this.cmdcancelar.Text = "Cancelar";
            this.cmdcancelar.UseVisualStyleBackColor = true;
            this.cmdcancelar.Click += new System.EventHandler(this.cmdcancelar_Click);
            // 
            // cmdok
            // 
            this.cmdok.Location = new System.Drawing.Point(381, 238);
            this.cmdok.Name = "cmdok";
            this.cmdok.Size = new System.Drawing.Size(120, 40);
            this.cmdok.TabIndex = 2;
            this.cmdok.Text = "OK";
            this.cmdok.UseVisualStyleBackColor = true;
            this.cmdok.Click += new System.EventHandler(this.cmdok_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Motivo:";
            // 
            // cmbmotivo
            // 
            this.cmbmotivo.FormattingEnabled = true;
            this.cmbmotivo.Location = new System.Drawing.Point(12, 34);
            this.cmbmotivo.Name = "cmbmotivo";
            this.cmbmotivo.Size = new System.Drawing.Size(615, 28);
            this.cmbmotivo.TabIndex = 0;
            // 
            // frmliberacao_zendesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(639, 288);
            this.Controls.Add(this.cmbmotivo);
            this.Controls.Add(this.cmdok);
            this.Controls.Add(this.cmdcancelar);
            this.Controls.Add(this.txtmotivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmliberacao_zendesk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Justificativa Liberação ZenDesk";
            this.Load += new System.EventHandler(this.frmliberacao_zendesk_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmotivo;
        private System.Windows.Forms.Button cmdcancelar;
        private System.Windows.Forms.Button cmdok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbmotivo;
    }
}