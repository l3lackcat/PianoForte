using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Enum
{
    public class EnumConverter
    {
        public EnumConverter()
        { 
            // Do Nothing
        }

        public static string ToString(ClassroomType classroomType)
        {
            string str = "";

            if (classroomType == ClassroomType.NORMAL)
            {
                str = "Normal";
            }
            else if (classroomType == ClassroomType.POSTPONE)
            {
                str = "Postpone";
            }
            else if (classroomType == ClassroomType.EXTRA)
            {
                str = "Extra";
            }

            return str;
        }

        public static ClassroomType ToClassroomType(string str)
        {
            ClassroomType classroomType = ClassroomType.NONE;

            if ((str == "Normal") || (str == "1"))
            {
                classroomType = ClassroomType.NORMAL;
            }
            else if ((str == "Postpone") || (str == "2"))
            {
                classroomType = ClassroomType.POSTPONE;
            }
            else if ((str == "Extra") || (str == "3"))
            {
                classroomType = ClassroomType.EXTRA;
            }
            else
            {
                classroomType = ClassroomType.NONE;
            }

            return classroomType;
        }

        public static string ToString(ProductType productType)
        {
            string str = "";

            if (productType == ProductType.COURSE)
            {
                str = "Course";
            }
            else if (productType == ProductType.BOOK)
            {
                str = "Book";
            }
            else if (productType == ProductType.BOOK)
            {
                str = "CD";
            }
            else if (productType == ProductType.BOOK)
            {
                str = "Other";
            }

            return str;
        }

        public static ProductType ToProductType(string str)
        {
            ProductType productType = ProductType.NONE;

            if ((str == "Course") || (str == "1"))
            {
                productType = ProductType.COURSE;
            }
            else if ((str == "Book") || (str == "2"))
            {
                productType = ProductType.BOOK;
            }
            else if ((str == "CD") || (str == "3"))
            {
                productType = ProductType.CD;
            }
            else if ((str == "Other") || (str == "4"))
            {
                productType = ProductType.OTHER;
            }
            else
            {
                productType = ProductType.NONE;
            }

            return productType;
        }

        public static string ToString(Status status)
        {
            string str = "";

            if (status == Status.ACTIVE)
            {
                str = "Active";
            }
            else if (status == Status.INACTIVE)
            {
                str = "Inactive";
            }
            else if (status == Status.DROP)
            {
                str = "Drop";
            }
            else if (status == Status.RESIGNED)
            {
                str = "Resigned";
            }
            else if (status == Status.AVAILABLE)
            {
                str = "Available";
            }
            else if (status == Status.EMPTY)
            {
                str = "Empty";
            }
            else if (status == Status.CANCELLED)
            {
                str = "Cancelled";
            }
            else if (status == Status.PAID)
            {
                str = "Paid";
            }
            else if (status == Status.NOT_PAID)
            {
                str = "Not Paid";
            }
            else if (status == Status.WAITING)
            {
                str = "Waiting";
            }
            else if (status == Status.CHECKED_IN)
            {
                str = "Checked In";
            }
            else if (status == Status.POSTPONED)
            {
                str = "Postponed";
            }
            else if (status == Status.STUDENT_ABSENCE)
            {
                str = "Student Absence";
            }
            else if (status == Status.STUDENT_MISSING)
            {
                str = "Student Missing";
            }
            else if (status == Status.TEACHER_ABSENCE)
            {
                str = "Teacher Absence";
            }
            else if (status == Status.TEACHER_MISSING)
            {
                str = "Teacher Missing";
            }
            else if (status == Status.TEACHER_QUITTED)
            {
                str = "Teacher Quitted";
            }
            else if (status == Status.SCHOOL_HOLIDAY)
            {
                str = "School Holiday";
            }
            else if (status == Status.DELETED)
            {
                str = "Deleted";
            }

            return str;
        }

        public static Status ToStatus(string str)
        {
            Status status = Status.NONE;

            if ((str == "Active") || (str == "1"))
            {
                status = Status.ACTIVE;
            }
            else if ((str == "Inactive") || (str == "2"))
            {
                status = Status.INACTIVE;
            }
            else if ((str == "Drop") || (str == "3"))
            {
                status = Status.DROP;
            }
            else if ((str == "Resigned") || (str == "4"))
            {
                status = Status.RESIGNED;
            }
            else if ((str == "Available") || (str == "5"))
            {
                status = Status.AVAILABLE;
            }
            else if ((str == "Empty") || (str == "6"))
            {
                status = Status.EMPTY;
            }
            else if ((str == "Cancelled") || (str == "7"))
            {
                status = Status.CANCELLED;
            }
            else if ((str == "Paid") || (str == "8"))
            {
                status = Status.PAID;
            }
            else if ((str == "Not Paid") || (str == "9"))
            {
                status = Status.NOT_PAID;
            }
            else if ((str == "Waiting") || (str == "10"))
            {
                status = Status.WAITING;
            }
            else if ((str == "Checked In") || (str == "11"))
            {
                status = Status.CHECKED_IN;
            }
            else if ((str == "Postponed") || (str == "12"))
            {
                status = Status.POSTPONED;
            }
            else if ((str == "Student Absence") || (str == "13"))
            {
                status = Status.STUDENT_ABSENCE;
            }
            else if ((str == "Student Missing") || (str == "14"))
            {
                status = Status.STUDENT_MISSING;
            }
            else if ((str == "Teacher Absence") || (str == "15"))
            {
                status = Status.STUDENT_ABSENCE;
            }
            else if ((str == "Teacher Missing") || (str == "16"))
            {
                status = Status.TEACHER_MISSING;
            }
            else if ((str == "Teacher Quitted") || (str == "17"))
            {
                status = Status.TEACHER_QUITTED;
            }
            else if ((str == "School Holiday") || (str == "18"))
            {
                status = Status.SCHOOL_HOLIDAY;
            }
            else if ((str == "Deleted") || (str == "19"))
            {
                status = Status.DELETED;
            }

            return status;
        }

        public static string ToString(UserRole userRole)
        {
            string str = "";

            if (userRole == UserRole.ADMIN)
            {
                str = "Admin";
            }
            else if (userRole == UserRole.LOCAL_ADMIN)
            {
                str = "Local Admin";
            }
            else if (userRole == UserRole.LOCAL_USER)
            {
                str = "Local User";
            }
            else if (userRole == UserRole.STUDENT)
            {
                str = "Student";
            }
            else if (userRole == UserRole.TEACHER)
            {
                str = "Teacher";
            }

            return str;
        }

        public static UserRole ToUserRole(string str)
        {
            UserRole localUserRole = UserRole.NONE;

            if ((str == "Admin") || (str == "1"))
            {
                localUserRole = UserRole.ADMIN;
            }
            else if ((str == "Local Admin") || (str == "2"))
            {
                localUserRole = UserRole.LOCAL_ADMIN;
            }
            else if ((str == "Local User") || (str == "3"))
            {
                localUserRole = UserRole.LOCAL_USER;
            }
            else if ((str == "Student") || (str == "4"))
            {
                localUserRole = UserRole.STUDENT;
            }
            else if ((str == "Teacher") || (str == "5"))
            {
                localUserRole = UserRole.TEACHER;
            }
            else
            {
                localUserRole = UserRole.NONE;
            }

            return localUserRole;
        }

        public static string ToString(ContactType contactType)
        {
            string str = "";

            if (contactType == ContactType.PHONE)
            {
                str = "Phone";
            }
            else if (contactType == ContactType.EMAIL)
            {
                str = "Email";
            }

            return str;
        }

        public static ContactType ToContactType(string str)
        {
            ContactType contactType = ContactType.NONE;

            if ((str == "Phone") || (str == "1"))
            {
                contactType = ContactType.PHONE;
            }
            else if ((str == "Email") || (str == "2"))
            {
                contactType = ContactType.EMAIL;
            }
            else
            {
                contactType = ContactType.NONE;
            }

            return contactType;
        }

        public static string ToString(TeacherProperty teacherProperty)
        {
            string str = "";

            if (teacherProperty == TeacherProperty.TEACHES_45_MIN)
            {
                str = "Phone";
            }

            return str;
        }

        public static TeacherProperty ToTeacherProperty(string str)
        {
            TeacherProperty teacherProperty = TeacherProperty.NONE;

            if ((str == "Home Phone") || (str == "1"))
            {
                teacherProperty = TeacherProperty.TEACHES_45_MIN;
            }
            else
            {
                teacherProperty = TeacherProperty.NONE;
            }

            return teacherProperty;
        }
    }
}