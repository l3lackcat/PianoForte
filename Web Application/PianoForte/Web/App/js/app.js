'use strict';

goog.provide('PianoForte.App');

// Controllers
goog.require('PianoForte.Controllers.Books.AboutController');
goog.require('PianoForte.Controllers.Books.GeneralInfoEditorController');
goog.require('PianoForte.Controllers.Books.MainController');
goog.require('PianoForte.Controllers.Books.RegisterController');

goog.require('PianoForte.Controllers.Cds.AboutController');
goog.require('PianoForte.Controllers.Cds.GeneralInfoEditorController');
goog.require('PianoForte.Controllers.Cds.MainController');
goog.require('PianoForte.Controllers.Cds.RegisterController');

goog.require('PianoForte.Controllers.Courses.AboutController');
goog.require('PianoForte.Controllers.Courses.MainController');

goog.require('PianoForte.Controllers.Students.AboutController');
goog.require('PianoForte.Controllers.Students.AddressInfoEditorController');
goog.require('PianoForte.Controllers.Students.ContactInfoEditorController');
goog.require('PianoForte.Controllers.Students.GeneralInfoEditorController');
goog.require('PianoForte.Controllers.Students.MainController');

goog.require('PianoForte.Controllers.Teachers.AboutController');
goog.require('PianoForte.Controllers.Teachers.ContactInfoEditorController');
goog.require('PianoForte.Controllers.Teachers.GeneralInfoEditorController');
goog.require('PianoForte.Controllers.Teachers.MainController');
goog.require('PianoForte.Controllers.Teachers.RegisterController');
goog.require('PianoForte.Controllers.Teachers.TeachedCourseInfoEditorController');

goog.require('PianoForte.Controllers.Widgets.BoxController');
goog.require('PianoForte.Controllers.Widgets.ButtonController');
goog.require('PianoForte.Controllers.Widgets.CheckboxController');
goog.require('PianoForte.Controllers.Widgets.DatepickerController');
goog.require('PianoForte.Controllers.Widgets.DialogBoxController');
goog.require('PianoForte.Controllers.Widgets.DropdownMenuController');
goog.require('PianoForte.Controllers.Widgets.LeftMenuController');
goog.require('PianoForte.Controllers.Widgets.NumericBoxController');
goog.require('PianoForte.Controllers.Widgets.PhoneBoxController');
goog.require('PianoForte.Controllers.Widgets.SearchBoxController');
goog.require('PianoForte.Controllers.Widgets.SelectController');
goog.require('PianoForte.Controllers.Widgets.TabsController');
goog.require('PianoForte.Controllers.Widgets.TextBoxController');

// Directives
goog.require('PianoForte.Directives.Books.GeneralInfoEditorDirective');
goog.require('PianoForte.Directives.Books.RegisterDirective');

goog.require('PianoForte.Directives.Cds.GeneralInfoEditorDirective');
goog.require('PianoForte.Directives.Cds.RegisterDirective');

goog.require('PianoForte.Directives.Students.AddressInfoEditorDirective');
goog.require('PianoForte.Directives.Students.ContactInfoEditorDirective');
goog.require('PianoForte.Directives.Students.GeneralInfoEditorDirective');

goog.require('PianoForte.Directives.Teachers.ContactInfoEditorDirective');
goog.require('PianoForte.Directives.Teachers.GeneralInfoEditorDirective');
goog.require('PianoForte.Directives.Teachers.RegisterDirective');
goog.require('PianoForte.Directives.Teachers.TeachedCourseInfoEditorDirective');

goog.require('PianoForte.Directives.Widgets.BoxDirective');
goog.require('PianoForte.Directives.Widgets.ButtonDirective');
goog.require('PianoForte.Directives.Widgets.CheckboxDirective');
goog.require('PianoForte.Directives.Widgets.DatepickerDirective');
goog.require('PianoForte.Directives.Widgets.DialogBoxDirective');
goog.require('PianoForte.Directives.Widgets.DropdownMenuDirective');
goog.require('PianoForte.Directives.Widgets.LeftMenuDirective');
goog.require('PianoForte.Directives.Widgets.NumericBoxDirective');
goog.require('PianoForte.Directives.Widgets.PhoneBoxDirective');
goog.require('PianoForte.Directives.Widgets.SearchBoxDirective');
goog.require('PianoForte.Directives.Widgets.SelectDirective');
goog.require('PianoForte.Directives.Widgets.PaneDirective');
goog.require('PianoForte.Directives.Widgets.TabsDirective');
goog.require('PianoForte.Directives.Widgets.TextBoxDirective');

