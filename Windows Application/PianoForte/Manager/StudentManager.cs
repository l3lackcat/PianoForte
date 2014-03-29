using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class StudentManager
    {
        private static StudentDao studentDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getStudentDao();

        //--------------------------------------------------------------------------------

        public static Student insertStudent(Student student)
        {
            bool isInsertComplete = studentDao.insertStudent(student);
            if (isInsertComplete)
            {
                student.Id = studentDao.findLastStudent().Id;
            }
            else
            {
                student = null;
            }
            return student;
        }

        public static bool updateStudent(Student student)
        {
            return studentDao.updateStudent(student);
        }

        public static bool deleteStudent(Student student)
        {
            return studentDao.deleteStudent(student.Id);
        }

        //--------------------------------------------------------------------------------

        public static Student findStudent(int studentId)
        {
            return studentDao.findStudent(studentId);
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudent()
        {
            return studentDao.findAllStudent();
        }

        public static List<Student> findAllStudent(int startIndex, int offset)
        {
            return studentDao.findAllStudent(startIndex, offset);
        }

        public static List<Student> findAllStudent(Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudent();
            }
            else
            {
                studentList = studentDao.findAllStudent(status);
            }

            return studentList;
        }

        public static List<Student> findAllStudent(Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudent(startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudent(status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByFirstname(string firstname)
        {
            return studentDao.findAllStudentByFirstname(firstname);
        }

        public static List<Student> findAllStudentByFirstname(string firstname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByFirstname(firstname, startIndex, offset);
        }

        public static List<Student> findAllStudentByFirstname(string firstname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstname(firstname);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstname(firstname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByFirstname(string firstname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstname(firstname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstname(firstname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByLastname(string lastname)
        {
            return studentDao.findAllStudentByLastname(lastname);
        }

        public static List<Student> findAllStudentByLastname(string lastname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByLastname(lastname, startIndex, offset);
        }

        public static List<Student> findAllStudentByLastname(string lastname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByLastname(lastname);
            }
            else
            {
                studentList = studentDao.findAllStudentByLastname(lastname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByLastname(string lastname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByLastname(lastname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByLastname(lastname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByNickname(string nickname)
        {
            return studentDao.findAllStudentByNickname(nickname);
        }

        public static List<Student> findAllStudentByNickname(string nickname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByNickname(nickname, startIndex, offset);
        }

        public static List<Student> findAllStudentByNickname(string nickname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByNickname(nickname);
            }
            else
            {
                studentList = studentDao.findAllStudentByNickname(nickname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByNickname(string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByNickname(nickname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByNickname(nickname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname)
        {
            return studentDao.findAllStudentByFirstnameAndLastname(firstname, lastname);
        }

        public static List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByFirstnameAndLastname(firstname, lastname, startIndex, offset);
        }

        public static List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastname(firstname, lastname);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastname(firstname, lastname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastname(firstname, lastname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastname(firstname, lastname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname)
        {
            return studentDao.findAllStudentByFirstnameAndNickname(firstname, nickname);
        }

        public static List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByFirstnameAndNickname(firstname, nickname, startIndex, offset);
        }

        public static List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstnameAndNickname(firstname, nickname);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstnameAndNickname(firstname, nickname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstnameAndNickname(firstname, nickname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstnameAndNickname(firstname, nickname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname)
        {
            return studentDao.findAllStudentByLastnameAndNickname(lastname, nickname);
        }

        public static List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByLastnameAndNickname(lastname, nickname, startIndex, offset);
        }

        public static List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByLastnameAndNickname(lastname, nickname);
            }
            else
            {
                studentList = studentDao.findAllStudentByLastnameAndNickname(lastname, nickname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByLastnameAndNickname(lastname, nickname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByLastnameAndNickname(lastname, nickname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------

        public static List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname)
        {
            return studentDao.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname);
        }

        public static List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            return studentDao.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset);
        }

        public static List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, status);
            }

            return studentList;
        }

        public static List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset)
        {
            List<Student> studentList;

            if (status == Student.StudentStatus.ALL)
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset);
            }
            else
            {
                studentList = studentDao.findAllStudentByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, status, startIndex, offset);
            }

            return studentList;
        }

        //--------------------------------------------------------------------------------
    }
}
