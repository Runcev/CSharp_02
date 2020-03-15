using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keneyz_02.Tools.Exeptions
{
    class NotBornException : Exception
    {
        public NotBornException() : base("Person is not born yet")
        {
        }
    }
}
