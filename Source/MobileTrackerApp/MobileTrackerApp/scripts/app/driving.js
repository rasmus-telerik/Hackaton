(function (global) {
  var DrivingViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");

  DrivingViewModel = kendo.data.ObservableObject.extend({
    routes: [],
  });

  app.drivingService = {
    viewModel: new DrivingViewModel()
    
  };
})(window);