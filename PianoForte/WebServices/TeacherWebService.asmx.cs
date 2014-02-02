using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Services;

namespace PianoForte.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class TeacherWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public Teacher getTeacherById(string databaseName, int teacherId)
        {
            //System.Threading.Thread.Sleep(3000);

            Teacher teacher = TeacherService.getTeacher(databaseName, teacherId);
            if (teacher != null)
            {
                //Contact list
                teacher.ContactList = TeacherContactService.getTeacherContactList(databaseName, teacherId, Status.ACTIVE);

                //Teached course list
                List<int> teachedCourseIdList = TeachedCourseService.getTeachedCourseIdList(databaseName, teacherId);
                foreach (int teachedCourseId in teachedCourseIdList)
                {
                    Course course = CourseService.getCourse(databaseName, teachedCourseId);
                    if (course != null)
                    {
                        if (!teacher.TeachedCourseList.Contains(course.Name))
                        {
                            teacher.TeachedCourseList.Add(course.Name);
                        }
                    }
                }
            }

            return teacher;
        }

        [WebMethod]
        public bool saveTeacherGeneralInfo(string databaseName, Teacher teacher)
        {
            System.Threading.Thread.Sleep(3000);
            return TeacherService.updateTeacher(databaseName, teacher);
        }
    }
}
