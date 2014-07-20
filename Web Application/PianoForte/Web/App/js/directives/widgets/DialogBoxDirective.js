'use strict';

goog.provide('PianoForte.Directives.Widgets.DialogBoxDirective');

PianoForte.Directives.Widgets.DialogBoxDirective = function () {
    return {        
        restrict: 'E',
        transclude: true,
        scope: {
            disabled: '=',
            filterable: '=',
            title: '@',
            submit: '&',
            close: '&',
            visible: '='
        },
        controller: 'Widgets.DialogBoxController',
        templateUrl: 'partials/widgets/dialog-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};