'use strict';

goog.provide('PianoForte.Services.CdService');

PianoForte.Services.CdService = function($http, FormatManager) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getCdList: function(onSuccess, onError) {
            var data = {
                databaseName: databaseName
            };

            $http.post('/WebServices/CdWebService.asmx/getCdList', data).success(onSuccess).error(onError);
        },

        getCdInfoById: function(id, onSuccess, onError) {
        	var data = {
                databaseName: databaseName,
                id: id
            };

            $http.post('/WebServices/CdWebService.asmx/getCdById', data).success(onSuccess).error(onError);
        },

        getCdInfoByBarcode: function(barcode, onSuccess, onError) {
        	var data = {
                databaseName: databaseName,
                barcode: barcode
            };

            $http.post('/WebServices/CdWebService.asmx/getCdByBarcode', data).success(onSuccess).error(onError);
        },

        updateCdInfo: function (cd, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                cd: {
                    Id: cd.id.value,
                    Barcode: cd.barcode.value,
                    Name: cd.name.value,
                    UnitPrice: FormatManager.unformatNumber(cd.unitPrice.value),
                    Quantity: FormatManager.unformatNumber(cd.quantity.value),
                    Status: cd.status.value
                }
            };

            $http.post('/WebServices/CdWebService.asmx/updateCdInfo', data).success(onSuccess).error(onError);
        },
    }
};