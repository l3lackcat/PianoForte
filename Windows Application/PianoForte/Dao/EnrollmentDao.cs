using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface EnrollmentDao
    {
        bool insertEnrollment(Enrollment enrollment);
        bool updateEnrollment(Enrollment enrollment);
        bool deleteEnrollment(int enrollmentId);

        Enrollment findLastEnrollment();

        Enrollment findEnrollment(int enrollmentId);

        Enrollment findEnrollmentByPaymentId(int paymentId);

        List<Enrollment> findAllEnrollment();

        List<Enrollment> findAllEnrollmentByPaymentId(int paymentId);

        List<Enrollment> findAllEnrollmentByStudentId(int studentId);
        List<Enrollment> findAllEnrollmentByStudentId(int studentId, Enrollment.EnrollmentStatus status);

        List<Enrollment> findAllEnrollmentByCourseId(int courseId);
        List<Enrollment> findAllEnrollmentByCourseId(int courseId, Enrollment.EnrollmentStatus status);

        List<Enrollment> findAllEnrollmentByDate(DateTime startDate, DateTime endDate);
        List<Enrollment> findAllEnrollmentByDate(DateTime startDate, DateTime endDate, Enrollment.EnrollmentStatus status);
    }
}
