namespace lsOPCTIBar
{
    partial class frmperformance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmperformance));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltotalatendimentos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbltma = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltotalpausa = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbltempologado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridview_atendimentos = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridview_pausas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview_atendimentos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview_pausas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lbltotalatendimentos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 109);
            this.panel1.TabIndex = 0;
            // 
            // lbltotalatendimentos
            // 
            this.lbltotalatendimentos.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalatendimentos.ForeColor = System.Drawing.Color.White;
            this.lbltotalatendimentos.Location = new System.Drawing.Point(25, 19);
            this.lbltotalatendimentos.Name = "lbltotalatendimentos";
            this.lbltotalatendimentos.Size = new System.Drawing.Size(110, 45);
            this.lbltotalatendimentos.TabIndex = 0;
            this.lbltotalatendimentos.Text = "00";
            this.lbltotalatendimentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atendimentos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.lbltma);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(196, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 109);
            this.panel2.TabIndex = 0;
            // 
            // lbltma
            // 
            this.lbltma.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltma.ForeColor = System.Drawing.Color.White;
            this.lbltma.Location = new System.Drawing.Point(25, 19);
            this.lbltma.Name = "lbltma";
            this.lbltma.Size = new System.Drawing.Size(110, 45);
            this.lbltma.TabIndex = 0;
            this.lbltma.Text = "00:00:00";
            this.lbltma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "T.M.A.";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Controls.Add(this.lbltotalpausa);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(378, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 109);
            this.panel3.TabIndex = 0;
            // 
            // lbltotalpausa
            // 
            this.lbltotalpausa.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalpausa.ForeColor = System.Drawing.Color.White;
            this.lbltotalpausa.Location = new System.Drawing.Point(25, 19);
            this.lbltotalpausa.Name = "lbltotalpausa";
            this.lbltotalpausa.Size = new System.Drawing.Size(110, 45);
            this.lbltotalpausa.TabIndex = 0;
            this.lbltotalpausa.Text = "00";
            this.lbltotalpausa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(51, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pausas";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.lbltempologado);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(558, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 109);
            this.panel4.TabIndex = 0;
            // 
            // lbltempologado
            // 
            this.lbltempologado.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltempologado.ForeColor = System.Drawing.Color.White;
            this.lbltempologado.Location = new System.Drawing.Point(29, 24);
            this.lbltempologado.Name = "lbltempologado";
            this.lbltempologado.Size = new System.Drawing.Size(110, 45);
            this.lbltempologado.TabIndex = 0;
            this.lbltempologado.Text = "00:00:00";
            this.lbltempologado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(51, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Logado";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 146);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(730, 381);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridview_atendimentos);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Atendimentos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridview_atendimentos
            // 
            this.gridview_atendimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview_atendimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridview_atendimentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridview_atendimentos.Location = new System.Drawing.Point(3, 3);
            this.gridview_atendimentos.Name = "gridview_atendimentos";
            this.gridview_atendimentos.ReadOnly = true;
            this.gridview_atendimentos.RowTemplate.Height = 24;
            this.gridview_atendimentos.Size = new System.Drawing.Size(716, 342);
            this.gridview_atendimentos.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridview_pausas);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(722, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pausas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridview_pausas
            // 
            this.gridview_pausas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridview_pausas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview_pausas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridview_pausas.Location = new System.Drawing.Point(6, 6);
            this.gridview_pausas.Name = "gridview_pausas";
            this.gridview_pausas.ReadOnly = true;
            this.gridview_pausas.RowTemplate.Height = 24;
            this.gridview_pausas.Size = new System.Drawing.Size(684, 328);
            this.gridview_pausas.TabIndex = 0;
            // 
            // frmperformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 527);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmperformance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance Operador";
            this.Load += new System.EventHandler(this.frmperformance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview_atendimentos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview_pausas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltotalatendimentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbltma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbltotalpausa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbltempologado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridview_atendimentos;
        private System.Windows.Forms.DataGridView gridview_pausas;
    }
}