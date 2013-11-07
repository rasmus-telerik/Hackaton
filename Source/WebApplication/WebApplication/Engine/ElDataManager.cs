using System;
using System.Collections.Generic;
using Telerik.Everlive.Sdk.Core;
using Telerik.Everlive.Sdk.Core.Linq.Translators;
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
            this.app = new EverliveApp("NFtPBKs75ALYLvLH");
            this.app.WorkWith().Authentication().Login("7YGY2GHctdzRB36kLiY5HwyWhgG2TN4W")
                .ExecuteSync();
        }

        #region Routes

        public void CreateRoute(Route route)
        {
            this.App.WorkWith().Data<Route>().Create(route).ExecuteSync();
        }

        public Route GetRouteById(Guid id)
        {
            return this.App.WorkWith().Data<Route>().GetById(id).ExecuteSync();
        }

        public int GetRoutesCountByCompany(Guid companyId)
        {
            return App.WorkWith().Data<Route>().GetCount()
                .Where(r => r.CompanyID == companyId)
                .ExecuteSync();
        }

        public IEnumerable<Route> GetRoutesByCompany(Guid companyId, int skip, int take, bool latestOnTop = true)
        {
            var direction = latestOnTop ? OrderByDirection.Ascending : OrderByDirection.Descending;
            SortingDefinition sortDesc = new SortingDefinition("CreatedAt", direction);
            return this.App.WorkWith().Data<Route>().Get()
                .Where(r => r.CompanyID == companyId)
                .SetSorting(sortDesc)
                .Skip(skip)
                .Take(take)
                .ExecuteSync();
        }

        public void UpdateRoute(Route route)
        {
            this.App.WorkWith().Data<Route>().Update(route).ExecuteSync();
        }

        public void DeleteRoute(Guid id)
        {
            this.App.WorkWith().Data<Route>().Delete(id);
        }

        #endregion

        #region Companies

        public void CreateCompany(Company company)
        {
            this.App.WorkWith().Data<Company>().Create(company).ExecuteSync();
        }

        public Company GetCompanyById(Guid id)
        {
            return this.App.WorkWith().Data<Company>().GetById(id).ExecuteSync();
        }

        public IEnumerable<Company> GetCompaniesByOwner(Guid ownerId)
        {
            return this.App.WorkWith().Data<Company>().Get()
                .Where(c => c.Owner == ownerId)
                .ExecuteSync();
        }

        public int GetCompaniesCount()
        {
            return App.WorkWith().Data<Company>().GetCount()
                .ExecuteSync();
        }

        public IEnumerable<Company> GetCompanies(int skip, int take, bool latestOnTop = true)
        {
            var direction = latestOnTop ? OrderByDirection.Ascending : OrderByDirection.Descending;
            SortingDefinition sortDesc = new SortingDefinition("CreatedAt", direction);
            return this.App.WorkWith().Data<Company>().Get()
                .SetSorting(sortDesc)
                .Skip(skip)
                .Take(take)
                .ExecuteSync();
        }

        public void UpdateCompany(Company company)
        {
            this.App.WorkWith().Data<Company>().Update(company).ExecuteSync();
        }

        public void DeleteCompany(Guid id)
        {
            this.App.WorkWith().Data<Company>().Delete(id);
        }

        #endregion

        #region Tasks

        public void CreateTask(Task task)
        {
            this.App.WorkWith().Data<Task>().Create(task).ExecuteSync();
        }

        public Task GetTaskById(Guid id)
        {
            return this.App.WorkWith().Data<Task>().GetById(id).ExecuteSync();
        }

        public int GetTasksCountByRoute(Guid routeId)
        {
            return App.WorkWith().Data<Task>().GetCount()
                .Where(t => t.Route == routeId)
                .ExecuteSync();
        }

        public IEnumerable<Task> GetTasksByRoute(Guid routeId, int skip, int take, bool latestOnTop = true)
        {
            var direction = latestOnTop ? OrderByDirection.Ascending : OrderByDirection.Descending;
            SortingDefinition sortDesc = new SortingDefinition("CreatedAt", direction);
            return this.App.WorkWith().Data<Task>().Get()
                .Where(t => t.Route == routeId)
                .SetSorting(sortDesc)
                .Skip(skip)
                .Take(take)
                .ExecuteSync();
        }

        public int GetTasksCountByCustomer(Guid customerId)
        {
            return App.WorkWith().Data<Task>().GetCount()
                .Where(t => t.Customer == customerId)
                .ExecuteSync();
        }

        public IEnumerable<Task> GetTasksByCustomer(Guid customerId, int skip, int take, bool latestOnTop = true)
        {
            var direction = latestOnTop ? OrderByDirection.Ascending : OrderByDirection.Descending;
            SortingDefinition sortDesc = new SortingDefinition("CreatedAt", direction);
            return this.App.WorkWith().Data<Task>().Get()
                .Where(t => t.Customer == customerId)
                .SetSorting(sortDesc)
                .Skip(skip)
                .Take(take)
                .ExecuteSync();
        }

        public void UpdateTask(Task task)
        {
            this.App.WorkWith().Data<Task>().Update(task).ExecuteSync();
        }

        public void DeleteTask(Guid id)
        {
            this.App.WorkWith().Data<Task>().Delete(id);
        }

        #endregion
    }
}