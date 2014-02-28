'use strict';

goog.provide('PianoForte.Directives.Widgets.MyScrollbarDirective');

PianoForte.Directives.Widgets.MyScrollbarDirective = function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.addClass('scroll-pane');
            element.jScrollPane();
            
            var api = element.data('jsp');
            scope.$watch(function () { return element.find('.' + attrs.scrollpane).length }, function (length) {
                api.reinitialise();
            });
        }
    };
};