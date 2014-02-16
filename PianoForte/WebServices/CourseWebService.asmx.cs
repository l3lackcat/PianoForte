using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using PianoForte.Enum;
using PianoForte.Services;

namespace PianoForte.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class CourseWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> getCourseNameList(string databaseName, Status status)
        {
            return CourseService.getCourseNameList(databaseName, status);
        }
    }
}
