angular.module('pianoforte', [
	'ngRoute'
])

.config([
	'$locationProvider',
	'$routeProvider',
	function ($locationProvider, $routeProvider) {
		$locationProvider.html5Mode(true);

		$routeProvider
			.when('/', {
				templateUrl: '/dev/views/home/home.htm'
			})
			// .when('/our-school', {
			// 	templateUrl: 'views/our-school.htm'
			// })
			// .when('/our-courses', {
			// 	templateUrl: 'views/our-courses.htm'
			// })
			// .when('/contact-us', {
			// 	templateUrl: 'views/contact-us.htm'
			// })
			// .when('/eng', {
			// 	templateUrl: 'views/eng.htm'
			// })
			.otherwise({
				redirectTo: '/'
			});
	}
]);
