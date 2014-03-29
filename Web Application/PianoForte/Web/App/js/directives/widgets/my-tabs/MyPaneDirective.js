'use strict';

goog.provide('PianoForte.Directives.Widgets.MyPaneDirective');

PianoForte.Directives.Widgets.MyPaneDirective = function () {
    return {
        require: '^myTabs',
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@'
        },
        templateUrl: 'partials/widgets/my-tabs/my-pane.htm',
        link: function (scope, element, attrs, tabsCtrl) {
            tabsCtrl.addPane(scope);
        }        
    };
};