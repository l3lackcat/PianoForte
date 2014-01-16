'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyBox.MyBoxController');

PianoForte.Controllers.Widgets.MyBox.MyBoxController = function ($scope) {
    $scope.getHeaderVisibility = function () {
        var isVisible = true;

        if (($scope.title === '') || ($scope.title === undefined)) {
            isVisible = false;
        }

        return isVisible;
    }
}

//PianoForteApp.controller('MyBoxController', function ($scope) {
//    $scope.getHeaderVisibility = function () {
//        var isVisible = true;

//        if (($scope.title === '') || ($scope.title === undefined)) {
//            isVisible = false;
//        }
//        
//        return isVisible;
//    }
//});