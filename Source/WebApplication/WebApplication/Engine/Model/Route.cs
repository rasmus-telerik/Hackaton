using System;
using Telerik.Everlive.Sdk.Core.Model.Base;
using Telerik.Everlive.Sdk.Core.Model.System;
using Telerik.Everlive.Sdk.Core.Serialization;

namespace WebApplication.Engine.Model
{
    [ServerType("Routes")]
    public class Route : DataItem
    {
        private DateTime startTime;
        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                this.startTime = value;
                this.OnPropertyChanged("StartTime");
            }
        }

        private Guid companyID;
        public Guid CompanyID
        {
            get
            {
                return this.companyID;
            }
            set
            {
                this.companyID = value;
                this.OnPropertyChanged("CompanyID");
            }
        }

        private Guid driver;
        public Guid Driver
        {
            get
            {
                return this.driver;
            }
            set
            {
                this.driver = value;
                this.OnPropertyChanged("Driver");
            }
        }

        private GeoPoint currentPosition;
        public GeoPoint CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                this.currentPosition = value;
                this.OnPropertyChanged("CurrentPosition");
            }
        }
    }
}