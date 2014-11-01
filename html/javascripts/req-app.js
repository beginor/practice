define(['jquery', 'angular', 'angular-route', 'angular-resource'],
    function($, angular) {
        var app = angular.module('app', []);
        app.controller('WelcomeController', function ($scope) {
               $scope.greeting = 'Welcome!';
           });
        return app;
    }
);