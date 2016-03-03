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
    public partial class EndustriyelBilgi : Form
    {
        private EndustriControl parent;
        public EndustriyelBilgi(EndustriControl parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EndustriyelBilgi_Load(object sender, EventArgs e)
        {
            ustLimitKira.Text = parent.kira.getDestekLimit().ToString("N2");
            ustLimitMakine.Text = parent.hizmet.getDestekLimit().ToString("N2");
            ustLimitPersonel.Text = parent.personel.getDestekLimit().ToString("N2");
            ustLimitPersonelMeslek.Text = parent.personelMeslekLisesi.ToString("N2");
            ustLimitPersonelOnlisans.Text = parent.personelOnLisans.ToString("N2");
            ustLimitPersonelLisans.Text = parent.personelLisans.ToString("N2");
            ustLimitPersonelYuksekLisans.Text = parent.personelYuksekLisans.ToString("N2");
            ustLimitPersonelDoktora.Text = parent.personelDoktora.ToString("N2");

            oranKira.Text = parent.kira.getDestekOrani().ToString("N2");
            oranMakine.Text = parent.hizmet.getDestekOrani().ToString("N2");
            oranPersonel.Text = parent.personel.getDestekOrani().ToString("N2");

            maksMiktarKira.Text = parent.kira.getMaxDestek().ToString("N2");
            maksMiktarMakine.Text = parent.hizmet.getMaxDestek().ToString("N2");
            maksMiktarPersonel.Text = parent.personel.getMaxDestek().ToString("N2");
        }
    }
}
