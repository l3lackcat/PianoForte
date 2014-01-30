'use strict';

goog.provide('PianoForte.Controllers.Courses.CourseMainController');

PianoForte.Controllers.Courses.CourseMainController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'courses');
    };
};