'use strict';

goog.provide('PianoForte.Directives.Widgets.MyTabsDirective');

PianoForte.Directives.Widgets.MyTabsDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {},
        controller: 'MyTabsController',
        templateUrl: 'partials/widgets/my-tabs/my-tabs.htm'
    };
};