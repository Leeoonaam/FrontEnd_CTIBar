namespace lsOPCTIBar
{
    partial class frmtelefoniamanual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtelefoniamanual));
            this.label1 = new System.Windows.Forms.Label();
            this.lblcampanha = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdTransferir = new System.Windows.Forms.Button();
            this.cmdconsultar = new System.Windows.Forms.Button();
            this.cmbvdn = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdtransfQualidade = new System.Windows.Forms.Button();
            this.cmdOutraChamada = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmddiscar = new System.Windows.Forms.Button();
            this.txtnumero_discar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grp_linha1 = new System.Windows.Forms.GroupBox();
            this.cmddesliga_linha1 = new System.Windows.Forms.Button();
            this.cmdretorna_linha1 = new System.Windows.Forms.Button();
            this.cmdespera_linha1 = new System.Windows.Forms.Button();
            this.lblcallid_linha1 = new System.Windows.Forms.Label();
            this.lbltempo_linha1 = new System.Windows.Forms.Label();
            this.lblstatus_linha1 = new System.Windows.Forms.Label();
            this.img_linha1 = new System.Windows.Forms.PictureBox();
            this.lblnumero_linha1 = new System.Windows.Forms.Label();
            this.grp_linha2 = new System.Windows.Forms.GroupBox();
            this.lblcallid_linha2 = new System.Windows.Forms.Label();
            this.lbltempo_linha2 = new System.Windows.Forms.Label();
            this.cmddesliga_linha2 = new System.Windows.Forms.Button();
            this.cmdretorna_linha2 = new System.Windows.Forms.Button();
            this.cmdespera_linha2 = new System.Windows.Forms.Button();
            this.lblstatus_linha2 = new System.Windows.Forms.Label();
            this.img_linha2 = new System.Windows.Forms.PictureBox();
            this.lblnumero_linha2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grp_linha1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_linha1)).BeginInit();
            this.grp_linha2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_linha2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblcampanha
            // 
            this.lblcampanha.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcampanha.ForeColor = System.Drawing.Color.Navy;
            this.lblcampanha.Location = new System.Drawing.Point(75, 13);
            this.lblcampanha.Name = "lblcampanha";
            this.lblcampanha.Size = new System.Drawing.Size(493, 24);
            this.lblcampanha.TabIndex = 0;
            this.lblcampanha.Text = "[campanha]";
            this.lblcampanha.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmdTransferir);
            this.groupBox1.Controls.Add(this.cmdconsultar);
            this.groupBox1.Controls.Add(this.cmbvdn);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(19, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transferência";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selecione o Destino da Transferência:";
            // 
            // cmdTransferir
            // 
            this.cmdTransferir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTransferir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmdTransferir.Location = new System.Drawing.Point(475, 29);
            this.cmdTransferir.Name = "cmdTransferir";
            this.cmdTransferir.Size = new System.Drawing.Size(110, 46);
            this.cmdTransferir.TabIndex = 2;
            this.cmdTransferir.Text = "Transferir";
            this.cmdTransferir.UseVisualStyleBackColor = true;
            this.cmdTransferir.Click += new System.EventHandler(this.cmdTransferir_Click);
            // 
            // cmdconsultar
            // 
            this.cmdconsultar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdconsultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cmdconsultar.Location = new System.Drawing.Point(352, 29);
            this.cmdconsultar.Name = "cmdconsultar";
            this.cmdconsultar.Size = new System.Drawing.Size(110, 46);
            this.cmdconsultar.TabIndex = 1;
            this.cmdconsultar.Text = "Consultar";
            this.cmdconsultar.UseVisualStyleBackColor = true;
            this.cmdconsultar.Click += new System.EventHandler(this.cmdconsultar_Click);
            // 
            // cmbvdn
            // 
            this.cmbvdn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbvdn.ForeColor = System.Drawing.Color.Black;
            this.cmbvdn.FormattingEnabled = true;
            this.cmbvdn.Location = new System.Drawing.Point(14, 47);
            this.cmbvdn.Name = "cmbvdn";
            this.cmbvdn.Size = new System.Drawing.Size(324, 28);
            this.cmbvdn.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdtransfQualidade);
            this.groupBox2.Controls.Add(this.cmdOutraChamada);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(18, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outras Funções";
            // 
            // cmdtransfQualidade
            // 
            this.cmdtransfQualidade.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdtransfQualidade.Location = new System.Drawing.Point(303, 33);
            this.cmdtransfQualidade.Name = "cmdtransfQualidade";
            this.cmdtransfQualidade.Size = new System.Drawing.Size(276, 49);
            this.cmdtransfQualidade.TabIndex = 1;
            this.cmdtransfQualidade.Text = "Transferir p/ Qualidade";
            this.cmdtransfQualidade.UseVisualStyleBackColor = true;
            this.cmdtransfQualidade.Click += new System.EventHandler(this.cmdtransfQualidade_Click);
            // 
            // cmdOutraChamada
            // 
            this.cmdOutraChamada.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOutraChamada.Location = new System.Drawing.Point(29, 33);
            this.cmdOutraChamada.Name = "cmdOutraChamada";
            this.cmdOutraChamada.Size = new System.Drawing.Size(258, 49);
            this.cmdOutraChamada.TabIndex = 0;
            this.cmdOutraChamada.Text = "Alternar Chamada";
            this.cmdOutraChamada.UseVisualStyleBackColor = true;
            this.cmdOutraChamada.Click += new System.EventHandler(this.cmdOutraChamada_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmddiscar);
            this.groupBox3.Controls.Add(this.txtnumero_discar);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(19, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(599, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Discagem Manual";
            // 
            // cmddiscar
            // 
            this.cmddiscar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmddiscar.Location = new System.Drawing.Point(302, 34);
            this.cmddiscar.Name = "cmddiscar";
            this.cmddiscar.Size = new System.Drawing.Size(276, 45);
            this.cmddiscar.TabIndex = 1;
            this.cmddiscar.Text = "Discar";
            this.cmddiscar.UseVisualStyleBackColor = true;
            this.cmddiscar.Click += new System.EventHandler(this.cmddiscar_Click);
            // 
            // txtnumero_discar
            // 
            this.txtnumero_discar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnumero_discar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtnumero_discar.Location = new System.Drawing.Point(18, 53);
            this.txtnumero_discar.Name = "txtnumero_discar";
            this.txtnumero_discar.Size = new System.Drawing.Size(245, 26);
            this.txtnumero_discar.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Informe o Número a ser discado:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(630, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grp_linha1
            // 
            this.grp_linha1.Controls.Add(this.cmddesliga_linha1);
            this.grp_linha1.Controls.Add(this.cmdretorna_linha1);
            this.grp_linha1.Controls.Add(this.cmdespera_linha1);
            this.grp_linha1.Controls.Add(this.lblcallid_linha1);
            this.grp_linha1.Controls.Add(this.lbltempo_linha1);
            this.grp_linha1.Controls.Add(this.lblstatus_linha1);
            this.grp_linha1.Controls.Add(this.img_linha1);
            this.grp_linha1.Controls.Add(this.lblnumero_linha1);
            this.grp_linha1.Location = new System.Drawing.Point(19, 46);
            this.grp_linha1.Name = "grp_linha1";
            this.grp_linha1.Size = new System.Drawing.Size(296, 123);
            this.grp_linha1.TabIndex = 12;
            this.grp_linha1.TabStop = false;
            this.grp_linha1.Visible = false;
            // 
            // cmddesliga_linha1
            // 
            this.cmddesliga_linha1.Location = new System.Drawing.Point(200, 80);
            this.cmddesliga_linha1.Name = "cmddesliga_linha1";
            this.cmddesliga_linha1.Size = new System.Drawing.Size(86, 34);
            this.cmddesliga_linha1.TabIndex = 2;
            this.cmddesliga_linha1.Text = "DESLIGAR";
            this.cmddesliga_linha1.UseVisualStyleBackColor = true;
            this.cmddesliga_linha1.Click += new System.EventHandler(this.cmddesliga_linha1_Click);
            // 
            // cmdretorna_linha1
            // 
            this.cmdretorna_linha1.Location = new System.Drawing.Point(105, 80);
            this.cmdretorna_linha1.Name = "cmdretorna_linha1";
            this.cmdretorna_linha1.Size = new System.Drawing.Size(89, 34);
            this.cmdretorna_linha1.TabIndex = 1;
            this.cmdretorna_linha1.Text = "RETORNAR";
            this.cmdretorna_linha1.UseVisualStyleBackColor = true;
            this.cmdretorna_linha1.Click += new System.EventHandler(this.cmdretorna_linha1_Click);
            // 
            // cmdespera_linha1
            // 
            this.cmdespera_linha1.Location = new System.Drawing.Point(10, 80);
            this.cmdespera_linha1.Name = "cmdespera_linha1";
            this.cmdespera_linha1.Size = new System.Drawing.Size(86, 34);
            this.cmdespera_linha1.TabIndex = 0;
            this.cmdespera_linha1.Text = "ESPERA";
            this.cmdespera_linha1.UseVisualStyleBackColor = true;
            this.cmdespera_linha1.Click += new System.EventHandler(this.cmdespera_linha1_Click);
            // 
            // lblcallid_linha1
            // 
            this.lblcallid_linha1.AutoSize = true;
            this.lblcallid_linha1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcallid_linha1.ForeColor = System.Drawing.Color.Navy;
            this.lblcallid_linha1.Location = new System.Drawing.Point(211, 46);
            this.lblcallid_linha1.Name = "lblcallid_linha1";
            this.lblcallid_linha1.Size = new System.Drawing.Size(58, 20);
            this.lblcallid_linha1.TabIndex = 14;
            this.lblcallid_linha1.Text = "[callid]";
            this.lblcallid_linha1.Visible = false;
            // 
            // lbltempo_linha1
            // 
            this.lbltempo_linha1.AutoSize = true;
            this.lbltempo_linha1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltempo_linha1.ForeColor = System.Drawing.Color.Navy;
            this.lbltempo_linha1.Location = new System.Drawing.Point(211, 23);
            this.lbltempo_linha1.Name = "lbltempo_linha1";
            this.lbltempo_linha1.Size = new System.Drawing.Size(75, 20);
            this.lbltempo_linha1.TabIndex = 14;
            this.lbltempo_linha1.Text = "[00:00:00]";
            this.lbltempo_linha1.Visible = false;
            // 
            // lblstatus_linha1
            // 
            this.lblstatus_linha1.AutoSize = true;
            this.lblstatus_linha1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus_linha1.ForeColor = System.Drawing.Color.Navy;
            this.lblstatus_linha1.Location = new System.Drawing.Point(35, 19);
            this.lblstatus_linha1.Name = "lblstatus_linha1";
            this.lblstatus_linha1.Size = new System.Drawing.Size(60, 20);
            this.lblstatus_linha1.TabIndex = 14;
            this.lblstatus_linha1.Text = "[status]";
            this.lblstatus_linha1.Visible = false;
            // 
            // img_linha1
            // 
            this.img_linha1.Image = global::lsOPCTIBar.Properties.Resources.makecall;
            this.img_linha1.Location = new System.Drawing.Point(14, 23);
            this.img_linha1.Margin = new System.Windows.Forms.Padding(2);
            this.img_linha1.Name = "img_linha1";
            this.img_linha1.Size = new System.Drawing.Size(16, 16);
            this.img_linha1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_linha1.TabIndex = 13;
            this.img_linha1.TabStop = false;
            this.img_linha1.Visible = false;
            // 
            // lblnumero_linha1
            // 
            this.lblnumero_linha1.AutoSize = true;
            this.lblnumero_linha1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumero_linha1.ForeColor = System.Drawing.Color.Navy;
            this.lblnumero_linha1.Location = new System.Drawing.Point(38, 46);
            this.lblnumero_linha1.Name = "lblnumero_linha1";
            this.lblnumero_linha1.Size = new System.Drawing.Size(106, 18);
            this.lblnumero_linha1.TabIndex = 12;
            this.lblnumero_linha1.Text = "[00000000000]";
            this.lblnumero_linha1.Visible = false;
            // 
            // grp_linha2
            // 
            this.grp_linha2.Controls.Add(this.lblcallid_linha2);
            this.grp_linha2.Controls.Add(this.lbltempo_linha2);
            this.grp_linha2.Controls.Add(this.cmddesliga_linha2);
            this.grp_linha2.Controls.Add(this.cmdretorna_linha2);
            this.grp_linha2.Controls.Add(this.cmdespera_linha2);
            this.grp_linha2.Controls.Add(this.lblstatus_linha2);
            this.grp_linha2.Controls.Add(this.img_linha2);
            this.grp_linha2.Controls.Add(this.lblnumero_linha2);
            this.grp_linha2.Location = new System.Drawing.Point(321, 46);
            this.grp_linha2.Name = "grp_linha2";
            this.grp_linha2.Size = new System.Drawing.Size(296, 123);
            this.grp_linha2.TabIndex = 12;
            this.grp_linha2.TabStop = false;
            this.grp_linha2.Visible = false;
            // 
            // lblcallid_linha2
            // 
            this.lblcallid_linha2.AutoSize = true;
            this.lblcallid_linha2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcallid_linha2.ForeColor = System.Drawing.Color.Navy;
            this.lblcallid_linha2.Location = new System.Drawing.Point(208, 46);
            this.lblcallid_linha2.Name = "lblcallid_linha2";
            this.lblcallid_linha2.Size = new System.Drawing.Size(58, 20);
            this.lblcallid_linha2.TabIndex = 19;
            this.lblcallid_linha2.Text = "[callid]";
            this.lblcallid_linha2.Visible = false;
            // 
            // lbltempo_linha2
            // 
            this.lbltempo_linha2.AutoSize = true;
            this.lbltempo_linha2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltempo_linha2.ForeColor = System.Drawing.Color.Navy;
            this.lbltempo_linha2.Location = new System.Drawing.Point(208, 19);
            this.lbltempo_linha2.Name = "lbltempo_linha2";
            this.lbltempo_linha2.Size = new System.Drawing.Size(75, 20);
            this.lbltempo_linha2.TabIndex = 19;
            this.lbltempo_linha2.Text = "[00:00:00]";
            this.lbltempo_linha2.Visible = false;
            // 
            // cmddesliga_linha2
            // 
            this.cmddesliga_linha2.Location = new System.Drawing.Point(197, 80);
            this.cmddesliga_linha2.Name = "cmddesliga_linha2";
            this.cmddesliga_linha2.Size = new System.Drawing.Size(86, 34);
            this.cmddesliga_linha2.TabIndex = 2;
            this.cmddesliga_linha2.Text = "DESLIGAR";
            this.cmddesliga_linha2.UseVisualStyleBackColor = true;
            this.cmddesliga_linha2.Click += new System.EventHandler(this.cmddesliga_linha2_Click);
            // 
            // cmdretorna_linha2
            // 
            this.cmdretorna_linha2.Location = new System.Drawing.Point(103, 80);
            this.cmdretorna_linha2.Name = "cmdretorna_linha2";
            this.cmdretorna_linha2.Size = new System.Drawing.Size(88, 34);
            this.cmdretorna_linha2.TabIndex = 1;
            this.cmdretorna_linha2.Text = "RETORNAR";
            this.cmdretorna_linha2.UseVisualStyleBackColor = true;
            this.cmdretorna_linha2.Click += new System.EventHandler(this.cmdretorna_linha2_Click);
            // 
            // cmdespera_linha2
            // 
            this.cmdespera_linha2.Location = new System.Drawing.Point(11, 80);
            this.cmdespera_linha2.Name = "cmdespera_linha2";
            this.cmdespera_linha2.Size = new System.Drawing.Size(86, 34);
            this.cmdespera_linha2.TabIndex = 0;
            this.cmdespera_linha2.Text = "ESPERA";
            this.cmdespera_linha2.UseVisualStyleBackColor = true;
            this.cmdespera_linha2.Click += new System.EventHandler(this.cmdespera_linha2_Click);
            // 
            // lblstatus_linha2
            // 
            this.lblstatus_linha2.AutoSize = true;
            this.lblstatus_linha2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus_linha2.ForeColor = System.Drawing.Color.Navy;
            this.lblstatus_linha2.Location = new System.Drawing.Point(37, 19);
            this.lblstatus_linha2.Name = "lblstatus_linha2";
            this.lblstatus_linha2.Size = new System.Drawing.Size(60, 20);
            this.lblstatus_linha2.TabIndex = 14;
            this.lblstatus_linha2.Text = "[status]";
            this.lblstatus_linha2.Visible = false;
            // 
            // img_linha2
            // 
            this.img_linha2.Image = global::lsOPCTIBar.Properties.Resources.makecall;
            this.img_linha2.Location = new System.Drawing.Point(16, 23);
            this.img_linha2.Margin = new System.Windows.Forms.Padding(2);
            this.img_linha2.Name = "img_linha2";
            this.img_linha2.Size = new System.Drawing.Size(16, 16);
            this.img_linha2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_linha2.TabIndex = 13;
            this.img_linha2.TabStop = false;
            this.img_linha2.Visible = false;
            // 
            // lblnumero_linha2
            // 
            this.lblnumero_linha2.AutoSize = true;
            this.lblnumero_linha2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumero_linha2.ForeColor = System.Drawing.Color.Navy;
            this.lblnumero_linha2.Location = new System.Drawing.Point(40, 46);
            this.lblnumero_linha2.Name = "lblnumero_linha2";
            this.lblnumero_linha2.Size = new System.Drawing.Size(106, 18);
            this.lblnumero_linha2.TabIndex = 12;
            this.lblnumero_linha2.Text = "[00000000000]";
            this.lblnumero_linha2.Visible = false;
            // 
            // frmtelefoniamanual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 529);
            this.Controls.Add(this.grp_linha2);
            this.Controls.Add(this.grp_linha1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblcampanha);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmtelefoniamanual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telefonia Manual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmtelefoniamanual_FormClosing);
            this.Load += new System.EventHandler(this.frmtelefoniamanual_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grp_linha1.ResumeLayout(false);
            this.grp_linha1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_linha1)).EndInit();
            this.grp_linha2.ResumeLayout(false);
            this.grp_linha2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_linha2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblcampanha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdTransferir;
        private System.Windows.Forms.Button cmdconsultar;
        private System.Windows.Forms.ComboBox cmbvdn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdOutraChamada;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtnumero_discar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmddiscar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grp_linha1;
        private System.Windows.Forms.Label lblstatus_linha1;
        private System.Windows.Forms.PictureBox img_linha1;
        private System.Windows.Forms.Label lblnumero_linha1;
        private System.Windows.Forms.GroupBox grp_linha2;
        private System.Windows.Forms.Label lblstatus_linha2;
        private System.Windows.Forms.PictureBox img_linha2;
        private System.Windows.Forms.Label lblnumero_linha2;
        private System.Windows.Forms.Button cmdespera_linha1;
        private System.Windows.Forms.Button cmdespera_linha2;
        private System.Windows.Forms.Button cmddesliga_linha1;
        private System.Windows.Forms.Button cmdretorna_linha1;
        private System.Windows.Forms.Button cmdretorna_linha2;
        private System.Windows.Forms.Button cmddesliga_linha2;
        private System.Windows.Forms.Label lbltempo_linha1;
        private System.Windows.Forms.Label lbltempo_linha2;
        private System.Windows.Forms.Label lblcallid_linha1;
        private System.Windows.Forms.Label lblcallid_linha2;
        private System.Windows.Forms.Button cmdtransfQualidade;
        private System.Windows.Forms.Label label2;
    }
}