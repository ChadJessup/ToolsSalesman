using ToolsSalesman.Common.Interfaces;

namespace ToolsSalesman.Common.Tools
{
    public class BaseTool : ITool
    {
        public virtual string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public virtual string Use()
        {
            return this.GetType().Name + " was used!";
        }
    }
}
