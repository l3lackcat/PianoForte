'use strict';

goog.provide('PianoForte.Directives.Teachers.TeacherContactInfoEditorDirective');

PianoForte.Directives.Teachers.TeacherContactInfoEditorDirective = function () {
	return {
		restrict: 'E',
		require: "MyDialogBoxDirective",
		replace: true,
		scope: {
			title: '@'
		},
		controller: 'TeacherContactInfoEditorController',
		templateUrl: 'partials/teachers/teacher-contact-info-editor.htm'
	};
};