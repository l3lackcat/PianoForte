'use strict';

goog.provide('PianoForte.Directives.Books.RegisterDirective');

PianoForte.Directives.Books.RegisterDirective = function () {
	return {
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Books.RegisterController',
		templateUrl: 'partials/books/register.htm'
	};
};