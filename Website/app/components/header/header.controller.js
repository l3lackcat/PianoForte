'use strict';

angular.module('pianoforte')
    .controller('HeaderCtrl', function ($scope, $location) {
        $scope.isActive = function(route) {
            var paths = $location.path().split('/');
            var path = '/' + paths[1];

            return route === path;
        };
    });