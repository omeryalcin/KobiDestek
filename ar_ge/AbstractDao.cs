using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    class AbstractDAO
    {
        protected DBConnection connection;

        public AbstractDAO()
        {
            connection = DBConnection.getInstance();
            connection.openConnection();
        }
    }
}
