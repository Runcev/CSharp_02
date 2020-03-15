using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keneyz_02.Tools.Exeptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"Invalid email address: {email}")

        {
        }
    }
}
