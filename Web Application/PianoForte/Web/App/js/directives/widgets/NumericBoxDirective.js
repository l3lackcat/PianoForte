'use strict';

goog.provide('PianoForte.Directives.Widgets.NumericBoxDirective');

PianoForte.Directives.Widgets.NumericBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {                      
            disabled: '=',
            placeholder: '@',
            precision: '=',
            text: '=',
            width: '='            
        },
        controller: 'Widgets.NumericBoxController',
        templateUrl: 'partials/widgets/numeric-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};