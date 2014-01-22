'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherController');

goog.require('PianoForte.Enum');
goog.require('PianoForte.Utilities.EnumConverter');
goog.require('PianoForte.Services.Teachers.TeacherService');

PianoForte.Controllers.Teachers.TeacherController = function ($scope, $routeParams, Enum, EnumConverter, TeacherService) {
    $scope['isReady'] = false;
    $scope['isOnEditGeneralInfo'] = false;
    $scope['teacher'] = {
        id: {
            label: 'รหัสประจำตัว',
            value: ''
        },
        firstname: {
            label: 'ชื่อ',
            value: ''
        },
        lastname: {
            label: 'นามสกุล',
            value: ''
        },
        nickname: {
            label: 'ชื่อเล่น',
            value: ''
        },
        status: {
            label: 'สถานะ',
            value: {
                key: '',
                displayString: ''
            }
        },
        contacts: {
            phones: [],
            emails: []
        },
        teachedCourses: []
    };

    $scope.init = function () {
        $scope['isReady'] = false;
        $scope.requestTeacherInfoById($routeParams.teacherId);
    };

    $scope.requestTeacherInfoById = function (teacherId) {
        TeacherService.getTeacherInfoById(teacherId, $scope.onSuccessReceiveTeacherInfoById, $scope.onErrorReceiveTeacherInfoById);
    };

    $scope.onSuccessReceiveTeacherInfoById = function (data, status, headers, config) {
        var tempTeacher = data.d;

        if (tempTeacher !== null) {
            $scope['teacher']['id']['value'] = tempTeacher.Id;
            $scope['teacher']['firstname']['value'] = tempTeacher.Firstname;
            $scope['teacher']['lastname']['value'] = tempTeacher.Lastname;
            $scope['teacher']['nickname']['value'] = tempTeacher.Nickname;

            $scope['teacher']['status']['value']['key'] = tempTeacher.Status;
            $scope['teacher']['status']['value']['displayString'] = EnumConverter.Status.toString(tempTeacher.Status);
            $scope['teacher']['teachedCourses'] = tempTeacher.TeachedCourseList;

            for (var i = 0; i < tempTeacher.ContactList.length; i++) {
                var contact = tempTeacher.ContactList[i];

                if (contact.Type === Enum.ContactType.Phone) {
                    $scope['teacher']['contacts']['phones'].push({
                        id: contact.Id,
                        label: contact.Label,
                        value: contact.Content
                    });
                }

                if (contact.Type === Enum.ContactType.Email) {
                    $scope['teacher']['contacts']['emails'].push({
                        id: contact.Id,
                        label: contact.Label,
                        value: contact.Content
                    });
                }
            }

            $scope['isReady'] = true;
        }
    };

    $scope.onErrorReceiveTeacherInfoById = function (data, status, headers, config) {
        console.log('onErrorReceiveTeacherInfoById');
    };

    $scope.onStartEditGeneralInfo = function () {
        $scope['isOnEditGeneralInfo'] = true;
    };

    $scope.onFinishEditGeneralInfo = function () {
        $scope['isOnEditGeneralInfo'] = false;
    };

    $scope.onEditContactInfo = function () {
        alert('onEditContactInfo');
    };
}