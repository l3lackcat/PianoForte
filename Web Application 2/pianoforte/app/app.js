angular.module('pianoforte', [
	'ngRoute'
])

.config([
	'$routeProvider',
	'$locationProvider',
	function ($routeProvider, $locationProvider) {	
		$locationProvider.html5Mode(true);
			
		$routeProvider
			.when('/', {
				controller: 'Teachers.MainController',
				templateUrl: 'views/teachers/main.htm'
			})
			.when('/books', {
				controller: 'Books.MainController',
				templateUrl: 'views/books/main.htm'
			})
			.when('/books/:bookId', {
				controller: 'Books.AboutController',
				templateUrl: 'views/books/about.htm'
			})
			.when('/cds', {
				controller: 'Cds.MainController',
				templateUrl: 'views/cds/main.htm'
			})
			.when('/cds/:cdId', {
				controller: 'Cds.AboutController',
				templateUrl: 'views/cds/about.htm'
			})
			.when('/courses', {
				controller: 'Courses.MainController',
				templateUrl: 'views/courses/main.htm'
			})
			.when('/courses:courseId', {
				controller: 'Courses.AboutController',
				templateUrl: 'views/courses/about.htm'
			})
			.when('/students', {
				controller: 'Students.MainController',
				templateUrl: 'views/students/main.htm'
			})
			.when('/students/:studentId', {
				controller: 'Students.AboutController',
				templateUrl: 'views/students/about.htm'
			})
			.when('/teachers', {
				controller: 'Teachers.MainController',
				templateUrl: 'views/teachers/main.htm'
			})
			.when('/teachers/:teacherId', {
				controller: 'Teachers.AboutController',
				templateUrl: 'views/teachers/about.htm'
			})
			.otherwise({
				redirectTo: '/'
			});		
	}
]);
