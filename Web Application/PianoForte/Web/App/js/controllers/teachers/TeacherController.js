'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherController');

PianoForte.Controllers.Teachers.TeacherController = function ($scope, $rootScope, $routeParams, TeacherService, CourseService, Enum, EnumConverter, FormatManager, ValidationManager) {
    $scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['teacher'] = null;
    $scope['courseNameList'] = null;
    $scope['subDistrictList'] = null;
    $scope['districtList'] = null;
    $scope['provinceList'] = null;

    $scope['edittedAddressInfo'] = null;
    $scope['isOnEditAddressInfo'] = false;
    $scope['isOnUpdateEdittedAddressInfo'] = false;

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope['isReady'] = false;
        $scope['teacher'] = null;
        $scope['courseNameList'] = null;
        $scope['subDistrictList'] = null;
        $scope['districtList'] = null;
        $scope['provinceList'] = null;        

        TeacherService.getTeacherInfoById($routeParams['teacherId'], onSuccessReceiveTeacherInfoById, onErrorReceiveTeacherInfoById);
        CourseService.getCourseNameList(Enum.Status.Active, onSuccessReceiveCourseNameList, onErrorReceiveCourseNameList);
    };

    $scope.onEditGeneralInfo = function () {
        $rootScope.$broadcast('EditTeacherGeneralInfo', $scope['teacher']);
    };

    $scope.$on('UpdateTeacherGeneralInfo', function (scope, teacher) {
        if ($scope['teacher'] !== null) {
            $scope['teacher']['firstname'] = teacher.firstname;
            $scope['teacher']['lastname'] = teacher.lastname;
            $scope['teacher']['nickname'] = teacher.nickname;
            $scope['teacher']['status'] = teacher.status;
        }            
    } .bind(this), true);

    $scope.onEditContactInfo = function () {
        $rootScope.$broadcast('EditTeacherContactInfo', $scope['teacher']['id'], $scope['teacher']['contacts']);
    };

    $scope.$on('UpdateTeacherContactInfo', function (scope, teacherId, contacts) {
        if ($scope['teacher'] !== null) {
            if ($scope['teacher']['id'] === teacherId) {
                $scope['teacher']['contacts']['emails'] = contacts.emails;
                $scope['teacher']['contacts']['phones'] = contacts.phones;
            }
        }            
    } .bind(this), true);

    $scope.onEditAddressInfo = function () {
        $scope['edittedAddressInfo'] = {
            'id': {
                // 'value': $scope['teacher']['address']['id'],
                'value': 0,
                'isRequired': false,
                'isValid': true
            },
            'buildingName': {
                // 'value': $scope['teacher']['address']['buildingName'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'streetAddress': {
                // 'value': $scope['teacher']['address']['streetAddress'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'subDistrict': {
                // 'value': $scope['teacher']['address']['subDistrict'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'district': {
                // 'value': $scope['teacher']['address']['district'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'province': {
                // 'value': $scope['teacher']['address']['province'],
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'postcode': {
                // 'value': $scope['teacher']['address']['postcode'],
                'value': '',
                'isRequired': true,
                'isValid': true
            }
        }

        $scope['isOnEditAddressInfo'] = true;
    };

    $scope.onEditTeachedCourseInfo = function () {
        $rootScope.$broadcast('EditTeacherTeachedCourseInfo', $scope['teacher']['id'], $scope['teacher']['teachedCourses'], $scope['courseNameList']);
    };

    $scope.$on('UpdateTeacherTeachedCourseInfo', function (scope, teacherId, teachedCourseList) {
        if ($scope['teacher'] !== null) {
            if ($scope['teacher']['id'] === teacherId) {
                $scope['teacher']['teachedCourses'] = teachedCourseList;
            }
        }            
    } .bind(this), true);

    $scope.onCancelEditAddressInfo = function () {
        hideAddressInfoDialogBox();
    };    

    function hideAddressInfoDialogBox() {
        $scope['edittedAddressInfo'] = null;
        $scope['isOnEditAddressInfo'] = false;
        $scope['isOnUpdateEdittedAddressInfo'] = false;
    }         

    var onSuccessReceiveTeacherInfoById = function (data, status, headers, config) {
        var tempTeacher = data.d;

        if (tempTeacher !== null) {
            $scope['teacher'] = {
                'id': tempTeacher.id,
                'firstname': tempTeacher.firstname,
                'lastname': tempTeacher.lastname,
                'nickname': tempTeacher.nickname,
                'status': tempTeacher.status,
                'contacts': {
                    'phones': tempTeacher.phoneList,
                    'emails': tempTeacher.emailList
                },
                'teachedCourses': tempTeacher.teachedCourseList
            };

            for(var i = $scope['teacher']['contacts']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['teacher']['contacts']['phones'][i];
                phone.value = FormatManager.unformatPhoneNumber(phone.value);
            };

            if ($scope['courseNameList'] !== null) {
                $scope['isReady'] = true;
            }            
        }
    };

    var onErrorReceiveTeacherInfoById = function (data, status, headers, config) {
        console.log('onErrorReceiveTeacherInfoById');
    };

    var onSuccessReceiveCourseNameList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope['courseNameList'] = data.d;

            if ($scope['teacher'] !== null) {
                $scope['isReady'] = true;
            }
        }
    };

    var onErrorReceiveCourseNameList = function (data, status, headers, config) {
        console.log('onErrorReceiveCourseNameList');
    };        
};