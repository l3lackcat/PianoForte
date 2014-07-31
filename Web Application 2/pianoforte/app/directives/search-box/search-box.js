angular.module('pianoforte')

.controller('Widgets.SearchBoxController', [
    '$scope',
    '$element',
    function ($scope, $element) {
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
            if (inputElement !== undefined) {
                var searchButtonElement = $element[0].children[0].children[1];
                if (searchButtonElement !== undefined) {
                    searchButtonElement.style.top = ((inputElement.clientHeight - searchButtonElement.clientHeight) / 2) + 'px';
                }  

                var searchIconElement = $element[0].children[0].children[2];
                if (searchIconElement !== undefined) {
                    searchIconElement.style.top = ((inputElement.clientHeight - searchIconElement.clientHeight) / 2) + 'px';
                }
            }
        };
    }
])

.directive('widgetSearchBox', function () {
    return {
        restrict: 'E',
        controller: 'Widgets.SearchBoxController',
        templateUrl: 'directives/search-box/search-box.htm',
        replace: true,
        scope: {
            disabled: '=',
            isFilterBox: '=',
            placeholder: '@',
            text: '=',
            width: '='
        },
        link: function (scope, element, attrs) {
            scope.initialize();
        }
    };
});