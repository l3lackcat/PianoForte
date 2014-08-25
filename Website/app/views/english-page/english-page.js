'use strict';

angular.module('pianoforte')
    .config(function ($routeProvider) {
        $routeProvider
            .when('/english-page', {
                templateUrl: 'views/english-page/english-page.html',
                controller: 'EnglishPageCtrl'
            });
    });