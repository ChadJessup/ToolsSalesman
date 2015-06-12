using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsSalesman.Common.Interfaces;
using ToolsSalesman.Common.Tools;
using ToolsSalesmanWithoutDI;

namespace ToolsSalesmanWithoutDI
{
    public class ToolboxWithJobTitle : IToolbox
    {
        public IBinder BindingTool { get; set; }
        public ICutter CuttingTool { get; set; }
        public IHolder HoldingTool { get; set; }
        public IImpactTool ImpactTool { get; set; }
        public IMagnifier MagnifyingTool { get; set; }

        public ToolboxWithJobTitle(JobTitle jobTitle)
        {
            switch(jobTitle)
            {
                case JobTitle.Carpenter:
                    this.FillCarpenter();
                    break;
                case JobTitle.ComputerRepairman:
                    this.FillComputerRepairman();
                    break;
                case JobTitle.ElectricalEngineer:
                    this.FillElectricalEngineer();
                    break;
                case JobTitle.Mechanic:
                    this.FillMechanic();
                    break;
                    // TODO: Add new jobs here
                default:
                    throw new InvalidOperationException("Unknown Job!");
            }
        }

        private void FillMechanic()
        {
            this.BindingTool = new Screw();
            this.CuttingTool = new WireCutter();
            this.HoldingTool = new Clamp();
            this.ImpactTool = new ImpactWrench();
            this.MagnifyingTool = new MagnifyingGlass();
        }

        private void FillElectricalEngineer()
        {
            this.BindingTool = new Glue();
            this.CuttingTool = new WireCutter();
            this.HoldingTool = new Clamp();
            this.ImpactTool = new ScrewDriver();
            this.MagnifyingTool = new MagnifyingGlass();
        }

        private void FillComputerRepairman()
        {
            this.BindingTool = new Screw();
            this.CuttingTool = new WireCutter();
            this.HoldingTool = new Tweezer();
            this.ImpactTool = new ScrewDriver();
            this.MagnifyingTool = new MagnifyingGlass();
        }

        private void FillCarpenter()
        {
            this.BindingTool = new Nail();
            this.CuttingTool = new Saw();
            this.HoldingTool = new Clamp();
            this.ImpactTool = new Hammer();
            this.MagnifyingTool = new MagnifyingGlass();
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
