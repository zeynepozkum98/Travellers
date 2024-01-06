using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.Core.Entities;

namespace Travellers.Entities.Concrete
{
    public class AppUser:IdentityUser<int>,IEntity
    {
        public AppUser()
        {
            CreatedDate = DateTime.Now;
        }

        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

       
        public virtual ICollection<Order> Orders { get; set; }






    }
}
