﻿using System;
using System.Collections.Generic;

namespace Swimming.Data.Entities
{
    public partial class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public bool? IsActive { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public int? LastModBy { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual Users AddedByNavigation { get; set; }
        public virtual Users LastModByNavigation { get; set; }
    }
}
