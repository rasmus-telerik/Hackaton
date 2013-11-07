(function (global) {
  var LoginViewModel,
	pp = global.app = global.app || {};

  el = new Everlive('NFtPBKs75ALYLvLH');

  LoginViewModel = kendo.data.ObservableObject.extend({
    isLoggedIn: false,
    username: "",
    password: "",

    onLogin: function () {
      var that = this,
				username = that.get("username").trim(),
				password = that.get("password").trim();

      if (username === "" || password === "") {
        navigator.notification.alert("Both fields are required!",
					function () { }, "Login failed", 'OK');
        return;
      }

      el.Users.login(username, password)
      .then(function () {
        that.set("isLoggedIn", true);        
      })
      .then(null,
            function (err) {
              navigator.notification.alert("Wrong username or password",
					      function () { }, "Login failed", 'OK');
            }
      );      
    },

    onLogout: function () {
      var that = this;

      that.clearForm();
      that.set("isLoggedIn", false);
    },

    clearForm: function () {
      var that = this;

      that.set("username", "");
      that.set("password", "");
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