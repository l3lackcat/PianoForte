'use strict';

goog.provide('PianoForte.Controllers.Courses.AboutController');

PianoForte.Controllers.Courses.AboutController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'courses');
    };
};