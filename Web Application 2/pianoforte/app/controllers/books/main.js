angular.module('pianoforte')

.controller('Books.MainController', [
    '$scope',
    '$rootScope',
    'filterFilter',
    // 'BookService',
    'EnumConverter',
    'FormatManager',
    function ($scope, $rootScope, filterFilter, EnumConverter, FormatManager) {
        $scope.enumConverter = EnumConverter;
        $scope.formatManager = FormatManager;

        $scope.isReady = false;
        $scope.bookList = [];
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
            $rootScope.$broadcast('SelectMenuItem', 'books');

            // BookService.getBookList(onSuccessReceiveBookList, onErrorReceiveBookList);
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

        $scope.onInsertNewBook = function () {
            $rootScope.$broadcast('InsertNewBook');
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
            updateFilteredResult($scope.bookList, newInput);
            updatePageNumbers();
        });

        function updateFilteredResult(bookList, filteredText) {
            $scope.filter.result = filterFilter(bookList, filteredText);
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

        var onSuccessReceiveBookList = function (data, status, headers, config) {
            if (data.d !== null) {
                $scope.bookList = data.d;

                updateFilteredResult($scope.bookList, $scope.filter.text);
                updatePageNumbers();

                $scope.isReady = true;
            }
        };

        var onErrorReceiveBookList = function (data, status, headers, config) {
            // To do
        };
    }
]);