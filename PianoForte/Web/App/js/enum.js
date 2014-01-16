'use strict';

goog.provide('PianoForte.Enum');

PianoForte.Enum = function () {
    this['Status'] = {
        'None': 0,
        'Active': 1,
        'Inactive': 2,
        'Drop': 3,
        'Resigned': 4,
        'Available': 5,
        'Empty': 6,
        'Cancelled': 7,
        'Paid': 8,
        'NotPaid': 9,
        'Waiting': 10,
        'CheckedIn': 11,
        'Postponed': 12,
        'StudentAbsence': 13,
        'StudentMissing': 14,
        'TeacherAbsence': 15,
        'TeacherMissing': 16,
        'TeacherQuitted': 17,
        'SchoolHoliday': 18,
        'Deleted': 19
    };

    this['ContactType'] = {
        'None': 0,
        'Phone': 1,
        'Email': 2
    };
}