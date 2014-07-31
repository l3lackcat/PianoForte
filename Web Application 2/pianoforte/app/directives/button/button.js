angular.module('pianoforte')

.controller('Widgets.ButtonController', [
    '$scope',
    '$element', 
    function ($scope, $element) {
        $scope.initialize = function () {
            adjustWidth();
        };

        $scope.click = function () {
            $scope.onClick();
        };

        function adjustWidth () {
            if ($scope.width !== undefined) {
                $element[0].style.width = $scope.width;
            }
        };
    }
])

.directive('widgetButton', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.ButtonController',
        templateUrl: 'directives/button/button.htm',
        replace: true,
        scope: {     
            disabled: '=',       
            onClick: '&',
            text: '@',
            type: '=',
            width: '='
        },
        link: function (scope, element, attrs) {
            scope.initialize();
        }       
    };
});