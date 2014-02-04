'use strict';

goog.provide('PianoForte.Directives.Widgets.MyTextbox.MyTextboxDirective');

PianoForte.Directives.Widgets.MyTextbox.MyTextboxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            text: '=',
            disabled: '=',
            width: '='
        },
        controller: 'MyTextboxController',
        templateUrl: 'partials/widgets/my-textbox/my-textbox.htm',
        link: function (scope, element, attrs) {
            scope.initialize(scope, element, attrs);
        }
    };
};