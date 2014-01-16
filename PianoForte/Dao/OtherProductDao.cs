using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface OtherProductDao
    {
        bool insertOtherProduct(string databaseName, OtherProduct otherProduct);

        bool updateOtherProduct(string databaseName, OtherProduct otherProduct);

        List<OtherProduct> getOtherProductList(string databaseName, int otherProductId);

        List<OtherProduct> getOtherProductList(string databaseName, int startIndex, int offset, string keyword);
    }
}
