'use strict';

goog.provide('PianoForte.Controllers.Students.AboutController');

PianoForte.Controllers.Students.AboutController = function ($scope, $rootScope, $routeParams, StudentService, ConvertManager, Enum, EnumConverter, FormatManager, ValidationManager) {
    $scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['student'] = null;

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'students');

        $scope['isReady'] = false;
        $scope['student'] = null;        

        StudentService.getStudentInfoById($routeParams['studentId'], onSuccessReceiveStudentInfoById, onErrorReceiveStudentInfoById);
    };

    $scope.returnToMain = function () {
        $location.path("/students");
    };

    $scope.onEditGeneralInfo = function () {
        $rootScope.$broadcast('EditStudentGeneralInfo', $scope['student']);
    };

    $scope.$on('UpdateStudentGeneralInfo', function (scope, student) {
        if ($scope['student'] !== null) {
            $scope['student']['firstname'] = student.firstname;
            $scope['student']['lastname'] = student.lastname;
            $scope['student']['nickname'] = student.nickname;
            $scope['student']['status'] = student.status;
        }            
    } .bind(this), true);

    $scope.onEditContactInfo = function () {
        $rootScope.$broadcast('EditStudentContactInfo', $scope['student']['id'], $scope['student']['contacts']);
    };

    $scope.$on('UpdateStudentContactInfo', function (scope, studentId, contacts) {
        if ($scope['student'] !== null) {
            if ($scope['student']['id'] === studentId) {
                $scope['student']['contacts']['emails'] = contacts.emails;
                $scope['student']['contacts']['phones'] = contacts.phones;
            }
        }            
    } .bind(this), true);       

    var onSuccessReceiveStudentInfoById = function (data, status, headers, config) {
        var tempStudent = data.d;

        if (tempStudent !== null) {
            $scope['student'] = {
                'id': tempStudent.id,
                'firstname': tempStudent.firstname,
                'lastname': tempStudent.lastname,
                'nickname': tempStudent.nickname,
                'birthDate': ConvertManager.parseJsonDate(tempStudent.birthDate),
                'registeredDate': ConvertManager.parseJsonDate(tempStudent.registeredDate),
                'lastDateOfClass': '',
                'status': tempStudent.status,
                'contacts': {
                    'phones': tempStudent.phoneList,
                    'emails': tempStudent.emailList
                },
                'teachedCourses': tempStudent.teachedCourseList
            };

            for(var i = $scope['student']['contacts']['phones'].length - 1; i >= 0; i--) {
                var phone = $scope['student']['contacts']['phones'][i];
                phone.value = FormatManager.unformatPhoneNumber(phone.value);
            };

            if ($scope['courseNameList'] !== null) {
                $scope['isReady'] = true;
            }            
        }
    };

    var onErrorReceiveStudentInfoById = function (data, status, headers, config) {
        console.log('onErrorReceiveStudentInfoById');
    };
};