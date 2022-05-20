using AdlezRestaurant.Core.Models;
using AdlezRestaurant.DataAccessLayer.UnitOfWork;
using AdlezRestaurant.Web.Const;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[DisallowConcurrentExecution]
public class CheckRoleJob : IJob
{
    private readonly RMContext _rmContext;
    public CheckRoleJob(RMContext context)
    {
        _rmContext = context;
    }

    public Task Execute(IJobExecutionContext context)
    {
        string[] roles = new[] { Role.Admin, Role.Chef, Role.Waiter_waitress, Role.Employee };
        //Assign UserRole
        foreach (var emp in _rmContext.Users.Where(u => u.Email != "admin@gmail.com").ToList())
        {
            var st = _rmContext.Staffs.FirstOrDefault(s => s.Email == emp.Email);
            string groupName = _rmContext.Groups.FirstOrDefault(g => g.GroupId == st.GroupId).Name;
            if (roles.Contains(groupName))
            {
                _rmContext.UserRoles.RemoveRange(_rmContext.UserRoles.Where(ur => ur.UserId == emp.Id));
                var roleId = _rmContext.Roles.FirstOrDefault(r => r.Name == groupName).Id;
                _rmContext.UserRoles.Add(new IdentityUserRole<string>() { UserId = emp.Id, RoleId = roleId });
            }
            else
            {
                _rmContext.UserRoles.RemoveRange(_rmContext.UserRoles.Where(ur => ur.UserId == emp.Id));
                var roleId = _rmContext.Roles.FirstOrDefault(r => r.Name == Role.Employee).Id;
                _rmContext.UserRoles.Add(new IdentityUserRole<string>() { UserId = emp.Id, RoleId = roleId });
            }
        }

        _rmContext.SaveChanges();
        return Task.CompletedTask;
    }
}