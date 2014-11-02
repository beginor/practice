define('req-app-controllers', ['req-app'], function(app) {
    'use strict';
    app.controller('WelcomeController', ['$scope', '$route',
            function ($scope, $route) {
                $scope.greeting = 'Welcome to AngularJS + RequireJS!';
            }
    ]);
    return app;
})