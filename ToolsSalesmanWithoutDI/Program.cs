using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolsSalesman.Common.Interfaces;

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

        private IToolbox LoadToolbox3(JobTitle jobSelection)
        {
            throw new NotImplementedException();
        }

        private IToolbox LoadToolbox2(JobTitle jobSelection)
        {
            throw new NotImplementedException();
        }

        private IToolbox LoadToolbox1(JobTitle jobSelection)
        {
            throw new NotImplementedException();
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
