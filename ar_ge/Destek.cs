using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    public interface Destek
    {
        double getDestekOrani();
        int getDestekLimit();
        int getDestekId();
        double getMaxDestek();
    }

    public class DestekAdapter : Destek
    {
        private const int DESTEK_ID_COL_NUM = 0;
        private const int DESTEK_LIMIT_COL_NUM = 3;
        private const int DESTEK_ORAN_COL_NUM = 4;
        private int destekId;
        private int destekLimit;
        private double destekOrani;

        public DestekAdapter(SqlDataReader reader)
        {
            destekId = reader.GetInt32(DESTEK_ID_COL_NUM);
            destekLimit = (int) reader.GetDouble(DESTEK_LIMIT_COL_NUM);
            destekOrani = reader.GetDouble(DESTEK_ORAN_COL_NUM);
        }

        public int getDestekId()
        {
            return destekId;
        }

        public int getDestekLimit()
        {
            return destekLimit;
        }

        public double getDestekOrani()
        {
            return destekOrani;
        }

        public double getMaxDestek()
        {
            return (double) destekLimit / destekOrani;
        }

        public override string ToString()
        {
            return "Üst limit: " + destekLimit + ", Oran: " + destekOrani;
        }
    }
}
