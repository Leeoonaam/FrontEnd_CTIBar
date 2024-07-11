namespace lsOPCTIBar
{
    partial class frmchat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmchat));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Paga",
            "08/04/2021",
            "09/04/2021",
            "R$ 131.31"}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Vencida",
            "08/06/2021",
            "",
            "R$ 128.70",
            "03399.89857 39100.000445 00000.001010 1 86450000012870"}, "vermelho.jpg", System.Drawing.Color.Black, System.Drawing.Color.Empty, null);
            this.Venc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CodBarra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtdataliberacao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblstatuscarencia = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Pagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtmotivo = new System.Windows.Forms.TextBox();
            this.txtnomeplano = new System.Windows.Forms.TextBox();
            this.txtdatanascimento = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtplano = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcpf = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdcopiar = new System.Windows.Forms.Button();
            this.txtcodigobarra = new System.Windows.Forms.TextBox();
            this.lswfaturas = new System.Windows.Forms.ListView();
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtgrupo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttelefone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Venc
            // 
            this.Venc.Text = "Venc";
            this.Venc.Width = 111;
            // 
            // Valor
            // 
            this.Valor.Text = "Valor";
            this.Valor.Width = 149;
            // 
            // CodBarra
            // 
            this.CodBarra.Text = "Código Barra";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "verde.jpg");
            this.imageList1.Images.SetKeyName(1, "amarelo.jpg");
            this.imageList1.Images.SetKeyName(2, "vermelho.jpg");
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::lsOPCTIBar.Properties.Resources.iconfinder_Dollar_1737376__2_;
            this.pictureBox3.Location = new System.Drawing.Point(20, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label13.Location = new System.Drawing.Point(60, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(196, 23);
            this.label13.TabIndex = 4;
            this.label13.Text = "CONTAS DO CLIENTE";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtdataliberacao);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.lblstatuscarencia);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Location = new System.Drawing.Point(549, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(495, 139);
            this.panel4.TabIndex = 6;
            // 
            // txtdataliberacao
            // 
            this.txtdataliberacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtdataliberacao.Location = new System.Drawing.Point(275, 90);
            this.txtdataliberacao.Name = "txtdataliberacao";
            this.txtdataliberacao.Size = new System.Drawing.Size(199, 22);
            this.txtdataliberacao.TabIndex = 11;
            this.txtdataliberacao.Text = "00/00/0000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(271, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 17);
            this.label14.TabIndex = 10;
            this.label14.Text = "LIBERAÇÃO:";
            // 
            // lblstatuscarencia
            // 
            this.lblstatuscarencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblstatuscarencia.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatuscarencia.ForeColor = System.Drawing.Color.White;
            this.lblstatuscarencia.Location = new System.Drawing.Point(18, 67);
            this.lblstatuscarencia.Name = "lblstatuscarencia";
            this.lblstatuscarencia.Size = new System.Drawing.Size(238, 55);
            this.lblstatuscarencia.TabIndex = 9;
            this.lblstatuscarencia.Text = "FORA DA CARÊNCIA";
            this.lblstatuscarencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::lsOPCTIBar.Properties.Resources.iconfinder_Tilda_Icons_1ed_calendar_3586371;
            this.pictureBox4.Location = new System.Drawing.Point(22, 17);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label16.Location = new System.Drawing.Point(57, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(176, 23);
            this.label16.TabIndex = 4;
            this.label16.Text = "CARÊNCIA PLANO";
            // 
            // Pagamento
            // 
            this.Pagamento.Text = "Pagamento";
            this.Pagamento.Width = 113;
            // 
            // txtmotivo
            // 
            this.txtmotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtmotivo.Location = new System.Drawing.Point(221, 346);
            this.txtmotivo.Name = "txtmotivo";
            this.txtmotivo.Size = new System.Drawing.Size(256, 22);
            this.txtmotivo.TabIndex = 9;
            // 
            // txtnomeplano
            // 
            this.txtnomeplano.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtnomeplano.Location = new System.Drawing.Point(221, 281);
            this.txtnomeplano.Name = "txtnomeplano";
            this.txtnomeplano.Size = new System.Drawing.Size(256, 22);
            this.txtnomeplano.TabIndex = 9;
            this.txtnomeplano.Text = "PLUS ABX 1000";
            // 
            // txtdatanascimento
            // 
            this.txtdatanascimento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtdatanascimento.Location = new System.Drawing.Point(328, 149);
            this.txtdatanascimento.Name = "txtdatanascimento";
            this.txtdatanascimento.Size = new System.Drawing.Size(149, 22);
            this.txtdatanascimento.TabIndex = 9;
            this.txtdatanascimento.Text = "07/06/1984";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(217, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "MOTIVO:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(217, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "NOME PLANO:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "DATA NASCIMENTO:";
            // 
            // txtstatus
            // 
            this.txtstatus.BackColor = System.Drawing.Color.Green;
            this.txtstatus.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstatus.ForeColor = System.Drawing.Color.White;
            this.txtstatus.Location = new System.Drawing.Point(22, 346);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(160, 26);
            this.txtstatus.TabIndex = 7;
            this.txtstatus.Text = "ATIVO";
            this.txtstatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 323);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "STATUS PLANO:";
            // 
            // txtplano
            // 
            this.txtplano.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtplano.Location = new System.Drawing.Point(22, 281);
            this.txtplano.Name = "txtplano";
            this.txtplano.Size = new System.Drawing.Size(160, 22);
            this.txtplano.TabIndex = 7;
            this.txtplano.Text = "FAMILIAR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "PLANO:";
            // 
            // txtemail
            // 
            this.txtemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtemail.Location = new System.Drawing.Point(22, 214);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(455, 22);
            this.txtemail.TabIndex = 7;
            this.txtemail.Text = "SERGIO.LOURENCO@OPSOLUTIONS.COM.BR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "E-MAIL:";
            // 
            // txtcpf
            // 
            this.txtcpf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtcpf.Location = new System.Drawing.Point(22, 149);
            this.txtcpf.Name = "txtcpf";
            this.txtcpf.Size = new System.Drawing.Size(160, 22);
            this.txtcpf.TabIndex = 7;
            this.txtcpf.Text = "321.627.028-94";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "CPF:";
            // 
            // txtnome
            // 
            this.txtnome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtnome.Location = new System.Drawing.Point(22, 90);
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(455, 22);
            this.txtnome.TabIndex = 7;
            this.txtnome.Text = "TESTE TESTE TESTE";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(549, 447);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(495, 139);
            this.panel5.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(22, 59);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(455, 70);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Rua Prof Joao Machado, 705 - CEP : 08020040 - Bairro: Nossa Senhora do O - Cidade" +
    ": São Paulo - UF: SP";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::lsOPCTIBar.Properties.Resources.iconfinder_home_outline_216240__1_;
            this.pictureBox5.Location = new System.Drawing.Point(22, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label18.Location = new System.Drawing.Point(58, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 23);
            this.label18.TabIndex = 4;
            this.label18.Text = "ENDEREÇO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "NOME:";
            // 
            // cmdcopiar
            // 
            this.cmdcopiar.Image = global::lsOPCTIBar.Properties.Resources.iconfinder_multimedia_32_2849804;
            this.cmdcopiar.Location = new System.Drawing.Point(443, 202);
            this.cmdcopiar.Name = "cmdcopiar";
            this.cmdcopiar.Size = new System.Drawing.Size(34, 25);
            this.cmdcopiar.TabIndex = 12;
            this.cmdcopiar.UseVisualStyleBackColor = true;
            // 
            // txtcodigobarra
            // 
            this.txtcodigobarra.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigobarra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtcodigobarra.Location = new System.Drawing.Point(22, 202);
            this.txtcodigobarra.Name = "txtcodigobarra";
            this.txtcodigobarra.Size = new System.Drawing.Size(415, 26);
            this.txtcodigobarra.TabIndex = 11;
            this.txtcodigobarra.Text = "03399.89857 39100.000445 00000.001010 1 86450000012870";
            // 
            // lswfaturas
            // 
            this.lswfaturas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            this.Venc,
            this.Pagamento,
            this.Valor,
            this.CodBarra});
            this.lswfaturas.FullRowSelect = true;
            this.lswfaturas.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lswfaturas.Location = new System.Drawing.Point(19, 54);
            this.lswfaturas.Name = "lswfaturas";
            this.lswfaturas.Size = new System.Drawing.Size(455, 142);
            this.lswfaturas.SmallImageList = this.imageList1;
            this.lswfaturas.TabIndex = 10;
            this.lswfaturas.UseCompatibleStateImageBehavior = false;
            this.lswfaturas.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 91;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.cmdcopiar);
            this.panel3.Controls.Add(this.txtcodigobarra);
            this.panel3.Controls.Add(this.lswfaturas);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(549, 174);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 248);
            this.panel3.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::lsOPCTIBar.Properties.Resources.Untitled_7;
            this.pictureBox2.Location = new System.Drawing.Point(22, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label6.Location = new System.Drawing.Point(65, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "DADOS CADASTRAIS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtmotivo);
            this.panel2.Controls.Add(this.txtnomeplano);
            this.panel2.Controls.Add(this.txtdatanascimento);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtstatus);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtplano);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtemail);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtcpf);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtnome);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(28, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 412);
            this.panel2.TabIndex = 9;
            // 
            // txtgrupo
            // 
            this.txtgrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtgrupo.Location = new System.Drawing.Point(221, 90);
            this.txtgrupo.Name = "txtgrupo";
            this.txtgrupo.Size = new System.Drawing.Size(256, 22);
            this.txtgrupo.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "GRUPO:";
            // 
            // txttelefone
            // 
            this.txttelefone.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txttelefone.Location = new System.Drawing.Point(22, 90);
            this.txttelefone.Name = "txttelefone";
            this.txttelefone.Size = new System.Drawing.Size(183, 26);
            this.txttelefone.TabIndex = 7;
            this.txttelefone.Text = "11994961511";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "TELEFONE:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::lsOPCTIBar.Properties.Resources.Untitled_8;
            this.pictureBox1.Location = new System.Drawing.Point(22, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(60, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "DADOS DO ATENDIMENTO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtgrupo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txttelefone);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(28, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 139);
            this.panel1.TabIndex = 10;
            // 
            // frmchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 611);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmchat";
            this.Text = "frmchat";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtdataliberacao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblstatuscarencia;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtmotivo;
        private System.Windows.Forms.TextBox txtnomeplano;
        private System.Windows.Forms.TextBox txtdatanascimento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtstatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtplano;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtcpf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdcopiar;
        private System.Windows.Forms.TextBox txtcodigobarra;
        private System.Windows.Forms.ListView lswfaturas;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtgrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttelefone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader Pagamento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ColumnHeader CodBarra;
        private System.Windows.Forms.ColumnHeader Valor;
        private System.Windows.Forms.ColumnHeader Venc;
    }
}