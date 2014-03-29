using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface CdDao
    {
        bool insertCd(Cd cd);
        bool updateCd(Cd cd);
        bool deleteCd(int cdId);

        Cd findLastCd();

        Cd findCd(int cdId);

        List<Cd> findAllCd();
        List<Cd> findAllCd(int startIndex, int offset);
        List<Cd> findAllCd(Cd.CdStatus status);
        List<Cd> findAllCd(Cd.CdStatus status, int startIndex, int offset);

        Cd findCdByBarcode(string barcode);
        //List<Cd> findAllCdByBarcode(string barcode, int startIndex, int offset);
        //List<Cd> findAllCdByBarcode(string barcode, Cd.CdStatus status);
        //List<Cd> findAllCdByBarcode(string barcode, Cd.CdStatus status, int startIndex, int offset);

        List<Cd> findAllCdByName(string cdName);
        List<Cd> findAllCdByName(string cdName, int startIndex, int offset);
        List<Cd> findAllCdByName(string cdName, Cd.CdStatus status);
        List<Cd> findAllCdByName(string cdName, Cd.CdStatus status, int startIndex, int offset);

        //List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName);
        //List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, int startIndex, int offset);
        //List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, Cd.CdStatus status);
        //List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, Cd.CdStatus status, int startIndex, int offset);
    }
}
