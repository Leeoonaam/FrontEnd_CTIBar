namespace lsOPCTIBar
{
    partial class frmMensagemAlerta
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
            this.cdmfechar = new System.Windows.Forms.Button();
            this.txtmensagem = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cdmfechar
            // 
            this.cdmfechar.Location = new System.Drawing.Point(261, 243);
            this.cdmfechar.Name = "cdmfechar";
            this.cdmfechar.Size = new System.Drawing.Size(256, 41);
            this.cdmfechar.TabIndex = 6;
            this.cdmfechar.Text = "Fechar";
            this.cdmfechar.UseVisualStyleBackColor = true;
            this.cdmfechar.Click += new System.EventHandler(this.cdmfechar_Click);
            // 
            // txtmensagem
            // 
            this.txtmensagem.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmensagem.ForeColor = System.Drawing.Color.Red;
            this.txtmensagem.Location = new System.Drawing.Point(12, 26);
            this.txtmensagem.Multiline = true;
            this.txtmensagem.Name = "txtmensagem";
            this.txtmensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtmensagem.Size = new System.Drawing.Size(761, 208);
            this.txtmensagem.TabIndex = 5;
            this.txtmensagem.Text = "fefwefew fw few fwe fwe";
            this.txtmensagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(788, 10);
            this.panel3.TabIndex = 7;
            // 
            // frmMensagemAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(788, 294);
            this.Controls.Add(this.cdmfechar);
            this.Controls.Add(this.txtmensagem);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMensagemAlerta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMensagemAlerta";
            this.Load += new System.EventHandler(this.frmMensagemAlerta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cdmfechar;
        private System.Windows.Forms.TextBox txtmensagem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
    }
}