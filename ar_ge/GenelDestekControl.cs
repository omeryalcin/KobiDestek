using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KobiDestek
{
    public partial class GenelDestekControl : AbstractUserControl
    {
        private static readonly int GENEL_DESTEK = 3;

        public Destek yurtIciFuar { get; set; }
        public Destek yurtDisiGezi { get; set; }
        public Destek tanitim { get; set; }
        public Destek eslestirme { get; set; }
        public Destek istihdam { get; set; }
        public Destek danismanlik { get; set; }
        public Destek egitim { get; set; }
        public Destek enerjiVerimliligi { get; set; }
        public Destek tasarim { get; set; }
        public Destek belgelendirme { get; set; }
        public Destek sinaiHaklar { get; set; }
        public Destek lojistik { get; set; }
        public Destek gonulluUzmanlik { get; set; }
        public Destek bagimsizDenetim { get; set; }

        //alt birimler
        public int yurtIciFuarUluslararasi { get; set; }
        public int yurtIciFuarIEF { get; set; }

        public int yurtDisiGeziToplam { get; set; }
        public int yurtDisiGeziDiger { get; set; }

        public int tanitimKatalog { get; set; }
        public int tanitimReklam { get; set; }
        public int tanitimWebMobil { get; set; }

        public int eslestirmeDanismanlikTekil { get; set; }
        public int eslestirmeDanismanlikToplam { get; set; }
        public int eslestirmeOrganizasyonTekil { get; set; }
        public int eslestirmeOrganizasyonToplam { get; set; }
        public int eslestirmeSergi { get; set; }

        public int istihdamBirimLimit { get; set; }

        public int danismanlikBirimLimit { get; set; }

        public int egitimKonuTekil { get; set; }
        public int egitimKonuToplam { get; set; }

        public int enerjiOnGrup1 { get; set; }
        public int enerjiOnGrup2 { get; set; }
        public int enerjiDetayliGrup1 { get; set; }
        public int enerjiDetayliGrup2 { get; set; }
        public int enerjiDetayliGrup3 { get; set; }

        public int sinaiHaklarTPE { get; set; }
        public int sinaiHaklarYurtdisi { get; set; }

        public int belgelendirmeBirimLimit { get; set; }

        public int gonulluUzmanlikBirimLimit { get; set; }

        public int lojistikBirimLimit { get; set; }

        //data access object
        private DestekDAO dao;

        public GenelDestekControl()
        {
            InitializeComponent();
        }

        protected override void initValues()
        {
            dao = new DestekDAO();
            int bolge = Credentials.getCredentials().bolge;

            yurtIciFuar = dao.getDestek(GENEL_DESTEK, "YICIFR", bolge);
            yurtDisiGezi = dao.getDestek(GENEL_DESTEK, "YDISIG", bolge);
            tanitim = dao.getDestek(GENEL_DESTEK, "TNTDES", bolge);
            eslestirme = dao.getDestek(GENEL_DESTEK, "ESLDES", bolge);
            istihdam = dao.getDestek(GENEL_DESTEK, "NELALM", bolge);
            danismanlik = dao.getDestek(GENEL_DESTEK, "DANDES", bolge);
            egitim = dao.getDestek(GENEL_DESTEK, "EGTDST", bolge);
            enerjiVerimliligi = dao.getDestek(GENEL_DESTEK, "ENVERD", bolge);
            tasarim = dao.getDestek(GENEL_DESTEK, "TASDES", bolge);
            belgelendirme = dao.getDestek(GENEL_DESTEK, "BELDES", bolge);
            sinaiHaklar = dao.getDestek(GENEL_DESTEK, "SMHD", bolge);
            lojistik = dao.getDestek(GENEL_DESTEK, "LOJDES", bolge);
            gonulluUzmanlik = dao.getDestek(GENEL_DESTEK, "GUZDES", bolge);
            bagimsizDenetim = dao.getDestek(GENEL_DESTEK, "BDENDS", bolge);

            //alt birimler
            yurtIciFuarUluslararasi = dao.getDestekBirimLimit(yurtIciFuar.getDestekId(), "ULUSLARAR");
            yurtIciFuarIEF = dao.getDestekBirimLimit(yurtIciFuar.getDestekId(), "IEF");

            yurtDisiGeziToplam = dao.getDestekBirimLimit(yurtDisiGezi.getDestekId(), "TOPLAM");
            yurtDisiGeziDiger = dao.getDestekBirimLimit(yurtDisiGezi.getDestekId(), "DIGER");

            tanitimKatalog = dao.getDestekBirimLimit(tanitim.getDestekId(), "KATALOG");
            tanitimReklam = dao.getDestekBirimLimit(tanitim.getDestekId(), "REKLAM");
            tanitimWebMobil = dao.getDestekBirimLimit(tanitim.getDestekId(), "WEBMOBIL");

            eslestirmeDanismanlikTekil = dao.getDestekBirimLimit(eslestirme.getDestekId(), "DANTEKIL");
            eslestirmeDanismanlikToplam = dao.getDestekBirimLimit(eslestirme.getDestekId(), "DANTOP");
            eslestirmeOrganizasyonTekil = dao.getDestekBirimLimit(eslestirme.getDestekId(), "ORGTEKIL");
            eslestirmeOrganizasyonToplam = dao.getDestekBirimLimit(eslestirme.getDestekId(), "ORGTOP");
            eslestirmeSergi = dao.getDestekBirimLimit(eslestirme.getDestekId(), "SERGI");

            istihdamBirimLimit = dao.getDestekBirimLimit(istihdam.getDestekId());

            danismanlikBirimLimit = dao.getDestekBirimLimit(danismanlik.getDestekId());

            egitimKonuTekil = dao.getDestekBirimLimit(egitim.getDestekId(), "KONUTEKIL");
            egitimKonuToplam = dao.getDestekBirimLimit(egitim.getDestekId(), "KONUTOP");

            enerjiOnGrup1 = dao.getDestekBirimLimit(enerjiVerimliligi.getDestekId(), "ON50-200");
            enerjiOnGrup2 = dao.getDestekBirimLimit(enerjiVerimliligi.getDestekId(), "ON200+");
            enerjiDetayliGrup1 = dao.getDestekBirimLimit(enerjiVerimliligi.getDestekId(), "DET50-200");
            enerjiDetayliGrup2 = dao.getDestekBirimLimit(enerjiVerimliligi.getDestekId(), "DET201-500");
            enerjiDetayliGrup3 = dao.getDestekBirimLimit(enerjiVerimliligi.getDestekId(), "DET500+");

            sinaiHaklarTPE = dao.getDestekBirimLimit(sinaiHaklar.getDestekId(), "TPE");
            sinaiHaklarYurtdisi = dao.getDestekBirimLimit(sinaiHaklar.getDestekId(), "YURTDISI");

            belgelendirmeBirimLimit = dao.getDestekBirimLimit(belgelendirme.getDestekId());

            gonulluUzmanlikBirimLimit = dao.getDestekBirimLimit(gonulluUzmanlik.getDestekId());

            lojistikBirimLimit = dao.getDestekBirimLimit(lojistik.getDestekId());


#if DEBUG
            printValues();
#endif
        }
        //
        private double toplamYici = 0;
        private double toplamYdisi = 0;
        private double toplamTanitim = 0;
        private double toplamPersonel = 0;
        private double toplamEsles = 0;
        private double toplamNel = 0;
        private double toplamDan = 0;
        private double toplamEgt = 0;
        private double toplamEnv = 0;
        private double toplamTas = 0;
        private double toplamTest = 0;
        private double toplamBelge = 0;
        private double toplamSMHD = 0;
        private double toplamLogis = 0;
        private double toplamUzman = 0;
        private double toplamBden = 0;
        private double toplamGenel = 0;
        //
        private double destekMikYici = 0;
        private double destekMikYdisi = 0;
        private double destekMikTanitim = 0;
        private double destekMikPersonel = 0;
        private double destekMikEsles = 0;
        private double destekMikNel = 0;
        private double destekMikDan = 0;
        private double destekMikEgt = 0;
        private double destekMikEnv = 0;
        private double destekMikTas = 0;
        private double destekMikTest = 0;
        private double destekMikBelge = 0;
        private double destekMikSMHD = 0;
        private double destekMikLogis = 0;
        private double destekMikUzman = 0;
        private double destekMikBden = 0;
        private double destekMikGenel = 0;

        private bool loaded = false;
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

        private void updateLabels(Destek destek, Double top, Double amt, Label lblTotal, Label lblAmt, Button btnAdd)
        {
            lblTotal.Text = top.ToString("N2") + " TL";

            if (top < destek.getMaxDestek())
            {
                lblTotal.Text += ", Halen " + (destek.getMaxDestek() - top).ToString("N2") + " TL limitiniz var.";
                lblAmt.Text = amt.ToString("N2") + " TL";
                btnAdd.Enabled = true;
            }
            else if (top > destek.getMaxDestek())
            {
                lblTotal.Text += ", Talep edilebilecek sınırı " + (top - destek.getMaxDestek()).ToString("N2") + " TL aştınız, lütfen bazı destekleri silin.";
                lblAmt.Text = destek.getMaxDestek().ToString("N2");
                btnAdd.Enabled = false;
            }
            else
            {
                lblAmt.Text = amt.ToString("N2") + " TL";
                btnAdd.Enabled = false;
            }
        }
        private Double cobxSelector(ComboBox cobx)
        {
            if ((String)cobx.SelectedItem == "")
                return yurtIciFuarUluslararasi;
            else if ((String)cobx.SelectedItem == "")
                return yurtIciFuarIEF;
            else if ((String)cobx.SelectedItem == "")
                return yurtDisiGeziToplam;
            else if ((String)cobx.SelectedItem == "")
                return yurtDisiGeziDiger;
            else if ((String)cobx.SelectedItem == "")
                return tanitimKatalog;
            else if ((String)cobx.SelectedItem == "")
                return tanitimReklam;
            else if ((String)cobx.SelectedItem == "")
                return tanitimWebMobil;
            else if ((String)cobx.SelectedItem == "")
                return eslestirmeDanismanlikTekil;
            else if ((String)cobx.SelectedItem == "")
                return eslestirmeDanismanlikToplam;
            else if ((String)cobx.SelectedItem == "")
                return eslestirmeOrganizasyonTekil;
            else if ((String)cobx.SelectedItem == "")
                return eslestirmeOrganizasyonToplam;
            else if ((String)cobx.SelectedItem == "")
                return eslestirmeSergi;
            else if ((String)cobx.SelectedItem == "")
                return istihdamBirimLimit;
            else if ((String)cobx.SelectedItem == "")
                return danismanlikBirimLimit;
            else if ((String)cobx.SelectedItem == "")
                return egitimKonuTekil;
            else if ((String)cobx.SelectedItem == "")
                return egitimKonuToplam;
            else if ((String)cobx.SelectedItem == "")
                return enerjiOnGrup1;
            else if ((String)cobx.SelectedItem == "")
                return enerjiOnGrup2;
            else if ((String)cobx.SelectedItem == "")
                return enerjiDetayliGrup1;
            else if ((String)cobx.SelectedItem == "")
                return enerjiDetayliGrup2;
            else if ((String)cobx.SelectedItem == "")
                return enerjiDetayliGrup3;
            else if ((String)cobx.SelectedItem == "")
                return sinaiHaklarTPE;
            else if ((String)cobx.SelectedItem == "")
                return sinaiHaklarYurtdisi;
            else if ((String)cobx.SelectedItem == "")
                return belgelendirmeBirimLimit;
            else if ((String)cobx.SelectedItem == "")
                return gonulluUzmanlikBirimLimit;
            else if ((String)cobx.SelectedItem == "")
                return lojistikBirimLimit;
            return 0;
        }

        private void sumAll()
        {
            toplamGenel = toplamYici + toplamYdisi + toplamTanitim + toplamPersonel + toplamEsles + toplamNel + toplamDan + toplamEgt + toplamEnv + toplamTas + toplamTest + toplamBelge + toplamSMHD + toplamLogis + toplamUzman + toplamBden;
            destekMikGenel = destekMikYici + destekMikYdisi + destekMikTanitim + destekMikPersonel + destekMikEsles + destekMikNel + destekMikDan + destekMikEgt + destekMikEnv + destekMikTas + destekMikTest + destekMikBelge + destekMikSMHD + destekMikLogis + destekMikUzman + destekMikBden;
            lblTotalTotal.Text = toplamGenel.ToString("N2") + " TL";
            lblTotalAmt.Text = destekMikGenel.ToString("N2") + " TL";
            lblTotalWarn.Text = "";
        }

#if DEBUG
        private void printValues()
        {
            Console.WriteLine(yurtIciFuar);
            Console.WriteLine(yurtDisiGezi);
            Console.WriteLine(tanitim);
            Console.WriteLine(eslestirme);
            Console.WriteLine(istihdam);
            Console.WriteLine(danismanlik);
            Console.WriteLine(egitim);
            Console.WriteLine(enerjiVerimliligi);
            Console.WriteLine(tasarim);
            Console.WriteLine(belgelendirme);
            Console.WriteLine(sinaiHaklar);
            Console.WriteLine(lojistik);
            Console.WriteLine(gonulluUzmanlik);
            Console.WriteLine(bagimsizDenetim);

            Console.WriteLine(yurtIciFuarUluslararasi);
            Console.WriteLine(yurtIciFuarIEF);

            Console.WriteLine(yurtDisiGeziToplam);
            Console.WriteLine(yurtDisiGeziDiger);

            Console.WriteLine(tanitimKatalog);
            Console.WriteLine(tanitimReklam);
            Console.WriteLine(tanitimWebMobil);

            Console.WriteLine(eslestirmeDanismanlikTekil);
            Console.WriteLine(eslestirmeDanismanlikToplam);
            Console.WriteLine(eslestirmeOrganizasyonTekil);
            Console.WriteLine(eslestirmeOrganizasyonToplam);
            Console.WriteLine(eslestirmeSergi);

            Console.WriteLine(istihdamBirimLimit);

            Console.WriteLine(danismanlikBirimLimit);

            Console.WriteLine(egitimKonuTekil);
            Console.WriteLine(egitimKonuToplam);

            Console.WriteLine(enerjiOnGrup1);
            Console.WriteLine(enerjiOnGrup2);
            Console.WriteLine(enerjiDetayliGrup1);
            Console.WriteLine(enerjiDetayliGrup2);
            Console.WriteLine(enerjiDetayliGrup3);

            Console.WriteLine(sinaiHaklarTPE);
            Console.WriteLine(sinaiHaklarYurtdisi);

            Console.WriteLine(belgelendirmeBirimLimit);

            Console.WriteLine(gonulluUzmanlikBirimLimit);

            Console.WriteLine(lojistikBirimLimit);
        }

        private void btnAddYici_Click(object sender, EventArgs e)
        {

        }
#endif
    }
}
