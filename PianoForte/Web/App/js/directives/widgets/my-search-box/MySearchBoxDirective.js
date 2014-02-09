'use strict';

goog.provide('PianoForte.Directives.Widgets.MySearchBoxDirective');

PianoForte.Directives.Widgets.MySearchBoxDirective = function () {
    return {
        restrict: 'E',
        replace: true,
        scope: {
            text: '=',
            disabled: '=',
            width: '=',
            placeholder: '='
        },
        controller: 'MySearchBoxController',
        templateUrl: 'partials/widgets/my-search-box/my-search-box.htm',
        link: function (scope, element, attrs) {
            scope.initialize(scope, element, attrs);
        }
    };
};