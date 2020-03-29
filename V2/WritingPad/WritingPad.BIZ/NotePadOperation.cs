using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPad.DATA;

namespace WritingPad.BIZ
{
   public class NotePadOperation
    {
        WritingPadEntities db;

        public NotePadOperation()
        {
            db = new WritingPadEntities();
        }

        public List<NotePad> GetAll()
        {
            List<NotePad> notePadList = db.NotePad.ToList();
            return notePadList;
        }


    }
}
