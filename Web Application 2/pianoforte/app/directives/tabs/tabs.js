angular.module('pianoforte')

.controller('Widgets.TabsController', [
    '$scope',
    function ($scope) {
        var panes = $scope.panes = [];

        $scope.select = function (pane) {
            angular.forEach(panes, function (pane) {
                pane.selected = false;
            });

            pane.selected = true;
        };

        this.addPane = function (pane) {
            if (panes.length === 0) {
                $scope.select(pane);
            }

            panes.push(pane);
        };
    }
])

.directive('widgetTabs', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.TabsController',
        templateUrl: 'directives/tabs/tabs.htm',
        replace: true,
        transclude: true,
        scope: {}
    };
});