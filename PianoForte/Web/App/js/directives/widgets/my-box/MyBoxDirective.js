'use strict';

goog.provide('PianoForte.Directives.Widgets.MyBox.MyBoxDirective');

PianoForte.Directives.Widgets.MyBox.MyBoxDirective = function () {
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