'use strict';

goog.provide('PianoForte.Controllers.Cds.GeneralInfoEditorController');

PianoForte.Controllers.Cds.GeneralInfoEditorController = function ($scope, $rootScope, CdService, Enum, EnumConverter, ValidationManager) {    
    $scope['edittedData'] = null;
    $scope['visible'] = false;
    $scope['isOnUpdateEdittedData'] = false;
    $scope['statusList'] = [
        { 'id': Enum.Status.Available, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Empty, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Cancelled, 'text': '', 'excluded': false }
    ];

    var _generalInfo = null;

    $scope.$on('EditCdGeneralInfo', function (scope, cd) {
        initStatusList();

        _generalInfo = cd;
        $scope['edittedData'] = {
            'id': {
                'value': cd.id,
                'isRequired': false,
                'isValid': true
            },
            'barcode': {
                'value': cd.barcode,
                'isRequired': true,
                'isValid': true
            },
            'name': {
                'value': cd.name,
                'isRequired': true,
                'isValid': true
            },
            'unitPrice': {
                'value': cd.unitPrice,
                'isRequired': true,
                'isValid': true
            },
            'quantity': {
                'value': cd.quantity,
                'isRequired': false,
                'isValid': true
            },
            'status': {
                'value': cd.status,
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['visible'] = true;        
    } .bind(this), true);

    $scope.submit = function () {
        if (validateEdittedData() === true) {
            var isDifferent = compare(_generalInfo, $scope['edittedData']);
            if (isDifferent === true) {
                $scope['isOnUpdateEdittedData'] = true;

                if ($scope['edittedData']['quantity']['value'] === '') {
                    $scope['edittedData']['quantity']['value'] = 0;                    
                }

                if ($scope['edittedData']['quantity']['value'] == 0) {
                    $scope['edittedData']['status']['value'] = Enum.Status.Empty;
                } else {                   
                    if ($scope['edittedData']['status']['value'] === Enum.Status.Empty) {
                        $scope['edittedData']['status']['value'] = Enum.Status.Available;
                    }
                }

                CdService.updateCdInfo($scope['edittedData'], onSuccessUpdateEdittedData, onErrorUpdateEdittedData);
            } else {
                hideDialogBox();
            }
        }
    };

    $scope.cancel = function () {
        hideDialogBox();
    };    

    function initStatusList() {
        for(var i = $scope['statusList'].length - 1; i >= 0; i--) {
            var status = $scope['statusList'][i];

            status.text = EnumConverter.Status.toString(status.id);
        }
    };

    function hideDialogBox() {        
        $scope['edittedData'] = null;
        $scope['visible'] = false;
        $scope['isOnUpdateEdittedData'] = false;

        _generalInfo = null;
    };

    function validateEdittedData () {
        var isValid = true;
        var barcodeObj = $scope['edittedData']['barcode'];
        var nameObj = $scope['edittedData']['name'];
        var unitPriceObj = $scope['edittedData']['unitPrice'];

        barcodeObj.isValid = ValidationManager.validate('name', barcodeObj.value);
        nameObj.isValid = ValidationManager.validate('name', nameObj.value);
        unitPriceObj.isValid = ValidationManager.validate('name', unitPriceObj.value);

        return barcodeObj.isValid && nameObj.isValid && unitPriceObj.isValid;
    };

    function compare(oldGeneralInfo, newGeneralInfo) {
        var isChanged = false;

        if ((oldGeneralInfo.barcode !== newGeneralInfo.barcode.value) ||
            (oldGeneralInfo.name !== newGeneralInfo.name.value) ||
            (oldGeneralInfo.unitPrice !== newGeneralInfo.unitPrice.value) ||
            (oldGeneralInfo.quantity !== newGeneralInfo.quantity.value) ||
            (oldGeneralInfo.status !== newGeneralInfo.status.value)) {
            isChanged = true;
        }

        return isChanged;
    };

    var onSuccessUpdateEdittedData = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            _generalInfo.barcode = $scope['edittedData']['barcode']['value'];
            _generalInfo.name = $scope['edittedData']['name']['value'];
            _generalInfo.unitPrice = $scope['edittedData']['unitPrice']['value'];
            _generalInfo.quantity = $scope['edittedData']['quantity']['value'];
            _generalInfo.status = $scope['edittedData']['status']['value'];

            $rootScope.$broadcast('UpdateCdGeneralInfo', _generalInfo);

            hideDialogBox();
        } else {
            onErrorUpdateEdittedData(data, status, headers, config);
        }        
    };

    var onErrorUpdateEdittedData = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedData'] = false;
        console.log('onErrorUpdateEdittedData');
    };
};