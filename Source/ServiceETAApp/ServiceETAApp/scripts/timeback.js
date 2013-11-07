(function (global) {
  var TimebackViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");
    
  TimebackViewModel = kendo.data.ObservableObject.extend({
    tasks: [],

    getTimebackForTaskId: function (id) {
      var data = Everlive.$.data('Tasks');
      var query = new Everlive.Query();
      query.where().eq('Id', id).done().select("Id", "Description", "Location", "TimeInMin");

      data.get(query).then(function (data) {
        app.timebackService.viewModel.tasks = data.result;
        app.timebackService.viewModel.trigger("change", { field: "tasks" });
      });
    },

  });

  app.timebackService = {
    viewModel: new TimebackViewModel()

  };
})(window);