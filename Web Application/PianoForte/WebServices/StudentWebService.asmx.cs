using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Services;
using PianoForte.Utilities;

namespace PianoForte.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class StudentWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public int getStudentListSize(string databaseName)
        {
            List<Student> studentList = StudentService.getStudentList(databaseName);
            return studentList.Count;
        }

        [WebMethod]
        public List<Object> getStudentList(string databaseName, int startIndex, int offset)
        {
            System.Threading.Thread.Sleep(1500);

            List<Object> displayedStudentList = new List<Object>();
            List<Student> studentList = StudentService.getStudentList(databaseName, startIndex, offset);
            foreach (Student student in studentList)
            {
                List<StudentContact> studentContactList = StudentContactService.getStudentContactList(databaseName, student.Id, Status.ACTIVE);

                string phoneNumber = "-";
                foreach (StudentContact contact in studentContactList)
                {
                    if (contact.Type == ContactType.PHONE)
                    {
                        if (phoneNumber == "-")
                        {
                            phoneNumber = contact.Content;
                        }
                        else
                        {
                            if (contact.IsPrimary)
                            {
                                phoneNumber = contact.Content;
                                break;
                            }
                        }
                    }
                }

                displayedStudentList.Add(new
                {
                    id = student.Id,
                    name = student.Firstname + " " + student.Lastname,
                    nickname = student.Nickname,
                    phoneNumber = phoneNumber,
                    status = student.Status
                });
            }

            return displayedStudentList;
        }
    }
}
