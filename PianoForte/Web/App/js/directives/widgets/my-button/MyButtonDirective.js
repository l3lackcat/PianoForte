'use strict';

goog.provide('PianoForte.Directives.Widgets.MyButtonDirective');

PianoForte.Directives.Widgets.MyButtonDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {            
            onClick: '&',
            text: '=',
            type: '=',
            width: '='
        },
        controller: 'MyButtonController',
        templateUrl: 'partials/widgets/my-button/my-button.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};