using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    class DestekDAO
    {
        
        public Destek getDestek(int programId, String destekTipId, bool? teknoparkIci, int? bolge)
        {
            Destek destek = null;
            String sql = "SELECT * FROM DESTEKLER WHERE ProgramId = @progid AND DestekTipId = @tipid";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(null, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@progid", programId));
                    cmd.Parameters.Add(new SqlParameter("@tipid", destekTipId));
                    if (teknoparkIci != null)
                    {
                        sql += " AND TeknoparkIci = @teknoici";
                        cmd.Parameters.Add(new SqlParameter("@teknoici", teknoparkIci));
                    }
                    if (bolge != null)
                    {
                        sql += " AND Bolgeler LIKE  '%' + @bolge + '%'";
                        cmd.Parameters.Add(new SqlParameter("@bolge", bolge.ToString()));
                    }

                    cmd.CommandText = sql;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            destek = new DestekAdapter(reader);
                    }
                }
            }
            return destek;
        }

        public Destek getDestek(int programId, String destekTipId)
        {
            return getDestek(programId, destekTipId, null, null);
        }

        public Destek getDestek(int programId, String destekTipId, bool teknoParkIci)
        {
            return getDestek(programId, destekTipId, teknoParkIci, null);
        }

        public Destek getDestek(int programId, String destekTipId, int bolge)
        {
            return getDestek(programId, destekTipId, null, bolge);
        }

        public int getDestekBirimLimit(int destekId, String etiket)
        {
            int value = 0;
            if (etiket == null)
                etiket = "";

            String sql = "SELECT Deger FROM DESTEK_BIRIM WHERE DestekId = @destId AND Etiket = @etiket";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@destId", destekId));
                    cmd.Parameters.Add(new SqlParameter("@etiket", etiket));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            value = (int)reader.GetDouble(0);
                    }
                }
            }

            return value;
        }

        public int getDestekBirimLimit(int destekId)
        {
            return getDestekBirimLimit(destekId, null);
        }

    }
}
