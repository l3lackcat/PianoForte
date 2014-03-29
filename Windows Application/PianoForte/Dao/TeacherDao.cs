using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface TeacherDao
    {
        bool insertTeacher(Teacher teacher);
        bool updateTeacher(Teacher teacher);
        bool deleteTeacher(int teacherId);

        Teacher findTeacher(int teacherId);
        Teacher findLastTeacher();        

        List<Teacher> findAllTeacher();
        List<Teacher> findAllTeacher(int startIndex, int offset);
        List<Teacher> findAllTeacher(Teacher.TeacherStatus status);
        List<Teacher> findAllTeacher(Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByFirstname(string firstname);
        List<Teacher> findAllTeacherByFirstname(string firstname, int startIndex, int offset);
        List<Teacher> findAllTeacherByFirstname(string firstname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByFirstname(string firstname, Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByLastname(string lastname);
        List<Teacher> findAllTeacherByLastname(string lastname, int startIndex, int offset);
        List<Teacher> findAllTeacherByLastname(string lastname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByLastname(string lastname, Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByNickname(string nickname);
        List<Teacher> findAllTeacherByNickname(string nickname, int startIndex, int offset);
        List<Teacher> findAllTeacherByNickname(string nickname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByNickname(string nickname, Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname);
        List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset);
        List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname);
        List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset);
        List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname);
        List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset);
        List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset);

        List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname);
        List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset);
        List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status);
        List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset);
    }
}