goog.require('PianoForte.Enum');

goog.require('PianoForte.Models.LocationDataModel');

goog.require('PianoForte.Services.BookService');
goog.require('PianoForte.Services.CdService');
goog.require('PianoForte.Services.CourseService');
goog.require('PianoForte.Services.StudentService');
goog.require('PianoForte.Services.TeacherService');

goog.require('PianoForte.Utilities.ConvertManager');
goog.require('PianoForte.Utilities.EnumConverter');
goog.require('PianoForte.Utilities.FormatManager');
goog.require('PianoForte.Utilities.LocationManager');
goog.require('PianoForte.Utilities.ValidationManager');

PianoForte.App = angular.module('PianoForteApplication', ['ngRoute']);

PianoForte.App.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            controller: 'Teachers.MainController',
            templateUrl: 'partials/teachers/main.htm'
        })
        .when('/books', {
            controller: 'Books.MainController',
            templateUrl: 'partials/books/main.htm'
        })
        .when('/books/:bookId', {
            controller: 'Books.AboutController',
            templateUrl: 'partials/books/about.htm'
        })
        .when('/cds', {
            controller: 'Cds.MainController',
            templateUrl: 'partials/cds/main.htm'
        })
        .when('/cds/:cdId', {
            controller: 'Cds.AboutController',
            templateUrl: 'partials/cds/about.htm'
        })
        .when('/courses', {
            controller: 'Courses.MainController',
            templateUrl: 'partials/courses/main.htm'
        })
        .when('/courses', {
            controller: 'Courses.AboutController',
            templateUrl: 'partials/courses/about.htm'
        })
        .when('/students', {
            controller: 'Students.MainController',
            templateUrl: 'partials/students/main.htm'
        })
        .when('/students/:studentId', {
            controller: 'Students.AboutController',
            templateUrl: 'partials/students/about.htm'
        })
		.when('/teachers', {
		    controller: 'Teachers.MainController',
		    templateUrl: 'partials/teachers/main.htm'
		})            
        .when('/teachers/:teacherId', {
            controller: 'Teachers.AboutController',
            templateUrl: 'partials/teachers/about.htm'
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

// Controller Injections
PianoForte.App.controller('Books.AboutController', ['$scope', '$rootScope', '$location', '$routeParams', 'BookService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Books.AboutController]);
PianoForte.App.controller('Books.GeneralInfoEditorController', ['$scope', '$rootScope', 'BookService', 'Enum', 'EnumConverter', 'ValidationManager', PianoForte.Controllers.Books.GeneralInfoEditorController]);
PianoForte.App.controller('Books.MainController', ['$scope', '$rootScope', 'filterFilter', 'BookService', 'EnumConverter', 'FormatManager', PianoForte.Controllers.Books.MainController]);
PianoForte.App.controller('Books.RegisterController', ['$scope', '$rootScope', '$location', 'BookService', 'Enum', 'ValidationManager', PianoForte.Controllers.Books.RegisterController]);

PianoForte.App.controller('Cds.AboutController', ['$scope', '$rootScope', '$location', '$routeParams', 'CdService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Cds.AboutController]);
PianoForte.App.controller('Cds.GeneralInfoEditorController', ['$scope', '$rootScope', 'CdService', 'Enum', 'EnumConverter', 'ValidationManager', PianoForte.Controllers.Cds.GeneralInfoEditorController]);
PianoForte.App.controller('Cds.MainController', ['$scope', '$rootScope', 'filterFilter', 'CdService', 'EnumConverter', 'FormatManager', PianoForte.Controllers.Cds.MainController]);
PianoForte.App.controller('Cds.RegisterController', ['$scope', '$rootScope', '$location', 'CdService', 'Enum', 'ValidationManager', PianoForte.Controllers.Cds.RegisterController]);

PianoForte.App.controller('Courses.AboutController', ['$scope', '$rootScope', '$routeParams', 'CourseService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Courses.AboutController]);
PianoForte.App.controller('Courses.MainController', ['$scope', '$rootScope', 'filterFilter', 'CourseService', 'EnumConverter', 'FormatManager', PianoForte.Controllers.Courses.MainController]);

PianoForte.App.controller('Students.AboutController', ['$scope', '$rootScope', '$routeParams', 'StudentService', 'ConvertManager', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Students.AboutController]);
PianoForte.App.controller('Students.AddressInfoEditorController', ['$scope', '$rootScope', 'StudentService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Students.AddressInfoEditorController]);
PianoForte.App.controller('Students.ContactInfoEditorController', ['$scope', '$rootScope', 'StudentService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Students.ContactInfoEditorController]);
PianoForte.App.controller('Students.GeneralInfoEditorController', ['$scope', '$rootScope', 'StudentService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Students.GeneralInfoEditorController]);
PianoForte.App.controller('Students.MainController', ['$scope', '$rootScope', 'filterFilter', 'StudentService', 'EnumConverter', 'FormatManager', PianoForte.Controllers.Students.MainController]);

PianoForte.App.controller('Teachers.AboutController', ['$scope', '$rootScope', '$location', '$routeParams', 'TeacherService', 'CourseService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Teachers.AboutController]);
PianoForte.App.controller('Teachers.ContactInfoEditorController', ['$scope', '$rootScope', 'TeacherService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Teachers.ContactInfoEditorController]);
PianoForte.App.controller('Teachers.GeneralInfoEditorController', ['$scope', '$rootScope', 'TeacherService', 'Enum', 'EnumConverter', 'FormatManager', 'ValidationManager', PianoForte.Controllers.Teachers.GeneralInfoEditorController]);
PianoForte.App.controller('Teachers.MainController', ['$scope', '$rootScope', 'filterFilter', 'TeacherService', 'Enum', 'EnumConverter', 'FormatManager', PianoForte.Controllers.Teachers.MainController]);
PianoForte.App.controller('Teachers.RegisterController', ['$scope', '$rootScope', '$location', 'TeacherService', 'Enum', 'ValidationManager', PianoForte.Controllers.Teachers.RegisterController]);
PianoForte.App.controller('Teachers.TeachedCourseInfoEditorController', ['$scope', '$rootScope', 'TeacherService', 'Enum', 'EnumConverter', 'ValidationManager', PianoForte.Controllers.Teachers.TeachedCourseInfoEditorController]);

PianoForte.App.controller('Widgets.BoxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.BoxController]);
PianoForte.App.controller('Widgets.ButtonController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.ButtonController]);
PianoForte.App.controller('Widgets.CheckboxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.CheckboxController]);
PianoForte.App.controller('Widgets.DatepickerController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.DatepickerController]);
PianoForte.App.controller('Widgets.DialogBoxController', ['$scope', '$attrs', '$element', '$rootScope', PianoForte.Controllers.Widgets.DialogBoxController]);
PianoForte.App.controller('Widgets.DropdownMenuController', ['$scope', '$attrs', '$element', '$document', 'filterFilter', PianoForte.Controllers.Widgets.DropdownMenuController]);
PianoForte.App.controller('Widgets.LeftMenuController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.LeftMenuController]);
PianoForte.App.controller('Widgets.NumericBoxController', ['$scope', '$attrs', '$element', 'FormatManager', PianoForte.Controllers.Widgets.NumericBoxController]);
PianoForte.App.controller('Widgets.PhoneBoxController', ['$scope', '$attrs', '$element', 'FormatManager', PianoForte.Controllers.Widgets.PhoneBoxController]);
PianoForte.App.controller('Widgets.SearchBoxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.SearchBoxController]);
PianoForte.App.controller('Widgets.SelectController', ['$scope', '$attrs', '$element', '$document', PianoForte.Controllers.Widgets.SelectController]);
PianoForte.App.controller('Widgets.TabsController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.TabsController]);
PianoForte.App.controller('Widgets.TextBoxController', ['$scope', '$attrs', '$element', PianoForte.Controllers.Widgets.TextBoxController]);

// Directive Injection
PianoForte.App.directive('bookGeneralInfoEditor', PianoForte.Directives.Books.GeneralInfoEditorDirective);
PianoForte.App.directive('bookRegister', PianoForte.Directives.Books.RegisterDirective);

PianoForte.App.directive('cdGeneralInfoEditor', PianoForte.Directives.Cds.GeneralInfoEditorDirective);
PianoForte.App.directive('cdRegister', PianoForte.Directives.Cds.RegisterDirective);

PianoForte.App.directive('studentAddressInfoEditor', PianoForte.Directives.Students.AddressInfoEditorDirective);
PianoForte.App.directive('studentContactInfoEditor', PianoForte.Directives.Students.ContactInfoEditorDirective);
PianoForte.App.directive('studentGeneralInfoEditor', PianoForte.Directives.Students.GeneralInfoEditorDirective);

PianoForte.App.directive('teacherContactInfoEditor', PianoForte.Directives.Teachers.ContactInfoEditorDirective);
PianoForte.App.directive('teacherGeneralInfoEditor', PianoForte.Directives.Teachers.GeneralInfoEditorDirective);
PianoForte.App.directive('teacherRegister', PianoForte.Directives.Teachers.RegisterDirective);
PianoForte.App.directive('teacherTeachedCourseInfoEditor', PianoForte.Directives.Teachers.TeachedCourseInfoEditorDirective);

PianoForte.App.directive('widgetBox', PianoForte.Directives.Widgets.BoxDirective);
PianoForte.App.directive('widgetButton', PianoForte.Directives.Widgets.ButtonDirective);
PianoForte.App.directive('widgetCheckbox', PianoForte.Directives.Widgets.CheckboxDirective);
PianoForte.App.directive('widgetDatepicker', PianoForte.Directives.Widgets.DatepickerDirective);
PianoForte.App.directive('widgetDialogBox', PianoForte.Directives.Widgets.DialogBoxDirective);
PianoForte.App.directive('widgetDropdownMenu', PianoForte.Directives.Widgets.DropdownMenuDirective);
PianoForte.App.directive('widgetLeftMenu', PianoForte.Directives.Widgets.LeftMenuDirective);
PianoForte.App.directive('widgetNumericBox', PianoForte.Directives.Widgets.NumericBoxDirective);
PianoForte.App.directive('widgetPhoneBox', PianoForte.Directives.Widgets.PhoneBoxDirective);
PianoForte.App.directive('widgetSearchBox', PianoForte.Directives.Widgets.SearchBoxDirective);
PianoForte.App.directive('widgetSelect', PianoForte.Directives.Widgets.SelectDirective);
PianoForte.App.directive('widgetPane', PianoForte.Directives.Widgets.PaneDirective);
PianoForte.App.directive('widgetTabs', PianoForte.Directives.Widgets.TabsDirective);
PianoForte.App.directive('widgetTextBox', PianoForte.Directives.Widgets.TextBoxDirective);


PianoForte.App.service('Enum', [PianoForte.Enum]);
PianoForte.App.service('ConvertManager', [PianoForte.Utilities.ConvertManager]);
PianoForte.App.service('EnumConverter', ['Enum', PianoForte.Utilities.EnumConverter]);
PianoForte.App.service('FormatManager', ['ValidationManager', PianoForte.Utilities.FormatManager]);
PianoForte.App.service('LocationManager', ['LocationDataModel', PianoForte.Utilities.LocationManager]);
PianoForte.App.service('ValidationManager', [PianoForte.Utilities.ValidationManager]);

PianoForte.App.service('BookService', ['$http', 'FormatManager', PianoForte.Services.BookService]);
PianoForte.App.service('CdService', ['$http', 'FormatManager', PianoForte.Services.CdService]);
PianoForte.App.service('CourseService', ['$http', 'FormatManager', PianoForte.Services.CourseService]);
PianoForte.App.service('StudentService', ['$http', PianoForte.Services.StudentService]);
PianoForte.App.service('TeacherService', ['$http', PianoForte.Services.TeacherService]);