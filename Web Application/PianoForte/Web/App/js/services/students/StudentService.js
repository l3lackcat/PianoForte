'use strict';

goog.provide('PianoForte.Services.StudentService');

PianoForte.Services.StudentService = function ($http) {
    var databaseName = 'pianoforte_b01';
    
    return {
        getStudentList: function (onSuccess, onError) {
            var data = {
                databaseName: databaseName
            };

            $http.post('/WebServices/StudentWebService.asmx/getStudentList', data).success(onSuccess).error(onError);
        },

        getStudentInfoById: function (teacherId, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherId: teacherId
            };

            $http.post('/WebServices/StudentWebService.asmx/getStudentById', data).success(onSuccess).error(onError);
        },

        updateStudentGeneralInfo: function (teacher, onSuccess, onError) {
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

            $http.post('/WebServices/StudentWebService.asmx/updateStudentGeneralInfo', data).success(onSuccess).error(onError);
        },

        insertStudentContactInfo: function (contact, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherContact: {
                    Id: contact.id,
                    Type: contact.type,
                    Label: contact.label,
                    Content: contact.value,
                    Status: contact.status,
                    IsPrimary: contact.isPrimary,
                    StudentId: contact.teacherId
                }
            };

            $http.post('/WebServices/StudentWebService.asmx/insertStudentContactInfo', data).success(onSuccess).error(onError);
        },

        updateStudentContactInfo: function (contact, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherContact: {
                    Id: contact.id,
                    Type: contact.type,
                    Label: contact.label,
                    Content: contact.value,
                    Status: contact.status,
                    IsPrimary: contact.isPrimary,
                    StudentId: contact.teacherId
                }
            };

            $http.post('/WebServices/StudentWebService.asmx/updateStudentContactInfo', data).success(onSuccess).error(onError);
        },

        deleteStudentContactInfo: function (contact, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherContact: {
                    Id: contact.id,
                    Type: contact.type,
                    Label: contact.label,
                    Content: contact.value,
                    Status: contact.status,
                    IsPrimary: contact.isPrimary,
                    StudentId: contact.teacherId
                }
            };

            $http.post('/WebServices/StudentWebService.asmx/deleteStudentContactInfo', data).success(onSuccess).error(onError);
        },

        updateTeachedCourseInfo: function (teacherId, teachedCourseNameList, onSuccess, onError) {
            var data = {
                databaseName: databaseName,
                teacherId: teacherId,
                teachedCourseNameList: teachedCourseNameList
            };

            $http.post('/WebServices/StudentWebService.asmx/updateTeachedCourseInfo', data).success(onSuccess).error(onError);
        }
    }
};