angular.module('pianoforte')

.controller('Students.MainController', [
    '$scope',
    '$rootScope',
    'filterFilter',
    // 'StudentService',
    'EnumConverter',
    'FormatManager',
    function ($scope, $rootScope, filterFilter, EnumConverter, FormatManager) {
        $scope.enumConverter = EnumConverter;
        $scope.formatManager = FormatManager;

        $scope.isReady = false;
        $scope.studentList = [];
        $scope.pageNumbers = [];
        $scope.currentPage = 1;
        $scope.showPerPage = 100;
        $scope.filter = {        
            dropdownList: [
                { id: 0, text: 'ดูทั้งหมด', excluded: false },
                { id: 1, text: 'Custom', excluded: false }
            ],
            dropdownSelectedId: 0,
            result: [],
            text: ''
        };

        $scope.initialize = function () {
            $rootScope.$broadcast('SelectMenuItem', 'students');

            StudentService.getStudentListSize(onSuccessReceiveStudentListSize, onErrorReceiveStudentListSize);
        };

        $scope.goToPage = function (pageNumbers) {
            if ($scope.currentPage !== pageNumbers) {
                $scope.currentPage = pageNumbers;
            }
        };

        $scope.goToPrevPage = function () {
            if ($scope.currentPage > 1) {
                $scope.currentPage--;
            }
        };

        $scope.goToNextPage = function () {
            if ($scope.currentPage < $scope.pageNumbers.length) {
                $scope.currentPage++;
            }
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

        $scope.$watch('filter.dropdownSelectedId', function (newInput, oldInput) {
            // ToDo
        });

        $scope.$watch('filter.text', function (newInput, oldInput) {
            updateFilteredResult($scope.studentList, newInput);
            updatePageNumbers();
        });

        function updateFilteredResult(studentList, filteredText) {
            $scope.filter.result = filterFilter(studentList, filteredText);
        };

        function updatePageNumbers() {
            $scope.pageNumbers = [];

            var numberOfPage = Math.ceil($scope.filter.result.length / $scope.showPerPage);
            for (var i = 1; i <= numberOfPage; i++) {
                $scope.pageNumbers.push({
                    index: i,
                    className: (i === $scope.currentPage) ? 'active' : ''
                });
            };
        };

        var onSuccessReceiveStudentListSize = function (data, status, headers, config) {
            if (data.d !== null) {          
                var studentListSize = data.d;
                var offset = 200;
                var startIndex = 0;

                for(startIndex = 0; startIndex < studentListSize; startIndex += offset) {
                    StudentService.getStudentList(startIndex, offset, onSuccessReceiveStudentList, onErrorReceiveStudentList);              
                }
            }
        };

        var onErrorReceiveStudentListSize = function (data, status, headers, config) {
            console.log('onErrorReceiveStudentListSize');
        };

        var onSuccessReceiveStudentList = function (data, status, headers, config) {
            if (data.d !== null) {
                if ($scope.studentList.length === 0) {
                    $scope.studentList = data.d;
                } else {
                    var tempStudentList = data.d;
                    var tempStudentListLength = data.d.length;
                    for(var i = 0; i < tempStudentListLength; i++) {
                        $scope.studentList.push(tempStudentList[i]);
                    }
                }           

                updateFilteredResult($scope.studentList, $scope.filter.text);
                updatePageNumbers();

                $scope.isReady = true;
            }
        };

        var onErrorReceiveStudentList = function (data, status, headers, config) {
            console.log('onErrorReceiveStudentList');
        };
    }
]);