angular.module('pianoforte')

.controller('Widgets.CheckboxController', [
    '$scope',
    '$element',
    function ($scope, $element) {
        $scope.initialize = function () {
            adjustCheckedIconPosition();
        };

        $scope.toggleCheck = function () {
            if ($scope.checked === undefined) {
                $scope.checked = false;
            }

            $scope.checked = !$scope.checked;

            $scope.onChanged({ 
                e: {
                    'checked': $scope.checked,
                    'name': $scope.name
                }
            });
        };

        function adjustCheckedIconPosition () {
            var checkedIconElement = $element[0].children[0].children[0];
            var textElement = $element[0].children[0].children[1];
            
            if ((textElement !== undefined) && (checkedIconElement !== undefined)) {
                checkedIconElement.style.lineHeight = textElement.clientHeight + 'px';
            }
        };
    }
])

.directive('widgetBox', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.CheckboxController',
        templateUrl: 'directives/box/box.htm',
        replace: true,
        scope: {
            checked: '=',
            name: '@',
            onChanged: '&',
            label: '@'
        },
        link: function (scope) {
            scope.initialize();
        }
    };
});