'use strict';

goog.provide('PianoForte.Directives.Widgets.MyBoxDirective');

PianoForte.Directives.Widgets.MyBoxDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@',
            editable: '@',
            edit: '&'
        },
        controller: 'MyBoxController',
        templateUrl: 'partials/widgets/my-box/my-box.htm'
    };
};