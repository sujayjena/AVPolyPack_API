﻿using AVPolyPack.Application.Models;
using AVPolyPack.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVPolyPack.Application.Interfaces
{
    public interface IUserRepository  
    {
        #region User 

        Task<int> SaveUser(User_Request parameters);

        Task<IEnumerable<User_Response>> GetUserList(BaseSearchEntity parameters);

        Task<User_Response?> GetUserById(long Id);

        Task<IEnumerable<UserListByRole_Response>> GetUserLisByRoleIdOrRoleName(UserListByRole_Search parameters);

        Task<IEnumerable<User_ImportDataValidation>> ImportUser(List<User_ImportData> parameters);

        Task<int> SaveUserOtherDetails(UserOtherDetails_Request parameters);
        Task<IEnumerable<UserOtherDetails_Response>> GetUserOtherDetailsList(UserOtherDetails_Search parameters);

        #endregion
    }
}
