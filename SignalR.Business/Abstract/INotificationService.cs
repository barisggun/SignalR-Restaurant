﻿using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        public int TNotificationCountByStatusFalse();
        public List<Notification> TGetAllNotificationByFalse();
    }
}
