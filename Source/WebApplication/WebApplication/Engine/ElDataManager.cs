using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Everlive.Sdk.Core;
using Telerik.Everlive.Sdk.Core.Linq.Translators;
using Telerik.Everlive.Sdk.Core.Model.Base;
using Telerik.Everlive.Sdk.Core.Model.System;
using Telerik.Everlive.Sdk.Core.Query.Definition.Sorting;
using WebApplication.Engine.Model;

namespace WebApplication.Engine
{
    public class ElDataManager
    {
        private EverliveApp app;
        protected EverliveApp App
        {
            get
            {
                return this.app;
            }
        }

        public ElDataManager()
        {
            this.app = new EverliveApp(new EverliveAppSettings()
                {
                    ApiKey = "NFtPBKs75ALYLvLH"
                });
            this.app.WorkWith().Authentication().Login("7YGY2GHctdzRB36kLiY5HwyWhgG2TN4W").ExecuteSync();
        }

        #region Common

        public void Create<T>(T item) where T : DataItem
        {
            this.App.WorkWith().Data<T>().Create(item).ExecuteSync();
        }

        public T GetById<T>(Guid id) where T : DataItem
        {
            return this.App.WorkWith().Data<T>().GetById(id).ExecuteSync();
        }

        public int GetAllCount<T>() where T : DataItem
        {
            return this.App.WorkWith().Data<T>().GetCount().ExecuteSync();
        }

        public IEnumerable<T> GetAll<T>(int skip, int take, bool lastOnTop = true) where T : DataItem
        {
            var sortDirection = lastOnTop ? OrderByDirection.Descending : OrderByDirection.Ascending;
            var sort = new SortingDefinition("CreatedAt", sortDirection);
            return this.App.WorkWith().Data<T>().Get().SetSorting(sort).Skip(skip).Take(take).ExecuteSync();
        }

        public void Update<T>(T item) where T : DataItem
        {
            this.App.WorkWith().Data<T>().Update(item);
        }

        public void Delete<T>(Guid id) where T : DataItem
        {
            this.App.WorkWith().Data<T>().Delete(id);
        }

        #endregion

        #region Companies

        public IEnumerable<Company> GetCompaniesByOwner(Guid ownerId)
        {
            return this.App.WorkWith().Data<Company>().Get().Where(c => c.Owner == ownerId).ExecuteSync();
        }

        #endregion

        #region Routes

        public int GetRoutesCountByCompany(Guid companyId)
        {
            return this.App.WorkWith().Data<Route>().GetCount().Where(r => r.CompanyID == companyId).ExecuteSync();
        }

        public IEnumerable<Route> GetRoutesByCompany(Guid companyId, int skip, int take, bool lastOnTop = true)
        {
            var sortDirection = lastOnTop ? OrderByDirection.Descending : OrderByDirection.Ascending;
            var sort = new SortingDefinition("CreatedAt", sortDirection);
            return this.App.WorkWith().Data<Route>().Get()
                .Where(r => r.CompanyID == companyId).SetSorting(sort).Skip(skip).Take(take).ExecuteSync();
        }

        #endregion

        #region Tasks

        public int GetTasksCountByRoute(Guid routeId)
        {
            return this.App.WorkWith().Data<Task>().GetCount().Where(r => r.Route == routeId).ExecuteSync();
        }

        public IEnumerable<Task> GetTasksByRoute(Guid routeId, int skip, int take, bool lastOnTop = true)
        {
            var sortDirection = lastOnTop ? OrderByDirection.Descending : OrderByDirection.Ascending;
            var sort = new SortingDefinition("CreatedAt", sortDirection);
            return this.App.WorkWith().Data<Task>().Get()
                .Where(t => t.Route == routeId).SetSorting(sort).Skip(skip).Take(take).ExecuteSync();
        }

        public int GetTasksCountByCustomer(Guid customerId)
        {
            return this.App.WorkWith().Data<Task>().GetCount().Where(r => r.Customer == customerId).ExecuteSync();
        }

        public IEnumerable<Task> GetTasksByCustomer(Guid customerId, int skip, int take, bool lastOnTop = true)
        {
            var sortDirection = lastOnTop ? OrderByDirection.Descending : OrderByDirection.Ascending;
            var sort = new SortingDefinition("CreatedAt", sortDirection);
            return this.App.WorkWith().Data<Task>().Get()
                .Where(t => t.Customer == customerId).SetSorting(sort).Skip(skip).Take(take).ExecuteSync();
        }

        #endregion
    }
}