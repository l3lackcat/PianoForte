'use strict';

goog.provide('PianoForte.Directives.Widgets.TabsDirective');

PianoForte.Directives.Widgets.TabsDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {},
        controller: 'Widgets.TabsController',
        templateUrl: 'partials/widgets/tabs.htm'
    };
};