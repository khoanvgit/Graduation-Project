using AdlezRestaurant.Core.Models;
using AdlezRestaurant.Web.Const;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.IO;
using System.Linq;

namespace AdlezRestaurant.Web.Models
{
    public class DbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, RMContext context)
        {
            //Add roles
            string[] roles = new[] { Role.Admin, Role.Chef, Role.Waiter_waitress, Role.Employee };

            foreach (string role in roles)
            {
                var roleStore = context.Roles;

                if (!context.Roles.Any(r => r.Name == role))
                {
                    if (role == Role.Admin)
                    {
                        roleStore.Add(new IdentityRole() { Name = Role.Admin, NormalizedName = Role.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
                    }
                    else if (role == Role.Chef)
                    {
                        roleStore.Add(new IdentityRole() { Name = Role.Chef, NormalizedName = Role.Chef.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
                    }
                    else if (role == Role.Waiter_waitress)
                    {
                        roleStore.Add(new IdentityRole() { Name = Role.Waiter_waitress, NormalizedName = Role.Waiter_waitress.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
                    }
                    else if (role == Role.Employee)
                    {
                        roleStore.Add(new IdentityRole() { Name = Role.Employee, NormalizedName = Role.Employee.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
                    }
                }
            }

            //Add users
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0988888888"
                };

                IdentityResult result = userManager.CreateAsync(user, "Abc@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();

                    if (!context.Staffs.Any())
                    {
                        ExcuteSqlScript();
                        foreach (Staff st in context.Staffs)
                        {
                            string groupName = context.Groups.FirstOrDefault(g => g.GroupId == st.GroupId).Name;
                            IdentityUser staff = new IdentityUser()
                            {
                                UserName = st.Email,
                                Email = st.Email,
                                EmailConfirmed = true,
                                PhoneNumber = st.Phone,
                                PhoneNumberConfirmed = true,
                                NormalizedEmail = st.Email.ToUpper(),
                                NormalizedUserName = st.Email.ToUpper(),
                                SecurityStamp = Guid.NewGuid().ToString(),
                                ConcurrencyStamp = Guid.NewGuid().ToString()
                            };

                            var password = new PasswordHasher<IdentityUser>();
                            var hashed = password.HashPassword(staff, "Abc@123");
                            staff.PasswordHash = hashed;

                            context.Users.Add(staff);
                        }
                    }

                    Group grp = new Group()
                    {
                        Name = "Admin",
                        Description = "Full control"
                    };

                    context.Groups.Add(grp);
                    context.SaveChanges();

                    Staff adm = new Staff()
                    {
                        GroupId = 6,
                        FirstName = "System",
                        LastName = "Admin",
                        Gender = "M",
                        Email = "admin@gmail.com",
                        Address = "VIETNAM",
                        City = "Hanoi",
                        Phone = "0988888888",
                        Birthday = null,
                        Image = "12.jpg"
                    };
                    context.Staffs.Add(adm);
                    context.SaveChanges();


                    GroupDivision gd = new GroupDivision() { GroupId = 6, StaffId = 12 };

                    context.GroupDivisions.Add(gd);


                }
            }
            context.SaveChanges();

            //Assign UserRole
            if(context.UserRoles.Count() == 1)
            {
                foreach (var emp in context.Users.Where(u => u.Email != "admin@gmail.com").ToList())
                {
                    var st = context.Staffs.FirstOrDefault(s => s.Email == emp.Email);
                    string groupName = context.Groups.FirstOrDefault(g => g.GroupId == st.GroupId).Name;
                    if (roles.Contains(groupName))
                    {
                        var roleId = context.Roles.FirstOrDefault(r => r.Name == groupName).Id;
                        context.UserRoles.Add(new IdentityUserRole<string>() { UserId = emp.Id, RoleId = roleId });
                    }
                    else
                    {
                        var roleId = context.Roles.FirstOrDefault(r => r.Name == Role.Employee).Id;
                        context.UserRoles.Add(new IdentityUserRole<string>() { UserId = emp.Id, RoleId = roleId });
                    }
                }
            }

        }

        private static void ExcuteSqlScript()
        {
            string sqlConnectionString = @"Server=Wolf\SQLEXPRESS;Database=Restaurant;Trusted_Connection=True;";

            string script = File.ReadAllText(@"D:\Game\QuanLyNhaHang\Data-restaurant.sql");

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
