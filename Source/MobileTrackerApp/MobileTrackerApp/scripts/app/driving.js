(function (global) {
  var DrivingViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");

  DrivingViewModel = kendo.data.ObservableObject.extend({
    tasks: [],

    getTasksForDriver: function (id) {
      var data = Everlive.$.data('Tasks');
      var query = new Everlive.Query();
      query.where().eq('Route', id).done().select("Id", "Description", "Location", "TimeInMin");
      //query.select("Id","Description", "Location", "TimeInMin");
      data.get(query).then(function (data) {
        app.drivingService.viewModel.tasks = data.result;
        app.drivingService.viewModel.trigger("change", { field: "tasks" });
      });
    }

  });

  app.drivingService = {
    viewModel: new DrivingViewModel()
    
  };
})(window);