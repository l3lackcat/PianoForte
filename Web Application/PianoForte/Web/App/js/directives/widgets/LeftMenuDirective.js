'use strict';

goog.provide('PianoForte.Directives.Widgets.LeftMenuDirective');

PianoForte.Directives.Widgets.LeftMenuDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            defaultMenu: '@'
        },
        link: function (scope, element, attrs) {
            scope.init();
        },
        controller: 'Widgets.LeftMenuController',
        templateUrl: 'partials/widgets/left-menu.htm'
    };
};