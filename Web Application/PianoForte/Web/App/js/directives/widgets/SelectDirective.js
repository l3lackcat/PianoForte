'use strict';

goog.provide('PianoForte.Directives.Widgets.SelectDirective');

PianoForte.Directives.Widgets.SelectDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {                   
            disabled: '=',
            filterable: '=',
            items: '=',
            maximumDisplayedItems: '=',
            onChanged: '&',
            placeholder: '@',            
            selectedItemId: '=',
            theme: '@',
            width: '='
        },
        controller: 'Widgets.SelectController',
        templateUrl: 'partials/widgets/select.htm',        
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};