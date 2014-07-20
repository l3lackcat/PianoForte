'use strict';

goog.provide('PianoForte.Controllers.Books.RegisterController');

PianoForte.Controllers.Books.RegisterController = function ($scope, $rootScope, $location, BookService, Enum, ValidationManager) {    
    $scope['data'] = null;
    $scope['visible'] = false;
    $scope['isOnInsertData'] = false;

    $scope.$on('InsertNewBook', function (scope) {
        $scope['data'] = {
            'id': {
                'value': 0,
                'isRequired': false,
                'isValid': true
            },
            'barcode': {
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'name': {
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'unitPrice': {
                'value': 0,
                'isRequired': true,
                'isValid': true
            },
            'quantity': {
                'value': 0,
                'isRequired': false,
                'isValid': true
            },
            'status': {
                'value': Enum.Status.Empty,
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['visible'] = true;        
    } .bind(this), true);

    $scope.submit = function () {
        if (validateData() === true) {
            $scope['isOnInsertData'] = true;

            if ($scope['data']['quantity']['value'] === '') {
                    $scope['data']['quantity']['value'] = 0;                    
                }

                if ($scope['data']['quantity']['value'] == 0) {
                    $scope['data']['status']['value'] = Enum.Status.Empty;
                } else {                   
                    if ($scope['data']['status']['value'] === Enum.Status.Empty) {
                        $scope['data']['status']['value'] = Enum.Status.Available;
                    }
                }

            BookService.insertBookInfo($scope['data'], onSuccessInsertData, onErrorInsertData);
        }
    };

    $scope.cancel = function () {
        hideDialogBox();
    };    

    function hideDialogBox() {        
        $scope['data'] = null;
        $scope['visible'] = false;
        $scope['isOnInsertData'] = false;
    };

    function validateData () {
        var isValid = true;
        var barcodeObj = $scope['data']['barcode'];
        var nameObj = $scope['data']['name'];
        var unitPriceObj = $scope['data']['unitPrice'];

        barcodeObj.isValid = ValidationManager.validate('name', barcodeObj.value);
        nameObj.isValid = ValidationManager.validate('name', nameObj.value);
        unitPriceObj.isValid = ValidationManager.validate('name', unitPriceObj.value);

        return barcodeObj.isValid && nameObj.isValid && unitPriceObj.isValid;
    };

    var onSuccessInsertData = function (data, status, headers, config) {
        var bookId = data.d;

        if (bookId !== 0) {
            $location.path("/books/" + bookId);
            $scope.$apply();
        } else {
            onErrorInsertData(data, status, headers, config);
        }        
    };

    var onErrorInsertData = function (data, status, headers, config) {
        $scope['isOnInsertData'] = false;
        console.log('onErrorInsertData');
    };
};