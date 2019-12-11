using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class UserCategories
    {
        public UserCategories()
        {
            UserTeam = new HashSet<UserTeam>();
            Users = new HashSet<Users>();
        }

        public int UserCategoryId { get; set; }
        public string UserCategory { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
