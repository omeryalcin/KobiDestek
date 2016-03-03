using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KobiDestek
{
    
    public partial class MainApp : Form
    {

        argeDataClassDataContext db = new argeDataClassDataContext();

        private DestekProgramiDAO destekProgramiDao;

        //queryleri tutacak stringler
        string[] maksMiktarArgeStr = new string[17];
        double[] maksMiktarArgeArray = new double[17];

        string[] oranArgeStr = new string[17];
        double[] oranArgeArray = new double[17];


        public MainApp()
        {
            InitializeComponent();
            destekProgramiDao = new DestekProgramiDAO();

            DestekProgrami[] programlar = destekProgramiDao.getDestekProgramlari().ToArray();
            comboBox1.Items.AddRange(programlar);
            lblCred1.Text = Credentials.getCredentials().execName + " " + Credentials.getCredentials().execSName;
            lblCred2.Text = Credentials.getCredentials().sirketAdi;
        }

        private void Ar_Ge_Load(object sender, EventArgs e)
        { 
            
            Do_Query();
            dataGridViewGet();
            
        }

        private void Do_Query()
        {
            //queryler
            var maksMiktarArgeQuery = from x in db.Ar_Ges
                                      select x.maksMiktar;

            var oranArgeQuery = from x in db.Ar_Ges
                                select x.oran;                                 
                

            //array'e çevirme
            maksMiktarArgeStr = maksMiktarArgeQuery.ToArray();
            oranArgeStr = oranArgeQuery.ToArray();

            //array'i double yapma
            for (int i = 0; i < 17; i++)
            {
                maksMiktarArgeArray[i] = Convert.ToDouble(maksMiktarArgeStr[i]);
                oranArgeArray[i] = (Convert.ToDouble(oranArgeStr[i]) / 100);
            }
        }

        private void dataGridViewGet()
        {
            this.argeFuarTableAdapter.Fill(this.kosgebDataSet.argeFuar);
            this.argeMakineTableAdapter.Fill(this.kosgebDataSet.argeMakine);
            this.argePersonelTableAdapter.Fill(this.kosgebDataSet.argePersonel);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablessControl1.SelectedIndex = comboBox1.SelectedIndex +1;
            this.Text = comboBox1.Text.Trim();
        }



        private void button10_Click(object sender, EventArgs e)
        {
            //EndustriyelBilgi endüstriyel_bilgi_form = new EndustriyelBilgi();
            //endüstriyel_bilgi_form.Show();
        }

        private void tablessControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl) sender;
            AbstractUserControl control = tabControl.SelectedTab.Controls.OfType<AbstractUserControl>().FirstOrDefault();
            if(control != null)
                control.initialize();
        }

    }
    class TablessControl : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
