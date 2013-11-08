(function (global) {
  var ScanViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");
    
  ScanViewModel = kendo.data.ObservableObject.extend({
    tasks: [],

   
  });

  app.onStartScan = function (id) {
    console.log('onStartScan');
    //TODO: use the real scanner for now we fake it
    window.location.href = "#tabstrip-timeback";

    console.log('After href');
    app.getTimebackForTaskId('71ef0150-47ad-11e3-afbf-61834747fc11');
    //var query = new Everlive.Query();
    //query.where().eq('Id', id).done().select("Id", "Description", "Location", "TimeInMin");

    //data.get(query).then(function (data) {

        
    //  app.timebackService.viewModel.tasks = data.result;
    //  app.timebackService.viewModel.trigger("change", { field: "tasks" });
    //});
  }

  app.scanService = {
    viewModel: new ScanViewModel()

  }
})(window);