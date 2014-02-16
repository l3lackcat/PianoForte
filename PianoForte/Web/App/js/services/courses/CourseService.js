'use strict';

goog.provide('PianoForte.Services.CourseService');

PianoForte.Services.CourseService = function ($http) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getCourseNameList: function (status, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                status: status
            };

            $http.post('/WebServices/CourseWebService.asmx/getCourseNameList', data).success(onSuccess).error(onError);
        }
    }
};