'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyBoxController');

PianoForte.Controllers.Widgets.MyBoxController = function ($scope) {
    $scope.getHeaderVisibility = function () {
        var isVisible = true;

        if (($scope.title === '') || ($scope.title === undefined)) {
            isVisible = false;
        }

        return isVisible;
    };

    $scope.onEdit = function () {
        $scope.edit();
    };
};