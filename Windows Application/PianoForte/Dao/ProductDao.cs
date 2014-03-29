using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface ProductDao
    {
        bool addProductPriceHistory(ProductPriceHistory productPriceHistory);
    }
}
