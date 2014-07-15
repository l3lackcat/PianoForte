﻿'use strict';

goog.provide('PianoForte.Directives.Teachers.GeneralInfoEditorDirective');

PianoForte.Directives.Teachers.GeneralInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {
			title: '@'
		},
		controller: 'GeneralInfoEditorController',
		templateUrl: 'partials/teachers/general-info-editor.htm'
	};
};