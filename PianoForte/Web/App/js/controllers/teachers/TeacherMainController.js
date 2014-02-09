'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherMainController');

PianoForte.Controllers.Teachers.TeacherMainController = function ($scope, $rootScope) {
    $scope['teacherList'] = [
        { id: '1001', name: 'AAA', nickname: 'AAA', phone: '089-999-9999' },
        { id: '1002', name: 'AAA', nickname: 'AAA', phone: '089-999-9999' },
        { id: '1003', name: 'AAA', nickname: 'AAA', phone: '089-999-9999' },
        { id: '1004', name: 'AAA', nickname: 'AAA', phone: '089-999-9999' },
        { id: '1005', name: 'AAA', nickname: 'AAA', phone: '089-999-9999' }
    ];
    $scope['currrentFilter'] = null;
    $scope['teacherFilterList'] = [
        { text: 'ดูทั้งหมด' }
    ];

    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope['currrentFilter'] = $scope['teacherFilterList'][0];
    };
};