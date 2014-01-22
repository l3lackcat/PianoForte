'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyDialogBox.MyDialogBoxController');

PianoForte.Controllers.Widgets.MyDialogBox.MyDialogBoxController = function ($scope) {
    $scope.onSubmit = function () {
        $scope.submit();
    };   

    $scope.onCancel = function () {
        $scope.close();
    };
}