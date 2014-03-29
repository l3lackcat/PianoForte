using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface StudentDao
    {
        bool insertStudent(Student student);
        bool updateStudent(Student student);
        bool deleteStudent(int studentId);

        Student findStudent(int studentId);
        Student findLastStudent();        

        List<Student> findAllStudent();
        List<Student> findAllStudent(int startIndex, int offset);
        List<Student> findAllStudent(Student.StudentStatus status);
        List<Student> findAllStudent(Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByFirstname(string firstname);
        List<Student> findAllStudentByFirstname(string firstname, int startIndex, int offset);
        List<Student> findAllStudentByFirstname(string firstname, Student.StudentStatus status);
        List<Student> findAllStudentByFirstname(string firstname, Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByLastname(string lastname);
        List<Student> findAllStudentByLastname(string lastname, int startIndex, int offset);
        List<Student> findAllStudentByLastname(string lastname, Student.StudentStatus status);
        List<Student> findAllStudentByLastname(string lastname, Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByNickname(string nickname);
        List<Student> findAllStudentByNickname(string nickname, int startIndex, int offset);
        List<Student> findAllStudentByNickname(string nickname, Student.StudentStatus status);
        List<Student> findAllStudentByNickname(string nickname, Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname);
        List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset);
        List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status);
        List<Student> findAllStudentByFirstnameAndLastname(string firstname, string lastname, Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname);
        List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset);
        List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status);
        List<Student> findAllStudentByFirstnameAndNickname(string firstname, string nickname, Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname);
        List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset);
        List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status);
        List<Student> findAllStudentByLastnameAndNickname(string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset);

        List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname);
        List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset);
        List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status);
        List<Student> findAllStudentByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Student.StudentStatus status, int startIndex, int offset);
    }
}
