using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPad.DATA;

namespace WritingPad.BIZ
{
    public class AppUserOperation
    {
        WritingPadEntities db;

        public AppUserOperation()
        {
            db = new WritingPadEntities();
        }


        public List<AppUser> GetAll()
        {
            List<AppUser> appUserList = db.AppUser.ToList();
            return appUserList;
        }

    }
}
