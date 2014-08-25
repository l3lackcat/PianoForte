angular.module('pianoforte', [
	'ngRoute'
])

.config([
	'$locationProvider',
	'$routeProvider',
	function ($locationProvider, $routeProvider) {
		$locationProvider.html5Mode(true);

		$routeProvider
			.otherwise({
				redirectTo: '/home'
			});
	}
]);
