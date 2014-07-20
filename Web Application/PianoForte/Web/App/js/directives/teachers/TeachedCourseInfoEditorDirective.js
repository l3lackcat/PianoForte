'use strict';

goog.provide('PianoForte.Directives.Teachers.TeachedCourseInfoEditorDirective');

PianoForte.Directives.Teachers.TeachedCourseInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Teachers.TeachedCourseInfoEditorController',
		templateUrl: 'partials/teachers/teached-course-info-editor.htm'
	};
};