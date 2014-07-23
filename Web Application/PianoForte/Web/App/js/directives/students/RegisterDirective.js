'use strict';

goog.provide('PianoForte.Directives.Teachers.RegisterDirective');

PianoForte.Directives.Teachers.RegisterDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Teachers.RegisterController',
		templateUrl: 'partials/teachers/register.htm'
	};
};