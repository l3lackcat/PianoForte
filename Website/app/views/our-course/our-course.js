'use strict';

angular.module('pianoforte')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/our-course', {
                templateUrl: 'views/our-course/our-course.html',
                controller: 'OurCourseCtrl'
            });
    });