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
    public partial class KobiControl : AbstractUserControl
    {
        private readonly int KOBI = 4;

        private Destek toplam;
        private Destek yazilim;
        private Destek hizmet;
        private Destek personel;
        private Destek makine;

        private DestekDAO dao;

        public KobiControl()
        {
            InitializeComponent();
        }

        protected override void initValues()
        {
            dao = new DestekDAO();

            int bolge = Credentials.getCredentials().bolge;

            toplam = dao.getDestek(KOBI, "KBTPLM", bolge);
            yazilim = dao.getDestek(KOBI, "KBYZLM", bolge);
            hizmet = dao.getDestek(KOBI, "KBHIZ", bolge);
            personel = dao.getDestek(KOBI, "KBPER", bolge);
            makine = dao.getDestek(KOBI, "KBMAK", bolge);

#if DEBUG
            printValues();
#endif
        }
#if DEBUG
        private void printValues()
        {
            Console.WriteLine(toplam);
            Console.WriteLine(yazilim);
            Console.WriteLine(hizmet);
            Console.WriteLine(personel);
            Console.WriteLine(makine);
        }

        private void tbxHizmetName_TextChanged(object sender, EventArgs e)
        {

        }
#endif
    }
}
