using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WritingPad.Models.Insert
{
    public class RegisterInsertModel
    {
        public string userName { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string rePassword { get; set; }

        public string fullName { get; set; }


    }
}