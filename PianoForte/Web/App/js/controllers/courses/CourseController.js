'use strict';

goog.provide('PianoForte.Controllers.Courses.CourseController');

PianoForte.Controllers.Courses.CourseController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'courses');
    };
};