'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherGeneralInfoEditorController');

PianoForte.Controllers.Teachers.TeacherGeneralInfoEditorController = function ($scope, ValidationManager) {
    $scope['originalData'] = null;
    $scope['edittedData'] = null;
    $scope['visible'] = false;
    $scope['isOnUpdateEdittedData'] = false;

    $scope.$on('EditTeacherGeneralInfo', function (scope, teacher) {
        $scope['originalData'] = teacher;
        $scope['edittedData'] = {
            'id': {
                'value': teacher.id,
                'isRequired': false,
                'isValid': true
            },
            'firstname': {
                'value': teacher.firstname,
                'isRequired': true,
                'isValid': true
            },
            'lastname': {
                'value': teacher.lastname,
                'isRequired': true,
                'isValid': true
            },
            'nickname': {
                'value': teacher.nickname,
                'isRequired': true,
                'isValid': true
            },
            'status': {
                'value': teacher.status,
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['visible'] = true;
    } .bind(this), true);

    $scope.submit = function () {
        if (validateGeneralInfo() === true) {
            if (isGeneralInfoChanged() === true) {
                $scope['isOnUpdateEdittedData'] = true;
                TeacherService.updateTeacherGeneralInfo($scope['edittedData'], onSuccessUpdateEdittedData, onErrorUpdateEdittedData);
            } else {
                hideGeneralInfoDialogBox();
            }
        }
    };

    $scope.cancel = function () {
        $scope['edittedData'] = null;
        $scope['visible'] = false;
    };

    function validateEdittedData () {
        var isValid = true;
        var firstnameObj = $scope['edittedData']['firstname'];
        var lastnameObj = $scope['edittedData']['lastname'];
        var nicknameObj = $scope['edittedData']['nickname'];

        firstnameObj.isValid = ValidateManager.validate('name', firstnameObj.value);
        lastnameObj.isValid = ValidateManager.validate('name', lastnameObj.value);
        nicknameObj.isValid = ValidateManager.validate('name', nicknameObj.value);

        return firstnameObj.isValid && lastnameObj.isValid && nicknameObj.isValid;
    };

    function isDataChanged() {
        var isChanged = false;

        if (($scope['originalData']['firstname'] !== $scope['edittedData']['firstname']['value']) ||
            ($scope['originalData']['lastname'] !== $scope['edittedData']['lastname']['value']) ||
            ($scope['originalData']['nickname'] !== $scope['edittedData']['nickname']['value'])) {
            isChanged = true;
        }

        return isChanged;
    };

    var onSuccessUpdateEdittedData = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            $scope['teacher']['firstname'] = $scope['edittedGeneralInfo']['firstname']['value'];
            $scope['teacher']['lastname'] = $scope['edittedGeneralInfo']['lastname']['value'];
            $scope['teacher']['nickname'] = $scope['edittedGeneralInfo']['nickname']['value'];

            hideGeneralInfoDialogBox();
        } else {
            onErrorUpdateEdittedData(data, status, headers, config);
        }        
    };

    var onErrorUpdateEdittedData = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedData'] = false;
        console.log('onErrorUpdateEdittedData');
    };
};