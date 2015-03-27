define(['app'], function (app) {
    'use strict';

    app.registerController('homeController', homeController);

    homeController.$inject = ['$scope'];

    function homeController($scope) {
        $scope.pageClass = 'page-home';
    }

});