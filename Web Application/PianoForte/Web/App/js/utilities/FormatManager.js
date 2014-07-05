'use strict';

goog.provide('PianoForte.Utilities.FormatManager');

PianoForte.Utilities.FormatManager = function(ValidationManager) {
    return {
        formatPhoneNumber: function(input) {
            if (input == null) { return input; };

            var formattedPhoneNumber = input;
            var isPhoneNumber = ValidationManager.isPhoneNumber(input);

            if ((input !== '') && (isPhoneNumber === true)) {
                var part1;
                var part2;
                var part3;

                input = input.replace(/-/g, '');

                var inputLength = input.length;
                if ((inputLength === 9) && (input.substring(0, 2) === '02')) {
                    part1 = input.substring(0, 2);
                    part2 = input.substring(2, 5);
                    part3 = input.substring(5, inputLength);
                } else {
                    part1 = input.substring(0, 3);
                    part2 = input.substring(3, 6);
                    part3 = input.substring(6, inputLength);                    
                }

                if ((part1 !== '') && (part1 !== '') && (part1 !== '')) {
                    formattedPhoneNumber = part1 + '-' + part2 + '-' + part3;
                }
            }

            return formattedPhoneNumber;
        },

        unformatPhoneNumber: function(input) {
            if (input == null) { return input; };
            
            var unformattedPhoneNumber = input;

            if (input !== '') {
                unformattedPhoneNumber = input.replace(/-/g, '');
            }

            return unformattedPhoneNumber;
        },

        formatNumber: function(input) {
            return accounting.formatNumber(input);
        },

        unformatNumber: function(input) {
            return accounting.unformat(input);
        }
    };
};