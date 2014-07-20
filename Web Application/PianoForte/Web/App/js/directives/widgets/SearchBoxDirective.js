'use strict';

goog.provide('PianoForte.Directives.Widgets.SearchBoxDirective');

PianoForte.Directives.Widgets.SearchBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            disabled: '=',
            isFilterBox: '=',
            placeholder: '@',            
            text: '=',            
            width: '='
        },
        controller: 'Widgets.SearchBoxController',
        templateUrl: 'partials/widgets/search-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};