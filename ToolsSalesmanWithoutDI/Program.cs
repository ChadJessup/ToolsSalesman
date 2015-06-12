using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolsSalesman.Common;
using ToolsSalesman.Common.Interfaces;
using ToolsSalesman.Common.Tools;

namespace ToolsSalesmanWithoutDI
{
    public class Program
    {
        private static class Constants
        {
            public const string Pitch = "Welcome to Chad's Tool Shop!\t\nI hear ya wanna buy some tools!";
            public const string QuestionHeader = "What kind of work are you interested in?";
            public const string NewLine = "\r\n";
            public const string AfterList = "Type the corresponding  number to the job then hit the enter key...";
            public const string PostJobSelection = "Awesome!!1!  Here are your tools...";
        }

        static void Main(string[] args)
        {
            new Program().SalesmanGo();
        }

        private void SalesmanGo()
        {
            Console.WriteLine(Constants.Pitch);
            this.ListJobs();

            JobTitle jobSelection = this.GetJob();

            Console.WriteLine();

            IToolbox toolbox1 = this.LoadToolbox1(jobSelection);
            IToolbox toolbox2 = this.LoadToolbox2(jobSelection);
            IToolbox toolbox3 = this.LoadToolbox3(jobSelection);

            toolbox1.UseAllTools();
            toolbox2.UseAllTools();
            toolbox3.UseAllTools();

            Console.ReadKey();
        }

        private IToolbox LoadToolbox1(JobTitle jobSelection)
        {
            return new ToolboxWithJobTitle(jobSelection);
        }

        private IToolbox LoadToolbox2(JobTitle jobSelection)
        {
            IToolbox toolbox = new Toolbox();

            switch (jobSelection)
            {
                case JobTitle.Carpenter:
                    toolbox.BindingTool = new Nail();
                    toolbox.CuttingTool = new Saw();
                    toolbox.HoldingTool = new Clamp();
                    toolbox.ImpactTool = new Hammer();
                    toolbox.MagnifyingTool = new MagnifyingGlass();
                    break;
                case JobTitle.ComputerRepairman:
                    toolbox.BindingTool = new Screw();
                    toolbox.CuttingTool = new WireCutter();
                    toolbox.HoldingTool = new Tweezer();
                    toolbox.ImpactTool = new ScrewDriver();
                    toolbox.MagnifyingTool = new MagnifyingGlass();
                    break;
                case JobTitle.ElectricalEngineer:
                    toolbox.BindingTool = new Glue();
                    toolbox.CuttingTool = new WireCutter();
                    toolbox.HoldingTool = new Clamp();
                    toolbox.ImpactTool = new ScrewDriver();
                    toolbox.MagnifyingTool = new MagnifyingGlass();
                    break;
                case JobTitle.Mechanic:
                    toolbox.BindingTool = new Screw();
                    toolbox.CuttingTool = new WireCutter();
                    toolbox.HoldingTool = new Clamp();
                    toolbox.ImpactTool = new ImpactWrench();
                    toolbox.MagnifyingTool = new MagnifyingGlass();
                    break;
                default:
                    throw new InvalidCastException("Unknown job!");
            }

            return toolbox;
        }

        private IToolbox LoadToolbox3(JobTitle jobSelection)
        {
            IToolbox toolbox;

            switch (jobSelection)
            {
                case JobTitle.Carpenter:
                    toolbox = new ToolboxConstuctor(new Nail(), new Saw(), new Clamp(), new Hammer(), new MagnifyingGlass());
                    break;
                case JobTitle.ComputerRepairman:
                    toolbox = new ToolboxConstuctor(new Screw(), new WireCutter(), new Tweezer(), new ScrewDriver(), new MagnifyingGlass());
                    break;
                case JobTitle.ElectricalEngineer:
                    toolbox = new ToolboxConstuctor(new Glue(), new WireCutter(), new Clamp(), new ScrewDriver(), new MagnifyingGlass());
                    break;
                case JobTitle.Mechanic:
                    toolbox = new ToolboxConstuctor(new Screw(), new WireCutter(), new Clamp(), new ImpactWrench(), new MagnifyingGlass());
                    break;
                default:
                    throw new InvalidCastException("Unknown job!");
            }

            return toolbox;
        }

        private void ListJobs()
        {
            Console.WriteLine(Constants.QuestionHeader);
            Console.WriteLine(Constants.NewLine);

            string output = string.Empty;
            int count = 1;

            foreach (string job in Enum.GetNames(typeof(JobTitle)))
            {
                output += count + ". " + job + Constants.NewLine;
                count++;
            }

            output += Constants.NewLine;

            Console.WriteLine(output);
            Console.WriteLine(Constants.NewLine);
            Console.WriteLine(Constants.AfterList);
        }

        private JobTitle GetJob()
        {
            bool waitingForValidInput = true;
            int number = -1;
            while (waitingForValidInput)
            {
                string input = Console.ReadLine();
                if (Int32.TryParse(input, out number) && Enum.IsDefined(typeof(JobTitle), number))
                {
                    return (JobTitle)number;
                }
            }

            throw new InvalidOperationException("Something broke, fix meeeeeee!");
        }
    }
}
