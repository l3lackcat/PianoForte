using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class CalendarEventDaoImplMySql : CalendarEventDao
    {
        //private List<CalendarEvent> getCalendarEvents(string sql)
        //{
        //    List<CalendarEvent> calendarEventList = new List<CalendarEvent>();

        //    MySqlConnection conn = null;
        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
        //        conn = new MySqlConnection(connectionString);
        //        if (conn != null)
        //        {
        //            conn.Open();
        //            MySqlCommand command = new MySqlCommand(sql, conn);
        //            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

        //            DataSet data = new DataSet();
        //            dataAdapter.Fill(data, ClassroomDetails.TableName);
        //            dataAdapter.Fill(data, Classrooms.TableName);
        //            dataAdapter.Fill(data, Enrollments.TableName);
        //            dataAdapter.Fill(data, Courses.TableName);
        //            dataAdapter.Fill(data, Students.TableName);

        //            for (int i = 0; i < data.Tables[ClassroomDetails.TableName].Rows.Count; i++)
        //            {
        //                Teacher teacher = new Teacher();
        //                teacher.Id = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnTeacherId].ToString());

        //                Course course = new Course();
        //                course.Id = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseId].ToString());
        //                course.Name = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseName].ToString();
        //                course.Level = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseLevel].ToString();
        //                course.ClassroomDuration = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnClassroomDuration].ToString());

        //                List<string> phoneNumberList = new List<string>();
        //                string phoneNumber = data.Tables[Students.TableName].Rows[i][Students.ColumnPhone1].ToString();
        //                if (phoneNumber != "")
        //                {
        //                    phoneNumberList.Add(phoneNumber);
        //                }

        //                phoneNumber = data.Tables[Students.TableName].Rows[i][Students.ColumnPhone2].ToString();
        //                if (phoneNumber != "")
        //                {
        //                    phoneNumberList.Add(phoneNumber);
        //                }

        //                phoneNumber = data.Tables[Students.TableName].Rows[i][Students.ColumnPhone3].ToString();
        //                if (phoneNumber != "")
        //                {
        //                    phoneNumberList.Add(phoneNumber);
        //                }

        //                Student student = new Student();
        //                student.Id = Convert.ToInt32(data.Tables[Students.TableName].Rows[i][Students.ColumnStudentId].ToString());
        //                student.Firstname = data.Tables[Students.TableName].Rows[i][Students.ColumnFirstname].ToString();
        //                student.Lastname = data.Tables[Students.TableName].Rows[i][Students.ColumnLastname].ToString();
        //                student.Nickname = data.Tables[Students.TableName].Rows[i][Students.ColumnNickname].ToString();
        //                student.ContactList = phoneNumberList;

        //                CalendarEvent calendarEvent = new CalendarEvent();
        //                calendarEvent.Id = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomDetailId].ToString());
        //                calendarEvent.Title = student.Id + " - " + student.Nickname;
        //                calendarEvent.Start = Convert.ToDateTime(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomStart].ToString());
        //                calendarEvent.End = Convert.ToDateTime(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassrooomEnd].ToString());
        //                calendarEvent.IsAllDay = false;
        //                calendarEvent.Teacher = teacher;
        //                calendarEvent.Student = student;
        //                calendarEvent.Course = course;

        //                calendarEventList.Add(calendarEvent);
        //            }
        //        }
        //    }
        //    catch (System.InvalidOperationException e)
        //    {
        //        Console.Write(e.Message);
        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.Write(e.Message);
        //    }
        //    catch (System.SystemException e)
        //    {
        //        Console.Write(e.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return calendarEventList;
        //}

        //public List<CalendarEvent> getCalendarEvents(int teacherId, DateTime startDate, DateTime endDate)
        //{
        //    string sql = "SELECT " +
        //                 ClassroomDetails.TableName + "." + ClassroomDetails.ColumnClassroomDetailId + ", " +
        //                 ClassroomDetails.TableName + "." + ClassroomDetails.ColumnTeacherId + ", " +
        //                 ClassroomDetails.TableName + "." + ClassroomDetails.ColumnClassroomStart + ", " +
        //                 ClassroomDetails.TableName + "." + ClassroomDetails.ColumnClassrooomEnd + ", " +
        //                 Courses.TableName + "." + Courses.ColumnCourseId + ", " +
        //                 Courses.TableName + "." + Courses.ColumnCourseName + ", " +
        //                 Courses.TableName + "." + Courses.ColumnCourseLevel + ", " +
        //                 Courses.TableName + "." + Courses.ColumnClassroomDuration + ", " +
        //                 Students.TableName + "." + Students.ColumnStudentId + ", " +
        //                 Students.TableName + "." + Students.ColumnFirstname + ", " +
        //                 Students.TableName + "." + Students.ColumnLastname + ", " +
        //                 Students.TableName + "." + Students.ColumnNickname + ", " +
        //                 Students.TableName + "." + Students.ColumnPhone1 + ", " +
        //                 Students.TableName + "." + Students.ColumnPhone2 + ", " +
        //                 Students.TableName + "." + Students.ColumnPhone3 + " " +
        //                 "FROM " +
        //                 ClassroomDetails.TableName + ", " +
        //                 Classrooms.TableName + ", " +
        //                 Enrollments.TableName + ", " +
        //                 Courses.TableName + ", " +
        //                 Students.TableName + " " +
        //                 "WHERE " + ClassroomDetails.TableName + "." + ClassroomDetails.ColumnClassroomId + " = " + Classrooms.TableName + "." + Classrooms.ColumnClassroomId + " " +
        //                 "AND " + Classrooms.TableName + "." + Classrooms.ColumnEnrollmentId + " = " + Enrollments.TableName + "." + Enrollments.ColumnEnrollmentId + " " +
        //                 "AND " + Enrollments.TableName + "." + Enrollments.ColumnCourseId + " = " + Courses.TableName + "." + Courses.ColumnCourseId + " " +
        //                 "AND " + Enrollments.TableName + "." + Enrollments.ColumnStudentId + " = " + Students.TableName + "." + Students.ColumnStudentId + " " +                         
        //                 "AND " + ClassroomDetails.TableName + "." + ClassroomDetails.ColumnTeacherId + " = " + teacherrd.ToString() +  " +
        //                 "AND " + ClassroomDetails.TableName + "." + ClassroomDetails.ColumnClassroomStart + " = '" + StartDate.ToString("yyyy-MM-dd HH:mm:ss" + "' " +
        //                 "AND " + ClassroomDetails.TableName + "."+ ClassroomDetails.ColumnClassroomStart + " <= " + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
        //                 "ORDER BY " + ClassroomDetails.ColumnClassroomDetailId + " ASC";
        //
        //    return getCalendarEvents(sql);
        //}
    }
}