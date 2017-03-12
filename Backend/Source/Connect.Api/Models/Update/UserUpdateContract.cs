using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Update
{
    public class UserUpdateContract
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}