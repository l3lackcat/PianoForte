'use strict';

goog.provide('PianoForte.Controllers.Students.GeneralInfoEditorController');

PianoForte.Controllers.Students.GeneralInfoEditorController = function ($scope, $rootScope, StudentService, Enum, EnumConverter, FormatManager, ValidationManager) {    
    $scope['FormatManager'] = FormatManager;

    $scope['edittedData'] = null;
    $scope['visible'] = false;
    $scope['isOnUpdateEdittedData'] = false;
    $scope['statusList'] = [
        { 'id': Enum.Status.Active, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Inactive, 'text': '', 'excluded': false },
        { 'id': Enum.Status.Resigned, 'text': '', 'excluded': false }
    ];

    var _generalInfo = null;

    $scope.$on('EditStudentGeneralInfo', function (scope, student) {
        initStatusList();

        _generalInfo = student;
        $scope['edittedData'] = {
            'id': {
                'value': student.id,
                'isRequired': false,
                'isValid': true
            },
            'firstname': {
                'value': student.firstname,
                'isRequired': true,
                'isValid': true
            },
            'lastname': {
                'value': student.lastname,
                'isRequired': true,
                'isValid': true
            },
            'nickname': {
                'value': student.nickname,
                'isRequired': true,
                'isValid': true
            },
            'birthDate': {
                'value': student.birthDate,
                'isRequired': true,
                'isValid': true
            },
            'registeredDate': {
                'value': student.registeredDate,
                'isRequired': true,
                'isValid': true
            },
            'lastDateOfClass': {
                'value': student.lastDateOfClass,
                'isRequired': true,
                'isValid': true
            },
            'status': {
                'value': student.status,
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['visible'] = true;        
    } .bind(this), true);

    $scope.submit = function () {
        if (validateEdittedData() === true) {
            var isDifferent = compare(_generalInfo, $scope['edittedData']);
            if (isDifferent === true) {
                $scope['isOnUpdateEdittedData'] = true;
                StudentService.updateStudentGeneralInfo($scope['edittedData'], onSuccessUpdateEdittedData, onErrorUpdateEdittedData);
            } else {
                hideDialogBox();
            }
        }
    };

    $scope.cancel = function () {
        hideDialogBox();
    };    

    function initStatusList () {
        for(var i = $scope['statusList'].length - 1; i >= 0; i--) {
            var status = $scope['statusList'][i];

            status.text = EnumConverter.Status.toString(status.id);
        }
    };

    function hideDialogBox () {        
        $scope['edittedData'] = null;
        $scope['visible'] = false;
        $scope['isOnUpdateEdittedData'] = false;

        _generalInfo = null;
    };

    function validateEdittedData () {
        var isValid = true;
        var firstnameObj = $scope['edittedData']['firstname'];
        var lastnameObj = $scope['edittedData']['lastname'];
        var nicknameObj = $scope['edittedData']['nickname'];

        firstnameObj.isValid = ValidationManager.validate('name', firstnameObj.value);
        lastnameObj.isValid = ValidationManager.validate('name', lastnameObj.value);
        nicknameObj.isValid = ValidationManager.validate('name', nicknameObj.value);

        return firstnameObj.isValid && lastnameObj.isValid && nicknameObj.isValid;
    };

    function compare(oldGeneralInfo, newGeneralInfo) {
        var isChanged = false;

        if ((oldGeneralInfo.firstname !== newGeneralInfo.firstname.value) ||
            (oldGeneralInfo.lastname !== newGeneralInfo.lastname.value) ||
            (oldGeneralInfo.nickname !== newGeneralInfo.nickname.value) ||
            (oldGeneralInfo.status !== newGeneralInfo.status.value)) {
            isChanged = true;
        }

        return isChanged;
    };

    var onSuccessUpdateEdittedData = function (data, status, headers, config) {
        var isSuccess = data.d;

        if (isSuccess === true) {
            _generalInfo.firstname = $scope['edittedData']['firstname']['value'];
            _generalInfo.lastname = $scope['edittedData']['lastname']['value'];
            _generalInfo.nickname = $scope['edittedData']['nickname']['value'];
            _generalInfo.status = $scope['edittedData']['status']['value'];

            $rootScope.$broadcast('UpdateStudentGeneralInfo', _generalInfo);

            hideDialogBox();
        } else {
            onErrorUpdateEdittedData(data, status, headers, config);
        }        
    };

    var onErrorUpdateEdittedData = function (data, status, headers, config) {
        $scope['isOnUpdateEdittedData'] = false;
        console.log('onErrorUpdateEdittedData');
    };
};