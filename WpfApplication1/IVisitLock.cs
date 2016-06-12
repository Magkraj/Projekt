using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    interface IVisitLock
    {
        bool Lock { get; }
        void LockVisit();
        void UnlockVisit();
    }
}
