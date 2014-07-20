'use strict';

goog.provide('PianoForte.Controllers.Widgets.ButtonController');

PianoForte.Controllers.Widgets.ButtonController = function ($scope, $attrs, $element) {
    $scope.initialize = function () {
    	adjustWidth();
    };

    $scope.click = function () {
        $scope.onClick();
    };

    function adjustWidth () {
    	if ($scope.width !== undefined) {
    		$element[0].style.width = $scope.width;
    	}
    };
};