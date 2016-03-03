using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KobiDestek
{
    public partial class ArGeControl : AbstractUserControl
    {
        private static readonly int AR_GE = 1;

        public Destek kiraTeknoIci { get; set; }
        public Destek kiraTeknoDisi { get; set; }
        public Destek hizmet { get; set; }
        public Destek baslangicSermayesi { get; set; }
        public Destek personel { get; set; }
        public Destek prjDanismalik { get; set; }
        public Destek prjEgitim { get; set; }
        public Destek prjTanitim { get; set; }
        public Destek prjTest { get; set; }
        public Destek prjSinai { get; set; }
        public Destek prjZiyaret { get; set; }
        public Destek prjToplam { get; set; }

        public int personelOnlisans { get; set; }
        public int personelLisans { get; set; }
        public int personelYuksekLisans { get; set; }
        public int personelDoktora { get; set; }

        public int ziyaretYurtici { get; set; }
        public int ziyaretYurtdisi { get; set; }

        private DestekDAO dao;
        private DestekArsivDAO arsivDao;

        public ArGeControl()
        {
            InitializeComponent();
        }

        protected override void initValues()
        {
            dao = new DestekDAO();
            arsivDao = new DestekArsivDAO();

            kiraTeknoIci = dao.getDestek(AR_GE, "KIRA", true);
            kiraTeknoDisi = dao.getDestek(AR_GE, "KIRA", false);
            hizmet = dao.getDestek(AR_GE, "HIZMET");
            baslangicSermayesi = dao.getDestek(AR_GE, "BSLSER");
            personel = dao.getDestek(AR_GE, "PERSON");
            prjDanismalik = dao.getDestek(AR_GE, "PRJDAN");
            prjEgitim = dao.getDestek(AR_GE, "EGTDES");
            prjTanitim = dao.getDestek(AR_GE, "PRJTNT");
            prjTest = dao.getDestek(AR_GE, "TESTAN");
            prjSinai = dao.getDestek(AR_GE, "SFMHD");
            prjZiyaret = dao.getDestek(AR_GE, "ZYRT");
            prjToplam = dao.getDestek(AR_GE, "PRJTOP");

            personelOnlisans = dao.getDestekBirimLimit(personel.getDestekId(), "ONLISANS");
            personelLisans = dao.getDestekBirimLimit(personel.getDestekId(), "LISANS");
            personelYuksekLisans = dao.getDestekBirimLimit(personel.getDestekId(), "YUKLISANS");
            personelDoktora = dao.getDestekBirimLimit(personel.getDestekId(), "DOKTORA");

            ziyaretYurtici = dao.getDestekBirimLimit(prjZiyaret.getDestekId(), "YURTICI");
            ziyaretYurtdisi = dao.getDestekBirimLimit(prjZiyaret.getDestekId(), "YURTDISI");

            foreach (DestekSablon t in arsivDao.getVersions(AR_GE, Credentials.getCredentials().kobiId))
                cobxArsiv.Items.Add(t);

#if DEBUG
            printValues();
#endif
        }
        //
        private double toplamKira = 0;
        private double toplamSermaye = 0;
        private double toplamHizmet = 0;
        private double toplamPersonel = 0;
        private double toplamZiyaret = 0;
        private double toplamDanismanlik = 0;
        private double toplamEgitim = 0;
        private double toplamTanitim = 0;
        private double toplamTest = 0;
        private double toplamSFMH = 0;
        private double toplamProje = 0;
        private double toplamGenel = 0;
        //
        private double destekMikKira = 0;
        private double destekMikSermaye = 0;
        private double destekMikHizmet = 0;
        private double destekMikPersonel = 0;
        private double destekMikZiyaret = 0;
        private double destekMikDanismanlik = 0;
        private double destekMikEgitim = 0;
        private double destekMikTanitim = 0;
        private double destekMikTest = 0;
        private double destekMikSFMH = 0;
        private double destekMikProje = 0;
        private double destekMikGenel = 0;

        private bool loaded = false;

        private void readScheme(DestekSablon sablon)
        {
            eraseAll();
            int projeSure;
            DestekArsiv arsiv = null;
            int kobiId = Credentials.getCredentials().kobiId;
            int sablonId = sablon.destekSablonId;

            arsiv = arsivDao.getDestek(sablonId, "KIRA");
            if (arsiv != null)
            {
                tbxKiraDemand.Text = arsiv.tutar.ToString("N2");
                cbxKiraTeknoIci.Checked = arsiv.teknoIci;
            }
            arsiv = arsivDao.getDestek(sablonId, "BSLSER");
            if (arsiv != null)
            {
                tbxBaslangicDemand.Text = arsiv.tutar.ToString("N2");
            }

            arsiv = arsivDao.getDestek(sablonId, "HIZMET");
            if (arsiv != null)
            {
                updateHizmetler(arsiv.tutar);
            }

            arsiv = arsivDao.getDestek(sablonId, "PERSON");
            if (arsiv != null)
            {
                updatePersonel(arsiv.tutar);
            }

            arsiv = arsivDao.getDestek(sablonId, "PRJDAN");
            if (arsiv != null)
            {
                tbxProjeDanDemand.Text = arsiv.tutar.ToString("N2");
            }

            arsiv = arsivDao.getDestek(sablonId, "EGTDES");
            if (arsiv != null)
            {
                tbxProjeEgtDemand.Text = arsiv.tutar.ToString("N2");
            }

            arsiv = arsivDao.getDestek(sablonId, "PRJTNT");
            if (arsiv != null)
            {
                tbxProjeTanDemand.Text = arsiv.tutar.ToString("N2");
            }

            arsiv = arsivDao.getDestek(sablonId, "TESTAN");
            if (arsiv != null)
            {
                tbxProjeTestDemand.Text = arsiv.tutar.ToString("N2");
            }

            arsiv = arsivDao.getDestek(sablonId, "SFMHD");
            if (arsiv != null)
            {
                tbxProjeSfmhDemand.Text = arsiv.tutar.ToString("N2");
            }

            arsiv = arsivDao.getDestek(sablonId, "ZYRT");
            if (arsiv != null)
            {
                updateZiyaret(arsiv.tutar);
            }

            projeSure = sablon.projeSuresi;
            tbxTime.Text = projeSure.ToString();


            List<DestekBirim> birimList;

            birimList = arsivDao.getDestekBirim(sablonId, "PERSON");
            foreach(DestekBirim birim in birimList)
                dgvPersonel.Rows.Add(new object[] { birim.etiket, birim.tutar ,(birim.tutar * sablon.projeSuresi)});

            birimList = arsivDao.getDestekBirim(sablonId, "HIZMET");
            foreach (DestekBirim birim in birimList)
                dgvHizmet.Rows.Add(new object[] { birim.etiket, birim.extra, birim.tutar });

            birimList = arsivDao.getDestekBirim(sablonId, "ZYRT");
            foreach (DestekBirim birim in birimList)
                dgvZiyaret.Rows.Add(new object[] { birim.etiket, birim.extra, birim.tutar});

        }

#if DEBUG
        private void printValues()
        {
            Console.WriteLine(kiraTeknoIci);
            Console.WriteLine(kiraTeknoDisi);
            Console.WriteLine(hizmet);
            Console.WriteLine(baslangicSermayesi);
            Console.WriteLine(personel);
            Console.WriteLine(prjDanismalik);
            Console.WriteLine(prjEgitim);
            Console.WriteLine(prjTanitim);
            Console.WriteLine(prjTest);
            Console.WriteLine(prjSinai);
            Console.WriteLine(prjZiyaret);
        }
#endif
        

        private void zero()
        {
            toplamKira = 0;
            toplamSermaye = 0;
            toplamHizmet = 0;
            toplamPersonel = 0;
            toplamZiyaret = 0;
            toplamDanismanlik = 0;
            toplamEgitim = 0;
            toplamTanitim = 0;
            toplamTest = 0;
            toplamSFMH = 0;
            toplamProje = 0;
            toplamGenel = 0;
            destekMikKira = 0;
            destekMikSermaye = 0;
            destekMikHizmet = 0;
            destekMikPersonel = 0;
            destekMikZiyaret = 0;
            destekMikDanismanlik = 0;
            destekMikEgitim = 0;
            destekMikTanitim = 0;
            destekMikTest = 0;
            destekMikSFMH = 0;
            destekMikProje = 0;
            destekMikGenel = 0;
        }

        // hesaplamalar ve checkbox kontrolü
        private double cbxChanger(CheckBox cbx, Destek destekTrue, Destek destekFalse, Double demand, Label lblWarn)
        {
            double sum;
            if (cbx.Checked)
            {
                sum = calculateAmt(destekTrue, demand, lblWarn);
            }
            else
            {
                sum = calculateAmt(destekFalse, demand, lblWarn);
            }
            return sum;
        }

        private double calculateAmt(Destek destek, Double demand, Label lblWarn)
        {
            double sum;
            if (demand != 0)
            {
                if (demand > destek.getMaxDestek())
                {
                    lblWarn.Text = "Talep edilebilecek sınırı " + (demand - destek.getMaxDestek()).ToString("N2") + " TL aştınız, lütfen rakamı düşürün.";
                    sum = destek.getDestekLimit();
                }
                else if (demand < destek.getMaxDestek())
                {
                    lblWarn.Text = "Halen " + (destek.getMaxDestek() - demand).ToString("N2") + " TL limitiniz var.";
                    sum = demand * destek.getDestekOrani();
                }
                else
                {
                    lblWarn.Text = "";
                    sum = demand * destek.getDestekOrani();
                }
            }
            else
            {
                sum = 0;
                lblWarn.Text = "";
            }
            return sum;
        }

        private double calculateAmt(Double limit, Double oran, Double demand, Label lblWarn, Button btn)
        {
            double sum;
            if (demand != 0)
            {
                if (demand > (limit/oran))
                {
                    lblWarn.Text = "Talep edilebilecek sınırı " + (demand - (limit / oran)).ToString("N2") + " TL aştınız, lütfen rakamı düşürün.";
                    sum = limit;
                    btn.Enabled = false;
                }
                else if (demand < limit/oran)
                {
                    lblWarn.Text = "Halen " + ((limit / oran) - demand).ToString("N2") + " TL limitiniz var.";
                    sum = demand * oran;
                    btn.Enabled = true;
                }
                else
                {
                    lblWarn.Text = "";
                    sum = demand * oran;
                    btn.Enabled = true;
                }
            }
            else
            {
                sum = 0;
                lblWarn.Text = "";
            }
            return sum;
        }

        private void sumAll()
        {
            toplamGenel = toplamKira + toplamSermaye + toplamHizmet + toplamPersonel + toplamProje;
            destekMikGenel = destekMikKira + destekMikSermaye + destekMikHizmet + destekMikPersonel + destekMikProje;
            lblTotalTotal.Text = toplamGenel.ToString("N2") + " TL";
            lblTotalAmt.Text = destekMikGenel.ToString("N2") + " TL";
            lblTotalWarn.Text = "";
        }

// hesaplama sonu
 
// destekler business logic

//kira desteği
        private void tbxKiraDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxKiraDemand.Text, out demand);
            destekMikKira =  cbxChanger(cbxKiraTeknoIci, kiraTeknoIci, kiraTeknoDisi, demand, lblKiraWarn);
            toplamKira = demand;
            lblKiraAmt.Text = destekMikKira.ToString("N2") + " TL";
            sumAll();
        }

        private void cbxKiraTeknoIci_CheckedChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxKiraDemand.Text, out demand);
            destekMikKira = cbxChanger(cbxKiraTeknoIci, kiraTeknoIci, kiraTeknoDisi, demand, lblKiraWarn);
            toplamKira = demand;
            lblKiraAmt.Text = destekMikKira.ToString("N2") + " TL";
            sumAll();
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//başlangıç sermayesi
        private void tbxBaslangicDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxBaslangicDemand.Text, out demand);
            destekMikSermaye = calculateAmt(baslangicSermayesi, demand, lblBaslangicWarn);
            toplamSermaye = demand;
            lblBaslangicAmt.Text = destekMikSermaye.ToString("N2") + " TL";
            sumAll();
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//hizmet, makine teçhizat
        private void updateHizmetler(Double top)
        {
            lblHizmetTotal.Text = top.ToString("N2") + " TL";

            if (top < hizmet.getMaxDestek())
            {
                lblHizmetTotal.Text += ", Halen " + (hizmet.getMaxDestek() - top).ToString("N2") + " TL limitiniz var.";
                lblHizmetAmt.Text = destekMikHizmet.ToString("N2") + " TL";
                btnHizmetAdd.Enabled = true;
            }
            else if (top > hizmet.getMaxDestek())
            {
                lblHizmetTotal.Text += ", Talep edilebilecek sınırı " + (top - hizmet.getMaxDestek()).ToString("N2") + " TL aştınız, lütfen bazı destekleri silin.";
                lblHizmetAmt.Text = hizmet.getMaxDestek().ToString("N2");
                btnHizmetAdd.Enabled = false;
            }
            else
            {
                lblHizmetAmt.Text = destekMikHizmet.ToString("N2") + " TL";
                btnHizmetAdd.Enabled = false;
            }
        }
        private void btnHizmetAdd_Click(object sender, EventArgs e)
        {
            if (!(cobxHizmetType.SelectedIndex < 0) && tbxHizmetDemand.Text != "" && tbxHizmetName.Text != "" && tbxTime.Text != "")
            {
                string tip = cobxHizmetType.SelectedItem.ToString();
                string adi = tbxHizmetName.Text;
                Byte projeTime;
                Byte.TryParse(tbxTime.Text, out projeTime);
                Double talepedilenbedel;
                Double.TryParse(tbxHizmetDemand.Text, out talepedilenbedel);
                dgvHizmet.Rows.Add(new object[] { tip, adi, talepedilenbedel });
                toplamHizmet += talepedilenbedel;
                destekMikHizmet += talepedilenbedel * hizmet.getDestekOrani();
                updateHizmetler(toplamHizmet);
                sumAll();
            }
            else
                MessageBox.Show("Lütfen proje süresi ve hizmet ile ilgili diğer alanları doldurduğunuzdan emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnHizmetDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvHizmet.SelectedRows;
            if (rows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    Double value = (Double)rows[i].Cells[2].Value;
                    dgvHizmet.Rows.Remove(rows[i]);
                    toplamHizmet -= value;
                    destekMikHizmet -= value * hizmet.getDestekOrani();
                }
                updateHizmetler(toplamHizmet);
                sumAll();
            }
            else
                MessageBox.Show("Lütfen seçim yapmak için satırın en solunu kullanınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Personel
        private void updatePersonel(Double top)
        {
            lblPersonelTotal.Text = top.ToString("N2") + " TL";

            if (top < personel.getMaxDestek())
            {
                lblPersonelTotal.Text += ", Halen " + (personel.getMaxDestek() - top).ToString("N2") + " TL limitiniz var.";
                lblPersonelAmt.Text = destekMikPersonel.ToString("N2") + " TL";
                btnPersonelAdd.Enabled = true;
            }
            else if (top > personel.getMaxDestek())
            {
                lblPersonelTotal.Text += ", Talep edilebilecek sınırı " + (top - personel.getMaxDestek()).ToString("N2") + " TL aştınız, lütfen bazı destekleri silin.";
                lblPersonelAmt.Text = personel.getMaxDestek().ToString("N2");
                btnPersonelAdd.Enabled = false;
            }
            else
            {
                lblPersonelAmt.Text = destekMikPersonel.ToString("N2") + " TL";
                btnPersonelAdd.Enabled = false;
            }
        }
        private Double personelSelector()
        {
            if ((String)cobxPersonelGrad.SelectedItem == "Önlisans")
                return personelOnlisans;
            else if ((String)cobxPersonelGrad.SelectedItem == "Lisans")
                return personelLisans;
            else if ((String)cobxPersonelGrad.SelectedItem == "Yüksek Lisans")
                return personelYuksekLisans;
            else if ((String)cobxPersonelGrad.SelectedItem == "Doktora")
                return personelDoktora;
            else return 0;
        }
        private void tbxPersonelDemand_TextChanged(object sender, EventArgs e)
        {
            Double limit = personelSelector();
            Double demand;
            Double.TryParse(tbxPersonelDemand.Text, out demand);
            calculateAmt(limit, personel.getDestekOrani(), demand, lblPersonelOneWarn, btnPersonelAdd);
        }
        private void cobxPersonelGrad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double limit = personelSelector();
            Double demand;
            Double.TryParse(tbxPersonelDemand.Text, out demand);
            calculateAmt(limit, personel.getDestekOrani(), demand, lblPersonelOneWarn, btnPersonelAdd);
        }
        private void btnPersonelAdd_Click(object sender, EventArgs e)
        {
            if (!(cobxPersonelGrad.SelectedIndex < 0) && tbxTime.Text != "" && tbxPersonelDemand.Text != "")
            {
                string tip = cobxPersonelGrad.SelectedItem.ToString();
                Byte projeTime;
                Byte.TryParse(tbxTime.Text, out projeTime);
                Double talepedilenbedel;
                Double.TryParse(tbxPersonelDemand.Text, out talepedilenbedel);
                Double topBedel = talepedilenbedel * projeTime;
                dgvPersonel.Rows.Add(new object[] { tip, talepedilenbedel, topBedel});
                toplamPersonel += talepedilenbedel * projeTime;
                destekMikPersonel += talepedilenbedel * personel.getDestekOrani() * projeTime;
                updatePersonel(toplamPersonel);
                sumAll();
            }
            else
                MessageBox.Show("Lütfen proje süresi ve personel ile ilgili diğer alanları doldurduğunuzdan emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPersonelDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvPersonel.SelectedRows;
            if (rows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    Double value = (Double)rows[i].Cells[2].Value;
                    dgvPersonel.Rows.Remove(rows[i]);
                    toplamPersonel -= value ;
                    destekMikPersonel -= value * personel.getDestekOrani();
                }
                updatePersonel(toplamPersonel);
                sumAll();
            }
            else
                MessageBox.Show("Lütfen seçim yapmak için satırın en solunu kullanınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//proje geliştirme
        private void tbxProjeDanDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxProjeDanDemand.Text, out demand);
            destekMikDanismanlik = calculateAmt(prjDanismalik, demand, lblProjeDanWarn);
            toplamDanismanlik = demand;
            projeTotal();
        }

        private void tbxProjeEgtDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxProjeEgtDemand.Text, out demand);
            destekMikEgitim = calculateAmt(prjEgitim, demand, lblProjeEgtWarn);
            toplamEgitim = demand;
            projeTotal();
        }

        private void tbxProjeTanDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxProjeTanDemand.Text, out demand);
            destekMikTanitim = calculateAmt(prjTanitim, demand, lblProjeTanWarn);
            toplamTanitim = demand;
            projeTotal();
        }

        private void tbxProjeTestDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxProjeTestDemand.Text, out demand);
            destekMikTest = calculateAmt(prjTest, demand, lblProjeTestWarn);
            toplamTest = demand;
            projeTotal();
        }

        private void tbxProjeSfmhDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxProjeSfmhDemand.Text, out demand);
            destekMikSFMH = calculateAmt(prjSinai, demand, lblProjeSfmhWarn);
            toplamSFMH = demand;
            projeTotal();
        }

        private void updateZiyaret(Double top)
        {
            lblProjeZiyaretTotal.Text = top.ToString("N2") + " TL";

            if (top < prjZiyaret.getMaxDestek())
            {
                lblProjeZiyaretTotal.Text += ", Halen " + (prjZiyaret.getMaxDestek() - top).ToString("N2") + " TL limitiniz var.";
                btnProjeZiyaretAdd.Enabled = true;
            }
            else if (top > prjZiyaret.getMaxDestek())
            {
                lblProjeZiyaretTotal.Text += ", Talep edilebilecek sınırı " + (top - prjZiyaret.getMaxDestek()).ToString("N2") + " TL aştınız, lütfen bazı destekleri silin.";
                btnProjeZiyaretAdd.Enabled = false;
            }
            else
            {
                btnProjeZiyaretAdd.Enabled = false;
            }
        }

        private void btnProjeZiyaretAdd_Click(object sender, EventArgs e)
        {
            if (!(cobxProjeZiyaretType.SelectedIndex < 0) && tbxProjeZiyaretDemand.Text != "" && tbxProjeZiyaretName.Text != "" && tbxTime.Text != "")
            {
                string tip = cobxProjeZiyaretType.SelectedItem.ToString();
                string adi = tbxProjeZiyaretName.Text;
                Byte projeTime;
                Byte.TryParse(tbxTime.Text, out projeTime);
                Double talepedilenbedel;
                Double.TryParse(tbxProjeZiyaretDemand.Text, out talepedilenbedel);
                dgvZiyaret.Rows.Add(new object[] { tip, adi, talepedilenbedel });
                toplamZiyaret += talepedilenbedel;
                destekMikZiyaret += talepedilenbedel * prjZiyaret.getDestekOrani();
                updateZiyaret(toplamZiyaret);
                projeTotal();
                sumAll();
            }
            else
                MessageBox.Show("Lütfen proje süresi ve ziyaret ile ilgili diğer alanları doldurduğunuzdan emin olunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnProjeZiyaretDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvZiyaret.SelectedRows;
            if (rows.Count > 0)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    Double value = (Double)rows[i].Cells[3].Value;
                    dgvHizmet.Rows.Remove(rows[i]);
                    toplamZiyaret -= value;
                    destekMikZiyaret -= value * prjZiyaret.getDestekOrani();
                }
                updateZiyaret(toplamZiyaret);
                projeTotal();
                sumAll();
            }
            else
                MessageBox.Show("Lütfen seçim yapmak için satırın en solunu kullanınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Double ziyaretSelector()
        {
            if (cbxProjeZiyaretYdisi.Checked)
                return ziyaretYurtdisi;
            else
                return ziyaretYurtici;

        }
        private void tbxProjeZiyaretDemand_TextChanged(object sender, EventArgs e)
        {
            Double limit = ziyaretSelector();
            Double demand;
            Double.TryParse(tbxProjeZiyaretDemand.Text, out demand);
            calculateAmt(limit, prjZiyaret.getDestekOrani(), demand, lblProjeZiyaretOneWarn, btnProjeZiyaretAdd);
        }

        private void cbxProjeZiyaretYdisi_CheckedChanged(object sender, EventArgs e)
        {
            Double limit = ziyaretSelector();
            Double demand;
            Double.TryParse(tbxProjeZiyaretDemand.Text, out demand);
            calculateAmt(limit, prjZiyaret.getDestekOrani(), demand, lblProjeZiyaretOneWarn, btnProjeZiyaretAdd);
        }


        private void projeTotal()
        {
            toplamProje = toplamDanismanlik + toplamEgitim + toplamTanitim + toplamTest + toplamSFMH + toplamZiyaret;
            destekMikProje = calculateAmt(prjToplam, toplamProje,lblTotalWarn);
            lblProjeAmt.Text = destekMikProje.ToString("N2");
            lblProjeTotal.Text = toplamProje.ToString("N2");
            sumAll();
        }

        private void btnOranLimitBilgi_Click(object sender, EventArgs e)
        {
            new ArGeBilgi(this).Show();
        }
        
        public void eraseAll()
        {
            tbxBaslangicDemand.Text = "";
            tbxHizmetDemand.Text = "";
            tbxHizmetName.Text = "";
            tbxKiraDemand.Text = "";
            tbxPersonelDemand.Text = "";
            tbxProjeDanDemand.Text = "";
            tbxProjeEgtDemand.Text = "";
            tbxProjeSfmhDemand.Text = "";
            tbxProjeTanDemand.Text = "";
            tbxProjeTestDemand.Text = "";
            tbxProjeZiyaretDemand.Text = "";
            tbxProjeZiyaretName.Text = "";
            tbxTime.Text = "";
            cbxKiraTeknoIci.Checked = false;
            cbxProjeZiyaretYdisi.Checked = false;

            cobxHizmetType.SelectedIndex = -1;
            cobxPersonelGrad.SelectedIndex = -1;
            cobxProjeZiyaretType.SelectedIndex = -1;

            dgvHizmet.Rows.Clear();
            dgvPersonel.Rows.Clear();
            dgvZiyaret.Rows.Clear();

            zero();

            updateHizmetler(toplamHizmet);
            updatePersonel(toplamPersonel);
            updateZiyaret(toplamZiyaret);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            eraseAll();
            loaded = false;
        }

        private void saveAll()
        {
            DateTime kayitTarihi = DateTime.Now;
            int kobiId = Credentials.getCredentials().kobiId;
            int projeSure;
            bool error = false;
            try
            {
                projeSure = Int32.Parse(tbxTime.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Proje süresi belirtmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int sablonId = arsivDao.createSablon(AR_GE, kobiId, kayitTarihi, projeSure);
            try
            {
                arsivDao.storeDestek(sablonId, "KIRA", toplamKira, cbxKiraTeknoIci.Checked);
                arsivDao.storeDestek(sablonId, "HIZMET", toplamHizmet);
                arsivDao.storeDestek(sablonId, "BSLSER", toplamSermaye);
                arsivDao.storeDestek(sablonId, "PERSON", toplamPersonel);

                arsivDao.storeDestek(sablonId, "PRJDAN", toplamDanismanlik);
                arsivDao.storeDestek(sablonId, "EGTDES", toplamEgitim);
                arsivDao.storeDestek(sablonId, "PRJTNT", toplamTanitim);
                arsivDao.storeDestek(sablonId, "TESTAN", toplamTest);
                arsivDao.storeDestek(sablonId, "SFMHD", toplamSFMH);
                arsivDao.storeDestek(sablonId, "ZYRT", toplamZiyaret);

                arsivDao.storeDestek(sablonId, "PRJTOP", toplamProje);

                foreach (DataGridViewRow row in dgvPersonel.Rows)
                    arsivDao.storeDestekBirim(sablonId, "PERSON", row.Cells[0].Value.ToString(), Double.Parse(row.Cells[1].Value.ToString()));
                foreach (DataGridViewRow row in dgvHizmet.Rows)
                    arsivDao.storeDestekBirim(sablonId, "HIZMET", row.Cells[0].Value.ToString(), Double.Parse(row.Cells[2].Value.ToString()), row.Cells[1].Value.ToString());
                foreach (DataGridViewRow row in dgvZiyaret.Rows)
                    arsivDao.storeDestekBirim(sablonId, "ZYRT", row.Cells[0].Value.ToString(), Double.Parse(row.Cells[2].Value.ToString()), row.Cells[1].Value.ToString());


                MessageBox.Show("Şablon başarıyla kaydedildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("hata:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                error = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                error = true;
            }
            finally
            {
                if (error)
                    MessageBox.Show("Beklenmeyen bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    cobxArsiv.Items.Clear();
                    foreach (DestekSablon t in arsivDao.getVersions(AR_GE, Credentials.getCredentials().kobiId))
                        cobxArsiv.Items.Add(t);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveAll();
            loaded = false;
        }

        private void cobxArsiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaded = false;
        }

        private void btnLoadScheme_Click(object sender, EventArgs e)
        {
            if (cobxArsiv.SelectedIndex >= 0)
            {
                readScheme((DestekSablon)cobxArsiv.SelectedItem);
                loaded = true;
            }
            else
                MessageBox.Show("Lütfen bir şablon seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDeleteScheme_Click(object sender, EventArgs e)
        {
            if (cobxArsiv.SelectedIndex >= 0)
            {
                arsivDao.deleteDestekSablon((DestekSablon)cobxArsiv.SelectedItem);
                cobxArsiv.Items.Clear();
                foreach (DestekSablon t in arsivDao.getVersions(AR_GE, Credentials.getCredentials().kobiId))
                    cobxArsiv.Items.Add(t);
                MessageBox.Show("Şablon başarıyla silindi.", "Silme İşlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaded = false;
            }
            else
                MessageBox.Show("Lütfen bir şablon seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnUpdateScheme_Click(object sender, EventArgs e)
        {
            if (cobxArsiv.SelectedIndex >= 0 && loaded)
            {
                arsivDao.deleteDestekSablon((DestekSablon)cobxArsiv.SelectedItem);
                saveAll();
            }
            else
                MessageBox.Show("Lütfen bir şablon yükleyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
