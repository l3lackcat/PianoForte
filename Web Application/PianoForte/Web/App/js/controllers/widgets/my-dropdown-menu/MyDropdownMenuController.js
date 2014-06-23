'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyDropdownMenuController');

PianoForte.Controllers.Widgets.MyDropdownMenuController = function ($scope, $attrs, $element, $document) {
    $scope['element'] = null;

    var dropdownMenuElement = null;

    $scope.initialize = function (selectCtrl) {
        $scope['element'] = $element[0];

        dropdownMenuElement = $element[0].children[0];

        selectCtrl.setDropdownMenu($scope);
    };

    $scope.select = function (selectedItem) {
        $scope.selectedItemId = selectedItem.id;
        $scope.hideDropdownMenu();
    };

    $scope.setTheme = function(theme) {
        dropdownMenuElement.className = dropdownMenuElement.className + ' ' + theme;
    }

    $scope.setWidth = function(width) {
        dropdownMenuElement.style.width = width + 'px';
    };

    $scope.updateHeight = function() {
        var maximumDisplayedItems = $scope['maximumDisplayedItems'];
        if (maximumDisplayedItems !== undefined) {
            var numberOfItems = $scope['items'].length;
            if (numberOfItems < maximumDisplayedItems) {
                dropdownMenuElement.style.height = (numberOfItems * 26) + 'px';
            } else {
                dropdownMenuElement.style.height = (maximumDisplayedItems * 26) + 'px';
            }
        }
    };
};