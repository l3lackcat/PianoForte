'use strict';

goog.provide('PianoForte.Directives.Teachers.TeacherGeneralInfoEditorDirective');

PianoForte.Directives.Teachers.TeacherGeneralInfoEditorDirective = function () {
	return {
		restrict: 'E',
		require: "MyDialogBoxDirective",
		replace: true,
		scope: {
			title: '@'
		},
		controller: 'TeacherGeneralInfoEditorController',
		templateUrl: 'partials/teachers/teacher-general-info-editor.htm'
	};
};