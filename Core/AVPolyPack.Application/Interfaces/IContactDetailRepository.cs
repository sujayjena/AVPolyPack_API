﻿using AVPolyPack.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IContactDetailRepository
    {
        Task<int> SaveContactDetail(ContactDetail_Request parameters);
        Task<IEnumerable<ContactDetail_Response>> GetContactDetailList(ContactDetail_Search parameters);
        Task<ContactDetail_Response?> GetContactDetailById(int Id);
    }
}
