'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySelectController');

PianoForte.Controllers.Widgets.MySelectController = function ($scope, $attrs, $element, $document) {
    $scope.textFilter = '';
    $scope.isMenuVisible = false;

    $scope.initialize = function () {
        adjustWidth();
        adjustCaretPosition();
        addEventsListen();        
    };

    $scope.toggleMenu = function () {
        $scope.isMenuVisible = !$scope.isMenuVisible;
    };

    $scope.select = function (selectedItem) {
        for (var i = $scope.items.length - 1; i >= 0; i--) {
            var item = $scope.items[i];

            if (item.id === selectedItem.id) {
                updateSelectedItemByIndex(i);
                $scope.isMenuVisible = false;
                break;
            }
        };
    }

    function adjustWidth () {
        if ($scope.width !== undefined) {
            $element.css('width', $scope.width + 'px');
        }
    };    

    function adjustCaretPosition () {
        var inputElement = $element[0].children[0];
        var caretElement = $element[0].children[1];        
        
        if ((inputElement !== undefined) && (caretElement !== undefined)) {
            caretElement.style.top = ((inputElement.clientHeight - caretElement.clientHeight) / 2) + 'px';        
        }
    };

    function updateSelectedItemByIndex (index) {
        var selectedItem = $scope.items[index];
        if (selectedItem !== undefined) {
            $scope.textFilter = selectedItem.text;
        }
    };

    function addEventsListen () {
        $document.bind('click', onClick);
    };

    function onClick (e) {
        if ($element[0].contains(e.target) === false) {
            $scope.isMenuVisible = false;
            $scope.$apply();
        }  
    };
};