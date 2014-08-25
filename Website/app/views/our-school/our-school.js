'use strict';

angular.module('pianoforte')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/our-school', {
                templateUrl: 'views/our-school/our-school.html',
                controller: 'OurSchoolCtrl'
            });
    });