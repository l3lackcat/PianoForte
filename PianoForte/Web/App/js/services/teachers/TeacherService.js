'use strict';

goog.provide('PianoForte.Services.TeacherService');

PianoForte.Services.TeacherService = function ($http) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getTeacherList: function (onSuccess, onError) {
            var data = {
                databaseName: databaseName
            };

            $http.post('/WebServices/TeacherWebService.asmx/getTeacherList', data).success(onSuccess).error(onError);
        },

        getTeacherInfoById: function (teacherId, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherId: teacherId
            };

            $http.post('/WebServices/TeacherWebService.asmx/getTeacherById', data).success(onSuccess).error(onError);
        },

        updateTeacherGeneralInfo: function (teacher, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacher: {
                    Id: teacher.id.value,
                    Firstname: teacher.firstname.value,
                    Lastname: teacher.lastname.value,
                    Nickname: teacher.nickname.value,
                    Status: teacher.status.value.key
                }
            };

            $http.post('/WebServices/TeacherWebService.asmx/updateTeacherGeneralInfo', data).success(onSuccess).error(onError);
        },

        insertTeacherContactInfo: function (contact, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherContact: {
                    Id: contact.id,
                    Type: contact.type,
                    Label: contact.label,
                    Content: contact.value,
                    Status: contact.status,
                    TeacherId: contact.teacherId
                }
            };

            $http.post('/WebServices/TeacherWebService.asmx/insertTeacherContactInfo', data).success(onSuccess).error(onError);
        },

        updateTeacherContactInfo: function (contact, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherContact: {
                    Id: contact.id,
                    Type: contact.type,
                    Label: contact.label,
                    Content: contact.value,
                    Status: contact.status,
                    TeacherId: contact.teacherId
                }
            };

            $http.post('/WebServices/TeacherWebService.asmx/updateTeacherContactInfo', data).success(onSuccess).error(onError);
        },

        deleteTeacherContactInfo: function (contact, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherContact: {
                    Id: contact.id,
                    Type: contact.type,
                    Label: contact.label,
                    Content: contact.value,
                    Status: contact.status,
                    TeacherId: contact.teacherId
                }
            };

            $http.post('/WebServices/TeacherWebService.asmx/updateTeacherContactInfo', data).success(onSuccess).error(onError);
        },

        updateTeachedCourseInfo: function (teacherId, teachedCourseNameList, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherId: teacherId,
                teachedCourseNameList: teachedCourseNameList
            };

            $http.post('/WebServices/TeacherWebService.asmx/updateTeachedCourseInfo', data).success(onSuccess).error(onError);
        }
    }
};