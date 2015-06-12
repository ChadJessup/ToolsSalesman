using Ninject.Modules;
using ToolsSalesman.Common.Interfaces;
using ToolsSalesman.Common.Jobs;
using ToolsSalesman.Common.Tools;

namespace ToolsSalesmanWithDI
{
    [Job(JobTitle.Carpenter)]
    public class Carpenter : NinjectModule
    {
         public override void Load()
         {
             Bind<IBinder>().To<Nail>();
             Bind<ICutter>().To<Saw>();
             Bind<IHolder>().To<Clamp>();
             Bind<IImpactTool>().To<Hammer>();
             Bind<IMagnifier>().To<MagnifyingGlass>();
         }
    }

    [Job(JobTitle.Mechanic)]
    public class Mechanic : NinjectModule
    {
        public override void Load()
        {
            Bind<IBinder>().To<Screw>();
            Bind<ICutter>().To<WireCutter>();
            Bind<IHolder>().To<Clamp>();
            Bind<IImpactTool>().To<ImpactWrench>();
            Bind<IMagnifier>().To<MagnifyingGlass>();
        }
    }

    [Job(JobTitle.ElectricalEngineer)]
    public class ElectricalEngineer : NinjectModule
    {
        public override void Load()
        {
            Bind<IBinder>().To<Glue>();
            Bind<ICutter>().To<WireCutter>();
            Bind<IHolder>().To<Clamp>();
            Bind<IImpactTool>().To<ScrewDriver>();
            Bind<IMagnifier>().To<MagnifyingGlass>();
        }
    }

    [Job(JobTitle.ComputerRepairman)]
    public class ComputerRepairman : NinjectModule
    {
        public override void Load()
        {
            Bind<IBinder>().To<Screw>();
            Bind<ICutter>().To<WireCutter>();
            Bind<IHolder>().To<Tweezer>();
            Bind<IImpactTool>().To<ScrewDriver>();
            Bind<IMagnifier>().To<MagnifyingGlass>();
        }
    }
}
