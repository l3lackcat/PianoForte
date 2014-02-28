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

goog.require('PianoForte.Controllers.Widgets.MyBoxController');
goog.require('PianoForte.Controllers.Widgets.MyButtonController');
goog.require('PianoForte.Controllers.Widgets.MyDialogBoxController');
goog.require('PianoForte.Controllers.Widgets.MyLeftMenuController');
goog.require('PianoForte.Controllers.Widgets.MySearchBoxController');
goog.require('PianoForte.Controllers.Widgets.MySelectController');
goog.require('PianoForte.Controllers.Widgets.MyTabsController');
goog.require('PianoForte.Controllers.Widgets.MyTextBoxController');

goog.require('PianoForte.Directives.Widgets.MyBoxDirective');
goog.require('PianoForte.Directives.Widgets.MyButtonDirective');
goog.require('PianoForte.Directives.Widgets.MyDialogBoxDirective');
goog.require('PianoForte.Directives.Widgets.MyLeftMenuDirective');
goog.require('PianoForte.Directives.Widgets.MyPaneDirective');
goog.require('PianoForte.Directives.Widgets.MyScrollbarDirective');
goog.require('PianoForte.Directives.Widgets.MySearchBoxDirective');
goog.require('PianoForte.Directives.Widgets.MySelectDirective');
goog.require('PianoForte.Directives.Widgets.MyTabsDirective');
goog.require('PianoForte.Directives.Widgets.MyTextBoxDirective');

goog.require('PianoForte.Enum');

goog.require('PianoForte.Services.CourseService');
goog.require('PianoForte.Services.TeacherService');

goog.require('PianoForte.Utilities.EnumConverter');
goog.require('PianoForte.Utilities.FormatManager');
goog.require('PianoForte.Utilities.ValidationManager');

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

//We already have a limitTo filter built-in to angular,
//let's make a startFrom filter
PianoForte.App.filter('startFrom', function() {
    return function(input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});

PianoForte.App.controller('BookMainController', ['$scope', '$rootScope', PianoForte.Controllers.Books.BookMainController]);
PianoForte.App.controller('CdMainController', ['$scope', '$rootScope', PianoForte.Controllers.Cds.CdMainController]);
PianoForte.App.controller('CourseMainController', ['$scope', '$rootScope', PianoForte.Controllers.Courses.CourseMainController]);
PianoForte.App.controller('StudentMainController', ['$scope', '$rootScope', PianoForte.Controllers.Students.StudentMainController]);
PianoForte.App.controller('TeacherController', ['$scope', '$rootScope', '$routeParams', 'TeacherService', 'CourseService', 'Enum', 'EnumConverter', 'ValidationManager', 'FormatManager', PianoForte.Controllers.Teachers.TeacherController]);
PianoForte.App.controller('TeacherMainController', ['$scope', '$rootScope', 'TeacherService', 'FormatManager', PianoForte.Controllers.Teachers.TeacherMainController]);
PianoForte.App.controller('MyBoxController', ['$scope', PianoForte.Controllers.Widgets.MyBoxController]);
PianoForte.App.controller('MyButtonController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.MyButtonController]);
PianoForte.App.controller('MyDialogBoxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.MyDialogBoxController]);
PianoForte.App.controller('MyLeftMenuController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.MyLeftMenuController]);
PianoForte.App.controller('MySearchBoxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.MySearchBoxController]);
PianoForte.App.controller('MySelectController', ['$scope', '$attrs', '$element', '$document', PianoForte.Controllers.Widgets.MySelectController]);
PianoForte.App.controller('MyTabsController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.MyTabsController]);
PianoForte.App.controller('MyTextBoxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.MyTextBoxController]);

PianoForte.App.directive('myBox', PianoForte.Directives.Widgets.MyBoxDirective);
PianoForte.App.directive('myButton', PianoForte.Directives.Widgets.MyButtonDirective);
PianoForte.App.directive('myDialogBox', PianoForte.Directives.Widgets.MyDialogBoxDirective);
PianoForte.App.directive('myLeftMenu', PianoForte.Directives.Widgets.MyLeftMenuDirective);
PianoForte.App.directive('myPane', PianoForte.Directives.Widgets.MyPaneDirective);
PianoForte.App.directive('myScrollbar', PianoForte.Directives.Widgets.MyScrollbarDirective);
PianoForte.App.directive('mySearchBox', PianoForte.Directives.Widgets.MySearchBoxDirective);
PianoForte.App.directive('mySelect', PianoForte.Directives.Widgets.MySelectDirective);
PianoForte.App.directive('myTabs', PianoForte.Directives.Widgets.MyTabsDirective);
PianoForte.App.directive('myTextBox', PianoForte.Directives.Widgets.MyTextBoxDirective);

PianoForte.App.service('Enum', [PianoForte.Enum]);
PianoForte.App.service('EnumConverter', ['Enum', PianoForte.Utilities.EnumConverter]);
PianoForte.App.service('FormatManager', [PianoForte.Utilities.FormatManager]);
PianoForte.App.service('ValidationManager', [PianoForte.Utilities.ValidationManager]);
PianoForte.App.service('CourseService', ['$http', PianoForte.Services.CourseService]);
PianoForte.App.service('TeacherService', ['$http', PianoForte.Services.TeacherService]);