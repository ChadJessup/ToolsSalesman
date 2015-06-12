namespace ToolsSalesmanWithoutDI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ToolsSalesman.Common.Interfaces;

    public class Toolbox : IToolbox
    {
        public IBinder BindingTool { get; set; }
        public ICutter CuttingTool { get; set; }
        public IHolder HoldingTool { get; set; }
        public IImpactTool ImpactTool { get; set; }
        public IMagnifier MagnifyingTool { get; set; }

        public void UseAllTools()
        {
            Console.WriteLine((this.BindingTool as ITool).Name + ": " + (this.BindingTool as ITool).Use());
            Console.WriteLine((this.CuttingTool as ITool).Name + ": " + (this.CuttingTool as ITool).Use());
            Console.WriteLine((this.HoldingTool as ITool).Name + ": " + (this.HoldingTool as ITool).Use());
            Console.WriteLine((this.ImpactTool as ITool).Name + ": " + (this.ImpactTool as ITool).Use());
            Console.WriteLine((this.MagnifyingTool as ITool).Name + ": " + (this.MagnifyingTool as ITool).Use());

            Console.WriteLine();
        }
    }
}
