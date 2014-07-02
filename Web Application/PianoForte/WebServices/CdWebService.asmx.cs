using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Globalization;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Services;

namespace PianoForte.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class CdWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Object> getCdList(string databaseName)
        {
            System.Threading.Thread.Sleep(1500);

            List<Object> displayedCdList = new List<Object>();
            List<Cd> cdList = CdService.getCdList(databaseName);
            foreach (Cd cd in cdList)
            {
                displayedCdList.Add(new
                {
                    id = cd.Id,
                    barcode = cd.Barcode,
                    name = cd.Name,
                    unitPrice = cd.UnitPrice,
                    quantity = cd.Quantity,
                    status = cd.Status
                });
            }

            return displayedCdList;
        }

        [WebMethod]
        public Object getCdById(string databaseName, int id)
        {
            System.Threading.Thread.Sleep(1500);

            Object displayedCd = null;
            Cd cd = CdService.getCd(databaseName, id);
            if (cd != null)
            {
                displayedCd = new
                {
                    id = cd.Id,
                    barcode = cd.Barcode,
                    name = cd.Name,
                    unitPrice = cd.UnitPrice,
                    quantity = cd.Quantity,
                    status = cd.Status
                };
            }

            return displayedCd;
        }

        [WebMethod]
        public Object getCdByBarcode(string databaseName, string barcode)
        {
            System.Threading.Thread.Sleep(1500);

            Object displayedCd = null;
            Cd cd = CdService.getCd(databaseName, barcode);
            if (cd != null)
            {
                displayedCd = new
                {
                    id = cd.Id,
                    barcode = cd.Barcode,
                    name = cd.Name,
                    unitPrice = cd.UnitPrice,
                    quantity = cd.Quantity,
                    status = cd.Status
                };
            }

            return displayedCd;
        }

        [WebMethod]
        public bool insertCdInfo(string databaseName, Cd cd)
        {
            System.Threading.Thread.Sleep(1500);
            return CdService.insertCd(databaseName, cd);
        }

        [WebMethod]
        public bool updateCdInfo(string databaseName, Cd cd)
        {
            System.Threading.Thread.Sleep(1500);
            return CdService.updateCd(databaseName, cd);
        }
    }
}
