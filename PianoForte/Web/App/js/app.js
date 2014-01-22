'use strict';

goog.provide('PianoForte.App');

goog.require('PianoForte.Controllers.Teachers.TeacherController');
goog.require('PianoForte.Controllers.Teachers.TeacherMainController');
goog.require('PianoForte.Controllers.Widgets.MyBox.MyBoxController');
goog.require('PianoForte.Controllers.Widgets.MyDialogBox.MyDialogBoxController');
goog.require('PianoForte.Controllers.Widgets.MyTabs.MyTabsController');

goog.require('PianoForte.Directives.Widgets.MyBox.MyBoxDirective');
goog.require('PianoForte.Directives.Widgets.MyDialogBox.MyDialogBoxDirective');
goog.require('PianoForte.Directives.Widgets.MyTabs.MyPaneDirective');
goog.require('PianoForte.Directives.Widgets.MyTabs.MyTabsDirective');

goog.require('PianoForte.Enum');

goog.require('PianoForte.Services.Teachers.TeacherService');

goog.require('PianoForte.Utilities.EnumConverter');

PianoForte.App = angular.module('PianoForteApplication', ['ngRoute']);

PianoForte.App.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'TeacherMainController',
            templateUrl: 'partials/teachers/teacher-main.htm'
        })
		.when('/teachers', {
		    controller: 'TeacherMainController',
		    templateUrl: 'partials/teachers/teacher-main.htm'
		})
        .when('/teachers/:teacherId', {
            controller: 'TeacherController',
            templateUrl: 'partials/teachers/teacher.htm'
        })
        .otherwise({
            redirectTo: '/'
        });
}]);

PianoForte.App.controller('TeacherController', ['$scope', '$routeParams', 'Enum', 'EnumConverter', 'TeacherService', PianoForte.Controllers.Teachers.TeacherController]);
PianoForte.App.controller('TeacherMainController', ['$scope', PianoForte.Controllers.Teachers.TeacherMainController]);
PianoForte.App.controller('MyBoxController', ['$scope', PianoForte.Controllers.Widgets.MyBox.MyBoxController]);
PianoForte.App.controller('MyDialogBoxController', ['$scope', PianoForte.Controllers.Widgets.MyDialogBox.MyDialogBoxController]);
PianoForte.App.controller('MyTabsController', ['$scope', PianoForte.Controllers.Widgets.MyTabs.MyTabsController]);

PianoForte.App.directive('myBox', PianoForte.Directives.Widgets.MyBox.MyBoxDirective);
PianoForte.App.directive('myDialogBox', PianoForte.Directives.Widgets.MyDialogBox.MyDialogBoxDirective);
PianoForte.App.directive('myPane', PianoForte.Directives.Widgets.MyTabs.MyPaneDirective);
PianoForte.App.directive('myTabs', PianoForte.Directives.Widgets.MyTabs.MyTabsDirective);

PianoForte.App.service('Enum', [PianoForte.Enum]);
PianoForte.App.service('EnumConverter', ['Enum', PianoForte.Utilities.EnumConverter]);
PianoForte.App.service('TeacherService', ['$http', PianoForte.Services.Teachers.TeacherService]);