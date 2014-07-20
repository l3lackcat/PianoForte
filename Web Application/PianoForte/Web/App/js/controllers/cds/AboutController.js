'use strict';

goog.provide('PianoForte.Controllers.Cds.AboutController');

PianoForte.Controllers.Cds.AboutController = function ($scope, $rootScope, $location, $routeParams, CdService, Enum, EnumConverter, FormatManager, ValidationManager) {
	$scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['cd'] = null;

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'cds');

        $scope['isReady'] = false;
        $scope['cd'] = null;

        CdService.getCdInfoById($routeParams['cdId'], onSuccessReceiveCdInfoById, onErrorReceiveCdInfoById);
    };

    $scope.returnToMain = function () {
        $location.path("/cds");
    };

    $scope.onEditCdInfo = function () {
        $rootScope.$broadcast('EditCdGeneralInfo', $scope['cd']);
    };

    $scope.$on('UpdateCdGeneralInfo', function (scope, cd) {
        if ($scope['cd'] !== null) {
            $scope['cd']['barcode'] = cd.barcode;
            $scope['cd']['name'] = cd.name;
            $scope['cd']['unitPrice'] = cd.unitPrice;
            $scope['cd']['quantity'] = cd.quantity;
            $scope['cd']['status']= cd.status;
        }            
    } .bind(this), true);

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
};