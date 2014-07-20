'use strict';

goog.provide('PianoForte.Directives.Widgets.BoxDirective');

PianoForte.Directives.Widgets.BoxDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@',
            editable: '=',
            edit: '&'
        },
        controller: 'Widgets.BoxController',
        templateUrl: 'partials/widgets/box.htm'
    };
};