'use strict';

goog.provide('PianoForte.Services.StudentService');

PianoForte.Services.StudentService = function ($http) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getStudentListSize: function(onSuccess, onError) {
            var data = {
                'databaseName': databaseName
            };

            $http.post('/WebServices/StudentWebService.asmx/getStudentListSize', data).success(onSuccess).error(onError);
        },

        getStudentList: function (startIndex, offset, onSuccess, onError) {
            var data = {
                'databaseName': databaseName,
                'startIndex': startIndex,
                'offset': offset
            };

            $http.post('/WebServices/StudentWebService.asmx/getStudentList', data).success(onSuccess).error(onError);
        },

        getStudentInfoById: function (id, onSuccess, onError) {
            var data = {
                'databaseName': databaseName,
                'id': id
            };

            $http.post('/WebServices/StudentWebService.asmx/getStudentById', data).success(onSuccess).error(onError);
        }
    }
};