'use strict';

goog.provide('PianoForte.Directives.Widgets.DatepickerDirective');

PianoForte.Directives.Widgets.DatepickerDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {},
        controller: 'Widgets.DatepickerController',
        templateUrl: 'partials/widgets/datepicker.htm'
    };
};