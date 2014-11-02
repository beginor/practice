define('req-app', ['angular', 'angular-route', 'angular-resource'],
    function (angular) {
        var app = angular.module('app', ['ngResource', 'ngRoute']);
        return app;
    }
);