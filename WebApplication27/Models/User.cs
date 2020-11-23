using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication27.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<UsersGroups> UsersGroups { get; set; }

        public ICollection<Post> Posts { get; set; }

        public int GroupAdminId { get; set; }
        public Group GroupAdmin { get; set; }
    }
}
