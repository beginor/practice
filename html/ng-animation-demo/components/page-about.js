define(['app'], function (app) {
    'use strict';

    app.registerController('aboutController', aboutController);

    aboutController.$inject = ['$scope'];

    function aboutController($scope) {
        $scope.pageClass = 'page-about';
    }

});