'use strict';

goog.provide('PianoForte.Controllers.Cds.CdController');

PianoForte.Controllers.Cds.CdController = function ($scope, $rootScope, $routeParams, CdService, Enum, EnumConverter, ValidationManager, FormatManager) {
	$scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['cd'] = null;

    $scope['edittedCdInfo'] = null;
    $scope['isOnEditCdInfo'] = false;
    $scope['isOnUpdateEdittedCdInfo'] = false;

    $scope['statusList'] = [
        { 'id': Enum.Status.Available, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Empty, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Cancelled, 'text': '', 'excluded': false }
    ];

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'cds');

        $scope['isReady'] = false;
        $scope['cd'] = null;

        initStatusList();

        CdService.getCdInfoById($routeParams['cdId'], onSuccessReceiveCdInfoById, onErrorReceiveCdInfoById);
    };

    $scope.onEditCdInfo = function () {
        $scope['edittedCdInfo'] = {
            'id': {
                'value': $scope['cd']['id'],
                'isRequired': false,
                'isValid': true
            },
            'barcode': {
                'value': $scope['cd']['barcode'],
                'isRequired': true,
                'isValid': true
            },
            'name': {
                'value': $scope['cd']['name'],
                'isRequired': true,
                'isValid': true
            },
            'unitPrice': {
                'value': $scope['cd']['unitPrice'],
                'isRequired': true,
                'isValid': true
            },
            'quantity': {
                'value': $scope['cd']['quantity'],
                'isRequired': false,
                'isValid': true
            },
            'status': {
                'value': $scope['cd']['status'],
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['isOnEditCdInfo'] = true;
    };

    $scope.onSubmitEditCdInfo = function () {
        if (validateCdInfo() === true) {
            if (isCdInfoChanged() === true) {
                $scope['isOnUpdateEdittedCdInfo'] = true;

                if ($scope['edittedCdInfo']['quantity']['value'] === '') {
                    $scope['edittedCdInfo']['quantity']['value'] = 0;                    
                }

                if ($scope['edittedCdInfo']['quantity']['value'] == 0) {
                    $scope['edittedCdInfo']['status']['value'] = Enum.Status.Empty;
                } else {                   
                    if ($scope['edittedCdInfo']['status']['value'] === Enum.Status.Empty) {
                        $scope['edittedCdInfo']['status']['value'] = Enum.Status.Available;
                    }
                }

                CdService.updateCdInfo($scope['edittedCdInfo'], onSuccessUpdateCdInfo, onErrorUpdateCdInfo);
            } else {
                hideCdInfoDialogBox();
            }
        }
    };

    $scope.onCancelEditCdInfo = function () {
        hideCdInfoDialogBox();
    };

    function initStatusList() {
        for(var i = $scope['statusList'].length - 1; i >= 0; i--) {
            var status = $scope['statusList'][i];

            status.text = EnumConverter.Status.toString(status.id);
        };
    }

    function validateCdInfo() {
        var isValid = true;

        if ($scope['edittedCdInfo']['barcode']['value'] === '') {
            $scope['edittedCdInfo']['barcode']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedCdInfo']['barcode']['isValid'] = true;
        }

        if ($scope['edittedCdInfo']['name']['value'] === '') {
            $scope['edittedCdInfo']['name']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedCdInfo']['name']['isValid'] = true;
        }

        if ($scope['edittedCdInfo']['unitPrice']['value'] === '') {
            $scope['edittedCdInfo']['unitPrice']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedCdInfo']['unitPrice']['isValid'] = true;
        }

        return isValid;
    };

    function isCdInfoChanged() {
        var isChanged = false;

        if (($scope['cd']['barcode'] !== $scope['edittedCdInfo']['barcode']['value']) ||
            ($scope['cd']['name'] !== $scope['edittedCdInfo']['name']['value']) ||
            ($scope['cd']['unitPrice'] !== $scope['edittedCdInfo']['unitPrice']['value']) ||
            ($scope['cd']['quantity'] !== $scope['edittedCdInfo']['quantity']['value']) ||
            ($scope['cd']['status'] !== $scope['edittedCdInfo']['status']['value'])) {
            isChanged = true;
        }

        return isChanged;
    }; 

    function hideCdInfoDialogBox() {
        $scope['edittedCdInfo'] = null;
        $scope['isOnEditCdInfo'] = false;
        $scope['isOnUpdateEdittedCdInfo'] = false;
    };

    var onSuccessReceiveCdInfoById = function(data, status, headers, config) {
    	var tempCd = data.d;

        if (tempCd !== null) {
            $scope['cd'] = {
                'id': tempCd.id,
                'barcode': tempCd.barcode,
                'name': tempCd.name,
                'unitPrice': tempCd.unitPrice,
                'quantity': tempCd.quantity,
                'status': tempCd.status
            };
			
			$scope['isReady'] = true;           
        }
    };

    var onErrorReceiveCdInfoById = function(data, status, headers, config) {
    	console.log('onErrorReceiveCdInfoById');
    };

    var onSuccessUpdateCdInfo = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            $scope['cd']['barcode'] = $scope['edittedCdInfo']['barcode']['value'];
            $scope['cd']['name'] = $scope['edittedCdInfo']['name']['value'];
            $scope['cd']['unitPrice'] = $scope['edittedCdInfo']['unitPrice']['value'];
            $scope['cd']['quantity'] = $scope['edittedCdInfo']['quantity']['value'];
            $scope['cd']['status'] = $scope['edittedCdInfo']['status']['value'];

            hideCdInfoDialogBox();
        } else {
            onErrorUpdateCdInfo(data, status, headers, config);
        }        
    };

    var onErrorUpdateCdInfo = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedCdInfo'] = false;
        console.log('onErrorUpdateCdInfo');
    };
};