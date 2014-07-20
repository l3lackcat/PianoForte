'use strict';

goog.provide('PianoForte.Utilities.ConvertManager');

PianoForte.Utilities.ConvertManager = function () {
    return {
        parseJsonDate: function(jsonDateString) {
            return moment(jsonDateString)
        }
    };
};