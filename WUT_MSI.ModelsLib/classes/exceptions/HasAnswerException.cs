using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUT_MSI.ModelsLib.classes.exceptions
{
    public class HasAnswerException : Exception
    {
        public HasAnswerException():base("Znaleziono rozwiazanie")
        { }
    }
}
