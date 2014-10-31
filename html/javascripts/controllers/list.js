(function(angular) {
    'use strict';

    var list = angular.module('list', []);

    list.controller('ListController', ['$scope', '$http',
        //
        function ($scope, $http) {
            $scope.greeting = 'Category list';

            $http.get('api/category').success(function (data, status, headers) {
                $scope.data = data;
            });
            //
            $scope.$on('$destroy', function(evt) {
                console.log('list controller destroy.');
            });
        }
    ]);
}(window.angular));