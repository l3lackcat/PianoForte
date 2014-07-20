'use strict';

goog.provide('PianoForte.Controllers.Teachers.RegisterController');

PianoForte.Controllers.Teachers.RegisterController = function ($scope, $rootScope, $location, TeacherService, Enum, ValidationManager) {    
    $scope['data'] = null;
    $scope['visible'] = false;
    $scope['isOnInsertData'] = false;

    $scope.$on('InsertNewTeacher', function (scope) {
        $scope['data'] = {
            'id': {
                'value': 0,
                'isRequired': false,
                'isValid': true
            },
            'firstname': {
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'lastname': {
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'nickname': {
                'value': '',
                'isRequired': true,
                'isValid': true
            },
            'status': {
                'value': Enum.Status.Inactive,
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['visible'] = true;        
    } .bind(this), true);

    $scope.submit = function () {
        if (validateData() === true) {
            $scope['isOnInsertData'] = true;
            TeacherService.insertTeacherGeneralInfo($scope['data'], onSuccessInsertData, onErrorInsertData);
        }
    };

    $scope.cancel = function () {
        hideDialogBox();
    };    

    function hideDialogBox() {        
        $scope['data'] = null;
        $scope['visible'] = false;
        $scope['isOnInsertData'] = false;
    };

    function validateData () {
        var isValid = true;
        var firstnameObj = $scope['data']['firstname'];
        var lastnameObj = $scope['data']['lastname'];
        var nicknameObj = $scope['data']['nickname'];

        firstnameObj.isValid = ValidationManager.validate('name', firstnameObj.value);
        lastnameObj.isValid = ValidationManager.validate('name', lastnameObj.value);
        nicknameObj.isValid = ValidationManager.validate('name', nicknameObj.value);

        return firstnameObj.isValid && lastnameObj.isValid && nicknameObj.isValid;
    };

    var onSuccessInsertData = function (data, status, headers, config) {
        var teacherId = data.d;

        if (teacherId !== 0) {
            $location.path("/teachers/" + teacherId);
            $scope.$apply();
        } else {
            onErrorInsertData(data, status, headers, config);
        }        
    };

    var onErrorInsertData = function (data, status, headers, config) {
        $scope['isOnInsertData'] = false;
        console.log('onErrorInsertData');
    };
};