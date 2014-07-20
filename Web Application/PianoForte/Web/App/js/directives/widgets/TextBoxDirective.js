'use strict';

goog.provide('PianoForte.Directives.Widgets.TextBoxDirective');

PianoForte.Directives.Widgets.TextBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {            
            disabled: '=',
            placeholder: '@',
            text: '=',
            width: '='            
        },
        controller: 'Widgets.TextBoxController',
        templateUrl: 'partials/widgets/text-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};