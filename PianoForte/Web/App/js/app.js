'use strict';

goog.provide('PianoForte.App');

goog.require('PianoForte.Controllers.Books.BookController');
goog.require('PianoForte.Controllers.Books.BookMainController');

goog.require('PianoForte.Controllers.Cds.CdController');
goog.require('PianoForte.Controllers.Cds.CdMainController');

goog.require('PianoForte.Controllers.Courses.CourseController');
goog.require('PianoForte.Controllers.Courses.CourseMainController');

goog.require('PianoForte.Controllers.Students.StudentController');
goog.require('PianoForte.Controllers.Students.StudentMainController');

goog.require('PianoForte.Controllers.Teachers.TeacherController');
goog.require('PianoForte.Controllers.Teachers.TeacherMainController');

goog.require('PianoForte.Controllers.Widgets.MyBox.MyBoxController');
goog.require('PianoForte.Controllers.Widgets.MyDialogBox.MyDialogBoxController');
goog.require('PianoForte.Controllers.Widgets.MyLeftMenu.MyLeftMenuController');
goog.require('PianoForte.Controllers.Widgets.MyTabs.MyTabsController');

goog.require('PianoForte.Directives.Widgets.MyBox.MyBoxDirective');
goog.require('PianoForte.Directives.Widgets.MyDialogBox.MyDialogBoxDirective');
goog.require('PianoForte.Directives.Widgets.MyLeftMenu.MyLeftMenuDirective');
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
        .when('/books', {
            controller: 'BookMainController',
            templateUrl: 'partials/books/book-main.htm'
        })
        .when('/cds', {
            controller: 'CdMainController',
            templateUrl: 'partials/cds/cd-main.htm'
        })
        .when('/courses', {
            controller: 'CourseMainController',
            templateUrl: 'partials/courses/course-main.htm'
        })
        .when('/students', {
            controller: 'StudentMainController',
            templateUrl: 'partials/students/student-main.htm'
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

PianoForte.App.controller('BookMainController', ['$scope', PianoForte.Controllers.Books.BookMainController]);
PianoForte.App.controller('CdMainController', ['$scope', PianoForte.Controllers.Cds.CdMainController]);
PianoForte.App.controller('CourseMainController', ['$scope', PianoForte.Controllers.Courses.CourseMainController]);    
PianoForte.App.controller('StudentMainController', ['$scope', PianoForte.Controllers.Students.StudentMainController]);
PianoForte.App.controller('TeacherController', ['$scope', '$routeParams', 'Enum', 'EnumConverter', 'TeacherService', PianoForte.Controllers.Teachers.TeacherController]);
PianoForte.App.controller('TeacherMainController', ['$scope', PianoForte.Controllers.Teachers.TeacherMainController]);
PianoForte.App.controller('MyBoxController', ['$scope', PianoForte.Controllers.Widgets.MyBox.MyBoxController]);
PianoForte.App.controller('MyDialogBoxController', ['$scope', PianoForte.Controllers.Widgets.MyDialogBox.MyDialogBoxController]);
PianoForte.App.controller('MyLeftMenuController', ['$scope', PianoForte.Controllers.Widgets.MyLeftMenu.MyLeftMenuController]);
PianoForte.App.controller('MyTabsController', ['$scope', PianoForte.Controllers.Widgets.MyTabs.MyTabsController]);

PianoForte.App.directive('myBox', PianoForte.Directives.Widgets.MyBox.MyBoxDirective);
PianoForte.App.directive('myDialogBox', PianoForte.Directives.Widgets.MyDialogBox.MyDialogBoxDirective);
PianoForte.App.directive('myLeftMenu', PianoForte.Directives.Widgets.MyLeftMenu.MyLeftMenuDirective);
PianoForte.App.directive('myPane', PianoForte.Directives.Widgets.MyTabs.MyPaneDirective);
PianoForte.App.directive('myTabs', PianoForte.Directives.Widgets.MyTabs.MyTabsDirective);

PianoForte.App.service('Enum', [PianoForte.Enum]);
PianoForte.App.service('EnumConverter', ['Enum', PianoForte.Utilities.EnumConverter]);
PianoForte.App.service('TeacherService', ['$http', PianoForte.Services.Teachers.TeacherService]);