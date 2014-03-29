'use strict';

goog.provide('PianoForte.Directives.Widgets.MySearchBoxDirective');

PianoForte.Directives.Widgets.MySearchBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            disabled: '=',
            placeholder: '=',            
            text: '=',            
            width: '='
        },
        controller: 'MySearchBoxController',
        templateUrl: 'partials/widgets/my-search-box/my-search-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
};