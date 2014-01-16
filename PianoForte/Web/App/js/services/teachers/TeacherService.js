'use strict';

goog.provide('PianoForte.Services.Teachers.TeacherService');

PianoForte.Services.Teachers.TeacherService = function ($http) {
    return {
        getTeacherInfoById: function (teacherId, onSuccess, onError) {
            var data = {
                databaseName: 'pianoforte_b01',
                teacherId: teacherId
            };

            $http.post('/WebServices/TeacherWebService.asmx/getTeacherById', data).success(onSuccess).error(onError);
        }
    }
}