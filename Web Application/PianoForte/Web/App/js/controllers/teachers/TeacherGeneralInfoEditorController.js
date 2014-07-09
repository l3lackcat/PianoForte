'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherGeneralInfoEditorController');

PianoForte.Controllers.Teachers.TeacherGeneralInfoEditorController = function ($scope) {
    $scope['edittedGeneralInfo'] = null;
    $scope['visible'] = false;

    $scope.$on('EditTeacherGeneralInfo', function (scope, teacher) {
        $scope['edittedGeneralInfo'] = {
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

    };

    $scope.cancel = function () {
        $scope['edittedGeneralInfo'] = null;
        $scope['visible'] = false;
    };
};