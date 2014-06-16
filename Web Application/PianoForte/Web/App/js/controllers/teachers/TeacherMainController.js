'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherMainController');

PianoForte.Controllers.Teachers.TeacherMainController = function ($scope, $rootScope, filterFilter, TeacherService, FormatManager) {
    $scope.isReady = false;
    $scope.teacherList = [];
    $scope.filteredTeacherList = [];
    $scope.pageNumbers = [];
    $scope.currentPage = 1;
    $scope.showPerPage = 20;
    $scope.filterText = '';
    $scope.dropdownFilterList = [
        { id: 0, text: 'ดูทั้งหมด', excluded: false },
        { id: 1, text: 'Item 2', excluded: false },
        { id: 2, text: 'Item 3', excluded: false }
    ];

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'teachers');

        $scope.isReady = false;
        $scope.teacherList = [];
        $scope.filteredTeacherList = [];
        $scope.pageNumbers = [];
        $scope.currentPage = 1;
        $scope.filterText = '';

        TeacherService.getTeacherList(onSuccessReceiveTeacherList, onErrorReceiveTeacherList);
    };

    $scope.onDropdownFilterChanged = function () {
        // To do
    };

    $scope.goToPage = function (pageNumbers) {
        if ($scope.currentPage !== pageNumbers) {
            $scope.currentPage = pageNumbers;
        }
    };

    $scope.goToPrevPage = function () {
        if ($scope.currentPage > 1) {
            $scope.currentPage--;
        };
    };

    $scope.goToNextPage = function () {
        if ($scope.currentPage < $scope.pageNumbers.length) {
            $scope.currentPage++;
        };
    };

    $scope.$watch('currentPage', function (newInput, oldInput) {
        for (var i = $scope.pageNumbers.length - 1; i >= 0; i--) {
            var pageNumber = $scope.pageNumbers[i];
            if (pageNumber.index === $scope.currentPage) {
                pageNumber.className = 'active';
            } else {
                pageNumber.className = '';
            }
        }
    });

    $scope.$watch('filterText', function (newInput, oldInput) {
        updateFilteredTeacherList($scope.teacherList, newInput);
        updatePageNumbers();
    });

    function updateFilteredTeacherList(teacherList, filterText) {
        $scope.filteredTeacherList = filterFilter(teacherList, filterText);
    };

    function updatePageNumbers() {
        $scope.pageNumbers = [];

        var numberOfPage = Math.ceil($scope.filteredTeacherList.length / $scope.showPerPage);
        for (var i = 1; i <= numberOfPage; i++) {
            $scope.pageNumbers.push({
                index: i,
                className: (i === $scope.currentPage) ? 'active' : ''
            });
        };
    };

    var onSuccessReceiveTeacherList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope.teacherList = data.d;

            updateFilteredTeacherList($scope.teacherList, $scope.filterText);
            updatePageNumbers();

            $scope.isReady = true;
        }
    };

    var onErrorReceiveTeacherList = function (data, status, headers, config) {
        // To do
    };
};