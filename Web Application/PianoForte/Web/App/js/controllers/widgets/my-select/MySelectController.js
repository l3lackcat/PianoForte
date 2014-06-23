'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySelectController');

PianoForte.Controllers.Widgets.MySelectController = function ($scope, $attrs, $element, $document) {
    $scope['selectedItem'] = null;
    $scope['dropdownMenu'] = null;

    var selectElement = null;
    var buttonElement = null;
    var textElement = null;
    var placeHolderElement = null;
    var caretElement = null;

    $scope.initialize = function () {
        selectElement = $element[0];
        buttonElement = selectElement.children[0];
        textElement = buttonElement.children[0];
        placeHolderElement = buttonElement.children[1];
        caretElement = buttonElement.children[2];

        updateLayout();
        addEventsListen();
    };

    $scope.toggleDropdownMenu = function () {
        if ($scope['dropdownMenu']['visible'] === false) {
            $scope.showDropdownMenu();
        } else {
            $scope.hideDropdownMenu();
        }
    };

    $scope.showDropdownMenu = function () {
        if ($scope['dropdownMenu'] !== null) {
            if (($scope['disabled'] === undefined) || ($scope['disabled'] === false)) {
                var selectElementOffset = selectElement.getBoundingClientRect();
                if (selectElementOffset !== undefined) {
                    var widgetDropdownMenuElement = $scope['dropdownMenu']['element'];
                    if (dropdownMenuElement !== null) {
                        var dropdownMenuElement = widgetDropdownMenuElement.children[0];
                        if (dropdownMenuElement !== undefined) {
                            dropdownMenuElement.style.top = (selectElementOffset.top + selectElement.clientHeight) + 'px';
                            dropdownMenuElement.style.left = selectElementOffset.left + 'px';
                        }

                        document.body.appendChild(widgetDropdownMenuElement);
                        $scope['dropdownMenu']['visible'] = true;
                    }                    
                }
            } 
        }                
    };

    $scope.hideDropdownMenu = function () {
        if ($scope['dropdownMenu'] !== null) {
            if ($scope['dropdownMenu']['visible'] === true) {
                $scope['dropdownMenu']['visible'] = false;

                selectElement.appendChild($scope['dropdownMenu']['element']);
            }
        }            
    };

    $scope.select = function (selectedItem) {
        $scope.selectedItemId = selectedItem.id;
        $scope.hideDropdownMenu();
    };

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

    this.setDropdownMenu = function(dropdownMenu) {
        if ($scope['dropdownMenu'] === null) {
            $scope['dropdownMenu'] = dropdownMenu;
            $scope['dropdownMenu']['filterable'] = $scope['filterable'];
            $scope['dropdownMenu']['items'] = $scope['items'];
            $scope['dropdownMenu']['maximumDisplayedItems'] = $scope['maximumDisplayedItems'];
            $scope['dropdownMenu']['visible'] = false;

            $scope['dropdownMenu'].setTheme($scope['theme']);
            $scope['dropdownMenu'].setWidth(selectElement.clientWidth);
            $scope['dropdownMenu'].updateHeight();
        }
    };

    function updateLayout() {
        var customizedWidth = $scope['width'];       
        if (customizedWidth !== undefined) {
            setSelectElementWidth(customizedWidth);
        }

        var textElementWidth = selectElement.clientWidth - caretElement.clientWidth - 12;

        setTextElementWidth(textElementWidth);
        setPlaceHolderElementWidth(textElementWidth)
    };

    function setSelectElementWidth(width) {
        selectElement.style.width = width + 'px';
    };

    function setTextElementWidth(width) {
        textElement.style.width = width + 'px';
    };

    function setPlaceHolderElementWidth(width) {
        placeHolderElement.style.width = width + 'px';
    };

    function addEventsListen() {
        document.addEventListener('click', onDocumentClicked);
        window.addEventListener('resize', onWindowResized); 
    };

    function onDocumentClicked(e) {
        if (selectElement.contains(e.target) === false) {
            $scope.hideDropdownMenu();
            $scope.$apply();
        }
    };

    function onWindowResized(e) {
        $scope.hideDropdownMenu();
        $scope.$apply();
    };
};