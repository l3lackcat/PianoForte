'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyTextBoxController');

PianoForte.Controllers.Widgets.MyTextBoxController = function ($scope) {
    $scope.initialize = function (scope, element, attrs) {
        if ($scope.width !== undefined) {
            element[0].style.width = $scope.width + 'px';
        }

        var inputTextElement = element[0].children[0].children[0];
        var btnRemoveElement = element[0].children[0].children[1];

        btnRemoveElement.style.top = ((inputTextElement.clientHeight - btnRemoveElement.clientHeight) / 2) + 'px';
    };

    $scope.removeText = function () {
        $scope.text = '';
    };
};