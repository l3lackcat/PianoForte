'use strict';

angular.module('pianoforte')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/contact-us', {
                templateUrl: 'views/contact-us/contact-us.html',
                controller: 'ContactUsCtrl'
            });
    });