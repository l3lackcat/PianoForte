angular.module('pianoforte')

.controller('Widgets.NumericBoxController', [
    '$scope',
    '$element',
    'FormatManager' 
    function ($scope, $element, FormatManager) {
        var hasSetFirstText = false;

        $scope.initialize = function () {
            adjustWidth();
            adjustRemoveIconPosition();
            addEventListener();
        };

        $scope.removeText = function () {
            $scope.text = '';
        };

        $scope.$watch('text', function (newInput, oldInput) {
            if ((hasSetFirstText === false) && (newInput !== null)) {
                $scope.text = FormatManager.formatNumber($scope.text);
                hasSetFirstText = true;
            }
        });

        function adjustWidth () {
            if ($scope.width !== undefined) {
                $element.css('width', $scope.width + 'px');
            }
        };

        function adjustRemoveIconPosition () {
            var inputElement = $element[0].children[0].children[0];
            var removeIconElement = $element[0].children[0].children[1];        
            
            if ((inputElement !== undefined) && (removeIconElement !== undefined)) {
                removeIconElement.style.top = ((inputElement.clientHeight - removeIconElement.clientHeight) / 2) + 'px';        
            }
        };

        function addEventListener () {
            var inputElement = $element[0].children[0].children[0];
            if (inputElement !== undefined) {
                inputElement.addEventListener('blur', onBlur);
                inputElement.addEventListener('focus', onFocus);
                inputElement.addEventListener('keypress', onKeyDown);
                inputElement.addEventListener('keyUp', onKeyUp);
            }
        };

        function onBlur(e) {
            $scope.text = FormatManager.formatNumber($scope.text);
            $scope.$apply();
        };

        function onFocus(e) {
            $scope.text = FormatManager.unformatNumber($scope.text);
            $scope.$apply();
        };

        function onKeyDown(e) {
            e = (e) ? e : window.event;

            var isKeyCodeAllowed = false;
            var allowedCharCodeList = [48, 49, 50, 51, 52, 53, 54, 55, 56, 57];
            var charCode = (e.which) ? e.which : e.charCode;

            if (allowedCharCodeList.indexOf(charCode) !== -1) {
                isKeyCodeAllowed = true;
            } else if (charCode === 46) {
                if ($scope['precision'] === true) {
                    var text = $scope.text.toString();
                    if (text !== '') {
                        var dotIndex = text.indexOf('.');
                        if (dotIndex === -1) {
                            isKeyCodeAllowed = true;
                        }
                    }
                }
            }

            if (isKeyCodeAllowed === false) {
                e.preventDefault();
            }
        };

        function onKeyUp(e) {
            // Formating
        };
    }
])

.directive('widgetBox', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.NumericBoxController',
        templateUrl: 'directives/numeric-box/numeric-box.htm',
        replace: true,
        scope: {
            disabled: '=',
            placeholder: '@',
            precision: '=',
            text: '=',
            width: '='
        },
        link: function (scope) {
            scope.initialize();
        }       
    };
});