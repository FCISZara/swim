using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class UserTeamRole
    {
        public int UserTeamRoleId { get; set; }
        public string UserTeamRoleName { get; set; }
        public string UserTeamRoleDesc { get; set; }
        public bool? IsActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
    }
}
