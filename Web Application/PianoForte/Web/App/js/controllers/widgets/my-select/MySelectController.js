'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySelectController');

PianoForte.Controllers.Widgets.MySelectController = function ($scope, $attrs, $element, $document) {
    $scope.selectedText = '';
    $scope.isMenuVisible = false;

    var selectElement = null;
    var buttonElement = null;
    var textElement = null;
    var caretElement = null;
    var dropdownElement = null;

    $scope.initialize = function () {
        selectElement = $element[0];
        dropdownElement = selectElement.children[1];
        buttonElement = selectElement.children[0];
        textElement = buttonElement.children[0];
        caretElement = buttonElement.children[1];

        updateTheme();
        updateLayout();
        addEventsListen();
        resetSelectedItem();
        setDefaultSelectedItem();
    };

    $scope.toggleDropdownMenu = function () {
        if ($scope.isMenuVisible === false) {
            $scope.showDropdownMenu();
        } else {
            $scope.hideDropdownMenu();
        }
    };

    $scope.showDropdownMenu = function () {
        if (($scope.disabled === undefined) || ($scope.disabled === false)) {
            var selectElementOffset = selectElement.getBoundingClientRect();
            if (selectElementOffset !== undefined) {
                dropdownElement.style.top = (selectElementOffset.top + selectElement.clientHeight) + 'px';
                dropdownElement.style.left = selectElementOffset.left + 'px';
                document.body.appendChild(dropdownElement);

                $scope.isMenuVisible = true;
            }
        }
    };

    $scope.hideDropdownMenu = function () {
        if ($scope.isMenuVisible === true) {
            $scope.isMenuVisible = false;
            selectElement.appendChild(dropdownElement);
        }
    };

    $scope.select = function (selectedItem) {
        resetSelectedItem();
        updateSelectedItemById(selectedItem.id);

        $scope.isMenuVisible = false;
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

    $scope.$on('onScroll', function (scope, scrolledElementName) {
        if (scrolledElementName === 'MyDialogBoxContent') {
            $scope.hideDropdownMenu();
            $scope.$apply();
        }        
    }, true);

    function updateTheme() {
        dropdownElement.className = dropdownElement.className + ' ' + $scope.theme;
    };

    function updateLayout() {
        adjustWidth();
        adjustDropdownMenuHeight();
    }

    function adjustWidth() {
        if ($scope.width !== undefined) {
            selectElement.style.width = $scope.width + 'px';
        }

        textElement.style.width = (selectElement.clientWidth - caretElement.clientWidth - 12) + 'px';
        dropdownElement.style.width = selectElement.clientWidth + 'px';
    };

    function adjustDropdownMenuHeight() {
        var maximumItems = $scope.showMaxItems;
        if (maximumItems !== undefined) {
            var numberOfItems = $scope.items.length;
            if (numberOfItems < maximumItems) {
                dropdownElement.style.height = (numberOfItems * 26) + 'px';
            } else {
                dropdownElement.style.height = (maximumItems * 26) + 'px';
            }
        }
    };

    function addEventsListen() {
        $document.bind('click', onClick);
        dropdownElement.addEventListener('blur', onBlurDropdownMenu);
    };

    function onClick(e) {
        if (selectElement.contains(e.target) === false) {
            $scope.hideDropdownMenu();
            $scope.$apply();
        }
    };

    function onBlurDropdownMenu(e) {
        $scope.hideDropdownMenu();
    };

    function resetSelectedItem() {
        if ($scope.items !== null) {
            for (var i = $scope.items.length - 1; i >= 0; i--) {
                $scope.items[i].selected = false;
            }
        }
    }

    function setDefaultSelectedItem() {
        if ($scope.defaultSelectedItemId !== undefined) {
            updateSelectedItemById($scope.defaultSelectedItemId);
        } else if ($scope.defaultSelectedItemIndex !== undefined) {
            updateSelectedItemByIndex($scope.defaultSelectedItemIndex);
        } else {
            updateSelectedItemByIndex(0);
        }
    }

    function updateSelectedItemById(itemId) {
        for (var i = $scope.items.length - 1; i >= 0; i--) {
            if ($scope.items[i].id === itemId) {
                updateSelectedItemByIndex(i);
            }
        };
    };

    function updateSelectedItemByIndex(index) {
        var selectedItem = $scope.items[index];
        if (selectedItem !== undefined) {
            selectedItem.selected = true;
            $scope.selectedText = selectedItem.text;
            textElement.classList.remove('placeholder');
        } else {
            if ($scope.placeholder !== undefined) {
                $scope.selectedText = $scope.placeholder;
                textElement.classList.add('placeholder');
            }
        }
    };
};