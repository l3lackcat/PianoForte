'use strict';

goog.provide('PianoForte.Directives.Widgets.MyPhoneBoxDirective');

PianoForte.Directives.Widgets.MyPhoneBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {                      
            disabled: '=',
            placeholder: '=',
            text: '=',
            width: '='            
        },
        controller: 'MyPhoneBoxController',
        templateUrl: 'partials/widgets/my-phone-box/my-phone-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};