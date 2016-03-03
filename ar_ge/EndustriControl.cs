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
    public partial class EndustriControl : AbstractUserControl
    {
        private readonly int ENDUSTRI = 2;

        public Destek kira { get; set; }
        public Destek hizmet { get; set; }
        public Destek personel { get; set; }

        public int personelMeslekLisesi { get; set; }
        public int personelOnLisans { get; set; }
        public int personelLisans { get; set; }
        public int personelYuksekLisans { get; set; }
        public int personelDoktora { get; set; }

        private DestekDAO dao;
        private DestekArsivDAO arsivDao;
        public EndustriControl()
        {
            InitializeComponent();
        }

        protected override void initValues()
        {
            dao = new DestekDAO();
            arsivDao = new DestekArsivDAO();

            kira = dao.getDestek(ENDUSTRI, "KIRA");
            hizmet = dao.getDestek(ENDUSTRI, "HIZMET");
            personel = dao.getDestek(ENDUSTRI, "PERSON");

            personelMeslekLisesi = dao.getDestekBirimLimit(personel.getDestekId(), "MESLEKLIS");
            personelOnLisans = dao.getDestekBirimLimit(personel.getDestekId(), "ONLISANS");
            personelLisans = dao.getDestekBirimLimit(personel.getDestekId(), "LISANS");
            personelYuksekLisans = dao.getDestekBirimLimit(personel.getDestekId(), "YUKLISANS");
            personelDoktora = dao.getDestekBirimLimit(personel.getDestekId(), "DOKTORA");

            foreach (DestekSablon t in arsivDao.getVersions(ENDUSTRI, Credentials.getCredentials().kobiId))
                cobxArsiv.Items.Add(t);
        }
        //
        private double toplamKira = 0;
        private double toplamHizmet = 0;
        private double toplamPersonel = 0;
        private double toplamGenel = 0;
        //
        private double destekMikKira = 0;
        private double destekMikHizmet = 0;
        private double destekMikPersonel = 0;
        private double destekMikGenel = 0;

        public bool loaded = false;

        private void zero()
        {
            toplamKira = 0;
            toplamHizmet = 0;
            toplamPersonel = 0;
            toplamGenel = 0;
            destekMikKira = 0;
            destekMikHizmet = 0;
            destekMikPersonel = 0;
            destekMikGenel = 0;
        }

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

            projeSure = sablon.projeSuresi;
            tbxTime.Text = projeSure.ToString();

            List<DestekBirim> birimList;
            birimList = arsivDao.getDestekBirim(sablonId, "PERSON");
            foreach (DestekBirim birim in birimList)
                dgvPersonel.Rows.Add(new object[] { birim.etiket, birim.tutar, (birim.tutar * sablon.projeSuresi) });

            birimList = arsivDao.getDestekBirim(sablonId, "HIZMET");
            foreach (DestekBirim birim in birimList)
                dgvHizmet.Rows.Add(new object[] { birim.etiket, birim.extra, birim.tutar });

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
                if (demand > (limit / oran))
                {
                    lblWarn.Text = "Talep edilebilecek sınırı " + (demand - (limit / oran)).ToString("N2") + " TL aştınız, lütfen rakamı düşürün.";
                    sum = limit;
                    btn.Enabled = false;
                }
                else if (demand < limit / oran)
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
        //kira
        private void tbxKiraDemand_TextChanged(object sender, EventArgs e)
        {
            Double demand;
            Double.TryParse(tbxKiraDemand.Text, out demand);
            destekMikKira = calculateAmt(kira, demand, lblKiraWarn);
            toplamKira = demand;
            lblKiraAmt.Text = destekMikKira.ToString("N2") + " TL";
            sumAll();
        }
        //personel
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
                return personelOnLisans;
            else if ((String)cobxPersonelGrad.SelectedItem == "Lisans")
                return personelLisans;
            else if ((String)cobxPersonelGrad.SelectedItem == "Yüksek Lisans")
                return personelYuksekLisans;
            else if ((String)cobxPersonelGrad.SelectedItem == "Doktora")
                return personelDoktora;
            else if ((String)cobxPersonelGrad.SelectedItem == "Meslek Lisesi")
                return personelMeslekLisesi;
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
                dgvPersonel.Rows.Add(new object[] { tip, talepedilenbedel, topBedel });
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
                    toplamPersonel -= value;
                    destekMikPersonel -= value * personel.getDestekOrani();
                }
                updatePersonel(toplamPersonel);
                sumAll();
            }
            else
                MessageBox.Show("Lütfen seçim yapmak için satırın en solunu kullanınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        ////////hizmetler
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
        ///////////sum
        private void sumAll()
        {
            toplamGenel = toplamKira + toplamHizmet + toplamPersonel;
            destekMikGenel = destekMikKira + destekMikHizmet + destekMikPersonel;
            lblTotalTotal.Text = toplamGenel.ToString("N2") + " TL";
            lblTotalAmt.Text = destekMikGenel.ToString("N2") + " TL";
            lblTotalWarn.Text = "";
        }
        public void eraseAll()
        {
            tbxHizmetDemand.Text = "";
            tbxHizmetName.Text = "";
            tbxKiraDemand.Text = "";
            tbxPersonelDemand.Text = "";
            tbxTime.Text = "";

            cobxHizmetType.SelectedIndex = -1;
            cobxPersonelGrad.SelectedIndex = -1;

            dgvHizmet.Rows.Clear();
            dgvPersonel.Rows.Clear();
            zero();
            updateHizmetler(toplamHizmet);
            updatePersonel(toplamPersonel);
        }

        public void saveAll()
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
            int sablonId = arsivDao.createSablon(ENDUSTRI, kobiId, kayitTarihi, projeSure);
            try
            {
                arsivDao.storeDestek(sablonId, "KIRA", toplamKira);
                arsivDao.storeDestek(sablonId, "HIZMET", toplamHizmet);
                arsivDao.storeDestek(sablonId, "PERSON", toplamPersonel);

                foreach (DataGridViewRow row in dgvPersonel.Rows)
                    arsivDao.storeDestekBirim(sablonId, "PERSON", row.Cells[0].Value.ToString(), Double.Parse(row.Cells[1].Value.ToString()));
                foreach (DataGridViewRow row in dgvHizmet.Rows)
                    arsivDao.storeDestekBirim(sablonId, "HIZMET", row.Cells[0].Value.ToString(), Double.Parse(row.Cells[2].Value.ToString()), row.Cells[1].Value.ToString());

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
                    foreach (DestekSablon t in arsivDao.getVersions(ENDUSTRI, Credentials.getCredentials().kobiId))
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            eraseAll();
            loaded = false;
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

        private void btnDeleteScheme_Click(object sender, EventArgs e)
        {
            if (cobxArsiv.SelectedIndex >= 0)
            {
                arsivDao.deleteDestekSablon((DestekSablon)cobxArsiv.SelectedItem);
                cobxArsiv.Items.Clear();
                foreach (DestekSablon t in arsivDao.getVersions(ENDUSTRI, Credentials.getCredentials().kobiId))
                    cobxArsiv.Items.Add(t);
                MessageBox.Show("Şablon başarıyla silindi.", "Silme İşlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaded = false;
            }
            else
                MessageBox.Show("Lütfen bir şablon seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOranLimitBilgi_Click(object sender, EventArgs e)
        {
            new EndustriyelBilgi(this);
        }
    }
}
