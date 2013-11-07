using System;
using Telerik.Everlive.Sdk.Core.Model.Base;
using Telerik.Everlive.Sdk.Core.Model.System;

namespace WebApplication.Engine.Model
{
    public class Task : DataItem
    {
        private Guid route;
        public Guid Route
        {
            get
            {
                return this.route;
            }
            set
            {
                this.route = value;
                this.OnPropertyChanged("Route");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.OnPropertyChanged("Description");
            }
        }

        private Guid customer;
        public Guid Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
                this.OnPropertyChanged("Customer");
            }
        }

        private GeoPoint location;
        public GeoPoint Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
                this.OnPropertyChanged("Location");
            }
        }

        private int timeInMins;
        public int TimeInMins
        {
            get
            {
                return this.timeInMins;
            }
            set
            {
                this.timeInMins = value;
                this.OnPropertyChanged("TimeInMins");
            }
        }
    }
}