'use strict';

goog.provide('PianoForte.Directives.Widgets.MyCheckboxDirective');

PianoForte.Directives.Widgets.MyCheckboxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        transclude: true,
        scope: {
            checked: '@',
            onChanged: '&',
            text: '='
        },
        controller: 'MyCheckboxController',
        templateUrl: 'partials/widgets/my-checkbox/my-checkbox.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};