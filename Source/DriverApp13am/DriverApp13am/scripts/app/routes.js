(function (global) {
  var RouteViewModel,
	pp = global.app = global.app || {};

  

  RouteViewModel = kendo.data.ObservableObject.extend({
    routes: [],
    beforeShow: function (event) {

      Everlive.$.Users.currentUser().then(function (userdata) {
        var data = Everlive.$.data('Routes');
        var query = new Everlive.Query();
        query.where().eq('Driver', userdata.result.Id).Done().select("Id", "StartTime", "CurrentPosition");
        //query.select("Id", "StartTime", "CurrentPosition");
        data.get(query).then(function (data) {
          app.routeService.viewModel.routes = data.result;
          app.routeService.viewModel.trigger("change", { field: "routes" });
        });

      },
      function (error) {
        alert(JSON.stringify(error));
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