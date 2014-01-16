using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class BranchService
    {
        private static BranchDao branchDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getBranchDao();

        public static bool insertBranch(Branch branch)
        {
            return branchDao.insertBranch(branch);
        }

        public static bool updateBranch(Branch branch)
        {
            return branchDao.updateBranch(branch);
        }

        public static Branch getBranch(int branchId)
        {
            Branch branch = null;

            List<Branch> tempBranchList = branchDao.getBranchList(branchId);
            if (tempBranchList.Count == 1)
            {
                branch = tempBranchList[0];
            }

            return branch;
        }

        public static List<Branch> getBranchList()
        {
            return branchDao.getBranchList();
        }
    }
}