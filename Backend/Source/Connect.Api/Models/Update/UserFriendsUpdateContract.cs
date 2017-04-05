using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Api.Models.Update
{
    public class UserFriendsUpdateContract
    {
        public int FirstUserId { get; set; }

        public int SecondUserId { get; set; }
    }
}