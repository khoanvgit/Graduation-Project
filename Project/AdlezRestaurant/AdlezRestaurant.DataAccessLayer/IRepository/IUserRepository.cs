﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlezRestaurant.DataAccessLayer.IRepository
{
    public interface IUserRepository : IBaseRepository<IdentityUser>
    {
    }
}
