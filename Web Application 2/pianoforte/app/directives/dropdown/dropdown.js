angular.module('pianoforte')

.controller('Widgets.DropdownController', [
    '$scope',
    '$element',
    'filterFilter',
    function ($scope, $element, filterFilter) {
        $scope.element = null;
        $scope.filter = {
            result: [],
            text: '',
        };
        
        var selectController = null;

        $scope.initialize = function (selectCtrl) {
            $scope.element = $element[0];
            selectController = selectCtrl;

            selectController.setDropdown($scope);
        };

        $scope.select = function (selectedItem) {
            selectController.onSelectedDropdown(selectedItem.id);
        };

        $scope.setTheme = function(theme) {
            var dropdownElement = $element[0].children[0];
            if (dropdownElement !== undefined) {
                dropdownElement.className = dropdownElement.className + ' ' + theme;
            }
        };

        $scope.updateHeight = function() {
            var dropdownElement = $element[0].children[0];
            if (dropdownElement !== undefined) {
                var itemWrapperElement = dropdownElement.children[1];
                if (itemWrapperElement !== undefined) {
                    var maximumDisplayedItems = $scope.maximumDisplayedItems;
                    if (maximumDisplayedItems !== undefined) {
                        var numberOfItems = 0;

                        if ($scope.filter.result !== undefined) {
                            numberOfItems = $scope.filter.result.length;
                        }
                        
                        if (numberOfItems < maximumDisplayedItems) {
                            itemWrapperElement.style.height = (numberOfItems * 26) + 'px';
                        } else {
                            itemWrapperElement.style.height = (maximumDisplayedItems * 26) + 'px';
                        }
                    }
                }
            }
        };

        $scope.$watch('filter.text', function (newInput, oldInput) {
            updateFilteredResult($scope.items, newInput);
            $scope.updateHeight();
        });

        function updateFilteredResult(menuList, filteredText) {
            $scope.filter.result = filterFilter(menuList, filteredText);
        };
    }
])

.directive('widgetDropdown', function () {
    return {
        require: '^widgetSelect',
        restrict: 'E',
        controller: 'Widgets.DropdownController',
        templateUrl: 'directives/dropdown/dropdown.htm',
        replace: true,
        scope: {},
        link: function (scope) {
            scope.initialize();
        }
    };
});