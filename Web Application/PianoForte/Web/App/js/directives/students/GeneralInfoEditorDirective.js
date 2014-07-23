'use strict';

goog.provide('PianoForte.Directives.Students.GeneralInfoEditorDirective');

PianoForte.Directives.Students.GeneralInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Students.GeneralInfoEditorController',
		templateUrl: 'partials/students/general-info-editor.htm'
	};
};