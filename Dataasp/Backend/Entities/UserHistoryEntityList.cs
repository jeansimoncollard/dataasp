using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Dataasp.Backend.Entities
{
    public class UserHistoryEntityList
    {

        public List<UserTravelRecord> UserHistory { get; set; }

        public UserHistoryEntityList()
        {
            UserHistory = new List<UserTravelRecord>();
        }
    }
}
