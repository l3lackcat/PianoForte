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
})

.directive('widgetPane', function () {
    return {
        require: '^widgetTabs',
        restrict: 'E',        
        // replace: true,
        transclude: true,
        scope: {
            title: '@'
        },
        link: function (scope, element, attrs, tabsCtrl) {
            tabsCtrl.addPane(scope);
        },
        templateUrl: 'directives/tabs/pane.htm'
    };
});