'use strict';

goog.provide('PianoForte.Controllers.Courses.CourseMainController');

PianoForte.Controllers.Courses.CourseMainController = function ($scope, $rootScope, filterFilter, CourseService, EnumConverter, FormatManager) {
	$scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['courseList'] = [];
    $scope['pageNumbers'] = [];
    $scope['currentPage'] = 1;
    $scope['showPerPage'] = 20;
    $scope['filter'] = {        
        'dropdownList': [
            { 'id': 0, 'text': 'ดูทั้งหมด', 'excluded': false }
        ],
        'dropdownSelectedId': 0,
        'result': [],
        'text': '',
    };

    $scope.initialize = function () {
        $rootScope.$broadcast('SelectMenuItem', 'courses');

        CourseService.getCourseList(onSuccessReceiveCourseList, onErrorReceiveCourseList);
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

    $scope.$watch('filter.text', function (newInput, oldInput) {
        updateFilteredResult($scope['courseList'], newInput);
        updatePageNumbers();
    });

    function updateFilteredResult(courseList, filteredText) {
        $scope['filter']['result'] = filterFilter(courseList, filteredText);
    };

    function updatePageNumbers() {
    	$scope['currentPage'] = 1;
        $scope['pageNumbers'] = [];

        var numberOfPage = Math.ceil($scope['filter']['result'].length / $scope['showPerPage']);
        for (var i = 1; i <= numberOfPage; i++) {
            $scope['pageNumbers'].push({
                index: i,
                className: (i === $scope['currentPage']) ? 'active' : ''
            });
        }
    };

    var onSuccessReceiveCourseList = function (data, status, headers, config) {
        if (data.d !== null) {
            $scope['courseList'] = data.d;

            updateFilteredResult($scope['courseList'], $scope['filter']['text']);
            updatePageNumbers();

            $scope['isReady'] = true;
        }
    };

    var onErrorReceiveCourseList = function (data, status, headers, config) {
        // To do
    };
};