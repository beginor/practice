(function(angular) {
    'use strict';

    var demoControllers = angular.module('demoControllers', []);

    demoControllers.controller('DialogsController', ['$scope', '$location', '$rootScope',
        //
        function ($scope, $location, $rootScope) {
        $scope.greeting = 'Hello';

        //
        $scope.$on('$destroy', function(evt, next, current) {
            console.log('destroy.');
        });
    }]);

    demoControllers.controller('ListController', ['$scope', function($scope) {
        $scope.greeting = 'List';
    }]);
}(window.angular));