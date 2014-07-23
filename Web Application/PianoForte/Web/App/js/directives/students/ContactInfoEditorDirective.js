'use strict';

goog.provide('PianoForte.Directives.Students.ContactInfoEditorDirective');

PianoForte.Directives.Students.ContactInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Students.ContactInfoEditorController',
		templateUrl: 'partials/students/contact-info-editor.htm'
	};
};