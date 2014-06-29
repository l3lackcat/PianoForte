'use strict';

goog.provide('PianoForte.Controllers.Books.BookController');

PianoForte.Controllers.Books.BookController = function ($scope, $rootScope, $routeParams, BookService, Enum, EnumConverter, ValidationManager, FormatManager) {
	$scope.isReady = false;
    $scope.book = null;

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'books');

        $scope.isReady = false;
        $scope.book = null;

        BookService.getBookInfoById($routeParams.bookId, onSuccessReceiveBookInfoById, onErrorReceiveBookInfoById);
    };

    var onSuccessReceiveBookInfoById = function(data, status, headers, config) {
    	var tempBook = data.d;

        if (tempBook !== null) {
            $scope.book = {
                id: tempBook.id,
                barcode: tempBook.barcode,
                name: tempBook.name,
                unitPrice: tempBook.unitPrice,
                quantity: tempBook.quantity,
                status: {
                    key: tempBook.status,
                    text: EnumConverter.Status.toString(tempBook.status)
                }                
            };
			
			$scope.isReady = true;           
        }
    };

    var onErrorReceiveBookInfoById = function(data, status, headers, config) {
    	console.log('onErrorReceiveBookInfoById');
    };
};