define(['app'], function (app) {
    'use strict';

    app.registerController('contactController', contactController);

    contactController.$inject = ['$scope'];

    function contactController($scope) {
        $scope.pageClass = 'page-contact';
    }

});