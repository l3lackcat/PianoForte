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
        private int delay = 1500;

        [WebMethod]
        public int getStudentListSize(string databaseName)
        {
            List<Student> studentList = StudentService.getStudentList(databaseName);
            return studentList.Count;
        }

        [WebMethod]
        public List<Object> getStudentList(string databaseName, int startIndex, int offset)
        {
            System.Threading.Thread.Sleep(delay);

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

        [WebMethod]
        public Object getStudentById(string databaseName, int id)
        {
            System.Threading.Thread.Sleep(delay);

            Object student = null;
            List<Object> phoneList = new List<Object>();
            List<Object> emailList = new List<Object>();

            Student tempStudent = StudentService.getStudent(databaseName, id);
            if (tempStudent != null)
            {
                //Contact list
                tempStudent.ContactList = StudentContactService.getStudentContactList(databaseName, tempStudent.Id, Status.ACTIVE);
                foreach (StudentContact contact in tempStudent.ContactList)
                {
                    if (contact.Type == ContactType.PHONE)
                    {
                        phoneList.Add(new
                        {
                            id = contact.Id,
                            label = contact.Label,
                            value = contact.Content,
                            status = contact.Status,
                            isPrimary = contact.IsPrimary
                        });
                    }
                    else if (contact.Type == ContactType.EMAIL)
                    {
                        emailList.Add(new
                        {
                            id = contact.Id,
                            label = contact.Label,
                            value = contact.Content,
                            status = contact.Status,
                            isPrimary = contact.IsPrimary
                        });
                    }
                }

                student = new
                {
                    id = tempStudent.Id,
                    firstname = tempStudent.Firstname,
                    lastname = tempStudent.Lastname,
                    nickname = tempStudent.Nickname,
                    birthDate = tempStudent.BirthDate,
                    registeredDate = tempStudent.RegisteredDate,
                    status = tempStudent.Status,
                    phoneList = phoneList,
                    emailList = emailList
                };
            }

            return student;
        }
    }
}
