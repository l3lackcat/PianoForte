'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyLeftMenu.MyLeftMenuController');

PianoForte.Controllers.Widgets.MyLeftMenu.MyLeftMenuController = function ($scope) {
    $scope['menuItems'] = [
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

    $scope.init = function () {
        for (var i = 0; i < $scope['menuItems'].length; i++) {
            $scope['menuItems'][i].className = $scope['menuItems'][i].name;
            $scope['menuItems'][i].text = $scope['menuItems'][i].name;

            if ($scope.defaultMenu === $scope['menuItems'][i].name) {
                $scope['menuItems'][i].className += ' active';
            }            
        }
    };

    $scope.select = function (item) {
        for (var i = 0; i < $scope['menuItems'].length; i++) {
            $scope['menuItems'][i].className = $scope['menuItems'][i].name;
        }

        item.className += ' active';
    };
}