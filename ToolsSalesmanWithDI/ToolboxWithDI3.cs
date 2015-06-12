using System;
using Ninject;
using ToolsSalesman.Common.Interfaces;

namespace ToolsSalesman
{
    public class ToolboxWithDI3 : IToolbox
    {
        [Inject]
        public IBinder BindingTool { get; set; }

        [Inject]
        public ICutter CuttingTool { get; set; }

        [Inject]
        public IHolder HoldingTool { get; set; }

        private readonly IImpactTool ImpactTool;
        private readonly IMagnifier MagnifyingTool;

        public ToolboxWithDI3(IImpactTool impact, IMagnifier magnifier)
        {
            this.ImpactTool = impact;
            this.MagnifyingTool = magnifier;
        }

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
