'use strict';

goog.provide('PianoForte.Controllers.Cds.CdMainController');

PianoForte.Controllers.Cds.CdMainController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'cds');
    };
};