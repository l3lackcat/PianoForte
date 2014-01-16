'use strict';

goog.provide('PianoForte.Directives.Widgets.MyBox.MyBoxDirective');

PianoForte.Directives.Widgets.MyBox.MyBoxDirective = function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: {
            title: '@',
            editable: '@'
        },
        controller: 'MyBoxController',
        templateUrl: 'partials/widgets/my-box/my-box.htm'
    };
}

//PianoForteApp.directive('myBox', function () {
//    return {
//        restrict: 'E',
//        transclude: true,
//        scope: {
//            title: '@',
//            editable: '@'
//        },
//        controller: 'MyBoxController',
//        templateUrl: 'partials/widgets/my-box/my-box.htm'
//    };
//});