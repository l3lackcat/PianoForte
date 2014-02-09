'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySearchBoxController');

PianoForte.Controllers.Widgets.MySearchBoxController = function ($scope) {
    $scope.initialize = function (scope, element, attrs) {
        if ($scope.width !== undefined) {
            element[0].style.width = $scope.width + 'px';
        }

        var inputTextElement = element[0].children[0].children[0];
        var btnSearchElement = element[0].children[0].children[1];

        btnSearchElement.style.top = ((inputTextElement.clientHeight - btnSearchElement.clientHeight) / 2) + 'px';
    };

    $scope.search = function () {
        // To do
    };
};