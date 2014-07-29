angular.module('pianoforte', [
  'ngRoute'
])
  .config(['$routeProvider', function ($routeProvider) {
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
