'use strict';

goog.provide('PianoForte.Controllers.Students.StudentController');

PianoForte.Controllers.Students.StudentController = function ($scope, $rootScope, $routeParams, StudentService, Enum, EnumConverter, FormatManager, ValidationManager) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'students');
    };
};