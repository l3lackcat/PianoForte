using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PianoForte.Dao
{
    public class DaoFactoryImplMySql : DaoFactory
    {        
        public override CalendarEventDao getCalendarEventDao()
        {
            return new CalendarEventDaoImplMySql();
        }

        public override BranchDao getBranchDao()
        {
            return new BranchDaoImplMySql();
        }

        public override GlobalUserDao getGlobalUserDao()
        {
            return new GlobalUserDaoImplMySql();
        }

        public override StudentDao getStudentDao()
        {
            return new StudentDaoImplMySql();
        }

        public override StudentAddressDao getStudentAddressDao()
        {
            return new StudentAddressDaoImplMySql();
        }

        public override StudentContactDao getStudentContactDao()
        {
            return new StudentContactDaoImplMySql();
        }

        public override TeacherDao getTeacherDao()
        {
            return new TeacherDaoImplMySql();
        }

        public override TeacherContactDao getTeacherContactDao()
        {
            return new TeacherContactDaoImplMySql();
        }

        public override LocalUserDao getLocalUserDao()
        {
            return new LocalUserDaoImplMySql();
        }

        public override CourseCategoryDao getCourseCategoryDao()
        {
            return new CourseCategoryDaoImplMySql();
        }

        public override CourseDao getCourseDao()
        {
            return new CourseDaoImplMySql();
        }

        public override BookDao getBookDao()
        {
            return new BookDaoImplMySql();
        }

        public override CdDao getCdDao()
        {
            return new CdDaoImplMySql();
        }

        public override OtherProductDao getOtherProductDao()
        {
            return new OtherProductDaoImplMySql();
        }

        public override ProductUnitPriceHistoryDao getProductUnitPriceHistoryDao()
        {
            return new ProductUnitPriceHistoryDaoImplMySql();
        }

        public override EnrollmentDao getEnrollmentDao()
        {
            return new EnrollmentDaoImplMySql();
        }

        public override ClassroomDao getClassroomDao()
        {
            return new ClassroomDaoImplMySql();
        }

        public override ClassroomDetailDao getClassroomDetailDao()
        {
            return new ClassroomDetailDaoImplMySql();
        }

        public override HolidayDao getHolidayDao()
        {
            return new HolidayDaoImplMySql();
        }

        public override PaymentDao getPaymentDao()
        {
            return new PaymentDaoImplMySql();
        }

        public override CashPaymentDao getCashPaymentDao()
        {
            return new CashPaymentDaoImplMySql();
        }

        public override CreditCardPaymentDao getCreditCardPaymentDao()
        {
            return new CreditCardPaymentDaoImplMySql();
        }

        public override PaymentDetailDao getPaymentDetailDao()
        {
            return new PaymentDetailDaoImplMySql();
        }

        public override TeachedCourseDao getTeachedCourseDao()
        {
            return new TeachedCourseDaoImplMySql();
        }
    }
}