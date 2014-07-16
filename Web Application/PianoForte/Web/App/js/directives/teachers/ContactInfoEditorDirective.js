'use strict';

goog.provide('PianoForte.Directives.Teachers.ContactInfoEditorDirective');

PianoForte.Directives.Teachers.ContactInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {
			title: '@'
		},
		controller: 'Teacher.ContactInfoEditorController',
		templateUrl: 'partials/teachers/contact-info-editor.htm'
	};
};