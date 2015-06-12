namespace ToolsSalesmanWithDI
{
    using System;
    using ToolsSalesman.Common.Jobs;

    [AttributeUsage(AttributeTargets.Class)]
    public class JobAttribute : Attribute
    {
        public JobTitle Job { get; set; }

        public JobAttribute(JobTitle jobTitle)
        {
            this.Job = jobTitle;
        }
    }
}
