angular.module('pianoforte')

.controller('Widgets.BoxController', [
    '$scope',
    function ($scope) {
        $scope.getHeaderVisibility = function () {
            var isVisible = true;

            if (($scope.title === '') || ($scope.title === undefined)) {
                isVisible = false;
            }

            return isVisible;
        };

        $scope.onEdit = function () {
            $scope.edit();
        };
    }
])

.directive('widgetBox', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.BoxController',
        templateUrl: 'directives/box/box.htm',
        replace: true,
        transclude: true,
        scope: {
            title: '@',
            editable: '=',
            edit: '&'
        }
    };
});