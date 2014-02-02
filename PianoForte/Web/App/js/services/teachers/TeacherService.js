'use strict';

goog.provide('PianoForte.Services.Teachers.TeacherService');

PianoForte.Services.Teachers.TeacherService = function ($http) {
    return {
        getTeacherInfoById: function (teacherId, onSuccess, onError) {
            var data = {
                'databaseName': 'pianoforte_b01',
                'teacherId': teacherId
            };

            $http.post('/WebServices/TeacherWebService.asmx/getTeacherById', data).success(onSuccess).error(onError);
        },

        saveTeacherGeneralInfo: function (teacher, onSuccess, onError) {
            var data = {
                'databaseName': 'pianoforte_b01',
                'teacher': {
                    'Id': teacher['id']['value'],
                    'Firstname': teacher['firstname']['value'],
                    'Lastname': teacher['lastname']['value'],
                    'Nickname': teacher['nickname']['value'],
                    'Status': teacher['status']['value']['key']
                }
            };

            $http.post('/WebServices/TeacherWebService.asmx/saveTeacherGeneralInfo', data).success(onSuccess).error(onError);
        }
    }
};