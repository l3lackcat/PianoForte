'use strict';

goog.provide('PianoForte.Controllers.Students.StudentMainController');

PianoForte.Controllers.Students.StudentMainController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'students');
    };
};