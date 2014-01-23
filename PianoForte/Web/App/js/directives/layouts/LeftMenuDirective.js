'use strict';

goog.provide('PianoForte.Directives.Layouts.LeftMenuDirective');

PianoForte.Directives.Layouts.LeftMenuDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@',
            editable: '@',
            edit: '&'
        },
        controller: 'LeftMenuController',
        templateUrl: 'partials/layouts/left-menu.htm'
    };
}