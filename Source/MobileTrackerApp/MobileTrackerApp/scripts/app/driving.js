(function (global) {
  var DrivingViewModel,
	pp = global.app = global.app || {};

  DrivingViewModel = kendo.data.ObservableObject.extend({
    gpsIsRunning:false,
    latitude:0,
    longitude: 0,
    gpsTimer:undefined,
    tasks: [],

    getTasksForDriver: function (id) {
      var data = Everlive.$.data('Tasks');
      var query = new Everlive.Query();
      query.where().eq('Route', id).done().select("Id", "Description", "Location", "TimeInMin", "OrderNo").order("OrderNo");

      data.get(query).then(function (data) {
        app.drivingService.viewModel.tasks = data.result;
        app.drivingService.viewModel.trigger("change", { field: "tasks" });
      });
    },

    startGpsCollection: function () {
      this.set("gpsIsRunning", true);
      var that = this;
      that.collectLocation();
      this.gpsTimer = setInterval(function () {
        that.collectLocation();
      }, 60 * 1000);

    },
    collectLocation: function () {
      var that = this;
      navigator.geolocation.getCurrentPosition(
      function (position) {
        that.set("latitude", position.coords.latitude);
        that.set("longitude", position.coords.longitude);
        //that.latitude = position.coords.latitude;
        //that.longitude = position.coords.longitude;

        //app.drivingService.viewModel.trigger("change", { field: "latitude" });
        //app.drivingService.viewModel.trigger("change", { field: "longitude" });
      },
      function (error) {
        navigator.notification.alert("Unable to determine current location. Cannot connect to GPS satellite.",
          function () { }, "Location failed", 'OK');
      },
      {
        timeout: 30000,
        enableHighAccuracy: true
      });
        
    },
    stopGpsCollection: function () {
      this.set("gpsIsRunning", false);
      clearInterval(this.gpsTimer);
    },
    onNavigateToCustomer: function (id) {
      var geopoint = id.data.Location;
      window.location.href = "https://maps.google.dk/maps?q=" + geopoint.latitude + "%2C" + +geopoint.longitude;
    }
  });

  app.drivingService = {
    viewModel: new DrivingViewModel()
    
  };
})(window);