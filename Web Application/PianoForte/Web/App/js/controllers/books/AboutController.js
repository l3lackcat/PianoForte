'use strict';

goog.provide('PianoForte.Controllers.Books.AboutController');

PianoForte.Controllers.Books.AboutController = function ($scope, $rootScope, $location, $routeParams, BookService, Enum, EnumConverter, FormatManager, ValidationManager) {
    $scope['EnumConverter'] = EnumConverter;
	$scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['book'] = null;

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'books');

        $scope['isReady'] = false;
        $scope['book'] = null;

        BookService.getBookInfoById($routeParams['bookId'], onSuccessReceiveBookInfoById, onErrorReceiveBookInfoById);
    };

    $scope.returnToMain = function () {
        $location.path("/books");
    };

    $scope.onEditBookInfo = function () {
        $rootScope.$broadcast('EditBookGeneralInfo', $scope['book']);
    };

    $scope.$on('UpdateBookGeneralInfo', function (scope, book) {
        if ($scope['book'] !== null) {
            $scope['book']['barcode'] = book.barcode;
            $scope['book']['name'] = book.name;
            $scope['book']['unitPrice'] = book.unitPrice;
            $scope['book']['quantity'] = book.quantity;
            $scope['book']['status']= book.status;
        }            
    } .bind(this), true);

    var onSuccessReceiveBookInfoById = function(data, status, headers, config) {
    	var tempBook = data.d;

        if (tempBook !== null) {
            $scope['book'] = {
                'id': tempBook.id,
                'barcode': tempBook.barcode,
                'name': tempBook.name,
                'unitPrice': tempBook.unitPrice,
                'quantity': tempBook.quantity,
                'status': tempBook.status               
            };
			
			$scope['isReady'] = true;           
        }
    };

    var onErrorReceiveBookInfoById = function(data, status, headers, config) {
    	console.log('onErrorReceiveBookInfoById');
    };
};