'use strict';

goog.provide('PianoForte.Directives.Widgets.MyNumericBoxDirective');

PianoForte.Directives.Widgets.MyNumericBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {                      
            disabled: '=',
            placeholder: '=',
            precision: '=',
            text: '=',
            width: '='            
        },
        controller: 'MyNumericBoxController',
        templateUrl: 'partials/widgets/my-numeric-box/my-numeric-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};