'use strict';

goog.provide('PianoForte.Controllers.Cds.CdController');

PianoForte.Controllers.Cds.CdController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'cds');
    };
};