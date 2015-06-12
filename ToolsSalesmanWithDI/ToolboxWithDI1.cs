using System;
using ToolsSalesman.Common.Interfaces;

namespace ToolsSalesman
{
    public class ToolboxWithDI1 : IToolbox
    {
        public IBinder BindingTool { get; set; }
        public ICutter CuttingTool { get; set; }
        public IHolder HoldingTool { get; set; }
        public IImpactTool ImpactTool { get; set; }
        public IMagnifier MagnifyingTool { get; set; }

        public ToolboxWithDI1(IBinder binder, ICutter cutter, IHolder holder, IImpactTool impact, IMagnifier magnifier)
        {
            this.BindingTool = binder;
            this.CuttingTool = cutter;
            this.HoldingTool = holder;
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
