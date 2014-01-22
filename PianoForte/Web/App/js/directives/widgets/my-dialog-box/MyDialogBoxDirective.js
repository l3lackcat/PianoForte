'use strict';

goog.provide('PianoForte.Directives.Widgets.MyDialogBox.MyDialogBoxDirective');

PianoForte.Directives.Widgets.MyDialogBox.MyDialogBoxDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@',
            submit: '&',
            close: '&'
        },
        controller: 'MyDialogBoxController',
        templateUrl: 'partials/widgets/my-dialog-box/my-dialog-box.htm'
    };
}