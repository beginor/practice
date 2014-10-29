'use strict';

var demoControllers = angular.module('demoControllers', []);

demoControllers.controller('DialogsController', ['$scope', function ($scope) {
    $scope.greeting = 'Hello';
}]);

demoControllers.controller('ListController', ['$scope', function($scope) {
    $scope.greeting = 'List';
}]);