angular.module('pianoforte')

.factory('Enum', [
	function () {
		return {
			ContactType: {
				NONE: 0,
				PHONE: 1,
				EMAIL: 2
			},

			Status: {
				NONE: 0,
				ACTIVE: 1,
				INACTIVE: 2,
				DROP: 3,
				RESIGNED: 4,
				AVAILABLE: 5,
				OUT_OF_STOCK: 6,
				CANCELLED: 7,
				PAID: 8,
				NOT_PAID: 9,
				WAITING: 10,
				CHECKED_IN: 11,
				POSTPONED: 12,
				STUDENT_ABSENCE: 13,
				STUDENT_MISSING: 14,
				TEACHER_ABSENCE: 15,
				TEACHER_MISSING: 16,
				TEACHER_QUITTED: 17,
				SCHOOL_HOLIDAY: 18,
				DELETED: 19
			}
		};
	}]);