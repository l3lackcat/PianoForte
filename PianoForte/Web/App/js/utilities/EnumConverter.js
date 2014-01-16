'use strict';

goog.provide('PianoForte.Utilities.EnumConverter');

PianoForte.Utilities.EnumConverter = function (Enum) {
    return {
        Status: {
            toNumber: function (input) {
                if (Enum['Status'].hasOwnProperty(val)) {
                    return Enum['Status'][input];
                }

                return 0;
            },

            toString: function (input) {
                var keyList = _.keys(Enum['Status']);

                if (keyList[input] !== undefined) {
                    return keyList[input];
                }

                return '';
            }
        },

        ContactType: {
            toNumber: function (input) {
                if (Enum['ContactType'].hasOwnProperty(val)) {
                    return Enum['ContactType'][input];
                }

                return 0;
            },

            toString: function (input) {
                var keyList = _.keys(Enum['Status']);

                if (keyList[input] !== undefined) {
                    return keyList[input];
                }

                return '';
            }
        }
    };
}