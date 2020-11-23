using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication27.Models
{
    public class UsersGroups
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
