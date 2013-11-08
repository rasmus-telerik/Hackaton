(function (global) {
  var LoginViewModel,
	pp = global.app = global.app || {};

  //while debugging
  //pp.el.Users.login("Thomas", "tha");
  
  LoginViewModel = kendo.data.ObservableObject.extend({
    isLoggedIn: false,
    username: "",
    password: "",

    onLogin: function () {
      var that = this,
				username = that.get("username").trim(),
				password = that.get("password").trim();

      //if (username === "" || password === "") {
      //  navigator.notification.alert("Both fields are required!",
			//		function () { }, "Login failed", 'OK');
      //  return;
      //}

      //pp.el.Users.login(username, password)
      pp.el.Users.login("Thomas (Driver)", "tha")
      .then(function () {        
        $('#footer').show();
        that.set("isLoggedIn", true);
        window.location.href = "#tabstrip-routes";
      })
      .then(null,
            function (err) {
              navigator.notification.alert("Wrong username or password",
					      function () { }, "Login failed", 'OK');
            }
      );      
    },    
    
    checkEnter: function (e) {
      var that = this;

      if (e.keyCode == 13) {
        $(e.target).blur();
        that.onLogin();
      }
    }
  });

  app.loginService = {
    viewModel: new LoginViewModel()
  };
})(window);