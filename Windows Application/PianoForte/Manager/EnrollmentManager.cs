using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class EnrollmentManager
    {
        private static EnrollmentDao enrollmentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getEnrollmentDao();

        public static Enrollment insertEnrollment(Enrollment enrollment)
        {
            bool isInsertComplete = enrollmentDao.insertEnrollment(enrollment);
            if (isInsertComplete)
            {
                enrollment.Id = enrollmentDao.findLastEnrollment().Id;
            }
            else
            {
                enrollment = null;
            }

            return enrollment;
        }

        public static bool updateEnrollment(Enrollment enrollment)
        {
            return enrollmentDao.updateEnrollment(enrollment);
        }

        public static bool deleteEnrollment(int enrollmentId)
        {
            return enrollmentDao.deleteEnrollment(enrollmentId);
        }

        public static Enrollment getEnrollment(int enrollmentId)
        {
            Enrollment enrollment = enrollmentDao.findEnrollment(enrollmentId);
            if (enrollment != null)
            {
                enrollment.Student = StudentManager.findStudent(enrollment.Student.Id);
                enrollment.Course = CourseManager.findCourse(enrollment.Course.Id);
                enrollment.ClassroomList = ClassroomManager.findAllClassroom(enrollment.Id);
                for (int j = 0; j < enrollment.ClassroomList.Count; j++)
                {
                    List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollment.ClassroomList[j].Id);
                    enrollment.ClassroomIdClassroomDetailListDictionary.Add(enrollment.ClassroomList[j].Id, tempClassroomDetilList);
                }
            }

            return enrollment;
        }

        public static List<Enrollment> findAllEnrollment()
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollment();
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByPaymentId(int paymentId)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByPaymentId(paymentId);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByStudentId(int studentId)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByStudentId(studentId);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByStudentId(int studentId, Enrollment.EnrollmentStatus enrollmentStatus)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByStudentId(studentId, enrollmentStatus);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByCourseId(int courseId)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByCourseId(courseId);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByCourseId(int courseId, Enrollment.EnrollmentStatus status)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByCourseId(courseId, status);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByDate(DateTime startDate, DateTime endDate)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByDate(startDate, endDate);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        public static List<Enrollment> findAllEnrollmentByDate(DateTime startDate, DateTime endDate, Enrollment.EnrollmentStatus status)
        {
            List<Enrollment> enrollmentList = enrollmentDao.findAllEnrollmentByDate(startDate, endDate, status);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                if (enrollmentList[i] != null)
                {
                    enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
                    enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
                    enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
                    for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
                    {
                        List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
                        enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
                    }
                }
            }

            return enrollmentList;
        }

        //public static Enrollment getEnrollmentByPaymentId_old(int paymentId)
        //{
        //    Enrollment enrollment = enrollmentService.getEnrollmentByPaymentId_old(paymentId);
        //    if (enrollment != null)
        //    {
        //        enrollment.Student = StudentManager.findStudent(enrollment.Student.Id);
        //        enrollment.Course = CourseManager.findCourse(CourseManager.getNewCourseId(enrollment.Course.Id));
        //    }

        //    return enrollment;
        //}

        //public static List<Enrollment> getAllEnrollment_old()
        //{
        //    List<Enrollment> enrollmentList = enrollmentService.getAllEnrollment_old();
        //    for (int i = 0; i < enrollmentList.Count; i++)
        //    {
        //        if (enrollmentList[i] != null)
        //        {
        //            enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
        //            enrollmentList[i].Course = CourseManager.findCourse(CourseManager.getNewCourseId(enrollmentList[i].Course.Id));
        //        }
        //    }

        //    return enrollmentList;
        //}

        //public static List<Enrollment> findAllEnrollment(DateTime startDate, DateTime endDate)
        //{
        //    List<Enrollment> enrollmentList = enrollmentService.getAllEnrollment(startDate, endDate);
        //    for (int i = 0; i < enrollmentList.Count; i++)
        //    {
        //        if (enrollmentList[i] != null)
        //        {
        //            enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
        //            enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
        //            enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
        //            for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
        //            {
        //                List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
        //                enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
        //            }
        //        }
        //    }

        //    return enrollmentList;
        //}

        //public static List<Enrollment> getAllPaidEnrollment(DateTime startDate, DateTime endDate)
        //{
        //    List<Enrollment> enrollmentList = enrollmentService.getAllPaidEnrollment(startDate, endDate);
        //    for (int i = 0; i < enrollmentList.Count; i++)
        //    {
        //        if (enrollmentList[i] != null)
        //        {
        //            enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
        //            enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
        //            enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
        //            for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
        //            {
        //                List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
        //                enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
        //            }
        //        }
        //    }

        //    return enrollmentList;
        //}

        //public static List<Enrollment> getAllEnrollmentByCourseId(int courseId)
        //{
        //    List<Enrollment> enrollmentList = enrollmentService.getAllEnrollmentByCourseId(courseId);
        //    for (int i = 0; i < enrollmentList.Count; i++)
        //    {
        //        if (enrollmentList[i] != null)
        //        {
        //            enrollmentList[i].Student = StudentManager.findStudent(enrollmentList[i].Student.Id);
        //            enrollmentList[i].Course = CourseManager.findCourse(enrollmentList[i].Course.Id);
        //            enrollmentList[i].ClassroomList = ClassroomManager.findAllClassroom(enrollmentList[i].Id);
        //            for (int j = 0; j < enrollmentList[i].ClassroomList.Count; j++)
        //            {
        //                List<ClassroomDetail> tempClassroomDetilList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(enrollmentList[i].ClassroomList[j].Id);
        //                enrollmentList[i].ClassroomIdClassroomDetailListDictionary.Add(enrollmentList[i].ClassroomList[j].Id, tempClassroomDetilList);
        //            }
        //        }
        //    }

        //    return enrollmentList;
        //}

        public static bool cancelEnrollment(int paymentId)
        {
            bool isCancelComplete = false;

            List<Enrollment> tempEnrollmentList = EnrollmentManager.findAllEnrollmentByPaymentId(paymentId);
            for (int i = 0; i < tempEnrollmentList.Count; i++)
            {
                Enrollment tempEnrollment = tempEnrollmentList[i];
                if (tempEnrollment != null)
                {
                    if (EnrollmentManager.cancelEnrollment(tempEnrollment))
                    {
                        isCancelComplete = true;
                    }
                    else
                    {
                        isCancelComplete = false;
                        break;
                    }
                }
            }

            return isCancelComplete;
        }

        public static bool cancelEnrollment(Enrollment enrollment)
        {
            bool returnFlag = false;

            if (enrollment != null)
            {
                enrollment.Status = Enrollment.EnrollmentStatus.CANCELED.ToString();                
                bool isUpdateEnrollmentComplete = EnrollmentManager.updateEnrollment(enrollment);
                if (isUpdateEnrollmentComplete)
                {
                    returnFlag = true;

                    List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(enrollment.Id);
                    for (int i = 0; i < tempClassroomList.Count; i++)
                    {
                        if (returnFlag)
                        {
                            Classroom tempClassroom = tempClassroomList[i];
                            if (tempClassroomList != null)
                            {
                                tempClassroom.Status = Classroom.ClassroomStatus.CANCELED.ToString();

                                bool isUpdateClassroomComplete = ClassroomManager.updateClassroom(tempClassroom);
                                if (isUpdateClassroomComplete)
                                {
                                    returnFlag = true;

                                    List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(tempClassroom.Id);
                                    for (int j = 0; j < tempClassroomDetailList.Count; j++)
                                    {
                                        if (returnFlag)
                                        {
                                            ClassroomDetail tempClassroomDetail = tempClassroomDetailList[j];
                                            if (tempClassroomDetail != null)
                                            {
                                                tempClassroomDetail.CurrentStatus = ClassroomDetail.ClassroomStatus.CANCELED.ToString();

                                                bool isUpdateClassroomDetailComplete = ClassroomDetailManager.updateClassroomDetail(tempClassroomDetail);
                                                if (isUpdateClassroomDetailComplete)
                                                {
                                                    returnFlag = true;
                                                }
                                                else
                                                {
                                                    LogManager.writeLog("Error Occur : updateClassroomDetail failed at PaymentMainForm.cancelEnrollment()");
                                                    returnFlag = false;
                                                    break;
                                                }
                                            }
                                        }                                        
                                    }
                                }
                                else
                                {
                                    LogManager.writeLog("Error Occur : updateClassroom failed at PaymentMainForm.cancelEnrollment()");
                                    returnFlag = false;
                                    break;
                                }
                            }
                        }  
                    }
                }
                else
                {
                    LogManager.writeLog("Error Occur : updateEnrollment failed at PaymentMainForm.cancelEnrollment()");
                }
            }

            return returnFlag;
        }

        public static bool processEnrollment(Enrollment enrollment)
        {
            bool returnFlag = false;
            
            if (enrollment.Id != 0)
            {                
                returnFlag = EnrollmentManager.updateEnrollment(enrollment);
            }
            else
            {
                enrollment = EnrollmentManager.insertEnrollment(enrollment);
                if (enrollment != null)
                {
                    returnFlag = true;

                    for (int i = 0; i < enrollment.ClassroomList.Count; i++)
                    {
                        int classroomIdBuffer = enrollment.ClassroomList[i].Id;

                        enrollment.ClassroomList[i].EnrollmentId = enrollment.Id;
                        Classroom tempClassroom = ClassroomManager.insertClassroom(enrollment.ClassroomList[i]);
                        if (tempClassroom != null)
                        {
                            returnFlag = true;
                            enrollment.ClassroomList[i].Id = tempClassroom.Id;

                            for (int j = 0; j < enrollment.ClassroomIdClassroomDetailListDictionary[classroomIdBuffer].Count; j++)
                            {
                                enrollment.ClassroomIdClassroomDetailListDictionary[classroomIdBuffer][j].ClassroomId = enrollment.ClassroomList[i].Id;
                                returnFlag = ClassroomDetailManager.insertClassroomDetail(enrollment.ClassroomIdClassroomDetailListDictionary[classroomIdBuffer][j]);
                                if (!returnFlag)
                                {
                                    LogManager.writeLog("Error occur : INSERT ClassroomDetail failed at StudentProfileForm.processEnrollment where classroomId = " + enrollment.ClassroomList[i].Id.ToString());
                                    break;
                                }
                            }
                        }
                        else
                        {
                            returnFlag = false;
                            LogManager.writeLog("Error occur : INSERT Classroom failed at StudentProfileForm.processEnrollment where enrollmentId = " + enrollment.Id.ToString());
                            break;
                        }

                        if (!returnFlag)
                        {
                            break;
                        }
                    }
                }
            }            

            return returnFlag;
        }
    }
}
