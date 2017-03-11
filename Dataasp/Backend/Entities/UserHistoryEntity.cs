using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.Generic;

namespace Dataasp.Backend.Entities
{
    public class UserHistoryEntity
    {
       
        public List<UserTravelRecord> UserHistory { get; set; }

        public UserHistoryEntity()
        {
            UserHistory = new List<UserTravelRecord>();
        }
    }


u