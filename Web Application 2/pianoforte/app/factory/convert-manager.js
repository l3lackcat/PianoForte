angular.module('pianoforte')

.factory('ConvertManager', [
    function () {
        return {
            parseJsonDate: function(jsonDateString) {
	            return moment(jsonDateString)
	        }
        };
    }
]);