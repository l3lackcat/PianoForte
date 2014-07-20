'use strict';

goog.provide('PianoForte.Directives.Widgets.PhoneBoxDirective');

PianoForte.Directives.Widgets.PhoneBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {                      
            disabled: '=',
            placeholder: '@',
            text: '=',
            width: '='            
        },
        controller: 'Widgets.PhoneBoxController',
        templateUrl: 'partials/widgets/phone-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};