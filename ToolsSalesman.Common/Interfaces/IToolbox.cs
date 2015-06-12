using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSalesman.Common.Interfaces
{
    public interface IToolbox
    {
        IBinder BindingTool { get; set; }
        ICutter CuttingTool { get; set; }
        IHolder HoldingTool { get; set; }
        IImpactTool ImpactTool { get; set; }
        IMagnifier MagnifyingTool { get; set; }

        void UseAllTools();
    }
}
