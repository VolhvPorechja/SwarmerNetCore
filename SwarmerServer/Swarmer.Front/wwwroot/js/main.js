requirejs.config({
    baseUrl: "bower_components",
    paths: {
        jquery: "jquery/dist/jquery.min",
        bootstrap: "bootstrap/dist/js/bootstrap.min",
        moment: "moment/min/moment.min",
        datetimepicker: "eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min",
        knockout: "knockout/dist/knockout",
        underscore: "underscore/underscore"
    }
});

require(["knockout"],
    function(ko) {
        window.ko = ko;
    });

require(["jquery", "bootstrap", "moment", "datetimepicker", "underscore"]);