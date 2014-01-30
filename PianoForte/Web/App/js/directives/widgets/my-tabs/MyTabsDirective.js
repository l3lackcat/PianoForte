'use strict';

goog.provide('PianoForte.Directives.Widgets.MyTabs.MyTabsDirective');

PianoForte.Directives.Widgets.MyTabs.MyTabsDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {},
        controller: 'MyTabsController',
        templateUrl: 'partials/widgets/my-tabs/my-tabs.htm'
    };
};