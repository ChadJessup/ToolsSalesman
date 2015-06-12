namespace ToolsSalesmanWithDI
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class JobAttribute : Attribute
    {
        public string JobTitle { get; set; }

        public JobAttribute(string jobTitle)
        {
            this.JobTitle = jobTitle;
        }
    }
}
