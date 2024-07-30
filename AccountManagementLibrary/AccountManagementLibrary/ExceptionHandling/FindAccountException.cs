using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementLibrary.ExceptionHandling
{
    internal class FindAccountException : Exception
    {
        public FindAccountException(string msg) : base(msg) 
        { }
    }
}
