'use strict';

goog.provide('PianoForte.Directives.Widgets.CheckboxDirective');

PianoForte.Directives.Widgets.CheckboxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        transclude: true,
        scope: {
            checked: '=',
            name: '@',
            onChanged: '&',
            label: '@'
        },
        controller: 'Widgets.CheckboxController',
        templateUrl: 'partials/widgets/checkbox.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};