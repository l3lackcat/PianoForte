angular.module('pianoforte')

.controller('Cds.MainController', [
    '$scope',
    '$rootScope',
    'filterFilter',
    // 'CdService',
    'EnumConverter',
    'FormatManager',
    function ($scope, $rootScope, filterFilter, Enum, EnumConverter, FormatManager) {
        $scope.enumConverter = EnumConverter;
        $scope.formatManager = FormatManager;
        
        $scope.isReady = false;
        $scope.cdList = [];
        $scope.pageNumbers = [];
        $scope.currentPage = 1;
        $scope.showPerPage = 20;
        $scope.filter = {        
            dropdownList: [
                { id: 0, text: 'ดูทั้งหมด', excluded: false }
            ],
            dropdownSelectedId: 0,
            result: [],
            text: ''
        };

        $scope.initialize = function () {
            $rootScope.$broadcast('SelectMenuItem', 'cds');

            // CdService.getCdList(onSuccessReceiveCdList, onErrorReceiveCdList);
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

        $scope.onInsertNewCd = function () {
            $rootScope.$broadcast('InsertNewCd');
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

        $scope.$watch('filter.text', function (newInput, oldInput) {
            updateFilteredResult($scope.cdList, newInput);
            updatePageNumbers();
        });

        function updateFilteredResult(cdList, filteredText) {
            $scope.filter.result = filterFilter(cdList, filteredText);
        };

        function updatePageNumbers() {
            $scope.currentPage = 1;
            $scope.pageNumbers = [];

            var numberOfPage = Math.ceil($scope.filter.result.length / $scope.showPerPage);
            for (var i = 1; i <= numberOfPage; i++) {
                $scope.pageNumbers.push({
                    index: i,
                    className: (i === $scope.currentPage) ? 'active' : ''
                });
            }
        };

        var onSuccessReceiveCdList = function (data, status, headers, config) {
            if (data.d !== null) {
                $scope.cdList = data.d;

                updateFilteredResult($scope.cdList, $scope.filter.text);
                updatePageNumbers();

                $scope.isReady = true;
            }
        };

        var onErrorReceiveCdList = function (data, status, headers, config) {
            // To do
        };
    }
]);