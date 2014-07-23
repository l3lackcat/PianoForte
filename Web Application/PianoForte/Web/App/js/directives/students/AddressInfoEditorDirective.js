'use strict';

goog.provide('PianoForte.Directives.Students.AddressInfoEditorDirective');

PianoForte.Directives.Students.AddressInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Students.AddressInfoEditorController',
		templateUrl: 'partials/students/address-info-editor.htm'
	};
};