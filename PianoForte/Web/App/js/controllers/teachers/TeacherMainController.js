'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherMainController');

PianoForte.Controllers.Teachers.TeacherMainController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');
    };
};