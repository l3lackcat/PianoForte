using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Enum
{
    public enum ClassroomType
    {
        NONE,                   // 0
        NORMAL,                 // 1
        POSTPONE,               // 2
        EXTRA,                  // 3
    }

    public enum ProductType
    {
        NONE,                   // 0
        COURSE,                 // 1
        BOOK,                   // 2
        CD,                     // 3
        OTHER,                  // 4
    }

    public enum Status
    {
        NONE,                   // 0          
        ACTIVE,                 // 1
        INACTIVE,               // 2
        DROP,                   // 3
        RESIGNED,               // 4
        AVAILABLE,              // 5
        EMPTY,                  // 6
        CANCELLED,              // 7
        PAID,                   // 8
        NOT_PAID,               // 9
        WAITING,                // 10
        CHECKED_IN,             // 11
        POSTPONED,              // 12
        STUDENT_ABSENCE,        // 13
        STUDENT_MISSING,        // 14
        TEACHER_ABSENCE,        // 15
        TEACHER_MISSING,        // 16
        TEACHER_QUITTED,        // 17
        SCHOOL_HOLIDAY,         // 18
        DELETED                 // 19
    }

    public enum UserRole
    {
        NONE,                   // 0
        ADMIN,                  // 1
        LOCAL_ADMIN,            // 2
        LOCAL_USER,             // 3
        STUDENT,                // 4
        TEACHER                 // 5
    }

    public enum ContactType
    {
        NONE,                   // 0
        PHONE,                  // 1
        EMAIL                   // 2
    }

    public enum TeacherProperty
    {
        NONE,                   // 0
        TEACHES_45_MIN          // 1
    }   

    public class Enum
    {
        // Do Nothing
    }
}