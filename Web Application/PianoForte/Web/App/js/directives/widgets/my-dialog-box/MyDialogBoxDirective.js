'use strict';

goog.provide('PianoForte.Directives.Widgets.MyDialogBoxDirective');

PianoForte.Directives.Widgets.MyDialogBoxDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            disabled: '=',
            title: '=',
            submit: '&',
            close: '&',
            visible: '='
        },
        controller: 'MyDialogBoxController',
        templateUrl: 'partials/widgets/my-dialog-box/my-dialog-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};