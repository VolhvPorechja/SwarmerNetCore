var AppViewModel = {
    activationKey: "",
    firstName: ko.observable(""),
    secondName: ko.observable(""),
    login: ko.observable(""),
    gender: ko.observable(),
    birthDate: ko.observable(),
    timeZone: ko.observable(),
    country: ko.observable(),
    agree: ko.observable(false),

    pass: ko.observable(),
    rpass: ko.observable(),

    availableGenders: ko.observableArray(["male", "femail", "unknown"]),
    availableCountries: ko.observableArray(["Russia", "Ukrain", "USA"]),
    availableTimeZones: ko.observableArray(Array.apply(null, Array(13)).map(function (_, i) { return "GTM+" + i; })),

    get: function () {
        return {
            activationKey: AppViewModel.activationKey,
            firstName: this.firstName(),
            secondName: this.secondName(),
            login: this.login(),
            gender: this.gender(),
            birthDate: this.birthDate(),
            timeZone: this.timeZone(),
            country: this.country(),
            agree: this.agree(),
            pass: this.pass(),
            rpass: this.rpass()
        }
    }
};

// Activates knockout.js
ko.applyBindings(AppViewModel);

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return "";
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

$(function () {
    AppViewModel.activationKey = getParameterByName("sk");
    AppViewModel.login(getParameterByName("l"));

    console.log("Activation key: " + AppViewModel.activationKey);
    console.log("login: " + AppViewModel.login());

    $("#birthdate").datetimepicker({
        viewMode: "years",
        format: "DD/MM/YYYY"
    });

    $("#reg-info-form")
        .submit(function (e) {
            e.preventDefault();
            var model = AppViewModel.get();
            if (model.pass !== model.rpass) {
                AppViewModel.pass("");
                AppViewModel.rpass("");
                $("#login-err").text("Passwords not similar. Please try again.");
                $("#login-err").slideDown(800).delay(4000).slideUp(800);
                return;
            }

            console.log(JSON.stringify(model));
            api.signup({
                activationKey: model.activationKey,
                password: model.pass,
                data: {
                    login: model.login,
                    firstName: model.firstName,
                    secondName: model.secondName,
                    country: model.country,
                    gender: model.gender,
                    birthDate: model.birthDate,
                    timeZone: Number(model.timeZone[4])
                }
            },
                function (resp) {

                },
                function (data) {
                    $("#login-err").text("Error occured during login.");
                    $("#login-err").slideDown(800).delay(4000).slideUp(800);
                });
        });
});