'use strict';

goog.provide('PianoForte.Controllers.Widgets.DialogBoxController');

PianoForte.Controllers.Widgets.DialogBoxController = function ($scope, $attrs, $element, $rootScope) {
    var dialogBoxContent = null;

    $scope.initialize = function () {
        dialogBoxContent = $element[0].children[0].children[0].children[1];

        addEventListener();
        adjustPostion();
    };

    $scope.onSubmit = function () {
        $scope.submit();
    };

    $scope.onCancel = function () {
        $scope.close();
    };

    $scope.$watch('visible', function (newInput, oldInput) {
        if (newInput === true) {
            adjustPostion();
        }
    });

    function addEventListener() {
        dialogBoxContent.onscroll = onScrollDialogBoxContent;
    };

    function adjustPostion() {
        var documentHeight = document.body.clientHeight;

        dialogBoxContent.style.maxHeight = (documentHeight - 481) + 'px';
    };

    function onScrollDialogBoxContent() {
        $rootScope.$broadcast('onScroll', 'DialogBoxContent');
    };
};