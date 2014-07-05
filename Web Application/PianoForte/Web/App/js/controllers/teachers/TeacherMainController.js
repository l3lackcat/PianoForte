'use strict';

goog.provide('PianoForte.Controllers.Teachers.TeacherMainController');

PianoForte.Controllers.Teachers.TeacherMainController = function ($scope, $rootScope, $location, filterFilter, TeacherService, Enum, EnumConverter, FormatManager) {
    $scope['EnumConverter'] = EnumConverter;
    $scope['FormatManager'] = FormatManager;

    $scope['isReady'] = false;
    $scope['teacherList'] = [];
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

    $scope['newTeacherGeneralInfo'] = null;
    $scope['showNewTeacherDialogBox'] = false;
    $scope['isOnInsertNewTeacher'] = false;

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

    $scope.onInsertNewTeacher = function () {
        $scope['newTeacherGeneralInfo'] = {
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
                'value': Enum.Status.Active,
                'isRequired': false,
                'isValid': true
            }
        }

        $scope['showNewTeacherDialogBox'] = true;
    };

    $scope.onSubmitNewTeacher = function () {
        if (validateGeneralInfo() === true) {
            $scope['isOnInsertNewTeacher'] = true;
            TeacherService.insertTeacherGeneralInfo($scope['newTeacherGeneralInfo'], onSuccessInsertNewTeacher, onErrorInsertNewTeacher);
        }
    };

    $scope.onCancelNewTeacher = function () {
        hideNewTeacherGeneralInfo();
    };

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

    function hideNewTeacherGeneralInfo() {
        $scope['newTeacherGeneralInfo'] = null;
        $scope['isOnInsertNewTeacher'] = false;
        $scope['showNewTeacherDialogBox'] = false;        
    };

    function validateGeneralInfo() {
        var isValid = true;

        if ($scope['newTeacherGeneralInfo']['firstname']['value'] === '') {
            $scope['newTeacherGeneralInfo']['firstname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['newTeacherGeneralInfo']['firstname']['isValid'] = true;
        }

        if ($scope['newTeacherGeneralInfo']['lastname']['value'] === '') {
            $scope['newTeacherGeneralInfo']['lastname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['newTeacherGeneralInfo']['lastname']['isValid'] = true;
        }

        if ($scope['newTeacherGeneralInfo']['nickname']['value'] === '') {
            $scope['newTeacherGeneralInfo']['nickname']['isValid'] = false;
            isValid = false;
        } else {
            $scope['newTeacherGeneralInfo']['nickname']['isValid'] = true;
        }

        return isValid;
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

    var onSuccessInsertNewTeacher = function (data, status, headers, config) {
        var teacherId = data.d;

        if (teacherId !== 0) {
            $location.path("/teachers/" + teacherId);
        } else {
            onErrorInsertNewTeacher(data, status, headers, config);
        }        
    };

    var onErrorInsertNewTeacher = function (data, status, headers, config) {
        $scope['isOnInsertNewTeacher'] = false;
        console.log('onErrorInsertNewTeacher');
    };
};