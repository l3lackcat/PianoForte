'use strict';

goog.provide('PianoForte.Directives.Widgets.MySelectDirective');

PianoForte.Directives.Widgets.MySelectDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {                   
            disabled: '=',
            filterable: '=',
            items: '=',
            maximumDisplayedItems: '=',
            onChanged: '&',
            placeholder: '=',            
            selectedItemId: '=',
            theme: '=',
            width: '='
        },
        controller: 'MySelectController',
        templateUrl: 'partials/widgets/my-select/my-select.htm',        
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};