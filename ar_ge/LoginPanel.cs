using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KobiDestek
{
    public partial class LoginPanel : Form
    {
        private UserDAO dao;

        private static readonly int USERNAME_MIN_LEN = 3;
        private static readonly int PASS_MIN_LEN = 8;
        private static readonly int USER_DEF_EXCEPTION_ERR_NUMBER = 50000;

        public LoginPanel()
        {
            InitializeComponent();
            dao = new UserDAO();
            this.Height = 200;
            this.Width = 240;
        }

        private DialogResult showErrorMessage(String msg)
        {
            return MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String errMsg = null;
            if ((errMsg = checkValuesRegister()) != null)
            {
                showErrorMessage(errMsg);
                return;
            }

            String username = tbxRegUname.Text;
            String pass = tbxRegPw.Text;
            String firmaAdi = tbxRegFname.Text;
            int bolge = cobxBolge.SelectedIndex + 1;
            String yetkiliAd = tbxYetkiliAd.Text;
            String yetkiliSoyad = tbxYetkiliSoyad.Text;
            String yetkiliUnvan = tbxYetkiliUnvan.Text;
            int yetkiliTel;
            String tel = String.Concat(tbxYetkiliTel1.Text, tbxYetkiliTel2.Text);
            Int32.TryParse(tel,out yetkiliTel);

            try
            {
                Console.WriteLine("Register..");
                dao.register(username, pass, firmaAdi, bolge, yetkiliAd, yetkiliSoyad, yetkiliUnvan, yetkiliTel);
            }
            catch (SqlException ex)
            {
#if DEBUG
                Console.WriteLine(ex.Number);
                Console.WriteLine(ex.ErrorCode);
                Console.WriteLine(ex.Message);
#endif
                String errMessage = null;
                if (ex.Number == USER_DEF_EXCEPTION_ERR_NUMBER)
                    errMessage = ex.Message;
                else errMessage = "Sunucu hatası.";

                showErrorMessage(errMessage);
                return;
            }

            onRegisterSuccess();
        }

        private String checkValuesRegister()
        {
            String errorMsg = null;

            if (tbxRegUname.Text.Length < USERNAME_MIN_LEN)
                errorMsg = String.Format("Kullanıcı adı en az {0} karakterden oluşmalıdır.", USERNAME_MIN_LEN);
            else if (tbxRegPw.Text.Length < PASS_MIN_LEN)
                errorMsg = String.Format("Parola en az {0} karakterden oluşmalıdır.", PASS_MIN_LEN);
            else if (!tbxRegPw.Text.Equals(tbxRegPwR.Text))
                errorMsg = "Girilen şifreler eşleşmiyor.";
            else if (tbxRegFname.Text.Equals(""))
                errorMsg = "Şirket ismi boş bırakılamaz.";
            else if (cobxBolge.SelectedIndex < 0)
                errorMsg = "Bölge seçilmelidir.";
            else if (tbxYetkiliAd.Text.Equals("") || tbxYetkiliSoyad.Text.Equals("") || (tbxYetkiliTel1.Text.Equals("") && tbxYetkiliTel2.Text.Equals("")) || tbxYetkiliUnvan.Text.Equals("")) 
                errorMsg = "Yetkili bilgileri boş bırakılamaz";

            return errorMsg;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String errMsg = null;
            if ((errMsg = checkValuesLogin()) != null)
            {
                showErrorMessage(errMsg);
                return;
            }

            String username = tbxLogUname.Text;
            String pass = tbxLogPw.Text;

            Credentials cr = null;
            try
            {
                cr = dao.logIn(username, pass);
            }
            catch(SqlException)
            { 
                showErrorMessage("Sunucu ile bağlantı kurulamadı.");
                return;
            }

            if(cr == null)
                showErrorMessage("Kullanıcı adı veya şifre hatalı.");
            else
            {
                Credentials.setCredentials(cr);
                MainApp app = new MainApp();
                this.Hide();
                app.FormClosed += new FormClosedEventHandler(this.onClose);
                app.Show();
            }
            
        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onRegisterSuccess()
        {
            MessageBox.Show("Kayıt işlemi başarılı. Artık giriş yapabilirsiniz.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tablessControl1.SelectedIndex = 0;
        }

        private String checkValuesLogin()
        {
            String errorMsg = null;
            if (tbxLogUname.Text.Equals(""))
                errorMsg = "Kullanıcı adı kısmı boş bırakılamaz.";
            else if (tbxLogPw.Text.Equals(""))
                errorMsg = "Şifre kısmı boş bırakılamaz.";
            return errorMsg;
        }

        private void linkLblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tablessControl1.SelectedIndex = 1;
            this.Text = "Kaydol";
            this.Height = 347;
            this.Width = 417;
        }

        private void linkLblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tablessControl1.SelectedIndex = 0;
            this.Text = "Giriş";
            this.Height = 200;
            this.Width = 240;
        }
    }
}
