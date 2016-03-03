using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    class DestekProgramiDAO
    {
        public List<DestekProgrami> getDestekProgramlari()
        {
            List<DestekProgrami> list = new List<DestekProgrami>();
            String sql = "SELECT * FROM DESTEK_PROGRAMI";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DestekProgrami prog = new DestekProgramiAdapter(reader);
                            list.Add(prog);
                        }
                    }
                }
            }
            return list;        
        }
        public DestekProgrami getDestekProgrami(int programId)
        {
            DestekProgrami prog = null;
            String sql = "SELECT * FROM DESTEK PROGRAMI WHERE DesktekProgramId = @id";
            using (SqlConnection conn = DBConnection.createConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", programId));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            prog = new DestekProgramiAdapter(reader);
                    }
                }
            }
            return prog;
        }
    }

    public interface DestekProgrami
    {
        int getDestekProgramId();
        string getDestekProgramAdi();
    }

    class DestekProgramiAdapter : DestekProgrami
    {
        private string destekProgramAdi;
        private int destekProgramId;
        public DestekProgramiAdapter(SqlDataReader reader)
        {
            destekProgramId = reader.GetInt32(0);
            destekProgramAdi = reader.GetString(1);
        }
        
        string DestekProgrami.getDestekProgramAdi()
        {
            return destekProgramAdi;
        }

        int DestekProgrami.getDestekProgramId()
        {
            return destekProgramId;
        }

        public override string ToString()
        {
            return destekProgramAdi;
        }
    }
}
