using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface OtherCostDao
    {
        bool insertOtherCost(OtherCost otherCost);
        bool updateOtherCost(OtherCost otherCost);
        bool deleteOtherCost(int otherCostId);

        OtherCost findLastOtherCost();

        OtherCost findOtherCost(int otherCostId);

        OtherCost findOtherCost(string otherCostName, double otherCostPrice);

        List<OtherCost> findAllOtherCost();
    }
}
