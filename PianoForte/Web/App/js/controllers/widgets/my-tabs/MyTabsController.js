'use strict';

goog.provide('PianoForte.Controllers.Widgets.MyTabsController');

PianoForte.Controllers.Widgets.MyTabsController = function ($scope, $attrs, $element) {
    var panes = $scope.panes = [];

    $scope.select = function (pane) {
        angular.forEach(panes, function (pane) {
            pane.selected = false;
        });

        pane.selected = true;
    };

    this.addPane = function (pane) {
        if (panes.length == 0) {
            $scope.select(pane);
        }

        panes.push(pane);
    };

    $scope.$on('changeTab', function (event, paneTitle) {
        var previousActivePane = null;
        var nextActivePane = null;

        angular.forEach(panes, function (pane) {
            if (pane.title === paneTitle) {
                nextActivePane = pane;
            }

            if (pane.selected === true) {
                previousActivePane = pane;
            }

            pane.selected = false;
        });

        if (nextActivePane === null) {
            if (previousActivePane !== null) {
                previousActivePane.selected = true;
            }
        } else {
            nextActivePane.selected = true;
        }
    });
};