'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySelectController');

PianoForte.Controllers.Widgets.MySelectController = function ($scope, $attrs, $element, $document) {
    $scope['selectedItem'] = null;
    $scope['isMenuVisible'] = false;

    var selectElement = null;
    var buttonElement = null;
    var textElement = null;
    var placeHolderElement = null;
    var caretElement = null;
    var dropdownElement = null;

    $scope.initialize = function () {
        selectElement = $element[0];
        dropdownElement = selectElement.children[1];
        buttonElement = selectElement.children[0];
        textElement = buttonElement.children[0];
        placeHolderElement = buttonElement.children[1];
        caretElement = buttonElement.children[2];

        updateTheme();
        updateLayout();
        addEventsListen();
    };

    $scope.toggleDropdownMenu = function () {
        if ($scope['isMenuVisible'] === false) {
            $scope.showDropdownMenu();
        } else {
            $scope.hideDropdownMenu();
        }
    };

    $scope.showDropdownMenu = function () {
        if (($scope['disabled'] === undefined) || ($scope['disabled'] === false)) {
            var selectElementOffset = selectElement.getBoundingClientRect();
            if (selectElementOffset !== undefined) {
                dropdownElement.style.top = (selectElementOffset.top + selectElement.clientHeight) + 'px';
                dropdownElement.style.left = selectElementOffset.left + 'px';
                document.body.appendChild(dropdownElement);

                $scope['isMenuVisible'] = true;
            }
        }
    };

    $scope.hideDropdownMenu = function () {
        if ($scope['isMenuVisible'] === true) {
            $scope['isMenuVisible'] = false;
            selectElement.appendChild(dropdownElement);
        }
    };

    $scope.select = function (selectedItem) {
        $scope.selectedItemId = selectedItem.id;
        $scope.hideDropdownMenu();
    }

    $scope.$watch('disabled', function (newValue, oldValue) {
        if (newValue === true) {
            if (buttonElement !== null) {
                buttonElement.classList.add('disabled');
            }
        } else {
            if (buttonElement !== null) {
                buttonElement.classList.remove('disabled');
            }
        }
    });

    $scope.$watch('selectedItemId', function (newValue, oldValue) {
        var selectedItemId = newValue;
        if (selectedItemId !== undefined) {
            for(var i = $scope.items.length - 1; i >= 0; i--) {
                var selectedItem = $scope.items[i];
                if (selectedItem.id === selectedItemId) {
                    $scope.selectedItem = selectedItem;
                }
            }
        } else {
            $scope.selectedItem = null;
        }
    });

    $scope.$on('onScroll', function (scope, scrolledElementName) {
        if (scrolledElementName === 'MyDialogBoxContent') {
            $scope.hideDropdownMenu();
            $scope.$apply();
        }        
    }, true);

    function updateTheme() {
        dropdownElement.className = dropdownElement.className + ' ' + $scope['theme'];
    };

    function updateLayout() {
        adjustWidth();
        adjustDropdownMenuHeight();
    };

    function adjustWidth() {
        var elementWidth = $scope['width'];       
        if (elementWidth !== undefined) {
            selectElement.style.width = elementWidth + 'px';
        }

        textElement.style.width = (selectElement.clientWidth - caretElement.clientWidth - 12) + 'px';
        placeHolderElement.style.width = (selectElement.clientWidth - caretElement.clientWidth - 12) + 'px';
        dropdownElement.style.width = selectElement.clientWidth + 'px';
    };

    function adjustDropdownMenuHeight() {
        var maximumDisplayedItems = $scope.maximumDisplayedItems;
        if (maximumDisplayedItems !== undefined) {
            var numberOfItems = $scope.items.length;
            if (numberOfItems < maximumDisplayedItems) {
                dropdownElement.style.height = (numberOfItems * 26) + 'px';
            } else {
                dropdownElement.style.height = (maximumDisplayedItems * 26) + 'px';
            }
        }
    };

    function addEventsListen() {
        $document.bind('click', onClick);
    };

    function onClick(e) {
        if (selectElement.contains(e.target) === false) {
            $scope.hideDropdownMenu();
            $scope.$apply();
        }
    };
};