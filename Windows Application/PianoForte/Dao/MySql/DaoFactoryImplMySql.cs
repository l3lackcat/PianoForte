using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;

namespace PianoForte.Dao.MySql
{
    public class DaoFactoryImplMySql : DaoFactory
    {
        public override BookDao getBookDao()
        {
            return new BookDaoImplMySql();
        }

        //public override BookOrderDetailDao getBookOrderDetailDao()
        //{
        //    return new BookOrderDetailDaoImplMySql();
        //}

        public override CdDao getCdDao()
        {
            return new CdDaoImplMySql();
        }

        //public override CdOrderDetailDao getCdOrderDetailDao()
        //{
        //    return new CdOrderDetailDaoImplMySql();
        //}

        public override ClassroomDao getClassroomDao()
        {
            return new ClassroomDaoImplMySql();
        }

        public override ClassroomDetailDao getClassroomDetailDao()
        {
            return new ClassroomDetailDaoImplMySql();
        }

        //public override ClassroomEnrollmentDao getClassroomEnrollmentDao()
        //{
        //    return new ClassroomEnrollmentDaoImplMySql();
        //}

        public override CourseCategoryDao getCourseCategoryDao()
        {
            return new CourseCategoryDaoImplMySql();
        }

        public override CourseDao getCourseDao()
        {
            return new CourseDaoImplMySql();
        }

        public override EnrollmentDao getEnrollmentDao()
        {
            return new EnrollmentDaoImplMySql();
        }

        public override HolidayDao getHolidayDao()
        {
            return new HolidayDaoImplMySql();
        }

        public override OtherCostDao getOtherCostDao()
        {
            return new OtherCostDaoImplMySql();
        }

        //public override OtherCostOrderDetailDao getOtherCostOrderDetailDao()
        //{
        //    return new OtherCostOrderDetailDaoImplMySql();
        //}

        public override PaymentDao getPaymentDao()
        {
            return new PaymentDaoImplMySql();
        }

        public override PaymentDetailDao getPaymentDetailDao()
        {
            return new PaymentDetailDaoImplMySql();
        }

        public override RoomDao getRoomDao()
        {
            return new RoomDaoImplMySql();
        }

        public override RoomDetailDao getRoomDetailDao()
        {
            return new RoomDetailDaoImplMySql();
        }

        public override StudentDao getStudentDao()
        {
            return new StudentDaoImplMySql();
        }

        public override TeacherDao getTeacherDao()
        {
            return new TeacherDaoImplMySql();
        }

        public override TeachingCourseDao getTeachingCourseDao()
        {
            return new TeachingCourseDaoImplMySql();
        }

        public override UserDao getUserDao()
        {
            return new UserDaoImplMySql();
        }

        public override ProductDao getProductDao()
        {
            return new ProductDaoImplMySql();
        }
    }
}
