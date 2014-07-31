angular.module('pianoforte')

.factory('ValidationManager', [
    function () {
        function validatePhoneNumber (input) {
            if (input == null) { return false; };

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
        };

        function validateEmail (input) {
            if (input == null) { return false; };

            var isValid = false;

            var emailRegEx = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

            if (emailRegEx.test(input)) {
                isValid = true;
            }

            return isValid;
        };

        function validateName (input) {
            if (input == null) { return false; };

            var isValid = false;

            if (input !== '') {
                isValid = true;
            }

            return isValid;
        };

        return {
            validate: function (type, input) {
                var isValid = false;

                type = type.toLowerCase();

                if (type === 'phone') {
                    isValid = validatePhoneNumber(input);
                } else if (type === 'email') {
                    isValid = validateEmail(input);
                } else if (type === 'name') {
                    isValid = validateName(input);
                }

                return isValid;
            }        
        };
    }
]);