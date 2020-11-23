using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication27.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UsersGroups> UsersGroups { get; set; }

        public User Admin { get; set; }
    }
}
