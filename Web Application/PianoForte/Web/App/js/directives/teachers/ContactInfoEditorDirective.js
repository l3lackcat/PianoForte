'use strict';

goog.provide('PianoForte.Directives.Teachers.ContactInfoEditorDirective');

PianoForte.Directives.Teachers.ContactInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Teachers.ContactInfoEditorController',
		templateUrl: 'partials/teachers/contact-info-editor.htm'
	};
};