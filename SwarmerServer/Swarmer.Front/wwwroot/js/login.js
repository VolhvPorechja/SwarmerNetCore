var AppViewModel = {
    login: ko.observable(""),
    password: ko.observable(""),

    newlogin: ko.observable(""),
    newemail: ko.observable("")
};
// Activates knockout.js
ko.applyBindings(AppViewModel);

function callapi(url, request, onSuccess, onFail) {
    $.ajax({
            url: "http://localhost/api/" + url.trimLeft("/"),
            type: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(request)
        })
        .success(onSuccess)
        .fail(onFail);
}

$(function () {
    var speed = 300;

    $("#login-form-link").click(function (e) {
        $("#login-form").delay(speed).fadeIn(speed);
        $("#register-form").fadeOut(speed);
        $('#register-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

    $("#register-form-link").click(function (e) {
        $("#register-form").delay(speed).fadeIn(speed);
        $("#login-form").fadeOut(speed);
        $("#login-form-link").removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

    $("#login-form")
		.submit(function (e) {
		    var request = { id: AppViewModel.login(), secret: AppViewModel.password() }
		    console.log("Sending login data: " + request.id + ":" + request.secret);
		    callapi("login", request,
                function(data) {
                    if (data.isSuccess === true)
                        window.location.href = data.url;
                    else {
                        $("#login-err").text("Incorrect login or password. Please try again.");
                        $("#login-err").slideDown(800).delay(4000).slideUp(800);
                    }
                },
                function(data) {
                    $("#login-err").text("Error occured during login.");
                    $("#login-err").slideDown(800).delay(4000).slideUp(800);
                });

		    e.preventDefault();
		});

    $("#signup-form")
		.submit(function (e) {
		    var request = { login: AppViewModel.newlogin(), email: AppViewModel.newemail() }
		    console.log("Sending sign up data: " + request.login + ":" + request.email);

            callapi("presignup",
                request,
                function(data) {
                    if (data.isSuccess === true)
                        window.location.href = data.url;
                    else {
                        $("#signup-err")
                            .text("Error: " +
                                (data.loginExists
                                    ? "Login already exists choose other one. "
                                    : "") +
                                (data.emailExists
                                    ? "Email already exists choose the other one."
                                    : ""));
                        $("#signup-err").slideDown(800).delay(4000).slideUp(800);
                    }
                },
                function(data) {
                    $("#signup-err").text("Error occured during pre sign up.");
                    $("#signup-err").slideDown(800).delay(4000).slideUp(800);
                }
            );

		    e.preventDefault();
		});
});