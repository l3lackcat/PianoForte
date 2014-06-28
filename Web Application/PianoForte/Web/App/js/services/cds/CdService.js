'use strict';

goog.provide('PianoForte.Services.CdService');

PianoForte.Services.CdService = function ($http) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getCdList: function (onSuccess, onError) {
            var data = {
                databaseName: databaseName
            };

            $http.post('/WebServices/CdWebService.asmx/getCdList', data).success(onSuccess).error(onError);
        }
    }
};