'use strict';

goog.provide('PianoForte.Directives.Widgets.MyDropdownMenuDirective');

PianoForte.Directives.Widgets.MyDropdownMenuDirective = function () {
	return {
		require: '^mySelect',
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'MyDropdownMenuController',
		templateUrl: 'partials/widgets/my-dropdown-menu/my-dropdown-menu.htm',
		link: function (scope, element, attrs, selectCtrl) {
			scope.initialize(selectCtrl);			
		}
	};
};