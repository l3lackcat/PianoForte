'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherMainController');

PianoForte.Controllers.Teachers.TeacherMainController = function ($scope, $rootScope, TeacherService) {
    $scope['teacherList'] = [];
    $scope['filterText'] = '';
    $scope['currrentFilter'] = null;
    $scope['teacherFilterList'] = [
        { text: 'ดูทั้งหมด' }
    ];

    $scope.init = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope['currrentFilter'] = $scope['teacherFilterList'][0];

        TeacherService.getTeacherList(onSuccessReceiveTeacherList, onErrorReceiveTeacherList);
    };

    $scope.$watch('filterText', function (newValue, oldValue) {
        // To do
    });

    var onSuccessReceiveTeacherList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope['teacherList'] = data.d;
        }
    };

    var onErrorReceiveTeacherList = function (data, status, headers, config) {
        console.log(data);
    };
};