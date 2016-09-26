var AppViewModel = {
    activationKey: "",
    firstName: ko.observable(""),
    secondName: ko.observable(""),
    login: ko.observable(""),
    gender: ko.observable("male"),
    birthDate: ko.observable(""),
    timeZone: ko.observable(0),
    contry: ko.observable(""),
    availableGenders: ko.observableArray(["male","femail","unknown"])
};

// Activates knockout.js
ko.applyBindings(AppViewModel);

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

$(function () {
    AppViewModel.activationKey = getParameterByName("sk");
    AppViewModel.login(getParameterByName("l"));

    console.log("Activation key: " + AppViewModel.activationKey);
    console.log("login: " + AppViewModel.login());
});