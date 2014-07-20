'use strict';

goog.provide('PianoForte.Directives.Widgets.ButtonDirective');

PianoForte.Directives.Widgets.ButtonDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {     
            disabled: '=',       
            onClick: '&',
            text: '@',
            type: '=',
            width: '='
        },
        controller: 'Widgets.ButtonController',
        templateUrl: 'partials/widgets/button.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};