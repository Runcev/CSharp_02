using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keneyz_02.Tools.Exeptions
{
    class TooOldException : Exception
    {
        public TooOldException() : base("Person can't be older than 135")
        {
        }
    }
}
