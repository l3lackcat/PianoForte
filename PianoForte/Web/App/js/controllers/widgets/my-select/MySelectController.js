'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySelectController');

PianoForte.Controllers.Widgets.MySelectController = function ($scope, $attrs, $element, $document) {
    $scope.selectedText = '';
    $scope.isMenuVisible = false;

    var selectElement = null;
    var textElement = null;
    var caretElement = null;

    $scope.initialize = function () {
        selectElement = $element[0];
        textElement = $element[0].children[0].children[0];
        caretElement = $element[0].children[0].children[1];

        updateLayout();
        addEventsListen();
        resetSelectedItem();
        setDefaultSelectedItem();
    };

    $scope.toggleMenu = function () {
        $scope.isMenuVisible = !$scope.isMenuVisible;
    };

    $scope.select = function (selectedItem) {
        resetSelectedItem();
        updateSelectedItemById(selectedItem.id);
        
        $scope.isMenuVisible = false;
    }

    function updateLayout () {
        adjustWidth();
    }

    function adjustWidth () {
        if ($scope.width !== undefined) {
            selectElement.style.width = $scope.width + 'px';
        }

        textElement.style.width = (selectElement.clientWidth - caretElement.clientWidth - 12) + 'px';
    };    

    function addEventsListen () {
        $document.bind('click', onClick);
    };

    function onClick (e) {
        if (selectElement.contains(e.target) === false) {
            $scope.isMenuVisible = false;
            $scope.$apply();
        }  
    };

    function resetSelectedItem () {
        if ($scope.items !== null) {
            for (var i = $scope.items.length - 1; i >= 0; i--) {
                $scope.items[i].selected = false;
            }
        }            
    }

    function setDefaultSelectedItem () {
        if ($scope.defaultSelectedItemId !== undefined) {
            updateSelectedItemById($scope.defaultSelectedItemId);
        } else if ($scope.defaultSelectedItemIndex !== undefined) {
            updateSelectedItemByIndex($scope.defaultSelectedItemIndex);
        } else {
            updateSelectedItemByIndex(0);
        }
    }

    function updateSelectedItemById (itemId) {
        for (var i = $scope.items.length - 1; i >= 0; i--) {
            if ($scope.items[i].id === itemId) {
                updateSelectedItemByIndex(i);
            }
        };
    }; 

    function updateSelectedItemByIndex (index) {
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