'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyDialogBoxController');

PianoForte.Controllers.Widgets.MyDialogBoxController = function ($scope) {
    $scope.onSubmit = function () {
        $scope.submit();
    };

    $scope.onCancel = function () {
        $scope.close();
    };
};