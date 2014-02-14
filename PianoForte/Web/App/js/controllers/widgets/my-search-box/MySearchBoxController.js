'use strict';

goog.provide('PianoForte.Controllers.Widgets.MySearchBoxController');

PianoForte.Controllers.Widgets.MySearchBoxController = function ($scope, $attrs, $element) {
    $scope.initialize = function () {
        adjustWidth();
        adjustSearchIconPosition();
    };

    $scope.search = function () {
        // To do
    };

    function adjustWidth () {
        if ($scope.width !== undefined) {
            $element.css('width', $scope.width + 'px');
        }
    };

    function adjustSearchIconPosition () {
        var inputElement = $element[0].children[0].children[0];
        var searchIconElement = $element[0].children[0].children[1];        
        
        if ((inputElement !== undefined) && (searchIconElement !== undefined)) {
            searchIconElement.style.top = ((inputElement.clientHeight - searchIconElement.clientHeight) / 2) + 'px';        
        }
    };
};