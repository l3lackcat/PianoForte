'use strict';

goog.provide('PianoForte.Directives.Cds.GeneralInfoEditorDirective');

PianoForte.Directives.Cds.GeneralInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Cds.GeneralInfoEditorController',
		templateUrl: 'partials/cds/general-info-editor.htm'
	};
};