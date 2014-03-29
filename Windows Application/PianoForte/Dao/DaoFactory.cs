using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Dao
{
    public abstract class DaoFactory
    {
        public enum FactoryType
        {
            MYSQL
        }

        public abstract BookDao getBookDao();

        //public abstract BookOrderDetailDao getBookOrderDetailDao();

        public abstract CdDao getCdDao();

        //public abstract CdOrderDetailDao getCdOrderDetailDao();

        public abstract ClassroomDao getClassroomDao();

        public abstract ClassroomDetailDao getClassroomDetailDao();

        //public abstract ClassroomEnrollmentDao getClassroomEnrollmentDao();

        public abstract CourseCategoryDao getCourseCategoryDao();

        public abstract CourseDao getCourseDao();

        public abstract EnrollmentDao getEnrollmentDao();

        public abstract HolidayDao getHolidayDao();

        public abstract OtherCostDao getOtherCostDao();

        //public abstract OtherCostOrderDetailDao getOtherCostOrderDetailDao();

        public abstract PaymentDao getPaymentDao();

        public abstract PaymentDetailDao getPaymentDetailDao();

        public abstract RoomDao getRoomDao();

        public abstract RoomDetailDao getRoomDetailDao();

        public abstract StudentDao getStudentDao();

        public abstract TeacherDao getTeacherDao();

        public abstract TeachingCourseDao getTeachingCourseDao();

        public abstract UserDao getUserDao();

        public abstract ProductDao getProductDao();

        public static DaoFactory getDaoFactory(FactoryType factoryType)
        {
            DaoFactory factory = null;

            switch (factoryType)
            {
                case FactoryType.MYSQL:
                    factory = new MySql.DaoFactoryImplMySql();
            	    break;
            }

            return factory;
        }
    }
}
