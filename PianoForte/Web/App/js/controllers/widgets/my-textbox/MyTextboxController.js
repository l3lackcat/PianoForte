'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyTextboxController');

PianoForte.Controllers.Widgets.MyTextboxController = function ($scope) {
    var textboxElement = null;
    var buttonElement = null;

    $scope.initialize = function (scope, element, attrs) {
        if ($scope.width !== undefined) {
            element[0].style.width = $scope.width + 'px';
        }

        textboxElement = element[0].children[0].children[0];
        buttonElement = element[0].children[0].children[1];

        buttonElement.style.top = ((textboxElement.clientHeight - buttonElement.clientHeight) / 2) + 'px';

        console.log(typeof $scope.disabled);
    };

    $scope.removeText = function () {
        $scope.text = '';
    };
};