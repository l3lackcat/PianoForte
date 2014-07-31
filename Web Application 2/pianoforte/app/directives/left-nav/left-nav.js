angular.module('pianoforte')

.controller('Widgets.LeftMenuController', [
	'$scope', 
	function ($scope) {
		$scope.menuItems = [
			{
				name: 'teachers',
				className: '',
				link: '#/teachers',
				text: ''
			},
			{
				name: 'students',
				className: '',
				link: '#/students',
				text: ''
			},
			{
				name: 'courses',
				className: '',
				link: '#/courses',
				text: ''
			},
			{
				name: 'books',
				className: '',
				link: '#/books',
				text: ''
			},
			{
				name: 'cds',
				className: '',
				link: '#/cds',
				text: ''
			}
		];

		$scope.$on('SelectMenuItem', function (scope, itemName) {
			$scope.select(itemName);
		});

		$scope.initialize = function () {
			for (var i = $scope.menuItems.length - 1; i >= 0; i--) {
				var menuItem = $scope.menuItems[i];		

				menuItem.className = menuItem.name;
				menuItem.text = menuItem.name;

				if (menuItem.name === $scope.defaultMenu) {
					menuItem.className += ' active';
				}			
			}
		};

		$scope.select = function (itemName) {
			for (var i = $scope.menuItems.length - 1; i >= 0; i--) {
				var menuItem = $scope.menuItems[i];
				
				menuItem.className = menuItem.name;

				if (menuItem.name === itemName) {
					menuItem.className += ' active';
				}
			}
		};
	}
])

.directive('widgetLeftMenu', function () {
	return {
		restrict: 'E',
		controller: 'Widgets.LeftMenuController',
		templateUrl: 'directives/left-nav/left-nav.htm',
		replace: true,
		scope: {
			defaultMenu: '@'
		},
		link: function (scope) {
			scope.initialize();
		}		
	};
});