using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using ToolsSalesman.Common.Interfaces;
using ToolsSalesman.Common.Jobs;
using ToolsSalesmanWithDI;

namespace ToolsSalesman
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

        private IKernel kernel;

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

            this.kernel = this.LoadModule(jobSelection);

            IToolbox toolbox1 = kernel.Get<ToolboxWithDI1>();
            IToolbox toolbox2 = kernel.Get<ToolboxWithDI2>();
            IToolbox toolbox3 = kernel.Get<ToolboxWithDI3>();

            toolbox1.UseAllTools();
            toolbox2.UseAllTools();
            toolbox3.UseAllTools();

            Console.ReadKey();
        }

        private void ListJobs()
        {
            Console.WriteLine(Constants.QuestionHeader);
            Console.WriteLine(Constants.NewLine);

            string output = string.Empty;
            int count = 1;

            foreach(string job in Enum.GetNames(typeof(JobTitle)))
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
                if(Int32.TryParse(input, out number) && Enum.IsDefined(typeof(JobTitle), number))
                {
                    return (JobTitle)number;
                }
            }

            throw new InvalidOperationException("Something broke, fix meeeeeee!");
        }

        private IKernel LoadModule(JobTitle jobSelection)
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass))
            {
                foreach (JobAttribute attr in type.GetCustomAttributes(typeof(JobAttribute), inherit: true))
                {
                    if (attr.Job == jobSelection)
                    {
                        return new StandardKernel((INinjectModule)Activator.CreateInstance(type));
                    }
                }
            }

            return null;
        }
    }
}
