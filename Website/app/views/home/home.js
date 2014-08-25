'use strict';

angular.module('pianoforte')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'views/home/home.html',
                controller: 'HomeCtrl'
            });
    });