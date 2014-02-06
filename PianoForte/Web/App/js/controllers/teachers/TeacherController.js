'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherController');

//goog.require('PianoForte.Enum');
//goog.require('PianoForte.Utilities.EnumConverter');
//goog.require('PianoForte.Services.Teachers.TeacherService');

PianoForte.Controllers.Teachers.TeacherController = function ($scope, $rootScope, $routeParams, Enum, EnumConverter, TeacherService) {
    $scope['isReady'] = false;
    $scope['isOnEditGeneralInfo'] = false;
    $scope['teacher'] = null;
    $scope['edittedGeneralInfo'] = null;
    $scope['isOnSaveEdittedGeneralInfo'] = false;

    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope['isReady'] = false;
        $scope['teacher'] = {
            'id': {
                'label': 'รหัสประจำตัว',
                'value': ''
            },
            'firstname': {
                'label': 'ชื่อ',
                'value': ''
            },
            'lastname': {
                'label': 'นามสกุล',
                'value': ''
            },
            'nickname': {
                'label': 'ชื่อเล่น',
                'value': ''
            },
            'status': {
                'label': 'สถานะ',
                'value': {
                    'key': '',
                    'displayString': ''
                }
            },
            'contacts': {
                'phones': [],
                'emails': []
            },
            'teachedCourses': []
        };

        TeacherService.getTeacherInfoById($routeParams['teacherId'], onSuccessReceiveTeacherInfoById, onErrorReceiveTeacherInfoById);
    };

    $scope.onEditGeneralInfo = function () {
        $scope['edittedGeneralInfo'] = {
            'id': {
                'label': $scope['teacher']['id']['label'],
                'value': $scope['teacher']['id']['value'],
                'isRequired': false,
                'isValid': true
            },
            'firstname': {
                'label': $scope['teacher']['firstname']['label'],
                'value': $scope['teacher']['firstname']['value'],
                'isRequired': true,
                'isValid': true
            },
            'lastname': {
                'label': $scope['teacher']['lastname']['label'],
                'value': $scope['teacher']['lastname']['value'],
                'isRequired': true,
                'isValid': true
            },
            'nickname': {
                'label': $scope['teacher']['nickname']['label'],
                'value': $scope['teacher']['nickname']['value'],
                'isRequired': false,
                'isValid': true
            },
            'status': {
                'label': $scope['teacher']['status']['label'],
                'value': {
                    'key': $scope['teacher']['status']['value']['key'],
                    'displayString': $scope['teacher']['status']['value']['displayString']
                },
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['isOnEditGeneralInfo'] = true;
    };

    $scope.onSubmitEditGeneralInfo = function () {
        if (validateGeneralInfo() === true) {
            if (isGeneralInfoChanged() === true) {
                $scope['isOnSaveEdittedGeneralInfo'] = true;
                TeacherService.saveTeacherGeneralInfo($scope['edittedGeneralInfo'], onSuccessSaveTeacherGeneralInfo, onErrorSaveTeacherGeneralInfo);
            } else {
                hideGeneralInfoDialogBox();
            }
        }
    };

    $scope.onCancelEditGeneralInfo = function () {
        hideGeneralInfoDialogBox();
    };

    $scope.onEditContactInfo = function () {
        alert('onEditContactInfo');
    };

    function hideGeneralInfoDialogBox() {
        $scope['edittedGeneralInfo'] = null;
        $scope['isOnEditGeneralInfo'] = false;
    };

    function validateGeneralInfo() {
        var isValid = true;

        if ($scope['edittedGeneralInfo']['firstname']['value'] === '') {
            $scope['edittedGeneralInfo']['firstname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedGeneralInfo']['firstname']['isValid'] = true;            
        }

        if ($scope['edittedGeneralInfo']['lastname']['value'] === '') {
            $scope['edittedGeneralInfo']['lastname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['edittedGeneralInfo']['lastname']['isValid'] = true;
        }

        return isValid;
    };

    function isGeneralInfoChanged() {
        var isChanged = false;

        if (($scope['teacher']['firstname']['value'] !== $scope['edittedGeneralInfo']['firstname']['value']) ||
            ($scope['teacher']['lastname']['value'] !== $scope['edittedGeneralInfo']['lastname']['value']) ||
            ($scope['teacher']['nickname']['value'] !== $scope['edittedGeneralInfo']['nickname']['value'])) {
            isChanged = true;
        }

        return isChanged;
    };

    var onSuccessReceiveTeacherInfoById = function (data, status, headers, config) {
        var tempTeacher = data.d;

        if (tempTeacher !== null) {
            $scope['teacher']['id']['value'] = tempTeacher['Id'];
            $scope['teacher']['firstname']['value'] = tempTeacher['Firstname'];
            $scope['teacher']['lastname']['value'] = tempTeacher['Lastname'];
            $scope['teacher']['nickname']['value'] = tempTeacher['Nickname'];

            $scope['teacher']['status']['value']['key'] = tempTeacher['Status'];
            $scope['teacher']['status']['value']['displayString'] = EnumConverter['Status'].toString(tempTeacher['Status']);
            $scope['teacher']['teachedCourses'] = tempTeacher['TeachedCourseList'];
            
            for (var i = 0; i < tempTeacher['ContactList'].length; i++) {
                var contact = tempTeacher['ContactList'][i];
                
                if (contact['Type'] === Enum['ContactType']['Phone']) {
                    $scope['teacher']['contacts']['phones'].push({
                        'id': contact['Id'],
                        'label': contact['Label'],
                        'value': contact['Content']
                    });
                }

                if (contact['Type'] === Enum['ContactType']['Email']) {
                    $scope['teacher']['contacts']['emails'].push({
                        'id': contact['Id'],
                        'label': contact['Label'],
                        'value': contact['Content']
                    });
                }
            }
            
            $scope['isReady'] = true;
        }
    };

    var onErrorReceiveTeacherInfoById = function (data, status, headers, config) {
        console.log('onErrorReceiveTeacherInfoById');
    };

    var onSuccessSaveTeacherGeneralInfo = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            $scope['teacher']['firstname']['value'] = $scope['edittedGeneralInfo']['firstname']['value'];
            $scope['teacher']['lastname']['value'] = $scope['edittedGeneralInfo']['lastname']['value'];
            $scope['teacher']['nickname']['value'] = $scope['edittedGeneralInfo']['nickname']['value'];

            hideGeneralInfoDialogBox();
        } else {
            onErrorSaveTeacherGeneralInfo(data, status, headers, config);
        }

        $scope['isOnSaveEdittedGeneralInfo'] = false;
    };

    var onErrorSaveTeacherGeneralInfo = function (data, status, headers, config) {
        $scope['isOnSaveEdittedGeneralInfo'] = false;
        console.log('onErrorSaveTeacherGeneralInfo');
    };
};