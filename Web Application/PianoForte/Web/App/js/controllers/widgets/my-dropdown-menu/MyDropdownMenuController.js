'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyDropdownMenuController');

PianoForte.Controllers.Widgets.MyDropdownMenuController = function ($scope, $attrs, $element, $document, filterFilter) {
    $scope['element'] = null;
    $scope['filter'] = {
        'result': [],
        'text': '',
    };
    
    var selectController = null;

    $scope.initialize = function (selectCtrl) {
        $scope['element'] = $element[0];
        selectController = selectCtrl;

        selectController.setDropdownMenu($scope);
    };

    $scope.select = function (selectedItem) {
        selectController.onSelectedDropdownMenu(selectedItem.id);
    };

    $scope.setTheme = function(theme) {
        var dropdownMenuElement = $element[0].children[0];
        if (dropdownMenuElement !== undefined) {
            dropdownMenuElement.className = dropdownMenuElement.className + ' ' + theme;
        }        
    }

    $scope.setWidth = function(width) {
        var dropdownMenuElement = $element[0].children[0];
        if (dropdownMenuElement !== undefined) {
            dropdownMenuElement.style.width = width + 'px';
        }        
    };

    $scope.updateHeight = function() {
        var dropdownMenuElement = $element[0].children[0];
        if (dropdownMenuElement !== undefined) {
            var itemWrapperElement = dropdownMenuElement.children[1];
            if (itemWrapperElement !== undefined) {
                var maximumDisplayedItems = $scope['maximumDisplayedItems'];
                if (maximumDisplayedItems !== undefined) {
                    var numberOfItems = $scope['filter']['result'].length;
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
        updateFilteredResult($scope['items'], newInput);
        $scope.updateHeight();
    });

    function updateFilteredResult(menuList, filteredText) {
        $scope['filter']['result'] = filterFilter(menuList, filteredText);
    };
};