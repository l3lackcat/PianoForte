'use strict';

goog.provide('PianoForte.Controllers.Books.BookController');

PianoForte.Controllers.Books.BookController = function ($scope, $rootScope) {
    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'books');
    };
};