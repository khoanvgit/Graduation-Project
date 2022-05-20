using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlezRestaurant.DataAccessLayer.Repository
{
    public class UserRepository : BaseRepository<IdentityUser>, IUserRepository
    {
        public UserRepository(RMContext context) : base(context)
        {
        }
    }
}
