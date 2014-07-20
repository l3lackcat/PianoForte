'use strict';

goog.provide('PianoForte.Directives.Books.GeneralInfoEditorDirective');

PianoForte.Directives.Books.GeneralInfoEditorDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Books.GeneralInfoEditorController',
		templateUrl: 'partials/books/general-info-editor.htm'
	};
};