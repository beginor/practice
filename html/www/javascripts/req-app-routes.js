define(['req-app'],
    function (app) {
        'use strict';
        app.config([
            '$routeProvider',
            function($routeProvider) {
                $routeProvider
                    .when('/welcome', { templateUrl: 'views/welcome.html', controller: 'WelcomeController' })
                    .otherwise({ redirectTo: '/welcome' });
            }
        ]);
        return app;
    }
);