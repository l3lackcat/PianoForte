angular.module('pianoforte')

.controller('Widgets.DialogBoxController', [
    '$scope',
    '$rootScope',
    '$element',
    function ($scope, $rootScope, $element) {
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
    }
])

.directive('widgetDialogBox', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.DialogBoxController',
        templateUrl: 'directives/dialog-box/dialog-box.htm',
        replace: true,
        transclude: true,
        scope: {
            disabled: '=',
            filterable: '=',
            title: '@',
            submit: '&',
            close: '&',
            visible: '='
        },
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
});