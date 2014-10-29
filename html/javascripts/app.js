'use strict';

var demo = angular.module('demo', ['ngRoute', 'demoControllers']);

demo.config([
    '$routeProvider',
    function ($rootProvider) {
        $rootProvider
            .when('/dialogs', { templateUrl: 'views/dialogs.html', controller: 'DialogsController' })
            .when('/list', { templateUrl: 'views/list.html', controller: 'ListController' })
            .otherwise({ redirectTo: '/dialogs' });
    }
]);