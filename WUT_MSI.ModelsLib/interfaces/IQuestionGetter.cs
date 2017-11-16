using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.Models.interfaces;

namespace WUT_MSI.ModelsLib.interfaces
{
    public interface IQuestionGetter<Tparam>
    {
        bool HasQuestion { get; }
        IQuestion<Tparam> GetNextQuestion(List<Tparam> currentEvaluatingSet);
    }
}
