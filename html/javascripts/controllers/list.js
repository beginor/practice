(function(angular) {
    'use strict';

    var list = angular.module('list', []);

    list.controller('ListController', ['$scope',
        //
        function ($scope) {
            $scope.greeting = 'List controller';

            //
            $scope.$on('$destroy', function(evt) {
                console.log('list controller destroy.');
            });
        }
    ]);
}(window.angular));