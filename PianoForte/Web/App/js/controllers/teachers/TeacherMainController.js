'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherMainController');

PianoForte.Controllers.Teachers.TeacherMainController = function ($scope, $rootScope, TeacherService) {
    $scope['teacherList'] = [];
    $scope['currrentFilter'] = null;
    $scope['teacherFilterList'] = [
        { id: 1, text: 'ดูทั้งหมด' },
        { id: 2, text: 'Item 2' },
        { id: 3, text: 'Item 3' }
    ];

    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope['currrentFilter'] = $scope['teacherFilterList'][0];

        TeacherService.getTeacherList(onSuccessReceiveTeacherList, onErrorReceiveTeacherList);
    };

    var onSuccessReceiveTeacherList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope['teacherList'] = data.d;
        }
    };

    var onErrorReceiveTeacherList = function (data, status, headers, config) {
        // To do
    };
};