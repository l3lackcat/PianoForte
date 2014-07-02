'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyNumericBoxController');

PianoForte.Controllers.Widgets.MyNumericBoxController = function ($scope, $attrs, $element) {
    $scope.initialize = function () {
        adjustWidth();
        adjustRemoveIconPosition();
        addEventListener();
    };

    $scope.removeText = function () {
        $scope['text'] = '';
    };

    function adjustWidth () {
        if ($scope['width'] !== undefined) {
            $element.css('width', $scope['width'] + 'px');
        }
    };

    function adjustRemoveIconPosition () {
        var inputElement = $element[0].children[0].children[0];
        var removeIconElement = $element[0].children[0].children[1];        
        
        if ((inputElement !== undefined) && (removeIconElement !== undefined)) {
            removeIconElement.style.top = ((inputElement.clientHeight - removeIconElement.clientHeight) / 2) + 'px';        
        }
    };

    function addEventListener () {
        var inputElement = $element[0].children[0].children[0];
        if (inputElement !== undefined) {
            inputElement.addEventListener('blur', onBlur);
            inputElement.addEventListener('focus', onFocus);
            inputElement.addEventListener('keypress', onKeyDown);
            inputElement.addEventListener('keyUp', onKeyUp);
        }
    };

    function onBlur(e) {
        $scope['text'] = accounting.formatNumber($scope['text']);
    };

    function onFocus(e) {
        $scope['text'] = accounting.unformat($scope['text']);
    };

    function onKeyDown(e) {
        e = (e) ? e : window.event;

        var isKeyCodeAllowed = false;
        var charCode = (e.which) ? e.which : e.charCode;

        if ((charCode === 13) ||     // enter
            (charCode === 48) ||     // 0
            (charCode === 49) ||     // 1
            (charCode === 50) ||     // 2
            (charCode === 51) ||     // 3
            (charCode === 52) ||     // 4
            (charCode === 53) ||     // 5
            (charCode === 54) ||     // 6
            (charCode === 55) ||     // 7
            (charCode === 56) ||     // 8
            (charCode === 57))       // 9 
        {
            isKeyCodeAllowed = true;
        } else if (charCode === 46) {
            if ($scope['precision'] === true) {
                var text = $scope['text'].toString();
                if (text !== '') {
                    var dotIndex = text.indexOf('.');
                    if (dotIndex === -1) {
                        isKeyCodeAllowed = true;
                    }
                }
            }                            
        }

        if (isKeyCodeAllowed === false) {
            e.preventDefault();
        }
    };

    function onKeyUp(e) {
        // Formating
    };
};