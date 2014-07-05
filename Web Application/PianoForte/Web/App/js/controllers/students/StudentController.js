'use strict';

goog.provide('PianoForte.Controllers.Students.StudentController');

PianoForte.Controllers.Students.StudentController = function ($scope, $rootScope, $routeParams, StudentService, Enum, EnumConverter, ValidationManager, FormatManager) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'students');
    };
};