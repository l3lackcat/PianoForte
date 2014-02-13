'use strict';

goog.provide('PianoForte.Utilities.ValidationService');

PianoForte.Utilities.ValidationService = function () {
    return {
        isPhoneNumber: function (input) {
            var isValid = false;

            input = input.replace(/-/g, '');
            if (input.length === 9) {
                var homePhoneRegEx = /^(0+)(2|5+)(\d{7})$/;

                if (homePhoneRegEx.test(input)) {
                    isValid = true;
                }
            } else if (input.length === 10) {
                var mobilePhoneRegEx = /^(0+)(8|9+)(\d{8})$/;

                if (mobilePhoneRegEx.test(input)) {
                    isValid = true;
                }
            }

            return isValid;
        },

        isEmail: function (input) {
            var isValid = false;

            var emailRegEx = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

            if (emailRegEx.test(input)) {
                isValid = true;
            }

            return isValid;
        }
    };
};