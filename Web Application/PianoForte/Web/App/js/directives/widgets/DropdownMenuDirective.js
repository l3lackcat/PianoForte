'use strict';

goog.provide('PianoForte.Directives.Widgets.DropdownMenuDirective');

PianoForte.Directives.Widgets.DropdownMenuDirective = function () {
	return {
		require: '^widgetSelect',
		restrict: 'E',
		replace: true,
		scope: {},
		controller: 'Widgets.DropdownMenuController',
		templateUrl: 'partials/widgets/dropdown-menu.htm',
		link: function (scope, element, attrs, selectCtrl) {
			scope.initialize(selectCtrl);			
		}
	};
};