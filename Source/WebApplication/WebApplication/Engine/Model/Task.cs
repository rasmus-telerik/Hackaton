﻿using System;
using Telerik.Everlive.Sdk.Core.Model.Base;
using Telerik.Everlive.Sdk.Core.Model.System;
using Telerik.Everlive.Sdk.Core.Serialization;

namespace WebApplication.Engine.Model
{
    [ServerType("Tasks")]
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

        private int orderNo;
        public int OrderNo
        {
            get
            {
                return this.orderNo;
            }
            set
            {
                this.orderNo = value;
                this.OnPropertyChanged("OrderNo");
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
                this.OnPropertyChanged("Address");
            }
        }
    }
}