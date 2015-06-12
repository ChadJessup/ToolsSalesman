using Ninject.Modules;
using ToolsSalesman.Common.Interfaces;
using ToolsSalesman.Common.Tools;

namespace ToolsSalesmanWithDI
{
    [Job("Carpenter")]
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

    [Job("Mechanic")]
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

    [Job("ElectricalEngineer")]
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

    [Job("ComputerRepairman")]
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
