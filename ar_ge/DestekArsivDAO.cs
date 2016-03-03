using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    class DestekArsivDAO
    {
        public int createSablon(int programId, int kobiId, DateTime destekTarih, int projeSuresi)
        {
            byte sure = (byte)projeSuresi;
            String sql = "INSERT INTO DESTEK_SABLONU " +
                           "OUTPUT Inserted.DestekSablonId " +
                           "VALUES(@progID, @kobiId, @destekTarih, @sure)";
            int id = -1;

            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@progId", programId);
                    cmd.Parameters.AddWithValue("@kobiId", kobiId);
                    cmd.Parameters.AddWithValue("@destekTarih", destekTarih);
                    cmd.Parameters.AddWithValue("@sure", sure);

                    id = (int)cmd.ExecuteScalar();
                }
            }

            return id;
        }

        public void storeDestek(int sablonId, String destekTip, double tutar, bool? teknoIci)
        {
            String sql = "INSERT INTO DESTEK_ARSIV(DestekSablonId, Tutar, TeknoparkIci, DestekTipi) " +
                        "VALUES(@sablonId, @tutar, @teknoIci, @destekTip)";

            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sablonId", sablonId);
                    cmd.Parameters.AddWithValue("@tutar", tutar);
                    if (teknoIci == null)
                        cmd.Parameters.AddWithValue("@teknoIci", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@teknoIci", teknoIci.Value);
                    cmd.Parameters.AddWithValue("@destekTip", destekTip);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void storeDestek(int sablonId, String destekTip, double tutar)
        {
            storeDestek(sablonId, destekTip, tutar, null);
        }

        public void deleteDestekSablon(DestekSablon destekSablon)
        {
            int destekSablonId = destekSablon.destekSablonId;
            deleteDestekBirim("DESTEK_BIRIM_ARSIV", destekSablonId);
            deleteDestekBirim("DESTEK_ARSIV", destekSablonId);
            deleteDestekBirim("DESTEK_SABLONU", destekSablonId);
        }

        public void deleteDestekBirim(String tablo,int sablonId)
        {
            
            String sql = "DELETE FROM" + " " + tablo + " " + "WHERE DestekSablonId = @sablonId";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sablonId", sablonId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /*
        public void storeDestekBirim(int progID, int kobiID, String destekTip, String etiket, Double tutar, DateTime destekTarih, String extra)
        {
            List<String> vars = new String[]
            {
                "@progId", "@kobiId", "@dTipId", "@tutar", "@tarih", "@extra", "@etiket"
            }.ToList();

            String sql = "INSERT INTO DESTEK_BIRIM_ARSIV(ProgramId, KobiId, DestekTipi, Tutar, DestekTarih, ExtraText, Etiket)" +
                            "VALUES(@progId, @kobiId, @dTipId, @tutar, @tarih, @extra, @etiket)";

            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(vars[0], progID);
                    cmd.Parameters.AddWithValue(vars[1], kobiID);
                    cmd.Parameters.AddWithValue(vars[2], destekTip);
                    cmd.Parameters.AddWithValue(vars[3], tutar);
                    cmd.Parameters.AddWithValue(vars[4], destekTarih);
                    cmd.Parameters.AddWithValue(vars[5], extra);
                    cmd.Parameters.AddWithValue(vars[6], etiket);

                    cmd.ExecuteNonQuery();
                }
            }
        }*/

        public void storeDestekBirim(int sablonId, String destekTipi, String etiket, double tutar, String extraText)
        {
            String sql = "INSERT INTO DESTEK_BIRIM_ARSIV(DestekSablonId, DestekTipi, Etiket, Tutar, ExtraText) " +
                            "VALUES(@sablonId, @destekTipi, @etiket, @tutar, @extra)";

            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sablonId", sablonId);
                    cmd.Parameters.AddWithValue("@destekTipi", destekTipi);
                    cmd.Parameters.AddWithValue("@etiket", etiket);
                    cmd.Parameters.AddWithValue("@tutar", tutar);
                    if(extraText == null)
                        cmd.Parameters.AddWithValue("@extra", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@extra", extraText);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void storeDestekBirim(int sablonId, String destekTipi, String etiket, double tutar)
        {
            storeDestekBirim(sablonId, destekTipi, etiket, tutar, null);
        }


        public List<DestekBirim> getDestekBirim(int sablonId, String destekTip)
        {
            String sql = "SELECT BirimId, Etiket, Tutar, ExtraText FROM DESTEK_BIRIM_ARSIV WHERE DestekSablonId = @sablonId AND DestekTipi = @dTip";
            List<DestekBirim> list = new List<DestekBirim>();

            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dTip", destekTip);
                    cmd.Parameters.AddWithValue("@sablonId", sablonId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DestekBirim obj = new DestekBirim();

                            obj.birimId = reader.GetInt32(0);
                            obj.etiket = reader.GetString(1);
                            obj.tutar = reader.GetDouble(2);
                            if (!reader.IsDBNull(3))
                            {
                                obj.extra = reader.GetString(3);
                            }
                            else obj.extra = "";
                            obj.sablonId = sablonId;
                            obj.destekTip = destekTip;
                            list.Add(obj);
                        }
                    }
                }
            }
            return list;
        }
            
        public DestekArsiv getDestek(int sablonId, String destekTipAdi)
        {
            DestekArsiv arsiv = null;

            String sql = "SELECT Tutar, TeknoparkIci FROM DESTEK_ARSIV WHERE DestekSablonId = @sablonId AND DestekTipi = @dTip";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@sablonId", sablonId));
                    cmd.Parameters.Add(new SqlParameter("@dTip", destekTipAdi));
                    /*cmd.Parameters.Add(new SqlParameter("@tarih", tarih));
                    cmd.Parameters.Add(new SqlParameter("@dTipId", destekTipAdi));*/
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            arsiv = new DestekArsiv();
                            /*arsiv.progAd = reader.GetString(0);
                            arsiv.kobiAd = reader.GetString(1);
                            arsiv.tutar = reader.GetDouble(2);
                            arsiv.projeSure = reader.GetByte(3);
                            arsiv.destekTarih = tarih;*/
                            arsiv.destekSablonId = sablonId;
                            arsiv.destekTip = destekTipAdi;
                            arsiv.tutar = reader.GetDouble(0);
                            SqlBoolean teknoIciSql = reader.GetSqlBoolean(1);
                            if (!teknoIciSql.IsNull)
                                arsiv.teknoIci = teknoIciSql.IsTrue;
                        }
                    }
                }
            }
            return arsiv;
        }

        public List<DestekSablon> getVersions(int progId, int kobiId)
        {
            String sql = "SELECT DestekSablonId, DestekTarih, ProjeSuresi FROM DESTEK_SABLONU WHERE ProgramId = @progId AND KobiId = @kobiId";
            List<DestekSablon> list = new List<DestekSablon>();
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@kobiId", kobiId));
                    cmd.Parameters.Add(new SqlParameter("@progId", progId));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DestekSablon sablon = new DestekSablon();
                            sablon.programId = progId;
                            sablon.kobiId = kobiId;
                            sablon.destekSablonId = reader.GetInt32(0);
                            sablon.destekTarih = reader.GetDateTime(1);
                            sablon.projeSuresi = reader.GetByte(2);
                            list.Add(sablon);
                        }
                    }
                }
            }
            return list;

        }
        
    }

    public class DestekBirim
    {
        public int birimId { get; set; }
        public int sablonId { get; set; }
        public String destekTip { get; set; }
        public Double tutar { get; set; }
        public String extra { get; set; }
        public String etiket { get; set; }
    }

    public class DestekSablon
    {
        public int destekSablonId { get; set; }
        public int programId { get; set; }
        public int kobiId { get; set; }
        public DateTime destekTarih { get; set; }
        public byte projeSuresi { get; set; }

        public override string ToString()
        {
            return destekTarih.ToString();
        }
    }

    public class DestekArsiv
    {
        public int destekSablonId { get; set; }
        public String destekTip { get; set; }
        public Double tutar { get; set; }
        public bool teknoIci { get; set; }
    }
}
