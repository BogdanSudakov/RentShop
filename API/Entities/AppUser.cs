using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Order> CompletedOrders { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}