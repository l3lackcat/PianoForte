'use strict';

goog.provide('PianoForte.Controllers.Students.StudentController');

PianoForte.Controllers.Students.StudentController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'students');
    };
};