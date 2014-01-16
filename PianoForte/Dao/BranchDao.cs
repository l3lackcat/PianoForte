using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface BranchDao
    {
        bool insertBranch(Branch branch);

        bool updateBranch(Branch branch);

        List<Branch> getBranchList(int branchId);

        List<Branch> getBranchList();
    }
}
