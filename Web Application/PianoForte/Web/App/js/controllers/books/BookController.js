'use strict';

goog.provide('PianoForte.Controllers.Books.BookController');

PianoForte.Controllers.Books.BookController = function ($scope, $rootScope, $routeParams, BookService, Enum, EnumConverter, ValidationManager, FormatManager) {
	$scope['isReady'] = false;
    $scope['book'] = null;

    $scope['edittedBookInfo'] = null;
    $scope['isOnEditBookInfo'] = false;
    $scope['isOnUpdateEdittedBookInfo'] = false;

    $scope['statusList'] = [
        { 'id': Enum.Status.Available, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Empty, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Cancelled, 'text': '', 'excluded': false }
    ];

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'books');

        $scope['isReady'] = false;
        $scope['book'] = null;

        initStatusList();

        BookService.getBookInfoById($routeParams.bookId, onSuccessReceiveBookInfoById, onErrorReceiveBookInfoById);
    };

    $scope.onEditBookInfo = function () {
        $scope['edittedBookInfo'] = {
            id: {
                value: $scope['book']['id'],
                isRequired: false,
                isValid: true
            },
            barcode: {
                value: $scope['book']['barcode'],
                isRequired: true,
                isValid: true
            },
            name: {
                value: $scope['book']['name'],
                isRequired: true,
                isValid: true
            },
            unitPrice: {
                value: $scope['book']['unitPrice'],
                isRequired: false,
                isValid: true
            },
            quantity: {
                value: $scope['book']['quantity'],
                isRequired: false,
                isValid: true
            },
            status: {
                value: $scope['book']['status']['key'],
                isRequired: false,
                isValid: true
            }
        }

        $scope['isOnEditBookInfo'] = true;
    };

    $scope.onSubmitEditBookInfo = function () {
        if (validateBookInfo() === true) {
            if (isBookInfoChanged() === true) {
                $scope['isOnUpdateEdittedBookInfo'] = true;

                if ($scope['edittedBookInfo']['quantity']['value'] === '') {
                    $scope['edittedBookInfo']['quantity']['value'] = 0;                    
                }

                if ($scope['edittedBookInfo']['quantity']['value'] === 0) {
                    $scope['edittedBookInfo']['status']['value'] = Enum.Status.Empty;
                } else {
                    if ($scope['edittedBookInfo']['status']['value'] === Enum.Status.Empty) {
                        $scope['edittedBookInfo']['status']['value'] = Enum.Status.Available;
                    }
                }

                BookService.updateBookInfo($scope['edittedBookInfo'], onSuccessUpdateBookInfo, onErrorUpdateBookInfo);
            } else {
                hideBookInfoDialogBox();
            }
        }
    };

    $scope.onCancelEditBookInfo = function () {
        hideBookInfoDialogBox();
    };

    function initStatusList() {
        for(var i = $scope['statusList'].length - 1; i >= 0; i--) {
            var status = $scope['statusList'][i];

            status.text = EnumConverter.Status.toString(status.id);
        };
    }

    function validateBookInfo() {
        var isValid = true;

        if ($scope['edittedBookInfo']['barcode']['value'] === '') {
            $scope['edittedBookInfo']['barcode']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedBookInfo']['barcode']['isValid'] = true;
        }

        if ($scope['edittedBookInfo']['name']['value'] === '') {
            $scope['edittedBookInfo']['name']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedBookInfo']['name']['isValid'] = true;
        }

        if ($scope['edittedBookInfo']['unitPrice']['value'] === '') {
            $scope['edittedBookInfo']['unitPrice']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedBookInfo']['unitPrice']['isValid'] = true;
        }

        return isValid;
    };

    function isBookInfoChanged() {
        var isChanged = false;

        if (($scope['book']['barcode'] !== $scope['edittedBookInfo']['barcode']['value']) ||
            ($scope['book']['name'] !== $scope['edittedBookInfo']['name']['value']) ||
            ($scope['book']['unitPrice'] !== $scope['edittedBookInfo']['unitPrice']['value']) ||
            ($scope['book']['quantity'] !== $scope['edittedBookInfo']['quantity']['value']) ||
            ($scope['book']['status']['key'] !== $scope['edittedBookInfo']['status']['value'])) {
            isChanged = true;
        }

        return isChanged;
    }; 

    function hideBookInfoDialogBox() {
        $scope['edittedBookInfo'] = null;
        $scope['isOnEditBookInfo'] = false;
        $scope['isOnUpdateEdittedBookInfo'] = false;
    };

    var onSuccessReceiveBookInfoById = function(data, status, headers, config) {
    	var tempBook = data.d;

        if (tempBook !== null) {
            $scope['book'] = {
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
			
			$scope['isReady'] = true;           
        }
    };

    var onErrorReceiveBookInfoById = function(data, status, headers, config) {
    	console.log('onErrorReceiveBookInfoById');
    };

    var onSuccessUpdateBookInfo = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            $scope['book']['barcode'] = $scope['edittedBookInfo']['barcode']['value'];
            $scope['book']['name'] = $scope['edittedBookInfo']['name']['value'];
            $scope['book']['unitPrice'] = $scope['edittedBookInfo']['unitPrice']['value'];
            $scope['book']['quantity'] = $scope['edittedBookInfo']['quantity']['value'];
            $scope['book']['status']['key'] = $scope['edittedBookInfo']['status']['value'];
            $scope['book']['status']['text'] = EnumConverter.Status.toString($scope['edittedBookInfo']['status']['value']);

            hideBookInfoDialogBox();
        } else {
            onErrorUpdateBookInfo(data, status, headers, config);
        }        
    };

    var onErrorUpdateBookInfo = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedBookInfo'] = false;
        console.log('onErrorUpdateBookInfo');
    };
};