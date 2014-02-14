'use strict';

goog.provide('PianoForte.Directives.Widgets.MySelectDirective');

PianoForte.Directives.Widgets.MySelectDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            width: '=',
            items: '=',
            selectedItemIndex: '='
        },
        controller: 'MySelectController',
        templateUrl: 'partials/widgets/my-select/my-select.htm',        
        link: function (scope, element, attr) {
            scope.initialize();            
        }
    };
};