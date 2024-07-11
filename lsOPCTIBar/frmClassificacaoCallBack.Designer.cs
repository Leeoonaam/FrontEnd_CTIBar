namespace lsOPCTIBar
{
    partial class frmClassificacaoCallBack
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassificacaoCallBack));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdatendido = new System.Windows.Forms.Button();
            this.cmdocupado = new System.Windows.Forms.Button();
            this.cmdnaoatende = new System.Windows.Forms.Button();
            this.cmdcaixapostal = new System.Windows.Forms.Button();
            this.cmdengano = new System.Windows.Forms.Button();
            this.cmdfax = new System.Windows.Forms.Button();
            this.cmdnaoinformado = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(68, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "CLASSIFICAÇÃO DO CALL BACK";
            // 
            // cmdatendido
            // 
            this.cmdatendido.Location = new System.Drawing.Point(12, 125);
            this.cmdatendido.Name = "cmdatendido";
            this.cmdatendido.Size = new System.Drawing.Size(563, 55);
            this.cmdatendido.TabIndex = 3;
            this.cmdatendido.Text = "ATENDIDO";
            this.cmdatendido.UseVisualStyleBackColor = true;
            this.cmdatendido.Click += new System.EventHandler(this.cmdatendido_Click);
            // 
            // cmdocupado
            // 
            this.cmdocupado.Location = new System.Drawing.Point(12, 204);
            this.cmdocupado.Name = "cmdocupado";
            this.cmdocupado.Size = new System.Drawing.Size(263, 55);
            this.cmdocupado.TabIndex = 3;
            this.cmdocupado.Text = "OCUPADO";
            this.cmdocupado.UseVisualStyleBackColor = true;
            this.cmdocupado.Click += new System.EventHandler(this.cmdocupado_Click);
            // 
            // cmdnaoatende
            // 
            this.cmdnaoatende.Location = new System.Drawing.Point(312, 204);
            this.cmdnaoatende.Name = "cmdnaoatende";
            this.cmdnaoatende.Size = new System.Drawing.Size(263, 55);
            this.cmdnaoatende.TabIndex = 3;
            this.cmdnaoatende.Text = "NÃO ATENDEU";
            this.cmdnaoatende.UseVisualStyleBackColor = true;
            this.cmdnaoatende.Click += new System.EventHandler(this.cmdnaoatende_Click);
            // 
            // cmdcaixapostal
            // 
            this.cmdcaixapostal.Location = new System.Drawing.Point(12, 275);
            this.cmdcaixapostal.Name = "cmdcaixapostal";
            this.cmdcaixapostal.Size = new System.Drawing.Size(263, 55);
            this.cmdcaixapostal.TabIndex = 3;
            this.cmdcaixapostal.Text = "CAIXA POSTAL";
            this.cmdcaixapostal.UseVisualStyleBackColor = true;
            this.cmdcaixapostal.Click += new System.EventHandler(this.cmdcaixapostal_Click);
            // 
            // cmdengano
            // 
            this.cmdengano.Location = new System.Drawing.Point(312, 275);
            this.cmdengano.Name = "cmdengano";
            this.cmdengano.Size = new System.Drawing.Size(263, 55);
            this.cmdengano.TabIndex = 3;
            this.cmdengano.Text = "ENGANO";
            this.cmdengano.UseVisualStyleBackColor = true;
            this.cmdengano.Click += new System.EventHandler(this.cmdengano_Click);
            // 
            // cmdfax
            // 
            this.cmdfax.Location = new System.Drawing.Point(12, 346);
            this.cmdfax.Name = "cmdfax";
            this.cmdfax.Size = new System.Drawing.Size(263, 55);
            this.cmdfax.TabIndex = 3;
            this.cmdfax.Text = "FAX";
            this.cmdfax.UseVisualStyleBackColor = true;
            this.cmdfax.Click += new System.EventHandler(this.cmdfax_Click);
            // 
            // cmdnaoinformado
            // 
            this.cmdnaoinformado.Location = new System.Drawing.Point(312, 346);
            this.cmdnaoinformado.Name = "cmdnaoinformado";
            this.cmdnaoinformado.Size = new System.Drawing.Size(263, 55);
            this.cmdnaoinformado.TabIndex = 3;
            this.cmdnaoinformado.Text = "NÃO INFORMADO";
            this.cmdnaoinformado.UseVisualStyleBackColor = true;
            this.cmdnaoinformado.Click += new System.EventHandler(this.cmdnaoinformado_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 436);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(563, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmClassificacaoCallBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(587, 464);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdnaoinformado);
            this.Controls.Add(this.cmdengano);
            this.Controls.Add(this.cmdnaoatende);
            this.Controls.Add(this.cmdfax);
            this.Controls.Add(this.cmdcaixapostal);
            this.Controls.Add(this.cmdocupado);
            this.Controls.Add(this.cmdatendido);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmClassificacaoCallBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classificação Call Back";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmClassificacaoCallBack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdatendido;
        private System.Windows.Forms.Button cmdocupado;
        private System.Windows.Forms.Button cmdnaoatende;
        private System.Windows.Forms.Button cmdcaixapostal;
        private System.Windows.Forms.Button cmdengano;
        private System.Windows.Forms.Button cmdfax;
        private System.Windows.Forms.Button cmdnaoinformado;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}