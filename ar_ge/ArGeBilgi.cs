using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KobiDestek
{
    public partial class ArGeBilgi : Form
    {
        private ArGeControl parent;
        public ArGeBilgi(ArGeControl parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ArgeBilgi_Load(object sender, EventArgs e)
        {


            //üst limitler
            ustLimitKiraTeknoİci.Text = parent.kiraTeknoIci.getDestekLimit().ToString("N2");
            ustLimitKiraTeknoDisi.Text = parent.kiraTeknoDisi.getDestekLimit().ToString("N2");
            ustLimitMakine.Text = parent.hizmet.getDestekLimit().ToString("N2");
            ustLimitPersonel.Text = parent.personel.getDestekLimit().ToString("N2");
            ustLimitPersonelOnlisans.Text = parent.personelOnlisans.ToString("N2");
            ustLimitPersonelLisans.Text = parent.personelLisans.ToString("N2");
            ustLimitPersonelYuksekLisans.Text = parent.personelYuksekLisans.ToString("N2");
            ustLimitPersonelDoktora.Text = parent.personelDoktora.ToString("N2");
            ustLimitBaslangic.Text = parent.baslangicSermayesi.getDestekLimit().ToString("N2");
            ustLimitDanismanlik.Text = parent.prjDanismalik.getDestekLimit().ToString("N2");
            ustLimitEgitim.Text = parent.prjEgitim.getDestekLimit().ToString("N2");
            ustLimitSinai.Text = parent.prjSinai.getDestekLimit().ToString("N2");
            ustLimitTanitim.Text = parent.prjTanitim.getDestekLimit().ToString("N2");
            ustLimitFuar.Text = parent.prjZiyaret.getDestekLimit().ToString("N2");
            ustLimitZiyaretYDisi.Text = parent.ziyaretYurtdisi.ToString("N2");
            ustLimitZiyaretYIci.Text = parent.ziyaretYurtici.ToString("N2");
            ustLimitTest.Text = parent.prjTest.getDestekLimit().ToString("N2");

            //oranlar
            oranKiraTeknoİci.Text = parent.kiraTeknoIci.getDestekOrani().ToString("N2");
            oranKiraTeknoDisi.Text = parent.kiraTeknoDisi.getDestekOrani().ToString("N2");
            oranMakine.Text = parent.hizmet.getDestekOrani().ToString("N2");
            oranPersonel.Text = parent.personel.getDestekOrani().ToString("N2");
            oranBaslangic.Text = parent.baslangicSermayesi.getDestekOrani().ToString("N2");
            oranDanismanlik.Text = parent.prjDanismalik.getDestekOrani().ToString("N2");
            oranEgitim.Text = parent.prjEgitim.getDestekOrani().ToString("N2");
            oranSinai.Text = parent.prjSinai.getDestekOrani().ToString("N2");
            oranTanitim.Text = parent.prjTanitim.getDestekOrani().ToString("N2");
            oranFuar.Text = parent.prjZiyaret.getDestekOrani().ToString("N2");
            oranTest.Text = parent.prjTest.getDestekOrani().ToString("N2");

            //maksimum destek miktarları            
            maksMiktarKiraTeknoİci.Text = parent.kiraTeknoIci.getMaxDestek().ToString("N2"); ;
            maksMiktarKiraTeknoDisi.Text = parent.kiraTeknoDisi.getMaxDestek().ToString("N2");
            maksMiktarMakine.Text = parent.hizmet.getMaxDestek().ToString("N2");
            maksMiktarPersonel.Text = parent.personel.getMaxDestek().ToString("N2");
            maksMiktarBaslangic.Text = parent.baslangicSermayesi.getMaxDestek().ToString("N2");
            maksMiktarDanismanlik.Text = parent.prjDanismalik.getMaxDestek().ToString("N2");
            maksMiktarEgitim.Text = parent.prjEgitim.getMaxDestek().ToString("N2");
            maksMiktarSinai.Text = parent.prjSinai.getMaxDestek().ToString("N2");
            maksMiktarTanitim.Text = parent.prjTanitim.getMaxDestek().ToString("N2");
            maksMiktarFuar.Text = parent.prjZiyaret.getMaxDestek().ToString("N2");
            maksMiktarTest.Text = parent.prjTest.getMaxDestek().ToString("N2");

        }
        private void textChanger(TextBox limit, TextBox oran, TextBox max)
        {
            if (limit.Text != "" && oran.Text != "")
            {
                max.Text = (Convert.ToDouble(limit.Text) / Convert.ToDouble(oran.Text) * 100).ToString("N2");
            }
            else max.Text = "";
        }

        private void ustLimitKiraTeknoİci_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitKiraTeknoİci, oranKiraTeknoİci, maksMiktarKiraTeknoİci);
        }

        private void oranKiraTeknoİci_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitKiraTeknoİci, oranKiraTeknoİci, maksMiktarKiraTeknoİci);
        }

        private void ustLimitKiraTeknoDisi_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitKiraTeknoDisi, oranKiraTeknoDisi, maksMiktarKiraTeknoDisi);
        }

        private void oranKiraTeknoDisi_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitKiraTeknoDisi, oranKiraTeknoDisi, maksMiktarKiraTeknoDisi);
        }

        private void ustLimitMakine_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitMakine, oranMakine, maksMiktarMakine);
        }

        private void oranMakine_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitMakine, oranMakine, maksMiktarMakine);
        }

        private void ustLimitPersonel_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitPersonel, oranPersonel, maksMiktarPersonel);
        }

        private void oranPersonel_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitPersonel, oranPersonel, maksMiktarPersonel);
        }

        private void ustLimitBaslangic_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitBaslangic, oranBaslangic, maksMiktarBaslangic);
        }

        private void oranBaslangic_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitBaslangic, oranBaslangic, maksMiktarBaslangic);
        }

        private void ustLimitDanismanlik_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitDanismanlik, oranDanismanlik, maksMiktarDanismanlik);
        }

        private void oranDanismanlik_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitDanismanlik, oranDanismanlik, maksMiktarDanismanlik);
        }

        private void ustLimitEgitim_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitEgitim, oranEgitim, maksMiktarEgitim);
        }

        private void oranEgitim_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitEgitim, oranEgitim, maksMiktarEgitim);
        }

        private void ustLimitSinai_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitSinai, oranSinai, maksMiktarSinai);
        }

        private void oranSinai_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitSinai, oranSinai, maksMiktarSinai);
        }

        private void ustLimitTanitim_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitTanitim, oranTanitim, maksMiktarTanitim);
        }

        private void oranTanitim_TextChanged(object sender, EventArgs e)
        {
            textChanger(ustLimitTanitim, oranTanitim, maksMiktarTanitim);
        }
        /*
        private void ustLimitFuar_TextChanged(object sender, EventArgs e)
        {
            if (ustLimitFuar.Text != "" && oranFuar.Text != "")
            {
                maksMiktarFuar.Text = (Convert.ToDouble(ustLimitFuar.Text) / Convert.ToDouble(oranFuar.Text) * 100).ToString("N2");
            }
        }

        private void oranFuar_TextChanged(object sender, EventArgs e)
        {
            if (ustLimitFuar.Text != "" && oranFuar.Text != "")
            {
                maksMiktarFuar.Text = (Convert.ToDouble(ustLimitFuar.Text) / Convert.ToDouble(oranFuar.Text) * 100).ToString("N2");
            }
        }
        */
        private void ustLimitTest_TextChanged(object sender, EventArgs e)
        {
            if (ustLimitTest.Text != "" && oranTest.Text != "")
            {
                maksMiktarTest.Text = (Convert.ToDouble(ustLimitTest.Text) / Convert.ToDouble(oranTest.Text) * 100).ToString("N2");
            }
        }

        private void oranTest_TextChanged(object sender, EventArgs e)
        {
            if (ustLimitTest.Text != "" && oranTest.Text != "")
            {
                maksMiktarTest.Text = (Convert.ToDouble(ustLimitTest.Text) / Convert.ToDouble(oranTest.Text) * 100).ToString("N2");
            }
        }

        private void ustLimitFuar_TextChanged(object sender, EventArgs e)
        {

        }

        private void oranFuar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
