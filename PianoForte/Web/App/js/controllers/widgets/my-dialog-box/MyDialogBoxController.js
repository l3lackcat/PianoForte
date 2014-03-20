'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyDialogBoxController');

PianoForte.Controllers.Widgets.MyDialogBoxController = function ($scope, $attrs, $element) {
	$scope.initialize = function () {
		var documentHeight = document.body.clientHeight;       
        var dialogBoxContent = $element[0].children[0].children[0].children[1];

        dialogBoxContent.style.maxHeight = (documentHeight - 481) + 'px'; 
    };

    $scope.onSubmit = function () {
        $scope.submit();
    };

    $scope.onCancel = function () {
        $scope.close();
    };
};