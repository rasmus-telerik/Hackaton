(function (global) {
  var ScanViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");
    
  ScanViewModel = kendo.data.ObservableObject.extend({
    tasks: [],

    onStartScan: function (id) {
      var data = '3db8ce10-47ae-11e3-a3b0-63ade7f90f31';

      //TODO: use the real scanner for now we fake it
      window.location.href = "#tabstrip-timeback";

      //var query = new Everlive.Query();
      //query.where().eq('Id', id).done().select("Id", "Description", "Location", "TimeInMin");

      //data.get(query).then(function (data) {

        
      //  app.timebackService.viewModel.tasks = data.result;
      //  app.timebackService.viewModel.trigger("change", { field: "tasks" });
      //});
    },
  });

  app.scanService = {
    viewModel: new ScanViewModel()

  };
})(window);