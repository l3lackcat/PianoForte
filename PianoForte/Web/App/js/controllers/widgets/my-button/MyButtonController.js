'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyButtonController');

PianoForte.Controllers.Widgets.MyButtonController = function ($scope, $attrs, $element) {
    $scope.initialize = function () {
    	adjustWidth();
    };

    function adjustWidth () {
    	if ($scope.width !== undefined) {
    		$element[0].style.width = $scope.width;
    	}
    };
};