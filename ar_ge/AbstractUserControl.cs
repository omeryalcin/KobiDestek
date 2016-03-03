using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KobiDestek
{
    public class AbstractUserControl : UserControl
    {
        protected virtual void initValues() { }

        protected bool initialized = false;
        public void initialize()
        {
            if (initialized)
                return;
#if DEBUG
            Console.WriteLine("Initializing...");
#endif
            initValues();
            initialized = true;
        }
    }
}
