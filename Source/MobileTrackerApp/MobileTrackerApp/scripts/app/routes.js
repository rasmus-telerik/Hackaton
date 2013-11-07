(function (global) {
  var RouteViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");

  var data = Everlive.$.data('Routes');
  var query = new Everlive.Query();
  //query.where().eq('Driver', el.User.Id).select("StartTime");
  query.select("StartTime");
  data.get(query).then(function (data) {
    app.routeService.viewModel.routes = data.result;
  });

  RouteViewModel = kendo.data.ObservableObject.extend({
    routes: [],
    onActivateRoute: function (e) {
      global.app.drivingService.viewModel.getTasksForDriver(e.data.Id);
      window.location.href = "#tabstrip-driving";
    }
  });

  app.routeService = {
    viewModel: new RouteViewModel()
    
  };
})(window);