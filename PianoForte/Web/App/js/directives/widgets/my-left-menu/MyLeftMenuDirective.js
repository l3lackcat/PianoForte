'use strict';

goog.provide('PianoForte.Directives.Widgets.MyLeftMenuDirective');

PianoForte.Directives.Widgets.MyLeftMenuDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            defaultMenu: '@'
        },
        link: function (scope, element, attrs) {
            scope.init();
        },
        controller: 'MyLeftMenuController',
        templateUrl: 'partials/widgets/my-left-menu/my-left-menu.htm'
    };
};