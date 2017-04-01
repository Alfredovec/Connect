using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Update
{
    public class RateUpdateModel
    {
        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int Value { get; set; }
    }
}