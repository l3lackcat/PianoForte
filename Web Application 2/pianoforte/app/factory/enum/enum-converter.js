angular.module('pianoforte')

.factory('EnumConverter', [
    function () {
        return {
            ContactType: {
                toNumber: function (input) {
                    if (Enum.Status.hasOwnProperty(val)) {
                        return Enum.Status[input];
                    }

                    return 0;
                },

                toString: function (input) {
                    var keyList = _.keys(Enum.Status);

                    if (keyList[input] !== undefined) {
                        return keyList[input];
                    }

                    return '';
                }
            },

            Status: {
                toNumber: function (input) {
                    if (Enum.Status.hasOwnProperty(val)) {
                        return Enum.Status[input];
                    }

                    return 0;
                },

                toString: function (input) {
                    var keyList = _.keys(Enum.Status);

                    if (keyList[input] !== undefined) {
                        return keyList[input];
                    }

                    return '';
                }
            }
        };
    }
]);