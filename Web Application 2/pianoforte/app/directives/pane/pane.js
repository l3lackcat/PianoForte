angular.module('pianoforte')

.directive('widgetPane', function () {
    return {
        restrict: 'E',
        templateUrl: 'directives/pane/pane.htm',
        replace: true,
        transclude: true,
        scope: {
            title: '@'
        },
        link: function (scope, tabsCtrl) {
            tabsCtrl.addPane(scope);
        }       
    };
});