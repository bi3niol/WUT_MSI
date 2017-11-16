using System;
using System.Collections.Generic;
using System.Text;

namespace WUT_MSI.Models.interfaces
{
    public interface IQuestrion
    {
        string Question { get; }
        List<IAnswer> Answer { get; }
    }
}
