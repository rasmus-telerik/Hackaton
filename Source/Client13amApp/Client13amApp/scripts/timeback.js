(function (global) {
  var TimebackViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  el.Users.login("Thomas", "tha");
    
  TimebackViewModel = kendo.data.ObservableObject.extend({
    task: undefined,
    startInterval: 'Loading data...',
    endInterval:'',
    stopBeforeYou: -1,
    timeCalculated: false,
    taskDescription: '',
    goBack: function () {
      $('#footer').show();
      $('#header').show();
      window.location.href = "#tabstrip-scan";
    }
  });

  app.getTimebackForTaskId = function (taskId) {
    $('#footer').hide();
    $('#header').hide();
    console.log('getTimebackForTaskId: ' + taskId);
    app.timebackService.viewModel.set('timeCalculated', false);
    app.timebackService.viewModel.set('startInterval', 'Loading data...');
    app.timebackService.viewModel.set('endInterval', '');

    var data = Everlive.$.data('Tasks');
    var query = new Everlive.Query();
    query.where().eq('Id', taskId).done().select("Id", "Route", "Description", "Location", "TimeInMin", "OrderNo", "Done");
    data.get(query).then(function (results) {
      
      if (results.result.length != 1) {
        alert('Task do not exist in database');
        return;
      }

      // Set current result
      app.timebackService.viewModel.task = results.result[0];
      app.timebackService.viewModel.set('taskDescription', app.timebackService.viewModel.task.Description);

      if (app.timebackService.viewModel.task.Done != true)
        calculateTotalTimeFromPreviouslyTask();
      else
        app.timebackService.viewModel.set('startInterval', 'We have been with you... use facebook to make friends. Have a nice day');
    });

    function calculateTotalTimeFromPreviouslyTask() {
      // Get current position of the driver
      var dataRoutes = Everlive.$.data('Routes');
      var queryDriverPosition = new Everlive.Query();
      queryDriverPosition.where().eq('Id', app.timebackService.viewModel.task.Route).done().select("CurrentPosition", "Modified at");
      
      dataRoutes.get(queryDriverPosition).then(function (resultForDriverPostion) {

        // make call to get stop before task and time remaning
        var queryForAllTask = new Everlive.Query();
        queryForAllTask.where().eq('Route', app.timebackService.viewModel.task.Route)
          .ne('Done', true)
          .lte('OrderNo', app.timebackService.viewModel.task.OrderNo)
          .done().select("Id", "Location", "TimeInMin", "Description");

        data.get(queryForAllTask).then(function (resultsForAllTasks) {
          // now we have all task for this route
          var length = resultsForAllTasks.result.length;
          app.timebackService.viewModel.stopBeforeYou = length - 1;

          var tempLocation = resultForDriverPostion.result[0].CurrentPosition;
          if (tempLocation == undefined)
          {
            app.timebackService.viewModel.set('startInterval', 'Routen is not active yet.');
            return;
          }

          var totalTimeToServiceManCame = 0;
          for (var i = 0; i < length; i++) {
            var step = resultsForAllTasks.result[i];
            var distInKm = getDistanceFromLatLonInKm(tempLocation.latitude, tempLocation.longitude, step.Location.latitude, step.Location.longitude);

            var travalTimeInMin = (distInKm / 50) * 60; // The driver travel with 50 km/hour
            totalTimeToServiceManCame += travalTimeInMin;

            // Add the task time for all task not the last task (current users)
            if (i + 1 < length)
              totalTimeToServiceManCame += step.TimeInMin;

            var tempLocation = step.Location;
          }

          setETAOnView(totalTimeToServiceManCame);
        });
      });
    }

    function getDistanceFromLatLonInKm(lat1, lon1, lat2, lon2) {
      var R = 6371; // Radius of the earth in km const
      var dLat = deg2rad(lat2 - lat1);  // deg2rad below
      var dLon = deg2rad(lon2 - lon1);
      var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
              Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
              Math.sin(dLon / 2) * Math.sin(dLon / 2);
      var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
      var d = R * c; // Distance in km
      return d;
    }

    function deg2rad(deg) {
      return deg * (Math.PI / 180)
    }

    function setETAOnView(totalTimeToServiceManCame) {

      var divideByInMin = 30; // 30 min precision
      var modNum = Math.floor(totalTimeToServiceManCame / divideByInMin);

      var earliestArrivalInMin = modNum * divideByInMin;
      var latestArrivalInMin = earliestArrivalInMin + divideByInMin;

      // Set the time text

      if (modNum == 0)
      {
        app.timebackService.viewModel.set('startInterval', '< ' + divideByInMin + ' min');
      }
      else if (earliestArrivalInMin > 60)
      {
        app.timebackService.viewModel.set('startInterval', minutesToStr(earliestArrivalInMin));
        app.timebackService.viewModel.set('endInterval', minutesToStr(latestArrivalInMin));
      }
      app.timebackService.viewModel.set('timeCalculated', true);

    }

    function minutesToStr(minutes) {
      var sign = '';
      if (minutes <= 0) {
        return 'unknown';
      }

      var hours = Math.floor(Math.abs(minutes) / 60);
      var minutes = leftPad(Math.abs(minutes) % 60);

      return sign + hours + 'hrs ' + minutes + 'min';
    }

    function leftPad(number) {
      return ((number < 10 && number >= 0) ? '0' : '') + number;
    }

  };

  app.timebackService = {
    viewModel: new TimebackViewModel()
  };

})(window);