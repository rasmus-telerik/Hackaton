﻿(function (global) {
  var RouteViewModel,
	pp = global.app = global.app || {};

  

  RouteViewModel = kendo.data.ObservableObject.extend({
    routes: [],
    beforeShow: function (event) { 
      var data = Everlive.$.data('Routes');
      var query = new Everlive.Query();
      //query.where().eq('Driver', app.el.User.Id).Done().select("StartTime");
      query.select("Id","StartTime");
      data.get(query).then(function (data) {
        app.routeService.viewModel.routes = data.result;
        app.routeService.viewModel.trigger("change", { field: "routes" });
      });
    },
    onActivateRoute: function (e) {
      global.app.drivingService.viewModel.getTasksForRoute(e.data);
      global.app.drivingService.viewModel.startGpsCollection();
      window.location.href = "#tabstrip-driving";
    }
  });

  app.routeService = {
    viewModel: new RouteViewModel()
    
  };
})(window);