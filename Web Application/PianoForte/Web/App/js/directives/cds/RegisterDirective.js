'use strict';

goog.provide('PianoForte.Directives.Cds.RegisterDirective');

PianoForte.Directives.Cds.RegisterDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Cds.RegisterController',
		templateUrl: 'partials/cds/register.htm'
	};
};