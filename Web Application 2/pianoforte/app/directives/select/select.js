angular.module('pianoforte')

.controller('Widgets.SelectController', [
    '$scope',
    '$element',
    function ($scope, $element) {
        $scope.selectedItem = null;
        $scope.dropdown = null;

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

        $scope.toggleDropdown = function () {
            if ($scope.dropdown.visible === false) {
                $scope.showDropdown();
            } else {
                $scope.hideDropdown();
            }
        };

        $scope.showDropdown = function () {
            var dropdown = $scope.dropdown;
            if (dropdown !== null) {
                if (($scope.disabled === undefined) || ($scope.disabled === false)) {
                    var selectElementOffset = selectElement.getBoundingClientRect();
                    if (selectElementOffset !== undefined) {
                        var widgetDropdownElement = dropdown.element;
                        if (dropdownElement !== null) {
                            var dropdownElement = widgetDropdownElement.children[0];
                            if (dropdownElement !== undefined) {
                                dropdownElement.style.top = (selectElementOffset.top + selectElement.clientHeight) + 'px';
                                dropdownElement.style.left = selectElementOffset.left + 'px';

                                var selectElementWidth = selectElement.clientWidth;
                                if (selectElementWidth !== dropdownElement.clientWidth) {
                                    dropdownElement.style.width = selectElementWidth + 'px';
                                }
                            }

                            document.body.appendChild(widgetDropdownElement);
                            dropdown.visible = true;
                            dropdown.filter.text = '';
                        }                    
                    }
                } 
            }                
        };

        $scope.hideDropdown = function () {
            var dropdown = $scope.dropdown;
            if (dropdown !== null) {
                if (dropdown.visible === true) {
                    dropdown.visible = false;

                    selectElement.appendChild(dropdown.element);
                }
            }            
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

            $scope.hideDropdown();
        });

        this.setDropdown = function(dropdown) {
            if ($scope.dropdown === null) {
                $scope.dropdown = dropdown;
                $scope.dropdown.filterable = $scope.filterable;
                $scope.dropdown.items = $scope.items;
                $scope.dropdown.maximumDisplayedItems = $scope.maximumDisplayedItems;
                $scope.dropdown.visible = false;

                $scope.dropdown.setTheme($scope.theme);
                $scope.dropdown.updateHeight();          
            }
        };

        this.onSelectedDropdown = function(selectedItemId) {
            $scope.selectedItemId = selectedItemId;
            $scope.hideDropdown();
        }

        function updateLayout () {
            var customizedWidth = $scope.width;       
            if (customizedWidth !== undefined) {
                setSelectElementWidth(customizedWidth);
            }

            var textElementWidth = selectElement.offsetWidth - caretElement.offsetWidth - 21;

            setTextElementWidth(textElementWidth);
            setPlaceHolderElementWidth(textElementWidth);
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
            window.addEventListener('scroll', onWindowScrolled);
        };

        function onDocumentClicked(e) {
            if (selectElement.contains(e.target) === false) {
                var dropdownElement = $scope.dropdown.element.children[0];
                var filterWrapperElement = dropdownElement.children[0];
                var noResultElement = dropdownElement.children[2];

                if ((filterWrapperElement.contains(e.target) === false) && (noResultElement.contains(e.target) === false)) {
                    $scope.hideDropdown();
                    $scope.$apply();
                }            
            }
        };

        function onWindowResized(e) {
            $scope.hideDropdown();
            $scope.$apply();
        };

        function onWindowScrolled(e) {
            $scope.hideDropdown();
            $scope.$apply();
        };
    }
])

.directive('widgetSelect', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.SelectController',
        templateUrl: 'directives/select/select.htm',
        replace: true,
        scope: {
            disabled: '=',
            filterable: '=',
            items: '=',
            maximumDisplayedItems: '=',
            onChanged: '&',
            placeholder: '@',
            selectedItemId: '=',
            theme: '@',
            width: '='
        },
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
});