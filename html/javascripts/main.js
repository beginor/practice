'use strict';

requirejs.config({
    baseUrl: 'javascripts',
    paths: {
        jquery: 'libs/jquery/2.1.1/jquery-2.1.1',
        bootstrap: 'libs/bootstrap/3.2.0/js/bootstrap',
        angular: 'libs/angularjs/1.3.0/angular',
        'angular-route': 'libs/angularjs/1.3.0/angular-route',
        'angular-resource': 'libs/angularjs/1.3.0/angular-resource'
    },
    shim: {
        bootstrap: { deps: ['jquery'] },
        angular: { deps: ['jquery'], exports: 'angular' },
        'angular-route': { deps: ['jquery', 'angular'] },
        'angular-resource': { deps: ['jquery', 'angular'] }
    }
});

require(['jquery', 'angular', 'req-app'],
    function ($, angular, app) {
        console.log(app);
        $(function() { angular.bootstrap(document, ['app']); });
    }
);