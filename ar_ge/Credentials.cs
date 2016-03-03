using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KobiDestek
{
    class Credentials
    {
        private static Credentials currentUser = null;
        
        public static Credentials getCredentials()
        {
            return currentUser;
        }

        public static void setCredentials(Credentials credentials)
        {
            currentUser = credentials;
        }
        public int kobiId { get; set; }
        public String sirketAdi { get; set; }
        public int bolge { get; set; }
        public String username { get; set; }
        public String execName { get; set; }
        public String execSName { get; set; }
        public String execTitle { get; set; }
        public int execPhone { get; set; }
    }
}
