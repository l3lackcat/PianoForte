'use strict';

goog.provide('PianoForte.Controllers.Teachers.MainController');

PianoForte.Controllers.Teachers.MainController = function ($scope, $rootScope, filterFilter, TeacherService, Enum, EnumConverter, FormatManager) {
    $scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['teacherList'] = [];
    $scope['pageNumbers'] = [];
    $scope['currentPage'] = 1;
    $scope['showPerPage'] = 20;
    $scope['filter'] = {        
        'dropdownList': [
            { 'id': 0, 'text': 'ดูทั้งหมด', 'excluded': false },
            { 'id': 1, 'text': 'Custom', 'excluded': false }
        ],
        'dropdownSelectedId': 0,
        'result': [],
        'text': '',
    };

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        TeacherService.getTeacherList(onSuccessReceiveTeacherList, onErrorReceiveTeacherList);
    };

    $scope.goToPage = function (pageNumbers) {
        if ($scope['currentPage'] !== pageNumbers) {
            $scope['currentPage'] = pageNumbers;
        }
    };

    $scope.goToPrevPage = function () {
        if ($scope['currentPage'] > 1) {
            $scope['currentPage']--;
        }
    };

    $scope.goToNextPage = function () {
        if ($scope['currentPage'] < $scope['pageNumbers'].length) {
            $scope['currentPage']++;
        }
    };

    $scope.onInsertNewTeacher = function () {
        $rootScope.$broadcast('InsertNewTeacher');
    };

    $scope.$watch('currentPage', function (newInput, oldInput) {
        for (var i = $scope['pageNumbers'].length - 1; i >= 0; i--) {
            var pageNumber = $scope['pageNumbers'][i];
            if (pageNumber.index === $scope['currentPage']) {
                pageNumber.className = 'active';
            } else {
                pageNumber.className = '';
            }
        }
    });

    $scope.$watch('filter.dropdownSelectedId', function (newInput, oldInput) {
        // ToDo
    });

    $scope.$watch('filter.text', function (newInput, oldInput) {
        updateFilteredResult($scope['teacherList'], newInput);
        updatePageNumbers();
    });

    function updateFilteredResult(teacherList, filteredText) {
        $scope['filter']['result'] = filterFilter(teacherList, filteredText);
    };

    function updatePageNumbers() {
        $scope['pageNumbers'] = [];

        var numberOfPage = Math.ceil($scope['filter']['result'].length / $scope['showPerPage']);
        for (var i = 1; i <= numberOfPage; i++) {
            $scope['pageNumbers'].push({
                index: i,
                className: (i === $scope['currentPage']) ? 'active' : ''
            });
        };
    };

    var onSuccessReceiveTeacherList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope['teacherList'] = data.d;

            updateFilteredResult($scope['teacherList'], $scope['filter']['text']);
            updatePageNumbers();

            $scope['isReady'] = true;
        }
    };

    var onErrorReceiveTeacherList = function (data, status, headers, config) {
        console.log('onErrorReceiveTeacherList');
    };
};