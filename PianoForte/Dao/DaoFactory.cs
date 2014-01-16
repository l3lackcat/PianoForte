using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Dao
{
    public abstract class DaoFactory
    {
        public enum FactoryType
        {
            MYSQL
        }

        public static DaoFactory getDaoFactory(FactoryType factoryType)
        {
            DaoFactory factory = null;

            switch (factoryType)
            {
                case FactoryType.MYSQL:
                    factory = new DaoFactoryImplMySql();
                    break;
            }

            return factory;
        }        

        public abstract CalendarEventDao getCalendarEventDao();

        public abstract BranchDao getBranchDao();

        public abstract GlobalUserDao getGlobalUserDao();

        public abstract StudentDao getStudentDao();

        public abstract StudentAddressDao getStudentAddressDao();

        public abstract StudentContactDao getStudentContactDao();

        public abstract TeacherDao getTeacherDao();

        public abstract TeacherContactDao getTeacherContactDao();

        public abstract LocalUserDao getLocalUserDao();

        public abstract CourseCategoryDao getCourseCategoryDao();

        public abstract CourseDao getCourseDao();

        public abstract BookDao getBookDao();

        public abstract CdDao getCdDao();

        public abstract OtherProductDao getOtherProductDao();

        public abstract ProductUnitPriceHistoryDao getProductUnitPriceHistoryDao();

        public abstract EnrollmentDao getEnrollmentDao();

        public abstract ClassroomDao getClassroomDao();

        public abstract ClassroomDetailDao getClassroomDetailDao();

        public abstract HolidayDao getHolidayDao();

        public abstract PaymentDao getPaymentDao();

        public abstract CashPaymentDao getCashPaymentDao();

        public abstract CreditCardPaymentDao getCreditCardPaymentDao();

        public abstract PaymentDetailDao getPaymentDetailDao();

        public abstract TeachedCourseDao getTeachedCourseDao();
    }
}