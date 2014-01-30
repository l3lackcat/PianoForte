'use strict';

goog.provide('PianoForte.Controllers.Books.BookMainController');

PianoForte.Controllers.Books.BookMainController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'books');
    };
};