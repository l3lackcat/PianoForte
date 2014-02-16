'use strict';

goog.provide('PianoForte.Directives.Widgets.MyTextBoxDirective');

PianoForte.Directives.Widgets.MyTextBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {            
            disabled: '=',
            placeholder: '=',
            text: '=',
            width: '='            
        },
        controller: 'MyTextBoxController',
        templateUrl: 'partials/widgets/my-text-box/my-text-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};