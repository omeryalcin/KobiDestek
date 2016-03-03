using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    class UserDAO
    {
        public void register(String username, String password, String firmaAdi, int bolge, String yetkiliAd, String yetkiliSoyad, String yetkiliUnvan, int yetkiliTel)
        {
            String sql = "Register";

            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@SirketAdi", firmaAdi);
                    cmd.Parameters.AddWithValue("@Bolge", bolge);
                    cmd.Parameters.AddWithValue("@ExecName", yetkiliAd);
                    cmd.Parameters.AddWithValue("@ExecSName", yetkiliSoyad);
                    cmd.Parameters.AddWithValue("@ExecTitle", yetkiliUnvan);
                    cmd.Parameters.AddWithValue("@ExecPhone", yetkiliTel);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Credentials logIn(String username, String password)
        {
            Credentials cr = null;

            String sql = "SELECT CAST(CASE WHEN Password = @pass THEN 1 ELSE 0 END AS BIT), KobiId, SirketAdi, Bolge, ExecName, ExecSName, ExecTitle, ExecPhone FROM KOBI WHERE Username = @uname;";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@pass", password));
                    cmd.Parameters.Add(new SqlParameter("@uname", username));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            bool success = false;
                            if ((success = reader.GetBoolean(0)))
                            {
                                cr = new Credentials();
                                cr.kobiId = reader.GetInt32(1);
                                cr.sirketAdi = reader.GetString(2);
                                cr.bolge = reader.GetByte(3);
                                cr.username = username;
                                cr.execName = reader.GetString(4);
                                cr.execSName = reader.GetString(5);
                                cr.execTitle = reader.GetString(6);
                                cr.execPhone = reader.GetInt32(7);
                            }
                        }
                    }
                }
            }
            return cr;
        }
    }
}
