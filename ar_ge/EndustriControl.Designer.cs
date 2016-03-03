namespace KobiDestek
{
    partial class EndustriControl
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
            this.dgvHizmet = new System.Windows.Forms.DataGridView();
            this.Tipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TalepMiktari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHizmetAmt = new System.Windows.Forms.Label();
            this.lblInfoHizmet5 = new System.Windows.Forms.Label();
            this.tbxHizmetName = new System.Windows.Forms.TextBox();
            this.lblInfoHizmet2 = new System.Windows.Forms.Label();
            this.lblHizmetOneWarn = new System.Windows.Forms.Label();
            this.cobxHizmetType = new System.Windows.Forms.ComboBox();
            this.gbxHizmet = new System.Windows.Forms.GroupBox();
            this.lblHizmetWarn = new System.Windows.Forms.Label();
            this.lblHizmetTotal = new System.Windows.Forms.Label();
            this.lblInfoHizmet4 = new System.Windows.Forms.Label();
            this.lblInfoHizmet1 = new System.Windows.Forms.Label();
            this.btnHizmetDel = new System.Windows.Forms.Button();
            this.btnHizmetAdd = new System.Windows.Forms.Button();
            this.lblInfoHizmet3 = new System.Windows.Forms.Label();
            this.tbxHizmetDemand = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.personelFullTalep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelTalep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personelTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblKiraAmt = new System.Windows.Forms.Label();
            this.lblInfoKira3 = new System.Windows.Forms.Label();
            this.lblKiraWarn = new System.Windows.Forms.Label();
            this.lblInfoKira2 = new System.Windows.Forms.Label();
            this.tbxKiraDemand = new System.Windows.Forms.TextBox();
            this.btnLoadScheme = new System.Windows.Forms.Button();
            this.lblInfoKira1 = new System.Windows.Forms.Label();
            this.cobxArsiv = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxKira = new System.Windows.Forms.GroupBox();
            this.tbxTime = new System.Windows.Forms.TextBox();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.lblPersonelAmt = new System.Windows.Forms.Label();
            this.lblInfoPersonel5 = new System.Windows.Forms.Label();
            this.gbxPersonel = new System.Windows.Forms.GroupBox();
            this.lblPersonelOneWarn = new System.Windows.Forms.Label();
            this.cobxPersonelGrad = new System.Windows.Forms.ComboBox();
            this.lblPersonelWarn = new System.Windows.Forms.Label();
            this.lblPersonelTotal = new System.Windows.Forms.Label();
            this.lblInfoPersonel4 = new System.Windows.Forms.Label();
            this.lblInfoPersonel1 = new System.Windows.Forms.Label();
            this.btnPersonelDel = new System.Windows.Forms.Button();
            this.btnPersonelAdd = new System.Windows.Forms.Button();
            this.lblInfoPersonel3 = new System.Windows.Forms.Label();
            this.tbxPersonelDemand = new System.Windows.Forms.TextBox();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.lblInfoTotal2 = new System.Windows.Forms.Label();
            this.lblTotalWarn = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.lblInfoTotal1 = new System.Windows.Forms.Label();
            this.gbxTotal = new System.Windows.Forms.GroupBox();
            this.btnOranLimitBilgi = new System.Windows.Forms.Button();
            this.gbxScheme = new System.Windows.Forms.GroupBox();
            this.btnUpdateScheme = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteScheme = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHizmet)).BeginInit();
            this.gbxHizmet.SuspendLayout();
            this.gbxKira.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            this.gbxPersonel.SuspendLayout();
            this.gbxTotal.SuspendLayout();
            this.gbxScheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHizmet
            // 
            this.dgvHizmet.AllowUserToAddRows = false;
            this.dgvHizmet.AllowUserToDeleteRows = false;
            this.dgvHizmet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHizmet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tipi,
            this.Adi,
            this.TalepMiktari});
            this.dgvHizmet.Location = new System.Drawing.Point(6, 83);
            this.dgvHizmet.Name = "dgvHizmet";
            this.dgvHizmet.ReadOnly = true;
            this.dgvHizmet.Size = new System.Drawing.Size(568, 140);
            this.dgvHizmet.TabIndex = 12;
            // 
            // Tipi
            // 
            this.Tipi.HeaderText = "Tipi";
            this.Tipi.Name = "Tipi";
            this.Tipi.ReadOnly = true;
            // 
            // Adi
            // 
            this.Adi.HeaderText = "Adı";
            this.Adi.Name = "Adi";
            this.Adi.ReadOnly = true;
            // 
            // TalepMiktari
            // 
            this.TalepMiktari.HeaderText = "Talep Miktarı";
            this.TalepMiktari.Name = "TalepMiktari";
            this.TalepMiktari.ReadOnly = true;
            // 
            // lblHizmetAmt
            // 
            this.lblHizmetAmt.AutoSize = true;
            this.lblHizmetAmt.Location = new System.Drawing.Point(164, 251);
            this.lblHizmetAmt.Name = "lblHizmetAmt";
            this.lblHizmetAmt.Size = new System.Drawing.Size(29, 13);
            this.lblHizmetAmt.TabIndex = 44;
            this.lblHizmetAmt.Text = "0 TL";
            // 
            // lblInfoHizmet5
            // 
            this.lblInfoHizmet5.AutoSize = true;
            this.lblInfoHizmet5.Location = new System.Drawing.Point(6, 251);
            this.lblInfoHizmet5.Name = "lblInfoHizmet5";
            this.lblInfoHizmet5.Size = new System.Drawing.Size(148, 13);
            this.lblInfoHizmet5.TabIndex = 43;
            this.lblInfoHizmet5.Text = "Tahmini Hibe Bedeli (Toplam):";
            // 
            // tbxHizmetName
            // 
            this.tbxHizmetName.Location = new System.Drawing.Point(240, 27);
            this.tbxHizmetName.Name = "tbxHizmetName";
            this.tbxHizmetName.Size = new System.Drawing.Size(149, 20);
            this.tbxHizmetName.TabIndex = 33;
            // 
            // lblInfoHizmet2
            // 
            this.lblInfoHizmet2.AutoSize = true;
            this.lblInfoHizmet2.Location = new System.Drawing.Point(209, 30);
            this.lblInfoHizmet2.Name = "lblInfoHizmet2";
            this.lblInfoHizmet2.Size = new System.Drawing.Size(25, 13);
            this.lblInfoHizmet2.TabIndex = 32;
            this.lblInfoHizmet2.Text = "Adı:";
            // 
            // lblHizmetOneWarn
            // 
            this.lblHizmetOneWarn.AutoSize = true;
            this.lblHizmetOneWarn.Location = new System.Drawing.Point(62, 59);
            this.lblHizmetOneWarn.Name = "lblHizmetOneWarn";
            this.lblHizmetOneWarn.Size = new System.Drawing.Size(0, 13);
            this.lblHizmetOneWarn.TabIndex = 31;
            // 
            // cobxHizmetType
            // 
            this.cobxHizmetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxHizmetType.FormattingEnabled = true;
            this.cobxHizmetType.Items.AddRange(new object[] {
            "Makine-Teçhizat",
            "Donanım",
            "Hammadde",
            "Yazılım",
            "Hizmet"});
            this.cobxHizmetType.Location = new System.Drawing.Point(65, 27);
            this.cobxHizmetType.Name = "cobxHizmetType";
            this.cobxHizmetType.Size = new System.Drawing.Size(128, 21);
            this.cobxHizmetType.TabIndex = 30;
            // 
            // gbxHizmet
            // 
            this.gbxHizmet.Controls.Add(this.dgvHizmet);
            this.gbxHizmet.Controls.Add(this.lblHizmetAmt);
            this.gbxHizmet.Controls.Add(this.lblInfoHizmet5);
            this.gbxHizmet.Controls.Add(this.tbxHizmetName);
            this.gbxHizmet.Controls.Add(this.lblInfoHizmet2);
            this.gbxHizmet.Controls.Add(this.lblHizmetOneWarn);
            this.gbxHizmet.Controls.Add(this.cobxHizmetType);
            this.gbxHizmet.Controls.Add(this.lblHizmetWarn);
            this.gbxHizmet.Controls.Add(this.lblHizmetTotal);
            this.gbxHizmet.Controls.Add(this.lblInfoHizmet4);
            this.gbxHizmet.Controls.Add(this.lblInfoHizmet1);
            this.gbxHizmet.Controls.Add(this.btnHizmetDel);
            this.gbxHizmet.Controls.Add(this.btnHizmetAdd);
            this.gbxHizmet.Controls.Add(this.lblInfoHizmet3);
            this.gbxHizmet.Controls.Add(this.tbxHizmetDemand);
            this.gbxHizmet.Location = new System.Drawing.Point(1, 203);
            this.gbxHizmet.Name = "gbxHizmet";
            this.gbxHizmet.Size = new System.Drawing.Size(580, 282);
            this.gbxHizmet.TabIndex = 53;
            this.gbxHizmet.TabStop = false;
            this.gbxHizmet.Text = "Makine-Teçhizat, Donanım, Hammadde, Yazılım ve Hizmet Alımı Giderleri Desteği";
            // 
            // lblHizmetWarn
            // 
            this.lblHizmetWarn.AutoSize = true;
            this.lblHizmetWarn.Location = new System.Drawing.Point(237, 226);
            this.lblHizmetWarn.Name = "lblHizmetWarn";
            this.lblHizmetWarn.Size = new System.Drawing.Size(0, 13);
            this.lblHizmetWarn.TabIndex = 29;
            // 
            // lblHizmetTotal
            // 
            this.lblHizmetTotal.AutoSize = true;
            this.lblHizmetTotal.Location = new System.Drawing.Point(164, 226);
            this.lblHizmetTotal.Name = "lblHizmetTotal";
            this.lblHizmetTotal.Size = new System.Drawing.Size(29, 13);
            this.lblHizmetTotal.TabIndex = 28;
            this.lblHizmetTotal.Text = "0 TL";
            // 
            // lblInfoHizmet4
            // 
            this.lblInfoHizmet4.AutoSize = true;
            this.lblInfoHizmet4.Location = new System.Drawing.Point(6, 226);
            this.lblInfoHizmet4.Name = "lblInfoHizmet4";
            this.lblInfoHizmet4.Size = new System.Drawing.Size(160, 13);
            this.lblInfoHizmet4.TabIndex = 27;
            this.lblInfoHizmet4.Text = "Makine - Yazılım Genel Toplamı: ";
            // 
            // lblInfoHizmet1
            // 
            this.lblInfoHizmet1.AutoSize = true;
            this.lblInfoHizmet1.Location = new System.Drawing.Point(6, 30);
            this.lblInfoHizmet1.Name = "lblInfoHizmet1";
            this.lblInfoHizmet1.Size = new System.Drawing.Size(27, 13);
            this.lblInfoHizmet1.TabIndex = 26;
            this.lblInfoHizmet1.Text = "Tipi:";
            // 
            // btnHizmetDel
            // 
            this.btnHizmetDel.Location = new System.Drawing.Point(499, 54);
            this.btnHizmetDel.Name = "btnHizmetDel";
            this.btnHizmetDel.Size = new System.Drawing.Size(75, 23);
            this.btnHizmetDel.TabIndex = 24;
            this.btnHizmetDel.Text = "Sil";
            this.btnHizmetDel.UseVisualStyleBackColor = true;
            this.btnHizmetDel.Click += new System.EventHandler(this.btnHizmetDel_Click);
            // 
            // btnHizmetAdd
            // 
            this.btnHizmetAdd.Location = new System.Drawing.Point(418, 54);
            this.btnHizmetAdd.Name = "btnHizmetAdd";
            this.btnHizmetAdd.Size = new System.Drawing.Size(75, 23);
            this.btnHizmetAdd.TabIndex = 23;
            this.btnHizmetAdd.Text = "Ekle";
            this.btnHizmetAdd.UseVisualStyleBackColor = true;
            this.btnHizmetAdd.Click += new System.EventHandler(this.btnHizmetAdd_Click);
            // 
            // lblInfoHizmet3
            // 
            this.lblInfoHizmet3.AutoSize = true;
            this.lblInfoHizmet3.Location = new System.Drawing.Point(395, 30);
            this.lblInfoHizmet3.Name = "lblInfoHizmet3";
            this.lblInfoHizmet3.Size = new System.Drawing.Size(93, 13);
            this.lblInfoHizmet3.TabIndex = 22;
            this.lblInfoHizmet3.Text = "Talep Miktarı (TL):";
            // 
            // tbxHizmetDemand
            // 
            this.tbxHizmetDemand.Location = new System.Drawing.Point(494, 27);
            this.tbxHizmetDemand.Name = "tbxHizmetDemand";
            this.tbxHizmetDemand.Size = new System.Drawing.Size(80, 20);
            this.tbxHizmetDemand.TabIndex = 20;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1064, 82);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 32);
            this.btnReset.TabIndex = 65;
            this.btnReset.Text = "Ekranı Temizle";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // personelFullTalep
            // 
            this.personelFullTalep.HeaderText = "Proje Süresince Toplam Maliyet";
            this.personelFullTalep.Name = "personelFullTalep";
            this.personelFullTalep.ReadOnly = true;
            this.personelFullTalep.Width = 150;
            // 
            // personelTalep
            // 
            this.personelTalep.HeaderText = "Talep Miktarı";
            this.personelTalep.Name = "personelTalep";
            this.personelTalep.ReadOnly = true;
            // 
            // personelTip
            // 
            this.personelTip.HeaderText = "Tipi";
            this.personelTip.Name = "personelTip";
            this.personelTip.ReadOnly = true;
            // 
            // lblKiraAmt
            // 
            this.lblKiraAmt.AutoSize = true;
            this.lblKiraAmt.Location = new System.Drawing.Point(1012, 33);
            this.lblKiraAmt.Name = "lblKiraAmt";
            this.lblKiraAmt.Size = new System.Drawing.Size(29, 13);
            this.lblKiraAmt.TabIndex = 22;
            this.lblKiraAmt.Text = "0 TL";
            // 
            // lblInfoKira3
            // 
            this.lblInfoKira3.AutoSize = true;
            this.lblInfoKira3.Location = new System.Drawing.Point(1012, 16);
            this.lblInfoKira3.Name = "lblInfoKira3";
            this.lblInfoKira3.Size = new System.Drawing.Size(101, 13);
            this.lblInfoKira3.TabIndex = 21;
            this.lblInfoKira3.Text = "Tahmini Hibe Bedeli";
            // 
            // lblKiraWarn
            // 
            this.lblKiraWarn.AutoSize = true;
            this.lblKiraWarn.Location = new System.Drawing.Point(153, 52);
            this.lblKiraWarn.Name = "lblKiraWarn";
            this.lblKiraWarn.Size = new System.Drawing.Size(0, 13);
            this.lblKiraWarn.TabIndex = 20;
            // 
            // lblInfoKira2
            // 
            this.lblInfoKira2.AutoSize = true;
            this.lblInfoKira2.Location = new System.Drawing.Point(261, 29);
            this.lblInfoKira2.Name = "lblInfoKira2";
            this.lblInfoKira2.Size = new System.Drawing.Size(20, 13);
            this.lblInfoKira2.TabIndex = 15;
            this.lblInfoKira2.Text = "TL";
            // 
            // tbxKiraDemand
            // 
            this.tbxKiraDemand.Location = new System.Drawing.Point(155, 26);
            this.tbxKiraDemand.Name = "tbxKiraDemand";
            this.tbxKiraDemand.Size = new System.Drawing.Size(100, 20);
            this.tbxKiraDemand.TabIndex = 14;
            this.tbxKiraDemand.TextChanged += new System.EventHandler(this.tbxKiraDemand_TextChanged);
            // 
            // btnLoadScheme
            // 
            this.btnLoadScheme.Location = new System.Drawing.Point(117, 44);
            this.btnLoadScheme.Name = "btnLoadScheme";
            this.btnLoadScheme.Size = new System.Drawing.Size(102, 32);
            this.btnLoadScheme.TabIndex = 64;
            this.btnLoadScheme.Text = "Şablonu Yükle";
            this.btnLoadScheme.UseVisualStyleBackColor = true;
            this.btnLoadScheme.Click += new System.EventHandler(this.btnLoadScheme_Click);
            // 
            // lblInfoKira1
            // 
            this.lblInfoKira1.AutoSize = true;
            this.lblInfoKira1.Location = new System.Drawing.Point(6, 29);
            this.lblInfoKira1.Name = "lblInfoKira1";
            this.lblInfoKira1.Size = new System.Drawing.Size(122, 13);
            this.lblInfoKira1.TabIndex = 13;
            this.lblInfoKira1.Text = "Talep Edilen Kira Bedeli:";
            // 
            // cobxArsiv
            // 
            this.cobxArsiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxArsiv.FormattingEnabled = true;
            this.cobxArsiv.Location = new System.Drawing.Point(225, 17);
            this.cobxArsiv.Name = "cobxArsiv";
            this.cobxArsiv.Size = new System.Drawing.Size(209, 21);
            this.cobxArsiv.TabIndex = 62;
            this.cobxArsiv.SelectedIndexChanged += new System.EventHandler(this.cobxArsiv_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Şablonu Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbxKira
            // 
            this.gbxKira.Controls.Add(this.lblKiraAmt);
            this.gbxKira.Controls.Add(this.lblInfoKira3);
            this.gbxKira.Controls.Add(this.lblKiraWarn);
            this.gbxKira.Controls.Add(this.lblInfoKira2);
            this.gbxKira.Controls.Add(this.tbxKiraDemand);
            this.gbxKira.Controls.Add(this.lblInfoKira1);
            this.gbxKira.Location = new System.Drawing.Point(1, 117);
            this.gbxKira.Name = "gbxKira";
            this.gbxKira.Size = new System.Drawing.Size(1166, 80);
            this.gbxKira.TabIndex = 52;
            this.gbxKira.TabStop = false;
            this.gbxKira.Text = "Kira Desteği";
            // 
            // tbxTime
            // 
            this.tbxTime.Location = new System.Drawing.Point(93, 3);
            this.tbxTime.Name = "tbxTime";
            this.tbxTime.Size = new System.Drawing.Size(36, 20);
            this.tbxTime.TabIndex = 60;
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(0, 6);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(87, 13);
            this.lblInfo1.TabIndex = 59;
            this.lblInfo1.Text = "Proje Süresi (Ay):";
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.AllowUserToAddRows = false;
            this.dgvPersonel.AllowUserToDeleteRows = false;
            this.dgvPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personelTip,
            this.personelTalep,
            this.personelFullTalep});
            this.dgvPersonel.Location = new System.Drawing.Point(6, 83);
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.ReadOnly = true;
            this.dgvPersonel.Size = new System.Drawing.Size(568, 140);
            this.dgvPersonel.TabIndex = 12;
            // 
            // lblPersonelAmt
            // 
            this.lblPersonelAmt.AutoSize = true;
            this.lblPersonelAmt.Location = new System.Drawing.Point(173, 251);
            this.lblPersonelAmt.Name = "lblPersonelAmt";
            this.lblPersonelAmt.Size = new System.Drawing.Size(29, 13);
            this.lblPersonelAmt.TabIndex = 44;
            this.lblPersonelAmt.Text = "0 TL";
            // 
            // lblInfoPersonel5
            // 
            this.lblInfoPersonel5.AutoSize = true;
            this.lblInfoPersonel5.Location = new System.Drawing.Point(6, 251);
            this.lblInfoPersonel5.Name = "lblInfoPersonel5";
            this.lblInfoPersonel5.Size = new System.Drawing.Size(148, 13);
            this.lblInfoPersonel5.TabIndex = 43;
            this.lblInfoPersonel5.Text = "Tahmini Hibe Bedeli (Toplam):";
            // 
            // gbxPersonel
            // 
            this.gbxPersonel.Controls.Add(this.dgvPersonel);
            this.gbxPersonel.Controls.Add(this.lblPersonelAmt);
            this.gbxPersonel.Controls.Add(this.lblInfoPersonel5);
            this.gbxPersonel.Controls.Add(this.lblPersonelOneWarn);
            this.gbxPersonel.Controls.Add(this.cobxPersonelGrad);
            this.gbxPersonel.Controls.Add(this.lblPersonelWarn);
            this.gbxPersonel.Controls.Add(this.lblPersonelTotal);
            this.gbxPersonel.Controls.Add(this.lblInfoPersonel4);
            this.gbxPersonel.Controls.Add(this.lblInfoPersonel1);
            this.gbxPersonel.Controls.Add(this.btnPersonelDel);
            this.gbxPersonel.Controls.Add(this.btnPersonelAdd);
            this.gbxPersonel.Controls.Add(this.lblInfoPersonel3);
            this.gbxPersonel.Controls.Add(this.tbxPersonelDemand);
            this.gbxPersonel.Location = new System.Drawing.Point(587, 203);
            this.gbxPersonel.Name = "gbxPersonel";
            this.gbxPersonel.Size = new System.Drawing.Size(580, 282);
            this.gbxPersonel.TabIndex = 57;
            this.gbxPersonel.TabStop = false;
            this.gbxPersonel.Text = "Personel Giderleri Desteği";
            // 
            // lblPersonelOneWarn
            // 
            this.lblPersonelOneWarn.AutoSize = true;
            this.lblPersonelOneWarn.Location = new System.Drawing.Point(98, 59);
            this.lblPersonelOneWarn.Name = "lblPersonelOneWarn";
            this.lblPersonelOneWarn.Size = new System.Drawing.Size(0, 13);
            this.lblPersonelOneWarn.TabIndex = 31;
            // 
            // cobxPersonelGrad
            // 
            this.cobxPersonelGrad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxPersonelGrad.FormattingEnabled = true;
            this.cobxPersonelGrad.Items.AddRange(new object[] {
            "Meslek Lisesi",
            "Önlisans",
            "Lisans",
            "Yüksek Lisans",
            "Doktora"});
            this.cobxPersonelGrad.Location = new System.Drawing.Point(101, 27);
            this.cobxPersonelGrad.Name = "cobxPersonelGrad";
            this.cobxPersonelGrad.Size = new System.Drawing.Size(128, 21);
            this.cobxPersonelGrad.TabIndex = 30;
            this.cobxPersonelGrad.SelectedIndexChanged += new System.EventHandler(this.cobxPersonelGrad_SelectedIndexChanged);
            // 
            // lblPersonelWarn
            // 
            this.lblPersonelWarn.AutoSize = true;
            this.lblPersonelWarn.Location = new System.Drawing.Point(252, 226);
            this.lblPersonelWarn.Name = "lblPersonelWarn";
            this.lblPersonelWarn.Size = new System.Drawing.Size(0, 13);
            this.lblPersonelWarn.TabIndex = 29;
            // 
            // lblPersonelTotal
            // 
            this.lblPersonelTotal.AutoSize = true;
            this.lblPersonelTotal.Location = new System.Drawing.Point(173, 226);
            this.lblPersonelTotal.Name = "lblPersonelTotal";
            this.lblPersonelTotal.Size = new System.Drawing.Size(29, 13);
            this.lblPersonelTotal.TabIndex = 28;
            this.lblPersonelTotal.Text = "0 TL";
            // 
            // lblInfoPersonel4
            // 
            this.lblInfoPersonel4.AutoSize = true;
            this.lblInfoPersonel4.Location = new System.Drawing.Point(6, 226);
            this.lblInfoPersonel4.Name = "lblInfoPersonel4";
            this.lblInfoPersonel4.Size = new System.Drawing.Size(166, 13);
            this.lblInfoPersonel4.TabIndex = 27;
            this.lblInfoPersonel4.Text = "Personel Giderleri Genel Toplamı: ";
            // 
            // lblInfoPersonel1
            // 
            this.lblInfoPersonel1.AutoSize = true;
            this.lblInfoPersonel1.Location = new System.Drawing.Point(6, 30);
            this.lblInfoPersonel1.Name = "lblInfoPersonel1";
            this.lblInfoPersonel1.Size = new System.Drawing.Size(89, 13);
            this.lblInfoPersonel1.TabIndex = 26;
            this.lblInfoPersonel1.Text = "Öğrenim Durumu:";
            // 
            // btnPersonelDel
            // 
            this.btnPersonelDel.Location = new System.Drawing.Point(499, 54);
            this.btnPersonelDel.Name = "btnPersonelDel";
            this.btnPersonelDel.Size = new System.Drawing.Size(75, 23);
            this.btnPersonelDel.TabIndex = 24;
            this.btnPersonelDel.Text = "Sil";
            this.btnPersonelDel.UseVisualStyleBackColor = true;
            this.btnPersonelDel.Click += new System.EventHandler(this.btnPersonelDel_Click);
            // 
            // btnPersonelAdd
            // 
            this.btnPersonelAdd.Location = new System.Drawing.Point(418, 54);
            this.btnPersonelAdd.Name = "btnPersonelAdd";
            this.btnPersonelAdd.Size = new System.Drawing.Size(75, 23);
            this.btnPersonelAdd.TabIndex = 23;
            this.btnPersonelAdd.Text = "Ekle";
            this.btnPersonelAdd.UseVisualStyleBackColor = true;
            this.btnPersonelAdd.Click += new System.EventHandler(this.btnPersonelAdd_Click);
            // 
            // lblInfoPersonel3
            // 
            this.lblInfoPersonel3.AutoSize = true;
            this.lblInfoPersonel3.Location = new System.Drawing.Point(370, 30);
            this.lblInfoPersonel3.Name = "lblInfoPersonel3";
            this.lblInfoPersonel3.Size = new System.Drawing.Size(118, 13);
            this.lblInfoPersonel3.TabIndex = 22;
            this.lblInfoPersonel3.Text = "Aylık Talep Miktarı (TL):";
            // 
            // tbxPersonelDemand
            // 
            this.tbxPersonelDemand.Location = new System.Drawing.Point(494, 27);
            this.tbxPersonelDemand.Name = "tbxPersonelDemand";
            this.tbxPersonelDemand.Size = new System.Drawing.Size(80, 20);
            this.tbxPersonelDemand.TabIndex = 20;
            this.tbxPersonelDemand.TextChanged += new System.EventHandler(this.tbxPersonelDemand_TextChanged);
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.Location = new System.Drawing.Point(756, 31);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(29, 13);
            this.lblTotalAmt.TabIndex = 45;
            this.lblTotalAmt.Text = "0 TL";
            // 
            // lblInfoTotal2
            // 
            this.lblInfoTotal2.AutoSize = true;
            this.lblInfoTotal2.Location = new System.Drawing.Point(589, 31);
            this.lblInfoTotal2.Name = "lblInfoTotal2";
            this.lblInfoTotal2.Size = new System.Drawing.Size(142, 13);
            this.lblInfoTotal2.TabIndex = 44;
            this.lblInfoTotal2.Text = "Tahmini Toplam Hibe Bedeli:";
            // 
            // lblTotalWarn
            // 
            this.lblTotalWarn.AutoSize = true;
            this.lblTotalWarn.Location = new System.Drawing.Point(226, 61);
            this.lblTotalWarn.Name = "lblTotalWarn";
            this.lblTotalWarn.Size = new System.Drawing.Size(0, 13);
            this.lblTotalWarn.TabIndex = 43;
            // 
            // lblTotalTotal
            // 
            this.lblTotalTotal.AutoSize = true;
            this.lblTotalTotal.Location = new System.Drawing.Point(226, 31);
            this.lblTotalTotal.Name = "lblTotalTotal";
            this.lblTotalTotal.Size = new System.Drawing.Size(29, 13);
            this.lblTotalTotal.TabIndex = 42;
            this.lblTotalTotal.Text = "0 TL";
            // 
            // lblInfoTotal1
            // 
            this.lblInfoTotal1.AutoSize = true;
            this.lblInfoTotal1.Location = new System.Drawing.Point(3, 31);
            this.lblInfoTotal1.Name = "lblInfoTotal1";
            this.lblInfoTotal1.Size = new System.Drawing.Size(217, 13);
            this.lblInfoTotal1.TabIndex = 41;
            this.lblInfoTotal1.Text = "Projede Destek Talep Edilen Genel Toplam: ";
            // 
            // gbxTotal
            // 
            this.gbxTotal.Controls.Add(this.lblTotalAmt);
            this.gbxTotal.Controls.Add(this.lblInfoTotal2);
            this.gbxTotal.Controls.Add(this.lblTotalWarn);
            this.gbxTotal.Controls.Add(this.lblTotalTotal);
            this.gbxTotal.Controls.Add(this.lblInfoTotal1);
            this.gbxTotal.Location = new System.Drawing.Point(1, 491);
            this.gbxTotal.Name = "gbxTotal";
            this.gbxTotal.Size = new System.Drawing.Size(1166, 95);
            this.gbxTotal.TabIndex = 58;
            this.gbxTotal.TabStop = false;
            this.gbxTotal.Text = "Genel Toplam";
            // 
            // btnOranLimitBilgi
            // 
            this.btnOranLimitBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOranLimitBilgi.Location = new System.Drawing.Point(841, 3);
            this.btnOranLimitBilgi.Name = "btnOranLimitBilgi";
            this.btnOranLimitBilgi.Size = new System.Drawing.Size(325, 32);
            this.btnOranLimitBilgi.TabIndex = 56;
            this.btnOranLimitBilgi.Text = "Oranlar ve Limitler Hakkında Bilgi";
            this.btnOranLimitBilgi.UseVisualStyleBackColor = true;
            this.btnOranLimitBilgi.Click += new System.EventHandler(this.btnOranLimitBilgi_Click);
            // 
            // gbxScheme
            // 
            this.gbxScheme.Controls.Add(this.btnUpdateScheme);
            this.gbxScheme.Controls.Add(this.label2);
            this.gbxScheme.Controls.Add(this.btnDeleteScheme);
            this.gbxScheme.Controls.Add(this.btnSave);
            this.gbxScheme.Controls.Add(this.btnLoadScheme);
            this.gbxScheme.Controls.Add(this.cobxArsiv);
            this.gbxScheme.Location = new System.Drawing.Point(1, 29);
            this.gbxScheme.Name = "gbxScheme";
            this.gbxScheme.Size = new System.Drawing.Size(440, 85);
            this.gbxScheme.TabIndex = 68;
            this.gbxScheme.TabStop = false;
            this.gbxScheme.Text = "Şablon İşlemleri";
            // 
            // btnUpdateScheme
            // 
            this.btnUpdateScheme.Location = new System.Drawing.Point(225, 44);
            this.btnUpdateScheme.Name = "btnUpdateScheme";
            this.btnUpdateScheme.Size = new System.Drawing.Size(102, 32);
            this.btnUpdateScheme.TabIndex = 67;
            this.btnUpdateScheme.Text = "Şablonu Güncelle";
            this.btnUpdateScheme.UseVisualStyleBackColor = true;
            this.btnUpdateScheme.Click += new System.EventHandler(this.btnUpdateScheme_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Destek Şablonu Seçin:";
            // 
            // btnDeleteScheme
            // 
            this.btnDeleteScheme.Location = new System.Drawing.Point(333, 44);
            this.btnDeleteScheme.Name = "btnDeleteScheme";
            this.btnDeleteScheme.Size = new System.Drawing.Size(102, 32);
            this.btnDeleteScheme.TabIndex = 66;
            this.btnDeleteScheme.Text = "Şablonu Sil";
            this.btnDeleteScheme.UseVisualStyleBackColor = true;
            this.btnDeleteScheme.Click += new System.EventHandler(this.btnDeleteScheme_Click);
            // 
            // EndustriControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxScheme);
            this.Controls.Add(this.gbxHizmet);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gbxKira);
            this.Controls.Add(this.tbxTime);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.gbxPersonel);
            this.Controls.Add(this.gbxTotal);
            this.Controls.Add(this.btnOranLimitBilgi);
            this.Name = "EndustriControl";
            this.Size = new System.Drawing.Size(1169, 952);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHizmet)).EndInit();
            this.gbxHizmet.ResumeLayout(false);
            this.gbxHizmet.PerformLayout();
            this.gbxKira.ResumeLayout(false);
            this.gbxKira.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            this.gbxPersonel.ResumeLayout(false);
            this.gbxPersonel.PerformLayout();
            this.gbxTotal.ResumeLayout(false);
            this.gbxTotal.PerformLayout();
            this.gbxScheme.ResumeLayout(false);
            this.gbxScheme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHizmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TalepMiktari;
        private System.Windows.Forms.Label lblHizmetAmt;
        private System.Windows.Forms.Label lblInfoHizmet5;
        private System.Windows.Forms.TextBox tbxHizmetName;
        private System.Windows.Forms.Label lblInfoHizmet2;
        private System.Windows.Forms.Label lblHizmetOneWarn;
        private System.Windows.Forms.ComboBox cobxHizmetType;
        private System.Windows.Forms.GroupBox gbxHizmet;
        private System.Windows.Forms.Label lblHizmetWarn;
        private System.Windows.Forms.Label lblHizmetTotal;
        private System.Windows.Forms.Label lblInfoHizmet4;
        private System.Windows.Forms.Label lblInfoHizmet1;
        private System.Windows.Forms.Button btnHizmetDel;
        private System.Windows.Forms.Button btnHizmetAdd;
        private System.Windows.Forms.Label lblInfoHizmet3;
        private System.Windows.Forms.TextBox tbxHizmetDemand;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelFullTalep;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelTalep;
        private System.Windows.Forms.DataGridViewTextBoxColumn personelTip;
        private System.Windows.Forms.Label lblKiraAmt;
        private System.Windows.Forms.Label lblInfoKira3;
        private System.Windows.Forms.Label lblKiraWarn;
        private System.Windows.Forms.Label lblInfoKira2;
        private System.Windows.Forms.TextBox tbxKiraDemand;
        private System.Windows.Forms.Button btnLoadScheme;
        private System.Windows.Forms.Label lblInfoKira1;
        private System.Windows.Forms.ComboBox cobxArsiv;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbxKira;
        private System.Windows.Forms.TextBox tbxTime;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.DataGridView dgvPersonel;
        private System.Windows.Forms.Label lblPersonelAmt;
        private System.Windows.Forms.Label lblInfoPersonel5;
        private System.Windows.Forms.GroupBox gbxPersonel;
        private System.Windows.Forms.Label lblPersonelOneWarn;
        private System.Windows.Forms.ComboBox cobxPersonelGrad;
        private System.Windows.Forms.Label lblPersonelWarn;
        private System.Windows.Forms.Label lblPersonelTotal;
        private System.Windows.Forms.Label lblInfoPersonel4;
        private System.Windows.Forms.Label lblInfoPersonel1;
        private System.Windows.Forms.Button btnPersonelDel;
        private System.Windows.Forms.Button btnPersonelAdd;
        private System.Windows.Forms.Label lblInfoPersonel3;
        private System.Windows.Forms.TextBox tbxPersonelDemand;
        private System.Windows.Forms.Label lblTotalAmt;
        private System.Windows.Forms.Label lblInfoTotal2;
        private System.Windows.Forms.Label lblTotalWarn;
        private System.Windows.Forms.Label lblTotalTotal;
        private System.Windows.Forms.Label lblInfoTotal1;
        private System.Windows.Forms.GroupBox gbxTotal;
        private System.Windows.Forms.Button btnOranLimitBilgi;
        private System.Windows.Forms.GroupBox gbxScheme;
        private System.Windows.Forms.Button btnUpdateScheme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteScheme;
    }
}
