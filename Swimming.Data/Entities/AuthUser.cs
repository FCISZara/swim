using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class AuthUser
    {
        public int AuthUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }
        public DateTime? LastloginDate { get; set; }
        public int? RoleId { get; set; }
    }
}
