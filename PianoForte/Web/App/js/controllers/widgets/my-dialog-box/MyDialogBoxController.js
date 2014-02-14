'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyDialogBoxController');

PianoForte.Controllers.Widgets.MyDialogBoxController = function ($scope, $attrs, $element) {
    $scope.onSubmit = function () {
        $scope.submit();
    };

    $scope.onCancel = function () {
        $scope.close();
    };
};