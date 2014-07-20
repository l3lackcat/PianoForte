'use strict';

goog.provide('PianoForte.Directives.Widgets.PaneDirective');

PianoForte.Directives.Widgets.PaneDirective = function () {
    return {
        require: '^widgetTabs',
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@'
        },
        templateUrl: 'partials/widgets/pane.htm',
        link: function (scope, element, attrs, tabsCtrl) {
            tabsCtrl.addPane(scope);
        }        
    };
};