using Telerik.Everlive.Sdk.Core.Model.Base;

namespace WebApplication.Engine.Model
{
    public class Company : DataItem
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }
    }
}