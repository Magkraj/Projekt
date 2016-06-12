using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class LockException :Exception
    {
        public override string Message => "Wizyta zablokowana!";
    }
}
