var AppViewModel = {
	login: ko.observable(""),
	password: ko.observable(""),
	newlogin: ko.observable("")
};

// Activates knockout.js
ko.applyBindings(AppViewModel);

$(function () {
	var speed = 300;

	$('#login-form-link').click(function (e) {
		$("#login-form").delay(speed).fadeIn(speed);
		$("#register-form").fadeOut(speed);
		$('#register-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});

	$('#register-form-link').click(function (e) {
		$("#register-form").delay(speed).fadeIn(speed);
		$("#login-form").fadeOut(speed);
		$('#login-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
	});

	$('#login-btn')
		.click(function(e) {
			console.log("Sending data: " + AppViewModel.login() + ":" + AppViewModel.password());
		});

	$('#sing-up-btn')
		.click(function(e) {
			console.log("Sending data: " + AppViewModel.newlogin());
		});
});