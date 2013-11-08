(function (global) {
  var DrivingViewModel,
	pp = global.app = global.app || {};

  DrivingViewModel = kendo.data.ObservableObject.extend({
    activeRoute:undefined,
    gpsIsRunning: false,
    latitude:0,
    longitude: 0,
    gpsTimer:undefined,
    tasks: [],

    getTasksForRoute: function (route) {
      this.activeRoute = route;
      var data = Everlive.$.data('Tasks');
      var query = new Everlive.Query();
      query.where().eq('Route', route.Id).done().select("Id", "Description", "Address", "Location", "TimeInMin", "OrderNo").order("OrderNo");
      var that = this;
      data.get(query).then(function (data) {

        for (var i = 0; i < data.result.length; i++) {
          data.result[i].Disttotask = '~';
        }

        // Calculate the distance from point to point
        if (route !== undefined) {
          var tempLocation = route.CurrentPosition;
          if (tempLocation !== undefined) {
            for (var i = 0; i < data.result.length; i++) {
              var taks = data.result[i];
              var distInKm = that.getDistanceFromLatLonInKm(tempLocation.latitude, tempLocation.longitude, taks.Location.latitude, taks.Location.longitude);
              data.result[i].Disttotask = Math.round(distInKm * 10) / 10;
              tempLocation = taks.Location;
            }
          }
        }

        app.drivingService.viewModel.tasks = data.result;
        app.drivingService.viewModel.trigger("change", { field: "tasks" });
      });
    },

    getDistanceFromLatLonInKm: function (lat1, lon1, lat2, lon2) {
      var R = 6371; // Radius of the earth in km const
      var dLat = this.deg2rad(lat2 - lat1);  // deg2rad below
      var dLon = this.deg2rad(lon2 - lon1);
      var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
              Math.cos(this.deg2rad(lat1)) * Math.cos(this.deg2rad(lat2)) *
              Math.sin(dLon / 2) * Math.sin(dLon / 2);
      var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
      var d = R * c; // Distance in km
      return d;
    },

    deg2rad: function (deg) {
      return deg * (Math.PI / 180)
    },

    startGpsCollection: function () {
      this.set("gpsIsRunning", true);
      var that = this;
      that.collectLocation();
      this.gpsTimer = setInterval(function () {
        that.collectLocation();
      }, 600 * 1000);

    },

    collectLocation: function () {
      var that = this;
      navigator.geolocation.getCurrentPosition(
      function (position) {
        that.set("latitude", position.coords.latitude);
        that.set("longitude", position.coords.longitude);

        that.getTasksForRoute(that.activeRoute);

        //Update route with the current location
        that.activeRoute.CurrentPosition = new Everlive.GeoPoint( position.coords.longitude, position.coords.latitude);
        Everlive.$.data('Routes').updateSingle(that.activeRoute);

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