angular.module('pianoforte')

.controller('Widgets.TextBoxController', [
    '$scope',
    '$element',
    function ($scope, $element) {
        $scope.initialize = function () {
            adjustWidth();
            adjustRemoveIconPosition();
        };

        $scope.removeText = function () {
            $scope.text = '';
        };

        function adjustWidth () {
            if ($scope.width !== undefined) {
                $element.css('display', 'inline-block');
                $element.css('width', $scope.width + 'px');
            }
        };

        function adjustRemoveIconPosition () {
            var inputElement = $element[0].children[0].children[0];
            var removeIconElement = $element[0].children[0].children[1];
            
            if ((inputElement !== undefined) && (removeIconElement !== undefined)) {
                removeIconElement.style.top = ((inputElement.clientHeight - removeIconElement.clientHeight) / 2) + 'px';
            }
        };
    }
])

.directive('widgetTextBox', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.TextBoxController',
        templateUrl: 'directives/text-box/text-box.htm',
        replace: true,
        scope: {            
            disabled: '=',
            placeholder: '@',
            text: '=',
            width: '='
        },
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
});