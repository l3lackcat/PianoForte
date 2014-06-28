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
                    barcode = cd.OriginalBarcode != "" ? cd.OriginalBarcode : cd.InternalBarcode,
                    name = cd.Name,
                    unitPrice = new
                    {
                        raw = cd.UnitPrice,
                        formatted = cd.UnitPrice.ToString("N", new CultureInfo("en-US"))
                    },
                    quantity = cd.Quantity,
                    status = cd.Status
                });
            }

            return displayedCdList;
        }
    }
}
